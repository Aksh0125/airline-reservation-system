using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AirlineReservationSystem
{
    public partial class ReservationForm : Form
    {
        int customerId;
        string customerName;

        public ReservationForm(int id)
        {
            InitializeComponent();
            customerId = id;
            customerName = ReservationRepository.GetCustomerName(id);
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            LoadCities();
            LoadCustomerBookings();
            lblCustomerName.Text = "Welcome, " + customerName;
        }

        void LoadCities()
        {
            using (var con = DbHelper.GetConnection())
            {
                con.Open();
                DataTable dt = new DataTable();
                new MySqlDataAdapter("SELECT DISTINCT Source FROM flights", con).Fill(dt);
                comboSource.DataSource = dt;
                comboSource.DisplayMember = "Source";

                dt = new DataTable();
                new MySqlDataAdapter("SELECT DISTINCT Destination FROM flights", con).Fill(dt);
                comboDestination.DataSource = dt;
                comboDestination.DisplayMember = "Destination";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (var con = DbHelper.GetConnection())
            {
                string q = "SELECT * FROM flights WHERE Source=@s AND Destination=@d AND SeatsAvailable>0";
                MySqlCommand cmd = new MySqlCommand(q, con);
                cmd.Parameters.AddWithValue("@s", comboSource.Text);
                cmd.Parameters.AddWithValue("@d", comboDestination.Text);

                DataTable dt = new DataTable();
                new MySqlDataAdapter(cmd).Fill(dt);
                dgvFlights.DataSource = dt;
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (dgvFlights.CurrentRow == null) return;

            int flightId = Convert.ToInt32(dgvFlights.CurrentRow.Cells["FlightID"].Value);

            using (var con = DbHelper.GetConnection())
            {
                con.Open();
                MySqlTransaction tx = con.BeginTransaction();

                new MySqlCommand(
                    "INSERT INTO bookings(CustomerID,FlightID,BookingDate,Status) VALUES(@c,@f,NOW(),'Confirmed')",
                    con, tx)
                {
                    Parameters =
                    {
                        new MySqlParameter("@c", customerId),
                        new MySqlParameter("@f", flightId)
                    }
                }.ExecuteNonQuery();

                new MySqlCommand(
                    "UPDATE flights SET SeatsAvailable=SeatsAvailable-1 WHERE FlightID=@f",
                    con, tx)
                {
                    Parameters = { new MySqlParameter("@f", flightId) }
                }.ExecuteNonQuery();

                tx.Commit();
                MessageBox.Show("Booking Confirmed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomerBookings(); // Refresh bookings after booking
            }
        }

        private void LoadCustomerBookings()
        {
            try
            {
                DataTable bookings = ReservationRepository.GetCustomerBookings(customerId);
                dgvMyBookings.DataSource = bookings;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewBookings_Click(object sender, EventArgs e)
        {
            LoadCustomerBookings();
            tabControl.SelectedTab = tabMyBookings;
        }

        private void btnBookFlight_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabBookFlight;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lf = new LoginForm();
            lf.Show();
        }
    }
}
