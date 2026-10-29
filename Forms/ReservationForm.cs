using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Hotel_Reservation_System.Database;
using Hotel_Reservation_System.Models;
using HotelReservationSystem.Models;
using Microsoft.Data.SqlClient;

namespace Hotel_Reservation_System.Forms
{
    public partial class ReservationForm : Form
    {
        private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private System.Windows.Forms.ComboBox cmbCustomer = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.ComboBox cmbRoom = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.DateTimePicker dtpCheckIn = new System.Windows.Forms.DateTimePicker();
        private System.Windows.Forms.DateTimePicker dtpCheckInTime = new System.Windows.Forms.DateTimePicker();
        private System.Windows.Forms.DateTimePicker dtpCheckOut = new System.Windows.Forms.DateTimePicker();
        private System.Windows.Forms.DateTimePicker dtpCheckOutTime = new System.Windows.Forms.DateTimePicker();
        private System.Windows.Forms.ComboBox cmbStatus = new System.Windows.Forms.ComboBox();
        ReservationDAO reservationDAO = new ReservationDAO();
        CustomerDAO customerDAO = new CustomerDAO();
        RoomDAO roomDAO = new RoomDAO();

        int selectedReservationId = -1;

        public ReservationForm()
        {
            InitializeComponent();
            
            LoadCustomers();
            LoadRooms();
            LoadReservations();
            this.dgvReservations.CellFormatting += dgvReservations_CellFormatting;

        }

        private void LoadCustomers()
        {
            var customers = CustomerDAO.GetAllCustomers();
            cmbCustomer.DataSource = customers;
            cmbCustomer.DisplayMember = "FullName";
            cmbCustomer.ValueMember = "CustomerId";
        }

        private void LoadRooms()
        {
            var rooms = RoomDAO.GetAllRooms();
            //var rooms = roomDAO.GetAllRooms();
            cmbRoom.DataSource = rooms;
            cmbRoom.DisplayMember = "RoomNumber";
            cmbRoom.ValueMember = "RoomId";
        }

