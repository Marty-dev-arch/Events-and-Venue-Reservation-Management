using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_Reservation_System.Database;
using Microsoft.Data.SqlClient;

namespace Hotel_Reservation_System.Forms.UserForms
{
    public partial class ProfileForm : Form
    {
        private int customerId;
        private bool isCoordinator = false;
        private string originalFullName;
        private string originalEmail;
        private string originalContact;
        private string originalAddress;
        private Guna.UI2.WinForms.Guna2TextBox? txtCoordinatorPassword;
        public event Action<string>? ProfileUpdated;

        public ProfileForm(int customerId, bool isCoordinator = false)
        {
            InitializeComponent();
            this.customerId = customerId;
            this.isCoordinator = isCoordinator;
            Resize += ProfileForm_Resize;

            if (isCoordinator)
                AddCoordinatorPasswordControls();

            CenterProfileCard();
        }

        private void AddCoordinatorPasswordControls()
        {
            guna2ShadowPanel1.Height = 390;
            btnUpdateProfile.Location = new Point(btnUpdateProfile.Left, 325);

            Label passwordLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10.2F),
                Location = new Point(41, 243),
                Text = "New Password"
            };

            txtCoordinatorPassword = new Guna.UI2.WinForms.Guna2TextBox
            {
                BorderColor = Color.FromArgb(0, 26, 26),
                BorderRadius = 10,
                FillColor = Color.FromArgb(242, 242, 242),
                Font = new Font("Segoe UI", 10.2F),
                ForeColor = Color.Black,
                Location = new Point(41, 264),
                MaxLength = 100,
                PasswordChar = '•',
                PlaceholderText = "Leave blank to keep current password",
                Size = new Size(386, 40),
                TabIndex = 6
            };

            CheckBox showPassword = new CheckBox
            {
                AutoSize = true,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(446, 275),
                Text = "Show password",
                UseVisualStyleBackColor = true
            };
            showPassword.CheckedChanged += (_, _) =>
                txtCoordinatorPassword.PasswordChar = showPassword.Checked ? '\0' : '•';

            guna2ShadowPanel1.Controls.Add(passwordLabel);
            guna2ShadowPanel1.Controls.Add(txtCoordinatorPassword);
            guna2ShadowPanel1.Controls.Add(showPassword);
            btnUpdateProfile.TabIndex = 7;
        }

        private void ProfileForm_Resize(object? sender, EventArgs e)
        {
            CenterProfileCard();
        }

        private void CenterProfileCard()
        {
            int x = Math.Max(20, (ClientSize.Width - guna2ShadowPanel1.Width) / 2);
            int y = Math.Max(20, (ClientSize.Height - guna2ShadowPanel1.Height) / 2);
            guna2ShadowPanel1.Location = new Point(x, y);
        }

        private UserMainForm? FindParentUserMain()
        {
            Control? current = this.Parent;
            while (current != null)
            {
                if (current is UserMainForm userMain)
                    return userMain;
                current = current.Parent;
            }
            return null;
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void LoadProfile()
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = isCoordinator
                    ? "SELECT full_name, email, ISNULL(contact_number, '') AS contact_number, ISNULL(address, '') AS address FROM coordinators WHERE coordinator_id = @id"
                    : "SELECT full_name, email, contact_number, address FROM customers WHERE customer_id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", customerId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        originalFullName = reader["full_name"]?.ToString() ?? "";
                        originalEmail = reader["email"]?.ToString() ?? "";
                        originalContact = reader["contact_number"]?.ToString() ?? "";
                        originalAddress = reader["address"]?.ToString() ?? "";

                        txtFullName.Text = originalFullName;
                        txtEmail.Text = originalEmail;
                        txtContact.Text = originalContact;
                        txtAddress.Text = originalAddress;
                    }
                }
            }
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string contact = txtContact.Text.Trim();
            string address = txtAddress.Text.Trim();
            string newPassword = txtCoordinatorPassword?.Text.Trim() ?? "";

            if (fullName == "" || email == "")
            {
                MessageBox.Show("Full name and email are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if anything has actually changed
            if (fullName == originalFullName &&
                email == originalEmail &&
                contact == originalContact &&
                address == originalAddress &&
                string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("No changes detected. Please modify at least one field before updating.", "No Changes Made", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Proceed with update
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = isCoordinator
                    ? "UPDATE coordinators SET full_name = @fullName, email = @email, contact_number = @contact, address = @address, password = CASE WHEN @password IS NULL THEN password ELSE @password END WHERE coordinator_id = @id"
                    : @"UPDATE customers 
                         SET full_name = @fullName, email = @email, 
                             contact_number = @contact, address = @address 
                         WHERE customer_id = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@id", customerId);
                if (isCoordinator)
                    cmd.Parameters.AddWithValue("@password", string.IsNullOrWhiteSpace(newPassword) ? DBNull.Value : newPassword);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    ShowCustomMessageBox("Success","Profile updated successfully!", 500, 200);

                    // Refresh original values
                    originalFullName = fullName;
                    originalEmail = email;
                    originalContact = contact;
                    originalAddress = address;
                    txtCoordinatorPassword?.Clear();

                    // Immediately update header greeting at the top of the coordinator portal
                    ProfileUpdated?.Invoke(fullName);
                    FindParentUserMain()?.UpdateGreeting(fullName);
                }
                else
                {
                    ShowCustomMessageBox("Error", "Update failed. Please try again.", 500, 200);
                }
            }
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
    }
}
