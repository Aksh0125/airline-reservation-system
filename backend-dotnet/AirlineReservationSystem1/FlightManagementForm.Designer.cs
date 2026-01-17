using System.Windows.Forms;

namespace AirlineReservationSystem
{
    partial class FlightManagement
    {
        System.ComponentModel.IContainer components = null;

        TextBox txtFlightNumber, txtSource, txtDestination, txtSeats, txtPrice;
        DateTimePicker dtDepartureDate, dtDepartureTime, dtArrivalDate, dtArrivalTime;
        Button btnAdd, btnDelete;
        DataGridView dgvFlights;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        void InitializeComponent()
        {
            this.Text = "Flight Management";
            this.Size = new System.Drawing.Size(1000, 600);

            txtFlightNumber = new TextBox() { Left = 20, Top = 20, Width = 150 };
            txtSource = new TextBox() { Left = 20, Top = 60, Width = 150 };
            txtDestination = new TextBox() { Left = 20, Top = 100, Width = 150 };
            txtSeats = new TextBox() { Left = 20, Top = 140, Width = 150 };
            txtPrice = new TextBox() { Left = 20, Top = 180, Width = 150 };

            dtDepartureDate = new DateTimePicker() { Left = 200, Top = 20 };
            dtDepartureTime = new DateTimePicker() { Left = 200, Top = 60, Format = DateTimePickerFormat.Time, ShowUpDown = true };
            dtArrivalDate = new DateTimePicker() { Left = 200, Top = 100 };
            dtArrivalTime = new DateTimePicker() { Left = 200, Top = 140, Format = DateTimePickerFormat.Time, ShowUpDown = true };

            btnAdd = new Button() { Left = 200, Top = 180, Width = 100, Text = "Add Flight" };
            btnDelete = new Button() { Left = 320, Top = 180, Width = 100, Text = "Delete Flight" };

            dgvFlights = new DataGridView()
            {
                Left = 20,
                Top = 230,
                Width = 940,
                Height = 300,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            btnAdd.Click += btnAdd_Click;
            btnDelete.Click += btnDelete_Click;
            this.Load += FlightManagement_Load;

            this.Controls.AddRange(new Control[]
            {
                txtFlightNumber, txtSource, txtDestination, txtSeats, txtPrice,
                dtDepartureDate, dtDepartureTime, dtArrivalDate, dtArrivalTime,
                btnAdd, btnDelete, dgvFlights
            });
        }
    }
}
