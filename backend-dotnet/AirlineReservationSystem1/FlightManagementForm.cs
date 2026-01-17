using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AirlineReservationSystem
{
    public partial class FlightManagement : Form
    {
        public FlightManagement()
        {
            InitializeComponent();
        }

        private void FlightManagement_Load(object sender, EventArgs e)
        {
            LoadFlights();
        }

        void LoadFlights()
        {
            try
            {
                using (var con = DbHelper.GetConnection())
                {
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM flights", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvFlights.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading flights: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtFlightNumber.Text))
            {
                MessageBox.Show("Please enter Flight Number", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSource.Text))
            {
                MessageBox.Show("Please enter Source", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDestination.Text))
            {
                MessageBox.Show("Please enter Destination", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtSeats.Text, out int seats) || seats <= 0)
            {
                MessageBox.Show("Please enter a valid number of seats", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid ticket price", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var con = DbHelper.GetConnection())
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(
                    @"INSERT INTO flights
                    (FlightNumber, Source, Destination, DepartureDate, DepartureTime,
                     ArrivalDate, ArrivalTime, SeatsAvailable, TicketPrice)
                    VALUES
                    (@fn,@src,@dest,@dd,@dt,@ad,@at,@seats,@price)", con);

                    cmd.Parameters.AddWithValue("@fn", txtFlightNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@src", txtSource.Text.Trim());
                    cmd.Parameters.AddWithValue("@dest", txtDestination.Text.Trim());
                    cmd.Parameters.AddWithValue("@dd", dtDepartureDate.Value.Date);
                    cmd.Parameters.AddWithValue("@dt", dtDepartureTime.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@ad", dtArrivalDate.Value.Date);
                    cmd.Parameters.AddWithValue("@at", dtArrivalTime.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@seats", seats);
                    cmd.Parameters.AddWithValue("@price", price);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Flight Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Clear fields
                txtFlightNumber.Clear();
                txtSource.Clear();
                txtDestination.Clear();
                txtSeats.Clear();
                txtPrice.Clear();
                
                LoadFlights();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding flight: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFlights.CurrentRow == null)
            {
                MessageBox.Show("Please select a flight to delete", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this flight?", "Confirm Delete", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result != DialogResult.Yes) return;

            try
            {
                int id = Convert.ToInt32(dgvFlights.CurrentRow.Cells["FlightID"].Value);

                using (var con = DbHelper.GetConnection())
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(
                        "DELETE FROM flights WHERE FlightID=@id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Flight Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFlights();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting flight: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
