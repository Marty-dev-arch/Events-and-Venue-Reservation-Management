using Guna.UI2.WinForms;
using Hotel_Reservation_System.Database;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Reservation_System.Forms.UserForms
{
    public partial class UserLoginForm : Form
    {
        public UserLoginForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string fullName = txtFullName.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(fullName))
            {
                ShowCustomMessageBox("Validation", "Please enter both email and full name.", 500, 200);
                return;
            }

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM customers WHERE email = @Email AND full_name = @FullName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@FullName", fullName);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                    int customerId = Convert.ToInt32(reader["customer_id"]);
                    string name = reader["full_name"].ToString();

                    // Show success alert before moving to dashboard
                    SuccessAlertForm alert = new SuccessAlertForm("Login Successful", $"Welcome, {name}!");
                    alert.ShowDialog(); // blocks until user closes it

                    // Store session info if needed
                    this.Hide();
                    UserMainForm dashboard = new UserMainForm(customerId, name); // Pass user info
                    dashboard.Show();
                    }
                    
                    else
                    {
                        ShowCustomMessageBox("Error", "Invalid login. Please try again.", 500, 200);
                    }
                }
            }
        }

        private void UserLoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void ShowCustomMessageBox(string title, string message, int width, int height)
        {
            Form customBox = new Form();
            customBox.Text = title;
            customBox.Size = new Size(width, height);
            customBox.StartPosition = FormStartPosition.CenterScreen;
            customBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            customBox.MaximizeBox = false;
            customBox.MinimizeBox = false;

            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.AutoSize = false;
            lblMessage.Font = new Font("Segoe UI", 10);
            lblMessage.Size = new Size(width - 40, height - 120);
            lblMessage.Location = new Point(20, 20);

            System.Windows.Forms.Button okButton = new System.Windows.Forms.Button();
            okButton.Text = "OK";
            okButton.Size = new Size(80, 30);
            okButton.Cursor = Cursors.Hand;
            okButton.Click += (s, e) => customBox.Close();

            customBox.Controls.Add(lblMessage);
            customBox.Controls.Add(okButton);

            customBox.Shown += (s, e) =>
            {
                int padding = 15;
                okButton.Location = new Point(
                    customBox.ClientSize.Width - okButton.Width - padding,
                    customBox.ClientSize.Height - okButton.Height - padding
                );
            };

            customBox.ShowDialog();
        }

        private void UserLoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
