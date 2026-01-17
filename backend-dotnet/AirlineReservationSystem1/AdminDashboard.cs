using System;
using System.Windows.Forms;

namespace AirlineReservationSystem
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void btnFlights_Click(object sender, EventArgs e)
        {
            FlightManagement fm = new FlightManagement();
            fm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lf = new LoginForm();
            lf.Show();
        }
    }
}
