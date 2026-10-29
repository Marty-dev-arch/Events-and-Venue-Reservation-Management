using Hotel_Reservation_System.Database;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Reservation_System.Forms.UserForms
{
    public partial class ReserveRoomForm : Form
    {
        private int customerId;
        private int roomId;
        private string coordinatorName;

        public ReserveRoomForm(int customerId, int roomId) : this(customerId, roomId, "")
        {
        }

        public ReserveRoomForm(int customerId, int roomId, string coordinatorName)
        {
            InitializeComponent();
            this.customerId = customerId;
            this.roomId = roomId;
            this.coordinatorName = coordinatorName ?? "";
        }

        private void ReserveRoomForm_Load(object sender, EventArgs e)
        {
            // Set current date as default
            DateTime now = DateTime.Now;
            dateCheckIn.MinDate = now.Date;
            dateCheckOut.MinDate = now.Date;

            dateCheckIn.Value = now.Date;
            dateCheckOut.Value = now.Date;

            // Populate time dropdowns and set default selection
            PopulateTimeDropdowns();

            // Populate Event Types if empty
            if (cmbEventType.Items.Count == 0)
            {
                cmbEventType.Items.AddRange(new object[] { "Wedding", "Birthday", "Conference", "Anniversary", "Seminar", "Private Party" });
            }
            if (cmbEventType.SelectedIndex < 0 && cmbEventType.Items.Count > 0)
            {
                cmbEventType.SelectedIndex = 0;
            }

            // Load default Event Type and Venue Location from room if configured
            try
            {
                var room = RoomDAO.GetRoomById(roomId);
                if (room != null)
                {
                    string venueName = string.IsNullOrWhiteSpace(room.VenueLocation) ? "Venue" : room.VenueLocation;
                    label1.Text = $"Make Reservation - {venueName} (Hall {room.RoomNumber})";

                    if (!string.IsNullOrEmpty(room.EventType))
                    {
                        int idx = cmbEventType.FindStringExact(room.EventType);
                        if (idx >= 0) cmbEventType.SelectedIndex = idx;
                        else cmbEventType.Text = room.EventType;
                    }
                }
            }
            catch { }
        }

        private void PopulateTimeDropdowns()
        {
            cmbCheckInTime.Items.Clear();
            cmbCheckOutTime.Items.Clear();

            // Generate half-hour intervals from 06:00 AM to 11:30 PM
            DateTime time = DateTime.Today.AddHours(6); // 06:00 AM
            DateTime endTime = DateTime.Today.AddHours(23).AddMinutes(30); // 11:30 PM

            while (time <= endTime)
            {
                string formatted = time.ToString("hh:mm tt");
                cmbCheckInTime.Items.Add(formatted);
                cmbCheckOutTime.Items.Add(formatted);
                time = time.AddMinutes(30);
            }

            // Set convenient defaults: Check-In at 09:00 AM, Check-Out at 05:00 PM
            int inIndex = cmbCheckInTime.FindStringExact("09:00 AM");
            cmbCheckInTime.SelectedIndex = inIndex >= 0 ? inIndex : 0;

            int outIndex = cmbCheckOutTime.FindStringExact("05:00 PM");
            cmbCheckOutTime.SelectedIndex = outIndex >= 0 ? outIndex : (cmbCheckOutTime.Items.Count > 10 ? 10 : 0);
        }

        private TimeSpan ParseTime(string text, TimeSpan defaultTime)
        {
            if (string.IsNullOrWhiteSpace(text)) return defaultTime;
            if (DateTime.TryParse(text.Trim(), out DateTime dt))
            {
                return dt.TimeOfDay;
            }
            if (TimeSpan.TryParse(text.Trim(), out TimeSpan ts))
            {
                return ts;
            }
            return defaultTime;
        }

        private int ResolveOrInsertCustomer(SqlConnection conn, SqlTransaction trans)
        {
            string custName = txtboxCustomerName.Text.Trim();
            string email = txtBoxEmail.Text.Trim();
            string phone = txtBoxPhone.Text.Trim();
            string address = txtBoxAddress.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                email = custName.ToLower().Replace(" ", ".") + "@client.com";
            }
            if (string.IsNullOrEmpty(phone))
            {
                phone = "09000000000";
            }
            if (string.IsNullOrEmpty(address))
            {
                address = "Hotel Client";
            }

            // Check if customer exists by name and email
            using (SqlCommand checkCmd = new SqlCommand("SELECT TOP 1 customer_id FROM customers WHERE full_name = @name AND (email = @email OR @email = '')", conn, trans))
            {
                checkCmd.Parameters.AddWithValue("@name", custName);
                checkCmd.Parameters.AddWithValue("@email", email);
                object res = checkCmd.ExecuteScalar();
                if (res != null && res != DBNull.Value)
                {
                    return Convert.ToInt32(res);
                }
            }

            // Insert new customer with status 'Pending' using sp_AddCustomer
            using (SqlCommand insertCmd = new SqlCommand("sp_AddCustomer", conn, trans))
            {
                insertCmd.CommandType = CommandType.StoredProcedure;
                insertCmd.Parameters.AddWithValue("@full_name", custName);
                insertCmd.Parameters.AddWithValue("@email", email);
                insertCmd.Parameters.AddWithValue("@contact_number", phone);
                insertCmd.Parameters.AddWithValue("@address", address);
                insertCmd.Parameters.AddWithValue("@status", "Pending");

                SqlParameter outIdParam = new SqlParameter("@customer_id", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output,
                    Value = DBNull.Value
                };
                insertCmd.Parameters.Add(outIdParam);

                object newId = insertCmd.ExecuteScalar();
                if (outIdParam.Value != null && outIdParam.Value != DBNull.Value)
                {
                    return Convert.ToInt32(outIdParam.Value);
                }
                if (newId != null && newId != DBNull.Value)
                {
                    return Convert.ToInt32(newId);
                }
            }

            // Fallback direct insert
            string sql = "INSERT INTO customers (full_name, email, contact_number, address, status, created_at) VALUES (@name, @email, @phone, @addr, 'Pending', GETDATE()); SELECT SCOPE_IDENTITY();";
            using (SqlCommand fbCmd = new SqlCommand(sql, conn, trans))
            {
                fbCmd.Parameters.AddWithValue("@name", custName);
                fbCmd.Parameters.AddWithValue("@email", email);
                fbCmd.Parameters.AddWithValue("@phone", phone);
                fbCmd.Parameters.AddWithValue("@addr", address);
                return Convert.ToInt32(fbCmd.ExecuteScalar());
            }
        }

        private void btnConfirmReservation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtboxCustomerName.Text))
            {
                ShowCustomMessageBox("Validation Error", "Please enter the customer name.", 500, 200);
                txtboxCustomerName.Focus();
                return;
            }

            DateTime checkInDate = dateCheckIn.Value.Date;
            TimeSpan checkInTime = ParseTime(cmbCheckInTime.Text, new TimeSpan(9, 0, 0));
            DateTime checkOutDate = dateCheckOut.Value.Date;
            TimeSpan checkOutTime = ParseTime(cmbCheckOutTime.Text, new TimeSpan(17, 0, 0));

            string eventType = cmbEventType.SelectedItem?.ToString() ?? cmbEventType.Text;
            if (string.IsNullOrWhiteSpace(eventType)) eventType = "Wedding";

            DateTime fullCheckIn = checkInDate + checkInTime;
            DateTime fullCheckOut = checkOutDate + checkOutTime;

            if (fullCheckIn < DateTime.Now.AddMinutes(-5))
            {
                ShowCustomMessageBox("Invalid", "Check-in time must not be in the past.", 500, 200);
                return;
            }

            if (fullCheckOut <= fullCheckIn)
            {
                ShowCustomMessageBox("Invalid", "Check-out time must be after check-in time.", 500, 200);
                return;
            }

            // Minimum stay validation (3 hours)
            if ((fullCheckOut - fullCheckIn).TotalHours < 3)
            {
                ShowCustomMessageBox("Invalid", "Minimum duration must be at least 3 hours.", 500, 200);
                return;
            }

            try
            {
                using (SqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Resolve or create customer (with status 'Pending')
                            int assignedCustomerId = ResolveOrInsertCustomer(conn, trans);

                            // 2. Insert reservation via sp_AddReservation with status 'Pending'
                            using (SqlCommand cmd = new SqlCommand("sp_AddReservation", conn, trans))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@customer_id", assignedCustomerId);
                                cmd.Parameters.AddWithValue("@room_id", roomId);
                                cmd.Parameters.AddWithValue("@event_type", eventType);
                                cmd.Parameters.AddWithValue("@check_in_date", checkInDate);
                                cmd.Parameters.AddWithValue("@check_in_time", checkInTime);
                                cmd.Parameters.AddWithValue("@check_out_date", checkOutDate);
                                cmd.Parameters.AddWithValue("@check_out_time", checkOutTime);
                                cmd.Parameters.AddWithValue("@status", "Pending");

                                SqlParameter outResParam = new SqlParameter("@reservation_id", SqlDbType.Int)
                                {
                                    Direction = ParameterDirection.Output,
                                    Value = DBNull.Value
                                };
                                cmd.Parameters.Add(outResParam);

                                cmd.ExecuteNonQuery();
                            }

                            trans.Commit();

                            ShowCustomMessageBox("Reservation Submitted", "Reservation has been successfully submitted! It is now pending approval by the Admin.", 520, 210);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowCustomMessageBox("Error", "Failed to submit reservation: " + ex.Message, 550, 220);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dateCheckIn_ValueChanged(object sender, EventArgs e)
        {
            if (dateCheckOut.Value.Date < dateCheckIn.Value.Date)
            {
                dateCheckOut.Value = dateCheckIn.Value.Date;
            }
            dateCheckOut.MinDate = dateCheckIn.Value.Date;
        }

        private void dateCheckOut_ValueChanged(object sender, EventArgs e)
        {
            if (dateCheckOut.Value.Date < dateCheckIn.Value.Date)
            {
                dateCheckIn.Value = dateCheckOut.Value.Date;
            }
        }

        public void ShowCustomMessageBox(string title, string message, int width, int height)
        {
            Form customBox = new Form
            {
                Text = title,
                Size = new Size(width, height),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblMessage = new Label
            {
                Text = message,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Font = new Font("Segoe UI", 10),
                Size = new Size(width - 40, height - 120),
                Location = new Point(20, 20)
            };

            Button okButton = new Button
            {
                Text = "OK",
                Size = new Size(80, 30),
                Cursor = Cursors.Hand
            };
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

        private void cmbEventType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

