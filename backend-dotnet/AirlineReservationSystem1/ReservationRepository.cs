using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace AirlineReservationSystem
{
    public static class ReservationRepository
    {
        // Get all flights
        public static DataTable GetFlights()
        {
            string sql = "SELECT FlightID, FlightNumber, Source, Destination, DepartureDate, DepartureTime, SeatsAvailable, TicketPrice FROM flights";
            return DbHelper.GetDataTable(sql);
        }

        // Get all customers
        public static DataTable GetCustomers()
        {
            string sql = "SELECT CustomerID, Username, FullName, Email, Phone FROM customers";
            return DbHelper.GetDataTable(sql);
        }

        // Get bookings with joined info (for display)
        public static DataTable GetBookings()
        {
            string sql = @"
                SELECT b.BookingID, b.CustomerID, c.FullName AS CustomerName, b.FlightID,
                       f.FlightNumber, f.Source, f.Destination,
                       b.BookingDate, b.Status
                FROM bookings b
                LEFT JOIN customers c ON b.CustomerID = c.CustomerID
                LEFT JOIN flights f ON b.FlightID = f.FlightID
                ORDER BY b.BookingDate DESC";
            return DbHelper.GetDataTable(sql);
        }

        // Get bookings for a specific customer by CustomerID
        public static DataTable GetCustomerBookings(int customerId)
        {
            string sql = @"
                SELECT b.BookingID, c.FullName AS CustomerName, b.FlightID,
                       f.FlightNumber, f.Source, f.Destination,
                       f.DepartureDate, f.DepartureTime, f.ArrivalDate, f.ArrivalTime,
                       f.TicketPrice, b.BookingDate, b.Status
                FROM bookings b
                LEFT JOIN customers c ON b.CustomerID = c.CustomerID
                LEFT JOIN flights f ON b.FlightID = f.FlightID
                WHERE b.CustomerID = @customerId
                ORDER BY b.BookingDate DESC";
            return DbHelper.GetDataTable(sql, new MySqlParameter("@customerId", customerId));
        }

        // Get customer name by CustomerID - supports different ID column names
        public static string GetCustomerName(int customerId)
        {
            using (var con = DbHelper.GetConnection())
            {
                con.Open();
                string sql = "SELECT FullName FROM customers WHERE CustomerID = @customerId";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@customerId", customerId);

                object result = cmd.ExecuteScalar();
                return result == null ? "Customer" : result.ToString();
            }
        }

        // Create booking: transactional - insert booking and decrement seats
        public static bool CreateBooking(int customerId, int flightId, DateTime bookingDate, out string error)
        {
            error = null;
            using (var con = DbHelper.GetConnection())
            {
                con.Open();
                using (var tx = con.BeginTransaction())
                {
                    try
                    {
                        // check seats
                        var checkCmd = new MySqlCommand("SELECT SeatsAvailable FROM flights WHERE FlightID=@fid FOR UPDATE", con, tx);
                        checkCmd.Parameters.AddWithValue("@fid", flightId);
                        int seats = Convert.ToInt32(checkCmd.ExecuteScalar() ?? 0);
                        if (seats <= 0)
                        {
                            error = "No seats available.";
                            tx.Rollback();
                            return false;
                        }

                        // insert booking
                        var insCmd = new MySqlCommand(
                            "INSERT INTO bookings (CustomerID, FlightID, BookingDate, Status) VALUES (@cid, @fid, @bdate, @status)",
                            con, tx);
                        insCmd.Parameters.AddWithValue("@cid", customerId);
                        insCmd.Parameters.AddWithValue("@fid", flightId);
                        insCmd.Parameters.AddWithValue("@bdate", bookingDate);
                        insCmd.Parameters.AddWithValue("@status", "Confirmed");
                        insCmd.ExecuteNonQuery();

                        // decrement seats
                        var updCmd = new MySqlCommand("UPDATE flights SET SeatsAvailable = SeatsAvailable - 1 WHERE FlightID = @fid", con, tx);
                        updCmd.Parameters.AddWithValue("@fid", flightId);
                        updCmd.ExecuteNonQuery();

                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); } catch { }
                        error = ex.Message;
                        return false;
                    }
                }
            }
        }

        // Cancel booking: insert into cancellations, update booking Status, increment seats (transactional)
        public static bool CancelBooking(int bookingId, string reason, out string error)
        {
            error = null;
            using (var con = DbHelper.GetConnection())
            {
                con.Open();
                using (var tx = con.BeginTransaction())
                {
                    try
                    {
                        // get flight id for this booking
                        var fidCmd = new MySqlCommand("SELECT FlightID FROM bookings WHERE BookingID=@bid FOR UPDATE", con, tx);
                        fidCmd.Parameters.AddWithValue("@bid", bookingId);
                        object obj = fidCmd.ExecuteScalar();
                        if (obj == null) { error = "Booking not found."; tx.Rollback(); return false; }
                        int flightId = Convert.ToInt32(obj);

                        // insert cancellation record
                        var insCanc = new MySqlCommand("INSERT INTO cancellations (BookingID, CancellationDate, Reason) VALUES (@bid, @cdate, @reason)", con, tx);
                        insCanc.Parameters.AddWithValue("@bid", bookingId);
                        insCanc.Parameters.AddWithValue("@cdate", DateTime.Now);
                        insCanc.Parameters.AddWithValue("@reason", reason ?? string.Empty);
                        insCanc.ExecuteNonQuery();

                        // update booking status
                        var updBooking = new MySqlCommand("UPDATE bookings SET Status = @status WHERE BookingID = @bid", con, tx);
                        updBooking.Parameters.AddWithValue("@status", "Cancelled");
                        updBooking.Parameters.AddWithValue("@bid", bookingId);
                        updBooking.ExecuteNonQuery();

                        // increment seats
                        var updFlight = new MySqlCommand("UPDATE flights SET SeatsAvailable = SeatsAvailable + 1 WHERE FlightID = @fid", con, tx);
                        updFlight.Parameters.AddWithValue("@fid", flightId);
                        updFlight.ExecuteNonQuery();

                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); } catch { }
                        error = ex.Message;
                        return false;
                    }
                }
            }
        }

        // Update booking (change flight) - adjusts seats on old and new flight
        public static bool UpdateBookingFlight(int bookingId, int newFlightId, out string error)
        {
            error = null;
            using (var con = DbHelper.GetConnection())
            {
                con.Open();
                using (var tx = con.BeginTransaction())
                {
                    try
                    {
                        // get old flight
                        var cmdOld = new MySqlCommand("SELECT FlightID FROM bookings WHERE BookingID=@bid FOR UPDATE", con, tx);
                        cmdOld.Parameters.AddWithValue("@bid", bookingId);
                        object o = cmdOld.ExecuteScalar();
                        if (o == null) { error = "Booking not found."; tx.Rollback(); return false; }
                        int oldFlightId = Convert.ToInt32(o);

                        if (oldFlightId == newFlightId) { error = "Selected same flight."; tx.Rollback(); return false; }

                        // check seats on new flight
                        var checkNew = new MySqlCommand("SELECT SeatsAvailable FROM flights WHERE FlightID=@fid FOR UPDATE", con, tx);
                        checkNew.Parameters.AddWithValue("@fid", newFlightId);
                        int seatsNew = Convert.ToInt32(checkNew.ExecuteScalar() ?? 0);
                        if (seatsNew <= 0) { error = "No seats available on the selected flight."; tx.Rollback(); return false; }

                        // update booking
                        var updBooking = new MySqlCommand("UPDATE bookings SET FlightID = @newfid WHERE BookingID = @bid", con, tx);
                        updBooking.Parameters.AddWithValue("@newfid", newFlightId);
                        updBooking.Parameters.AddWithValue("@bid", bookingId);
                        updBooking.ExecuteNonQuery();

                        // decrement new flight seats
                        var decNew = new MySqlCommand("UPDATE flights SET SeatsAvailable = SeatsAvailable - 1 WHERE FlightID = @fid", con, tx);
                        decNew.Parameters.AddWithValue("@fid", newFlightId);
                        decNew.ExecuteNonQuery();

                        // increment old flight seats
                        var incOld = new MySqlCommand("UPDATE flights SET SeatsAvailable = SeatsAvailable + 1 WHERE FlightID = @fid", con, tx);
                        incOld.Parameters.AddWithValue("@fid", oldFlightId);
                        incOld.ExecuteNonQuery();

                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); } catch { }
                        error = ex.Message;
                        return false;
                    }
                }
            }
        }
    }
}
