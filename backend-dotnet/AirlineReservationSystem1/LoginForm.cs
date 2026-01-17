
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace AirlineReservationSystem
{
    public partial class LoginForm : Form
    {
        MySqlConnection con = new MySqlConnection(
            "server=localhost;database=reservation;uid=root;pwd=root;");

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ================= ADMIN LOGIN =================
            if (username.ToLower() == "admin" && password == "admin123")
            {
                AdminDashboard admin = new AdminDashboard();
                admin.Show();
                this.Hide();
                return;
            }

            // ================= CUSTOMER LOGIN =================
            try
            {
                con.Open();

                // Get customer data - supports both PasswordHash and Password columns
                // Also supports different ID column names (CustomerID, ID, Customer_Id, etc.)
                var cmd = new MySqlCommand(
                    @"SELECT * FROM customers WHERE Username=@u", con);
                cmd.Parameters.AddWithValue("@u", username);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Get customer ID - try different possible column names
                        int customerId = 0;
                        string storedPassword = null;
                        bool isPasswordHash = false;
                        
                        // Scan all columns to find ID and password
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string colName = reader.GetName(i).ToLower();
                            
                            // Find ID column (CustomerID, ID, Customer_Id, etc.)
                            if (customerId == 0 && colName.Contains("id"))
                            {
                                try
                                {
                                    customerId = reader.GetInt32(i);
                                }
                                catch
                                {
                                    // Not an integer ID, continue
                                }
                            }
                            
                            // Find password column
                            if (storedPassword == null)
                            {
                                if (colName == "passwordhash")
                                {
                                    storedPassword = reader.IsDBNull(i) ? null : reader.GetString(i);
                                    isPasswordHash = true;
                                }
                                else if (colName == "password")
                                {
                                    storedPassword = reader.IsDBNull(i) ? null : reader.GetString(i);
                                    isPasswordHash = false;
                                }
                            }
                        }

                        // Verify password
                        bool passwordValid = false;
                        if (storedPassword != null)
                        {
                            passwordValid = (password == storedPassword);
                        }

                        if (passwordValid && customerId > 0)
                        {
                            ReservationForm rf = new ReservationForm(customerId);
                            rf.Show();
                            this.Hide();
                        }
                        else
                        {
                            if (customerId == 0)
                            {
                                MessageBox.Show("Customer account found but ID column not detected.\nPlease ensure your table has an ID column (CustomerID, ID, etc.)", 
                                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (MySqlException ex)
            {
                string errorMsg = "Database Error: " + ex.Message;
                if (ex.Number == 1049)
                {
                    errorMsg += "\n\nDatabase 'reservation' does not exist.";
                }
                else if (ex.Number == 1146)
                {
                    errorMsg += "\n\nTable 'customers' does not exist.";
                }
                else if (ex.Number == 1045)
                {
                    errorMsg += "\n\nAccess denied. Check your MySQL username and password in DbHelper.cs";
                }
                MessageBox.Show(errorMsg, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\n\nMake sure your customer table has:\n- Username column\n- Password or PasswordHash column\n- An ID column (CustomerID, ID, etc.)", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
