using System;
using System.Windows.Forms;

namespace AirlineReservationSystem
{
    partial class ReservationForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Button btnLogout;

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBookFlight;
        private System.Windows.Forms.TabPage tabMyBookings;

        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;

        private System.Windows.Forms.ComboBox comboSource;
        private System.Windows.Forms.ComboBox comboDestination;
        private System.Windows.Forms.DateTimePicker dtpDate;

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvFlights;
        private System.Windows.Forms.Button btnBook;

        private System.Windows.Forms.DataGridView dgvMyBookings;
        private System.Windows.Forms.Button btnViewBookings;
        private System.Windows.Forms.Button btnBookFlight;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBookFlight = new System.Windows.Forms.TabPage();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.comboSource = new System.Windows.Forms.ComboBox();
            this.comboDestination = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvFlights = new System.Windows.Forms.DataGridView();
            this.btnBook = new System.Windows.Forms.Button();
            this.tabMyBookings = new System.Windows.Forms.TabPage();
            this.dgvMyBookings = new System.Windows.Forms.DataGridView();
            this.btnViewBookings = new System.Windows.Forms.Button();
            this.btnBookFlight = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabBookFlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlights)).BeginInit();
            this.tabMyBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBookings)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Red;
            this.headerPanel.Controls.Add(this.btnLogout);
            this.headerPanel.Controls.Add(this.lblCustomerName);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1670, 87);
            this.headerPanel.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.DarkRed;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1550, 20);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 40);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerName.Location = new System.Drawing.Point(30, 50);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(200, 32);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "Welcome, Customer";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(633, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Airline Reservation System(ARS)";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabBookFlight);
            this.tabControl.Controls.Add(this.tabMyBookings);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 87);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1670, 501);
            this.tabControl.TabIndex = 1;
            // 
            // tabBookFlight
            // 
            this.tabBookFlight.Controls.Add(this.lblFrom);
            this.tabBookFlight.Controls.Add(this.lblTo);
            this.tabBookFlight.Controls.Add(this.lblDate);
            this.tabBookFlight.Controls.Add(this.comboSource);
            this.tabBookFlight.Controls.Add(this.comboDestination);
            this.tabBookFlight.Controls.Add(this.dtpDate);
            this.tabBookFlight.Controls.Add(this.btnSearch);
            this.tabBookFlight.Controls.Add(this.dgvFlights);
            this.tabBookFlight.Controls.Add(this.btnBook);
            this.tabBookFlight.Location = new System.Drawing.Point(4, 35);
            this.tabBookFlight.Name = "tabBookFlight";
            this.tabBookFlight.Padding = new System.Windows.Forms.Padding(3);
            this.tabBookFlight.Size = new System.Drawing.Size(1662, 462);
            this.tabBookFlight.TabIndex = 0;
            this.tabBookFlight.Text = "Book Flight";
            this.tabBookFlight.UseVisualStyleBackColor = true;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFrom.Location = new System.Drawing.Point(50, 30);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(60, 28);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTo.Location = new System.Drawing.Point(300, 30);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(40, 28);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDate.Location = new System.Drawing.Point(550, 30);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(150, 28);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Departure Date:";
            // 
            // comboSource
            // 
            this.comboSource.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboSource.Location = new System.Drawing.Point(50, 60);
            this.comboSource.Name = "comboSource";
            this.comboSource.Size = new System.Drawing.Size(200, 35);
            this.comboSource.TabIndex = 4;
            // 
            // comboDestination
            // 
            this.comboDestination.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboDestination.Location = new System.Drawing.Point(300, 60);
            this.comboDestination.Name = "comboDestination";
            this.comboDestination.Size = new System.Drawing.Size(200, 35);
            this.comboDestination.TabIndex = 5;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDate.Location = new System.Drawing.Point(550, 60);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 34);
            this.dtpDate.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Red;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(800, 135);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 35);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "SEARCH FLIGHTS";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvFlights
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.dgvFlights.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFlights.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFlights.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvFlights.ColumnHeadersHeight = 34;
            this.dgvFlights.Location = new System.Drawing.Point(50, 120);
            this.dgvFlights.Name = "dgvFlights";
            this.dgvFlights.ReadOnly = true;
            this.dgvFlights.RowHeadersWidth = 62;
            this.dgvFlights.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlights.Size = new System.Drawing.Size(1550, 250);
            this.dgvFlights.TabIndex = 8;
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.Green;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(700, 400);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(250, 50);
            this.btnBook.TabIndex = 9;
            this.btnBook.Text = "BOOK FLIGHT";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // tabMyBookings
            // 
            this.tabMyBookings.Controls.Add(this.btnBookFlight);
            this.tabMyBookings.Controls.Add(this.btnViewBookings);
            this.tabMyBookings.Controls.Add(this.dgvMyBookings);
            this.tabMyBookings.Location = new System.Drawing.Point(4, 35);
            this.tabMyBookings.Name = "tabMyBookings";
            this.tabMyBookings.Padding = new System.Windows.Forms.Padding(3);
            this.tabMyBookings.Size = new System.Drawing.Size(1662, 462);
            this.tabMyBookings.TabIndex = 1;
            this.tabMyBookings.Text = "My Bookings";
            this.tabMyBookings.UseVisualStyleBackColor = true;
            // 
            // dgvMyBookings
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvMyBookings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMyBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyBookings.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dgvMyBookings.ColumnHeadersHeight = 34;
            this.dgvMyBookings.Location = new System.Drawing.Point(20, 60);
            this.dgvMyBookings.Name = "dgvMyBookings";
            this.dgvMyBookings.ReadOnly = true;
            this.dgvMyBookings.RowHeadersWidth = 62;
            this.dgvMyBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyBookings.Size = new System.Drawing.Size(1620, 350);
            this.dgvMyBookings.TabIndex = 0;
            // 
            // btnViewBookings
            // 
            this.btnViewBookings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnViewBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewBookings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewBookings.ForeColor = System.Drawing.Color.White;
            this.btnViewBookings.Location = new System.Drawing.Point(20, 20);
            this.btnViewBookings.Name = "btnViewBookings";
            this.btnViewBookings.Size = new System.Drawing.Size(200, 35);
            this.btnViewBookings.TabIndex = 1;
            this.btnViewBookings.Text = "Refresh Bookings";
            this.btnViewBookings.UseVisualStyleBackColor = false;
            this.btnViewBookings.Click += new System.EventHandler(this.btnViewBookings_Click);
            // 
            // btnBookFlight
            // 
            this.btnBookFlight.BackColor = System.Drawing.Color.Green;
            this.btnBookFlight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookFlight.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBookFlight.ForeColor = System.Drawing.Color.White;
            this.btnBookFlight.Location = new System.Drawing.Point(240, 20);
            this.btnBookFlight.Name = "btnBookFlight";
            this.btnBookFlight.Size = new System.Drawing.Size(200, 35);
            this.btnBookFlight.TabIndex = 2;
            this.btnBookFlight.Text = "Book New Flight";
            this.btnBookFlight.UseVisualStyleBackColor = false;
            this.btnBookFlight.Click += new System.EventHandler(this.btnBookFlight_Click);
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::AirlineReservationSystem1.Properties.Resources.istockphoto_171154596_612x612;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1670, 588);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.headerPanel);
            this.Name = "ReservationForm";
            this.Text = "Customer Dashboard";
            this.Load += new System.EventHandler(this.ReservationForm_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabBookFlight.ResumeLayout(false);
            this.tabBookFlight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlights)).EndInit();
            this.tabMyBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBookings)).EndInit();
            this.ResumeLayout(false);

        }

    }
}
