using Hotel_Reservation_System.Database;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Reservation_System.Forms
{
    public enum ActivePortal
    {
        Admin,
        Coordinator
    }

    /// <summary>
    /// Expanded Portal Login Screen maintaining original resort pool background
    /// and brand aesthetics, with a modern clickable switcher between Admin & Coordinator.
    /// </summary>
    public partial class AdminLoginForm : Form
    {
        private ActivePortal _activePortal = ActivePortal.Admin;
        private bool _isPasswordVisible = false;

        public AdminLoginForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void AdminLoginForm_Load(object sender, EventArgs e)
        {
            CenterCard();
            SetPortal(ActivePortal.Admin);
        }

        private void AdminLoginForm_Shown(object sender, EventArgs e)
        {
            // Re-center after full layout is rendered (fixes clipping on low-res screens)
            CenterCard();
        }

        private void AdminLoginForm_Resize(object sender, EventArgs e)
        {
            CenterCard();
        }

        private void CenterCard()
        {
            if (pnlMainCard == null || guna2Panel1 == null) return;
            int x = Math.Max(20, (guna2Panel1.ClientSize.Width - pnlMainCard.Width) / 2);
            int y = Math.Max(20, (guna2Panel1.ClientSize.Height - pnlMainCard.Height) / 2);
            pnlMainCard.Location = new Point(x, y);
            pnlMainCard.BringToFront();
        }

        // ─────────────────────────────────────────────────────────
        // CLICKABLE SWITCHER (Admin <-> Coordinator)
        // ─────────────────────────────────────────────────────────
        private void btnTabAdmin_Click(object sender, EventArgs e)
        {
            SetPortal(ActivePortal.Admin);
        }

        private void btnTabCoordinator_Click(object sender, EventArgs e)
        {
            SetPortal(ActivePortal.Coordinator);
        }

        public void SetPortal(ActivePortal portal)
        {
            _activePortal = portal;

            if (portal == ActivePortal.Admin)
            {
                btnTabAdmin.FillColor = Color.FromArgb(0, 26, 26);
                btnTabAdmin.ForeColor = Color.White;
                btnTabAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                btnTabCoordinator.FillColor = Color.Transparent;
                btnTabCoordinator.ForeColor = Color.FromArgb(100, 116, 139);
                btnTabCoordinator.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

                pnlCardLeft.FillColor = Color.FromArgb(0, 26, 26);
                pnlCardLeft.FillColor2 = Color.FromArgb(0, 26, 26);
                pnlCardLeft.FillColor3 = Color.FromArgb(0, 36, 36);
                pnlCardLeft.FillColor4 = Color.FromArgb(0, 46, 46);

                lblHotelName.ForeColor = Color.Teal;
                lblTagline.ForeColor = Color.FromArgb(180, 210, 210);

                lblFormTitle.Text = "Admin Login";
                lblFormSubtitle.Text = "Please enter your administrative credentials to manage the hotel.";

                txtUsername.PlaceholderText = "Username";
                lblUsernameLabel.Text = "Username";
                txtUsername.FocusedState.BorderColor = Color.Teal;
                txtPassword.FocusedState.BorderColor = Color.Teal;

                btnActionLogin.Text = "Login as Admin";
                btnActionLogin.FillColor = Color.FromArgb(0, 26, 26);
                btnActionLogin.HoverState.FillColor = Color.FromArgb(0, 80, 80);
            }
            else
            {
                btnTabAdmin.FillColor = Color.Transparent;
                btnTabAdmin.ForeColor = Color.FromArgb(100, 116, 139);
                btnTabAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

                btnTabCoordinator.FillColor = Color.FromArgb(74, 34, 120);
                btnTabCoordinator.ForeColor = Color.White;
                btnTabCoordinator.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                pnlCardLeft.FillColor = Color.FromArgb(35, 15, 80);
                pnlCardLeft.FillColor2 = Color.FromArgb(55, 25, 110);
                pnlCardLeft.FillColor3 = Color.FromArgb(20, 8, 50);
                pnlCardLeft.FillColor4 = Color.FromArgb(45, 20, 95);

                lblHotelName.ForeColor = Color.FromArgb(195, 160, 255);
                lblTagline.ForeColor = Color.FromArgb(190, 175, 230);

                lblFormTitle.Text = "Coordinator Login";
                lblFormSubtitle.Text = "Please enter your staff credentials to manage guests and bookings.";

                txtUsername.PlaceholderText = "Username or email";
                lblUsernameLabel.Text = "Username or email";
                txtUsername.FocusedState.BorderColor = Color.FromArgb(120, 60, 200);
                txtPassword.FocusedState.BorderColor = Color.FromArgb(120, 60, 200);

                btnActionLogin.Text = "Login as Coordinator";
                btnActionLogin.FillColor = Color.FromArgb(74, 34, 120);
                btnActionLogin.HoverState.FillColor = Color.FromArgb(110, 55, 180);
            }
        }

        // ─────────────────────────────────────────────────────────
        // PASSWORD VISIBILITY TOGGLE
        // ─────────────────────────────────────────────────────────
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            _isPasswordVisible = chkShowPassword.Checked;
            txtPassword.UseSystemPasswordChar = !_isPasswordVisible;
            picTogglePassword.Image = _isPasswordVisible
                ? Properties.Resources.eye_open
                : Properties.Resources.eye_closed;
        }

        private void picTogglePassword_Click(object sender, EventArgs e)
        {
            _isPasswordVisible = !_isPasswordVisible;
            txtPassword.UseSystemPasswordChar = !_isPasswordVisible;
            chkShowPassword.Checked = _isPasswordVisible;
            picTogglePassword.Image = _isPasswordVisible
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
            if (!_isPasswordVisible)
            {
                txtPassword.UseSystemPasswordChar = true;
                picTogglePassword.Image = Properties.Resources.eye_closed;
            }
        }

        // ─────────────────────────────────────────────────────────
        // LOGIN AUTHENTICATION (SQL Server)
        // ─────────────────────────────────────────────────────────
        private void btnActionLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowDialogMsg("Validation Error", "Please enter both username and password.", Color.OrangeRed);
                return;
            }

            if (_activePortal == ActivePortal.Admin)
            {
                AuthenticateAdmin(username, password);
            }
            else
            {
                AuthenticateCoordinator(username, password);
            }
        }

        private void AuthenticateAdmin(string username, string password)
        {
            try
            {
                using (SqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT admin_id, username FROM admins WHERE username = @u AND password = @p";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int adminId = Convert.ToInt32(reader["admin_id"]);
                                string name = reader["username"].ToString() ?? username;
                                ShowDialogMsg("Login Successful", $"Welcome Administrator, {name}!", Color.Teal);
                                this.Hide();
                                MainForm dashboard = new MainForm(adminId, name);
                                dashboard.OnLogout = () =>
                                {
                                    this.Show();
                                    this.SetPortal(ActivePortal.Admin);
                                    txtPassword.Clear();
                                    txtUsername.Focus();
                                };
                                dashboard.Show();
                            }
                            else
                            {
                                ShowDialogMsg("Login Failed", "Invalid credentials. Check your username and password.", Color.OrangeRed);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowDialogMsg("Connection Error", $"Could not connect to database in SSMS:\n{ex.Message}", Color.OrangeRed);
            }
        }

        private void AuthenticateCoordinator(string username, string password)
        {
            try
            {
                using (SqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT coordinator_id, full_name FROM coordinators WHERE (username = @u OR email = @u) AND password = @p";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int coordId = Convert.ToInt32(reader["coordinator_id"]);
                                string name = reader["full_name"].ToString() ?? username;
                                ShowDialogMsg("Login Successful", $"Welcome Coordinator, {name}!", Color.FromArgb(120, 60, 200));
                                this.Hide();
                                var userMain = new UserForms.UserMainForm(coordId, name, isCoordinator: true);
                                userMain.OnLogout = () =>
                                {
                                    this.Show();
                                    this.SetPortal(ActivePortal.Coordinator);
                                    txtPassword.Clear();
                                    txtUsername.Focus();
                                };
                                userMain.Show();
                            }
                            else
                            {
                                ShowDialogMsg(
                                    "Login Failed",
                                    "Invalid credentials. If you entered an email, make sure it contains '@'; check your username and password.",
                                    Color.OrangeRed);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowDialogMsg("Connection Error", $"Could not connect to database in SSMS:\n{ex.Message}", Color.OrangeRed);
            }
        }

        private void ShowDialogMsg(string title, string message, Color accent)
        {
            Form box = new Form
            {
                Text = title,
                Size = new Size(440, 200),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(20, 25, 35)
            };

            var strip = new Panel { Size = new Size(440, 4), Location = new Point(0, 0), BackColor = accent };
            var lbl = new Label
            {
                Text = message,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F),
                Size = new Size(380, 100),
                Location = new Point(25, 20),
                TextAlign = ContentAlignment.MiddleLeft
            };
            var ok = new Button
            {
                Text = "OK",
                Size = new Size(95, 36),
                BackColor = accent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Location = new Point(310, 130)
            };
            ok.FlatAppearance.BorderSize = 0;
            ok.Click += (s, e) => box.Close();

            box.Controls.AddRange(new Control[] { strip, lbl, ok });
            box.ShowDialog();
        }

        private void AdminLoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool anyOtherOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f != this && f.Visible) { anyOtherOpen = true; break; }
            }
            if (!anyOtherOpen) Application.Exit();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
