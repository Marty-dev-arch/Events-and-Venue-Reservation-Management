using System;
using System.Drawing;
using System.Windows.Forms;
using Hotel_Reservation_System.Database;
using Microsoft.Data.SqlClient;

namespace Hotel_Reservation_System.Forms
{
    public partial class AdminProfileForm : Form
    {
        private int adminId;
        private string originalUsername = "";
        private string originalFullName = "";
        private string originalEmail = "";
        private string originalContact = "";
        private string originalPassword = "";

        public event Action<string>? ProfileUpdated;

        public AdminProfileForm() : this(1)
        {
        }

        public AdminProfileForm(int adminId)
        {
            InitializeComponent();
            this.adminId = adminId;
        }

        private void AdminProfileForm_Load(object sender, EventArgs e)
        {
            LoadAdminProfile();
        }

        private void LoadAdminProfile()
        {
            try
            {
                using (SqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT TOP 1 admin_id, username, password, 
                                           ISNULL(full_name, 'System Administrator') AS full_name,
                                           ISNULL(email, 'admin@eventvenue.com') AS email,
                                           ISNULL(contact_number, '') AS contact_number
                                    FROM admins
                                    WHERE admin_id = @id OR @id <= 0
                                    ORDER BY admin_id ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", adminId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                adminId = Convert.ToInt32(reader["admin_id"]);
                                originalUsername = reader["username"]?.ToString() ?? "admin";
                                originalPassword = reader["password"]?.ToString() ?? "";
                                originalFullName = reader["full_name"]?.ToString() ?? "System Administrator";
                                originalEmail = reader["email"]?.ToString() ?? "admin@eventvenue.com";
                                originalContact = reader["contact_number"]?.ToString() ?? "";

                                txtUsername.Text = originalUsername;
                                txtPassword.Text = originalPassword;
                                txtFullName.Text = originalFullName;
                                txtEmail.Text = originalEmail;
                                txtContact.Text = originalContact;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load administrator profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string contact = txtContact.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Check if changes were made
            if (fullName == originalFullName &&
                username == originalUsername &&
                email == originalEmail &&
                contact == originalContact &&
                password == originalPassword)
            {
                MessageBox.Show("No changes detected. Please modify a field to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE admins
                                     SET username = @username,
                                         password = @password,
                                         full_name = @full_name,
                                         email = @email,
                                         contact_number = @contact_number
                                     WHERE admin_id = @admin_id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@admin_id", adminId);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@full_name", fullName);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@contact_number", contact);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            originalFullName = fullName;
                            originalUsername = username;
                            originalEmail = email;
                            originalContact = contact;
                            originalPassword = password;

                            ProfileUpdated?.Invoke(username);
                            MessageBox.Show("Administrator profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Administrator profile was not found and could not be updated.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update administrator profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '•';
        }
    }
}
