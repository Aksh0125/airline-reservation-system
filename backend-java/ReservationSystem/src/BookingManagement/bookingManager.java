package BookingManagement;
import FlightManagement.Flight;

import java.sql.*;
import java.time.LocalDate;
import java.time.LocalDateTime;

import java.util.ArrayList;
import java.util.List;




public class bookingManager {
   

    public List<Flight> searchFlights(String source, String destination, LocalDate date) {
        List<Flight> flights = new ArrayList<>();
        String sql = "SELECT * FROM flights WHERE Source = ? AND Destination = ? AND DepartureDate = ?";
        try (Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/reservation", "root", "root");
             PreparedStatement stmt = conn.prepareStatement(sql)) {
            stmt.setString(1, source);
            stmt.setString(2, destination);
            stmt.setDate(3, Date.valueOf(date));
            ResultSet rs = stmt.executeQuery();
            while (rs.next()) {
                Flight flight = new Flight();
                flight.setflightid(rs.getInt("FlightID"));
                flight.setflightnumber(rs.getString("FlightNumber"));
                flight.setsource(rs.getString("Source"));
                flight.setdest(rs.getString("Destination"));
                flight.setdeptdate(rs.getDate("DepartureDate").toLocalDate());
                flight.setdeptime(rs.getTime("DepartureTime").toLocalTime());
                flight.setdate(rs.getDate("ArrivalDate").toLocalDate());
                flight.settime(rs.getTime("ArrivalTime").toLocalTime());
                flight.setseats(rs.getInt("SeatsAvailable"));
                flight.setprice(rs.getDouble("TicketPrice"));
                flights.add(flight);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return flights;
    }

    public boolean bookTicket(int customerId, int flightId) {
        String sql = "INSERT INTO bookings (CustomerID, FlightID, BookingDateTime, Status) VALUES (?, ?, ?, ?)";
        try (Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/reservation", "root", "root");
             PreparedStatement stmt = conn.prepareStatement(sql)) {
            stmt.setInt(1, customerId);
            stmt.setInt(2, flightId);
            stmt.setTimestamp(3, Timestamp.valueOf(LocalDateTime.now()));
            stmt.setString(4, "CONFIRMED");
            return stmt.executeUpdate() == 1;
        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }
    }

    public List<booking> getBookingHistory(int customerId) {
        List<booking> bookings = new ArrayList<>();
        String sql = "SELECT * FROM bookings WHERE CustomerID = ?";
        try (Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/reservation", "root", "root");
             PreparedStatement stmt = conn.prepareStatement(sql)) {
            stmt.setInt(1, customerId);
            ResultSet rs = stmt.executeQuery();
            while (rs.next()) {
                booking booking = new booking();
                booking.setbookingid(rs.getInt("BookingID"));
                booking.setcustomerid(rs.getInt("CustomerID"));
                booking.setflightid(rs.getInt("FlightID"));
                booking.setbookingdate(rs.getTimestamp("BookingDateTime").toLocalDateTime());
                booking.setstatus(rs.getString("Status"));
                bookings.add(booking);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return bookings;
    }
}