        private void LoadReservations()
        {
            var reservations = ReservationDAO.GetAllReservations();  // Correct static call
            dgvReservations.DataSource = reservations;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Confirmed");
            cmbStatus.Items.Add("Cancelled");
            cmbStatus.SelectedIndex = 0;

            // Check and display pending reservations alert
            int pendingCount = ReservationDAO.GetPendingReservationsCount();
            if (pendingCount > 0)
            {
                lblPendingAlert.Text = $"🔔 Notice: You have {pendingCount} pending reservation{(pendingCount > 1 ? "s" : "")} awaiting approval.";
                lblPendingAlert.Visible = true;
            }
            else
            {
                lblPendingAlert.Visible = false;
            }

            // Hide internal IDs
            if (dgvReservations.Columns["CustomerId"] != null) dgvReservations.Columns["CustomerId"].Visible = false;
            if (dgvReservations.Columns["RoomId"] != null) dgvReservations.Columns["RoomId"].Visible = false;

            // Picture 3 Exact Column Order & Styles:
            // 0: Select
            if (dgvReservations.Columns["Select"] != null)
            {
                dgvReservations.Columns["Select"].DisplayIndex = 0;
                dgvReservations.Columns["Select"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["Select"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["Select"].Width = 65;
            }

            // 1: ReservationId
            if (dgvReservations.Columns["ReservationId"] != null)
            {
                dgvReservations.Columns["ReservationId"].DisplayIndex = 1;
                dgvReservations.Columns["ReservationId"].Visible = true;
                dgvReservations.Columns["ReservationId"].HeaderText = "ReservationId";
                dgvReservations.Columns["ReservationId"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["ReservationId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 2: Customer Name
            if (dgvReservations.Columns["CustomerName"] != null)
            {
                dgvReservations.Columns["CustomerName"].DisplayIndex = 2;
                dgvReservations.Columns["CustomerName"].HeaderText = "Customer Name";
                dgvReservations.Columns["CustomerName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservations.Columns["CustomerName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservations.Columns["CustomerName"].HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                dgvReservations.Columns["CustomerName"].DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
            }

            // 3: Function Hall No
            if (dgvReservations.Columns["RoomNumber"] != null)
            {
                dgvReservations.Columns["RoomNumber"].DisplayIndex = 3;
                dgvReservations.Columns["RoomNumber"].HeaderText = "Function Hall No";
                dgvReservations.Columns["RoomNumber"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["RoomNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 4: Venue Location
            if (dgvReservations.Columns["VenueLocation"] != null)
            {
                dgvReservations.Columns["VenueLocation"].DisplayIndex = 4;
                dgvReservations.Columns["VenueLocation"].HeaderText = "Venue Location";
                dgvReservations.Columns["VenueLocation"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservations.Columns["VenueLocation"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservations.Columns["VenueLocation"].HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                dgvReservations.Columns["VenueLocation"].DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
            }

            // 5: Event Type
            if (dgvReservations.Columns["EventType"] != null)
            {
                dgvReservations.Columns["EventType"].DisplayIndex = 5;
                dgvReservations.Columns["EventType"].HeaderText = "Event Type";
                dgvReservations.Columns["EventType"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservations.Columns["EventType"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservations.Columns["EventType"].HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                dgvReservations.Columns["EventType"].DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
            }

            // 6: Function Hall Type
            var ftypeCol = dgvReservations.Columns["FunctionhallType"] ?? dgvReservations.Columns["RoomType"];
            if (ftypeCol != null)
            {
                ftypeCol.DisplayIndex = 6;
                ftypeCol.HeaderText = "Function Hall Type";
                ftypeCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ftypeCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                ftypeCol.HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                ftypeCol.DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
            }

            // 6: Check-In Date
            if (dgvReservations.Columns["CheckInDate"] != null)
            {
                dgvReservations.Columns["CheckInDate"].DisplayIndex = 6;
                dgvReservations.Columns["CheckInDate"].HeaderText = "Check-In Date";
                dgvReservations.Columns["CheckInDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvReservations.Columns["CheckInDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["CheckInDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 7: Check-In Time
            if (dgvReservations.Columns["CheckInTime"] != null)
            {
                dgvReservations.Columns["CheckInTime"].DisplayIndex = 7;
                dgvReservations.Columns["CheckInTime"].HeaderText = "Check-In Time";
                dgvReservations.Columns["CheckInTime"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["CheckInTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 8: Check-Out Date
            if (dgvReservations.Columns["CheckOutDate"] != null)
            {
                dgvReservations.Columns["CheckOutDate"].DisplayIndex = 8;
                dgvReservations.Columns["CheckOutDate"].HeaderText = "Check-Out Date";
                dgvReservations.Columns["CheckOutDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvReservations.Columns["CheckOutDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["CheckOutDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 9: Check-Out Time
            if (dgvReservations.Columns["CheckOutTime"] != null)
            {
                dgvReservations.Columns["CheckOutTime"].DisplayIndex = 9;
                dgvReservations.Columns["CheckOutTime"].HeaderText = "Check-Out Time";
                dgvReservations.Columns["CheckOutTime"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["CheckOutTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 10: Date Reserved
            if (dgvReservations.Columns["DateReserved"] != null)
            {
                dgvReservations.Columns["DateReserved"].DisplayIndex = 10;
                dgvReservations.Columns["DateReserved"].HeaderText = "Date Reserved";
                dgvReservations.Columns["DateReserved"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvReservations.Columns["DateReserved"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["DateReserved"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 11: Status
            if (dgvReservations.Columns["Status"] != null)
            {
                dgvReservations.Columns["Status"].DisplayIndex = 11;
                dgvReservations.Columns["Status"].HeaderText = "Status";
                dgvReservations.Columns["Status"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void ClearFields()
        {
            cmbCustomer.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);
            dtpCheckInTime.Value = DateTime.Now;
            dtpCheckOutTime.Value = DateTime.Now.AddHours(1);
            cmbStatus.SelectedIndex = -1;
            selectedReservationId = -1;
        }

        private void dgvReservations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvReservations.Columns[e.ColumnIndex].Name == "CheckInTime" ||
                dgvReservations.Columns[e.ColumnIndex].Name == "CheckOutTime")
            {
                if (e.Value != null && TimeSpan.TryParse(e.Value.ToString(), out TimeSpan time))
                {
                    DateTime timeWithDate = DateTime.Today.Add(time);
                    e.Value = timeWithDate.ToString("hh:mm tt"); // e.g., 03:45:00 PM
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            // Find selected reservation or first pending reservation
            int targetReservationId = -1;
            string targetCustomerName = "";

            foreach (DataGridViewRow row in dgvReservations.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                {
                    targetReservationId = Convert.ToInt32(row.Cells["ReservationId"].Value);
                    targetCustomerName = row.Cells["CustomerName"]?.Value?.ToString() ?? "Guest";
                    break;
                }
            }

            if (targetReservationId == -1 && dgvReservations.CurrentRow != null)
            {
                targetReservationId = Convert.ToInt32(dgvReservations.CurrentRow.Cells["ReservationId"].Value);
                targetCustomerName = dgvReservations.CurrentRow.Cells["CustomerName"]?.Value?.ToString() ?? "Guest";
            }

            if (targetReservationId == -1)
            {
                // Fallback to first pending reservation
                foreach (DataGridViewRow row in dgvReservations.Rows)
                {
                    if (string.Equals(row.Cells["Status"]?.Value?.ToString(), "Pending", StringComparison.OrdinalIgnoreCase))
                    {
                        targetReservationId = Convert.ToInt32(row.Cells["ReservationId"].Value);
                        targetCustomerName = row.Cells["CustomerName"]?.Value?.ToString() ?? "Guest";
                        break;
                    }
                }
            }

            if (targetReservationId == -1)
            {
                ShowCustomMessageBox("Selection Needed", "Please select a reservation to accept.", 500, 200);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Accept reservation #{targetReservationId} for '{targetCustomerName}'?\n\nThis will mark the reservation Confirmed, book the venue, and automatically place the customer into Customer Management.",
                "Accept Reservation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool success = ReservationDAO.AcceptReservation(targetReservationId);
                if (success)
                {
                    ShowCustomMessageBox("Reservation Confirmed", $"Reservation #{targetReservationId} has been successfully accepted! Customer '{targetCustomerName}' is now placed into Customer Management.", 540, 210);
                    LoadReservations();
                }
                else
                {
                    ShowCustomMessageBox("Error", "Failed to accept reservation.", 500, 200);
                }
            }
        }

        private void lblPendingAlert_Click(object sender, EventArgs e)
        {
            btnAccept_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<int> selectedIds = new List<int>();
            DataGridViewRow selectedRow = null;

            foreach (DataGridViewRow row in dgvReservations.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                {
                    int reservationId = Convert.ToInt32(row.Cells["ReservationId"].Value);
                    selectedIds.Add(reservationId);
                    selectedRow = row;
                }
            }

            if (selectedIds.Count == 0)
            {
                ShowCustomMessageBox("Selection Needed", "Please select one reservation to update.", 500, 200);
                return;
            }

            if (selectedIds.Count > 1)
            {
                ShowCustomMessageBox("Reminder", "Please select only one reservation to update at a time.", 500, 200);
                return;
            }

            // Get reservation data from selected row
            int id = Convert.ToInt32(selectedRow.Cells["ReservationId"].Value);
            int customerId = Convert.ToInt32(selectedRow.Cells["CustomerId"].Value);
            int roomId = Convert.ToInt32(selectedRow.Cells["RoomId"].Value);
            DateTime checkInDate = Convert.ToDateTime(selectedRow.Cells["CheckInDate"].Value);

            // Use nullable TimeSpan to avoid exception if null
            TimeSpan? checkInTimeNullable = selectedRow.Cells["CheckInTime"].Value as TimeSpan?;
            TimeSpan checkInTime = TimeSpan.Zero;
            if (TimeSpan.TryParse(selectedRow.Cells["CheckInTime"].Value?.ToString(), out TimeSpan parsedCheckInTime))
                checkInTime = parsedCheckInTime;

            DateTime checkOutDate = Convert.ToDateTime(selectedRow.Cells["CheckOutDate"].Value);

            TimeSpan? checkOutTimeNullable = selectedRow.Cells["CheckOutTime"].Value as TimeSpan?;
            TimeSpan checkOutTime = TimeSpan.Zero;
            if (TimeSpan.TryParse(selectedRow.Cells["CheckOutTime"].Value?.ToString(), out TimeSpan parsedCheckOutTime))
                checkOutTime = parsedCheckOutTime;

            string status = selectedRow.Cells["Status"].Value?.ToString() ?? "";
            string eventType = selectedRow.Cells["EventType"]?.Value?.ToString() ?? "Wedding";

            // Open AddReservationForm with pre-filled data
            AddReservationForm updateForm = new AddReservationForm();
            updateForm.SetReservationData(id, customerId, roomId, checkInDate, checkInTime, checkOutDate, checkOutTime, status, eventType);

            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                // Get updated reservation from form
                Reservation updatedReservation = updateForm.NewReservation;
                updatedReservation.ReservationId = id; // Keep same ID

                bool success = ReservationDAO.UpdateReservation(updatedReservation);
                if (success)
                {
                    ShowCustomMessageBox("Success", "Reservation updated successfully!", 500, 200);
                }
                else
                {
                    ShowCustomMessageBox("Error", "Failed to update reservation.", 500, 200);
                }

                LoadReservations();
                ClearFields();
            }
        }

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //if (selectedReservationId == -1)
        //{
        //MessageBox.Show("Please select a reservation to delete.");
        //return;
        //}

        //var confirm = MessageBox.Show("Are you sure you want to delete this reservation?", "Confirm Delete", MessageBoxButtons.YesNo);
        //if (confirm == DialogResult.Yes)
        //{
        //reservationDAO.DeleteReservation(selectedReservationId);
        //LoadReservations();
        //ClearFields();
        //MessageBox.Show("Reservation deleted successfully!");
        //}
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> selectedIds = new List<int>();

            foreach (DataGridViewRow row in dgvReservations.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                {
                    int reservationId = Convert.ToInt32(row.Cells["ReservationId"].Value);
                    selectedIds.Add(reservationId);
                }
            }

            if (selectedIds.Count == 0)
            {
                ShowCustomMessageBox("Selection Needed", "Please select at least one reservation to delete.", 500, 200);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected reservations?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool allDeleted = true;
                bool hasConstraintErrors = false;

                foreach (int id in selectedIds)
                {
                    try
                    {
                        bool success = ReservationDAO.DeleteReservation(id);
                        if (!success)
                        {
                            allDeleted = false;
                        }
                    }
                    catch (SqlException ex) when (ex.Number == 547 || ex.Message.Contains("REFERENCE constraint"))
                    {
                        hasConstraintErrors = true;
                        allDeleted = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        allDeleted = false;
                    }
                }

                if (allDeleted)
                {
                    ShowCustomMessageBox("Success", "Selected reservations deleted successfully!", 500, 200);
                }
                else if (hasConstraintErrors)
                {
                    ShowCustomMessageBox("Notice", "Some reservations couldn't be deleted because they have related payment records.", 500, 200);
                }
                else
                {
                    ShowCustomMessageBox("Error", "Some reservations failed to delete.", 500, 200);
                }

                LoadReservations();
                ClearFields();
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvReservations.Rows[e.RowIndex];
                selectedReservationId = Convert.ToInt32(row.Cells["ReservationId"].Value);
                cmbCustomer.SelectedValue = Convert.ToInt32(row.Cells["CustomerId"].Value);
                cmbRoom.SelectedValue = Convert.ToInt32(row.Cells["RoomId"].Value);

                // Handle Check-In Date
                if (DateTime.TryParse(row.Cells["CheckInDate"].Value?.ToString(), out DateTime checkInDate) &&
                    checkInDate >= dtpCheckIn.MinDate && checkInDate <= dtpCheckIn.MaxDate)
                {
                    dtpCheckIn.Value = checkInDate;
                }
                else
                {
                    dtpCheckIn.Value = DateTime.Now;
                }

                // Handle Check-In Time
                if (TimeSpan.TryParse(row.Cells["CheckInTime"].Value?.ToString(), out TimeSpan checkInTime))
                {
                    dtpCheckInTime.Value = dtpCheckIn.Value.Date + checkInTime;
                }
                else
                {
                    dtpCheckInTime.Value = dtpCheckIn.Value.Date.AddHours(14);
                }

                // Handle Check-Out Date
                if (DateTime.TryParse(row.Cells["CheckOutDate"].Value?.ToString(), out DateTime checkOutDate) &&
                    checkOutDate >= dtpCheckOut.MinDate && checkOutDate <= dtpCheckOut.MaxDate)
                {
                    dtpCheckOut.Value = checkOutDate;
                }
                else
                {
                    dtpCheckOut.Value = DateTime.Now.AddDays(1);
                }

                // Handle Check-Out Time
                if (TimeSpan.TryParse(row.Cells["CheckOutTime"].Value?.ToString(), out TimeSpan checkOutTime))
                {
                    dtpCheckOutTime.Value = dtpCheckOut.Value.Date + checkOutTime;
                }
                else
                {
                    dtpCheckOutTime.Value = dtpCheckOut.Value.Date.AddHours(12);
                }

                cmbStatus.Text = row.Cells["Status"].Value?.ToString() ?? "";
            }
        }


        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void btnAccept_MouseHover(object sender, EventArgs e)
        {
            Point location = new Point(btnAccept.Width, 0); // Top-right of the button
            toolTip.Show("Accept Reservation", btnAccept, location);
        }

        private void btnAccept_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(btnAccept);
        }

        private void btnUpdate_MouseHover(object sender, EventArgs e)
        {
            Point location = new Point(btnUpdate.Width, 0); // Top-right of the button
            toolTip.Show("Update", btnUpdate, location);
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(btnUpdate);
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            Point location = new Point(btnDelete.Width, 0); // Top-right of the button
            toolTip.Show("Delete", btnDelete, location);
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(btnDelete);
        }

        private void dgvReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
