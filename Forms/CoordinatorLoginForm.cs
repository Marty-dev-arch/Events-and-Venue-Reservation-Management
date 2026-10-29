using Hotel_Reservation_System.Database;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Reservation_System.Forms
{
    public partial class CoordinatorLoginForm : Form
    {
        private bool isPasswordVisible = false;
        private string _coordinatorName = "";

        public CoordinatorLoginForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowMessage("Validation Error", "Please enter both username and password.", Color.OrangeRed);
                return;
            }

            try
            {
                using (SqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT coordinator_id, full_name FROM coordinators WHERE username = @username AND password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _coordinatorName = reader["full_name"].ToString() ?? username;
                                int coordId = reader.GetInt32(reader.GetOrdinal("coordinator_id"));

                                // Show success
                                ShowMessage("Login Successful", $"Welcome, {_coordinatorName}!", Color.MediumSeaGreen);

                                this.Hide();
                                var dashboard = new UserForms.UserMainForm(coordId, _coordinatorName, isCoordinator: true);
                                dashboard.FormClosed += (s2, args2) => Application.Exit();
                                dashboard.Show();
                            }
                            else
                            {
                                ShowMessage("Login Failed", "Invalid username or password.\n\nDemo credentials:\ncoordinator / coord123", Color.OrangeRed);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Connection Error", $"Could not connect to database.\n{ex.Message}", Color.OrangeRed);
            }
        }

        private void ShowMessage(string title, string message, Color accentColor)
        {
            Form msg = new Form();
            msg.Text = title;
            msg.Size = new Size(440, 200);
            msg.StartPosition = FormStartPosition.CenterScreen;
            msg.FormBorderStyle = FormBorderStyle.FixedDialog;
            msg.MaximizeBox = false;
            msg.MinimizeBox = false;
            msg.BackColor = Color.FromArgb(22, 35, 58);

            // Accent strip
            Panel strip = new Panel { Size = new Size(440, 4), Location = new Point(0, 0), BackColor = accentColor };
            msg.Controls.Add(strip);

            Label lbl = new Label
            {
                Text = message,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F),
                Size = new Size(380, 110),
                Location = new Point(30, 20),
                TextAlign = ContentAlignment.MiddleLeft
            };
            msg.Controls.Add(lbl);

            Button ok = new Button
            {
                Text = "OK",
                Size = new Size(90, 34),
                BackColor = accentColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            ok.FlatAppearance.BorderSize = 0;
            ok.Location = new Point(325, 135);
            ok.Click += (s, e) => msg.Close();
            msg.Controls.Add(ok);

            msg.ShowDialog();
        }

        private void picTogglePassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            txtPassword.UseSystemPasswordChar = !isPasswordVisible;
            picTogglePassword.Image = isPasswordVisible
                ? Properties.Resources.eye_open
                : Properties.Resources.eye_closed;
        }

        private void picTogglePassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
            picTogglePassword.Image = Properties.Resources.eye_open;
        }

        private void picTogglePassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            picTogglePassword.Image = Properties.Resources.eye_closed;
        }

        private void btnBackToPortal_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLoginForm adminLogin = new AdminLoginForm();
            adminLogin.FormClosed += (s, args) => Application.Exit();
            adminLogin.Show();
        }

        private void CoordinatorLoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Only exit if no other forms are visible
            bool anyOtherOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f != this && f.Visible) { anyOtherOpen = true; break; }
            }
            if (!anyOtherOpen) Application.Exit();
        }
    }
}
