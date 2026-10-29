using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Hotel_Reservation_System.Database;
using HotelReservationSystem.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel_Reservation_System.Forms
{
    public partial class RoomForm : Form
    {
        private List<Room> rooms = new List<Room>();
        private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private System.Windows.Forms.TextBox txtRoomNumber = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.TextBox txtRoomType = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.TextBox txtRate = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.CheckBox chkAvailable = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.CheckBox chkMaintenance = new System.Windows.Forms.CheckBox();
        private System.Windows.Forms.NumericUpDown nudCapacity = new System.Windows.Forms.NumericUpDown();
        private System.Windows.Forms.NumericUpDown nudBeds = new System.Windows.Forms.NumericUpDown();
        System.Windows.Forms.Button okButton = new System.Windows.Forms.Button();

        public RoomForm()
        {
            InitializeComponent();
            dgvRooms.AutoGenerateColumns = true;
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            LoadRooms();
            this.Controls.Add(txtRoomNumber);
            this.Controls.Add(txtRoomType);
            this.Controls.Add(chkAvailable);
            this.Controls.Add(txtRate);
            // You can set options here if you want
            toolTip.AutoPopDelay = 2000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 100;
            toolTip.ShowAlways = true;

            //DataGridViewTextBoxColumn actionColumn = new DataGridViewTextBoxColumn();
            //actionColumn.Name = "Actions";
            //actionColumn.HeaderText = "Actions";
            //actionColumn.Width = 60; // Enough to fit two icons side by side
            //dgvRooms.Columns.Add(actionColumn);
        }

        private void LoadRooms()
        {
            rooms = RoomDAO.GetAllRooms();
            dgvRooms.DataSource = null;
            dgvRooms.DataSource = rooms;

            if (dgvRooms.Columns["RoomId"] != null) dgvRooms.Columns["RoomId"].Visible = false;
            if (dgvRooms.Columns["ImageData"] != null) dgvRooms.Columns["ImageData"].Visible = false;
            // Hide event type from room overview table per user specification (admin manages venues, not event types)
            if (dgvRooms.Columns["EventType"] != null) dgvRooms.Columns["EventType"].Visible = false;

            // 1. Select checkbox
            if (dgvRooms.Columns["Select"] != null)
            {
                dgvRooms.Columns["Select"].DisplayIndex = 0;
                dgvRooms.Columns["Select"].HeaderText = "Select";
                dgvRooms.Columns["Select"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRooms.Columns["Select"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRooms.Columns["Select"].Width = 65;
            }

            // 2. Room Number -> Function Hall No
            var roomNumberColumn = dgvRooms.Columns["RoomNumber"];
            if (roomNumberColumn != null)
            {
                roomNumberColumn.HeaderText = "Function Hall No";
                roomNumberColumn.Width = 140;
            }

            // 3. Venue Location (Big 8, Golden Palace, New City Hall, Jzar Function Hall, Palmeras Private Resort)
            if (dgvRooms.Columns["VenueLocation"] != null)
            {
                dgvRooms.Columns["VenueLocation"].DisplayIndex = 2;
                dgvRooms.Columns["VenueLocation"].HeaderText = "Venue Location";
                dgvRooms.Columns["VenueLocation"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvRooms.Columns["VenueLocation"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvRooms.Columns["VenueLocation"].HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                dgvRooms.Columns["VenueLocation"].DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
                dgvRooms.Columns["VenueLocation"].Width = 180;
            }

            // 4. FunctionhallType
            var typeCol = dgvRooms.Columns["FunctionhallType"] ?? dgvRooms.Columns["RoomType"];
            if (typeCol != null)
            {
                typeCol.DisplayIndex = 3;
                typeCol.HeaderText = "FunctionhallType";
                typeCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                typeCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                typeCol.HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                typeCol.DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
                typeCol.Width = 160;
            }

            // 5. Rate
            if (dgvRooms.Columns["Rate"] != null)
            {
                dgvRooms.Columns["Rate"].DisplayIndex = 4;
                dgvRooms.Columns["Rate"].HeaderText = "Rate";
                dgvRooms.Columns["Rate"].DefaultCellStyle.Format = "N2";
                dgvRooms.Columns["Rate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvRooms.Columns["Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvRooms.Columns["Rate"].HeaderCell.Style.Padding = new Padding(0, 0, 16, 0);
                dgvRooms.Columns["Rate"].DefaultCellStyle.Padding = new Padding(0, 0, 16, 0);
                dgvRooms.Columns["Rate"].Width = 120;
            }

            // 6. Capacity
            if (dgvRooms.Columns["Capacity"] != null)
            {
                dgvRooms.Columns["Capacity"].DisplayIndex = 5;
                dgvRooms.Columns["Capacity"].HeaderText = "Capacity";
                dgvRooms.Columns["Capacity"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRooms.Columns["Capacity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRooms.Columns["Capacity"].Width = 100;
            }

            // 7. Beds (Tables)
            if (dgvRooms.Columns["Beds"] != null)
            {
                dgvRooms.Columns["Beds"].DisplayIndex = 6;
                dgvRooms.Columns["Beds"].HeaderText = "No. of Tables";
                dgvRooms.Columns["Beds"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRooms.Columns["Beds"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRooms.Columns["Beds"].Width = 110;
            }

            // 8. Availability
            if (dgvRooms.Columns["Availability"] != null)
            {
                dgvRooms.Columns["Availability"].DisplayIndex = 7;
                dgvRooms.Columns["Availability"].HeaderText = "Availability";
                dgvRooms.Columns["Availability"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRooms.Columns["Availability"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRooms.Columns["Availability"].Width = 100;
            }

            // 9. Maintenance
            if (dgvRooms.Columns["Maintenance"] != null)
            {
                dgvRooms.Columns["Maintenance"].DisplayIndex = 8;
                dgvRooms.Columns["Maintenance"].HeaderText = "Maintenance";
                dgvRooms.Columns["Maintenance"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRooms.Columns["Maintenance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRooms.Columns["Maintenance"].Width = 110;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddRoomForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Room newRoom = new Room
                    {
                        RoomNumber = form.RoomNumber,
                        VenueLocation = form.VenueLocation,
                        EventType = form.EventType,
                        FunctionhallType = form.RoomType,
                        Rate = form.Rate,
                        // When admin creates a venue, it is Available (not booked), unless marked under maintenance
                        Availability = form.Maintenance ? false : true,
                        Maintenance = form.Maintenance,
                        ImageData = form.ImageData,  // ← Pass image byte[] instead of path
                        Capacity = form.Capacity,
                        Beds = form.Beds
                    };

                    bool success = RoomDAO.AddRoom(newRoom);
                    if (success)
                    {
                        ShowCustomMessageBox("Success", "Function hall added successfully!", 500, 200);
                        rooms.Add(newRoom);
                        LoadRooms();
                    }
                    else
                    {
                        ShowCustomMessageBox("Error", "Failed to add function hall.", 500, 200);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<int> selectedIds = new List<int>();
            DataGridViewRow selectedRow = null;

            foreach (DataGridViewRow row in dgvRooms.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                {
                    int roomId = Convert.ToInt32(row.Cells["RoomId"].Value);
                    selectedIds.Add(roomId);
                    selectedRow = row;
                }
            }

            if (selectedIds.Count == 0)
            {
                ShowCustomMessageBox("Selection Needed", "Please select one room to update.", 500, 200);
                return;
            }

            if (selectedIds.Count > 1)
            {
                ShowCustomMessageBox("Reminder", "Please select only one room to update at a time.", 500, 200);
                return;
            }

            int id = Convert.ToInt32(selectedRow.Cells["RoomId"].Value);
            string roomNumber = selectedRow.Cells["RoomNumber"].Value?.ToString() ?? "";
            string venueLocation = (dgvRooms.Columns.Contains("VenueLocation") ? selectedRow.Cells["VenueLocation"].Value?.ToString() : null) ?? "Big 8";
            string eventType = (dgvRooms.Columns.Contains("EventType") ? selectedRow.Cells["EventType"].Value?.ToString() : null) ?? "Wedding";
            string roomType = (dgvRooms.Columns.Contains("FunctionhallType") ? selectedRow.Cells["FunctionhallType"].Value?.ToString() : null)
                           ?? (dgvRooms.Columns.Contains("RoomType") ? selectedRow.Cells["RoomType"].Value?.ToString() : null)
                           ?? "";
            decimal rate = Convert.ToDecimal(selectedRow.Cells["Rate"].Value);
            bool availability = Convert.ToBoolean(selectedRow.Cells["Availability"].Value);
            bool maintenance = Convert.ToBoolean(selectedRow.Cells["Maintenance"].Value);
            byte[] imageData = RoomDAO.GetRoomImageById(id); // ← Fetch image byte[] from DB
            int capacity = Convert.ToInt32(selectedRow.Cells["Capacity"].Value);
            int beds = Convert.ToInt32(selectedRow.Cells["Beds"].Value);

            Room roomToUpdate = new Room
            {
                RoomId = id,
                RoomNumber = roomNumber,
                VenueLocation = venueLocation,
                EventType = eventType,
                FunctionhallType = roomType,
                Rate = rate,
                Availability = availability,
                Maintenance = maintenance,
                ImageData = imageData,
                Capacity = capacity,
                Beds = beds
            };

            using (var form = new AddRoomForm())
            {
                form.SetRoomData(roomNumber, roomType, rate, availability, maintenance, imageData, capacity, beds, venueLocation, eventType);
                if (imageData != null) form.SetImageData(imageData);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    roomToUpdate.RoomNumber = form.RoomNumber;
                    roomToUpdate.VenueLocation = form.VenueLocation;
                    roomToUpdate.EventType = form.EventType;
                    roomToUpdate.FunctionhallType = form.RoomType;
                    roomToUpdate.Rate = form.Rate;
                    roomToUpdate.Availability = form.Availability;
                    roomToUpdate.Maintenance = form.Maintenance;
                    roomToUpdate.ImageData = form.ImageData;
                    roomToUpdate.Capacity = form.Capacity;
                    roomToUpdate.Beds = form.Beds;

                    bool success = RoomDAO.UpdateRoom(roomToUpdate);
                    if (success)
                    {
                        ShowCustomMessageBox("Success", "Function hall updated successfully!", 500, 200);
                        LoadRooms();
                    }
                    else
                    {
                        ShowCustomMessageBox("Error", "Failed to update function hall.", 500, 200);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> selectedIds = new List<int>();

            foreach (DataGridViewRow row in dgvRooms.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                {
                    int roomId = Convert.ToInt32(row.Cells["RoomId"].Value);
                    selectedIds.Add(roomId);
                }
            }

            if (selectedIds.Count == 0)
            {
                ShowCustomMessageBox("Selection Needed", "Please select at least one function hall / room to delete.", 500, 200);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected function hall(s)?\nAssociated reservations and payments will also be cascade deleted.", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool allDeleted = true;
                foreach (int id in selectedIds)
                {
                    try
                    {
                        bool success = RoomDAO.DeleteRoom(id);
                        if (!success)
                        {
                            allDeleted = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting room: " + ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        allDeleted = false;
                    }
                }

                if (allDeleted)
                {
                    ShowCustomMessageBox("Success", "Selected function hall(s) deleted successfully!", 500, 200);
                }
                else
                {
                    ShowCustomMessageBox("Error", "Some function halls failed to delete.", 500, 200);
                }

                LoadRooms();
                ClearFields();
            }
        }

        private void dgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtRoomNumber.Text = dgvRooms.Rows[e.RowIndex].Cells["RoomNumber"].Value?.ToString() ?? "";

                string rType = (dgvRooms.Columns.Contains("FunctionhallType") ? dgvRooms.Rows[e.RowIndex].Cells["FunctionhallType"].Value?.ToString() : null)
                            ?? (dgvRooms.Columns.Contains("RoomType") ? dgvRooms.Rows[e.RowIndex].Cells["RoomType"].Value?.ToString() : null)
                            ?? "";
                txtRoomType.Text = rType;

                decimal rateValue = 0;
                if (dgvRooms.Columns.Contains("Rate") && dgvRooms.Rows[e.RowIndex].Cells["Rate"].Value != null)
                {
                    decimal.TryParse(dgvRooms.Rows[e.RowIndex].Cells["Rate"].Value.ToString(), out rateValue);
                }
                txtRate.Text = rateValue.ToString("N2");

                if (dgvRooms.Columns.Contains("Availability") && dgvRooms.Rows[e.RowIndex].Cells["Availability"].Value != null)
                {
                    chkAvailable.Checked = Convert.ToBoolean(dgvRooms.Rows[e.RowIndex].Cells["Availability"].Value);
                }
                if (dgvRooms.Columns.Contains("Capacity") && dgvRooms.Rows[e.RowIndex].Cells["Capacity"].Value != null)
                {
                    nudCapacity.Text = dgvRooms.Rows[e.RowIndex].Cells["Capacity"].Value.ToString();
                }
                if (dgvRooms.Columns.Contains("Beds") && dgvRooms.Rows[e.RowIndex].Cells["Beds"].Value != null)
                {
                    nudBeds.Text = dgvRooms.Rows[e.RowIndex].Cells["Beds"].Value.ToString();
                }
            }
        }

        private void ClearFields()
        {
            txtRoomNumber.Clear();
            txtRoomType.Clear();
            txtRate.Clear();
            chkAvailable.Checked = false;
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

        private void dgvRooms_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvRooms.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Load your icons
                Image editIcon = Image.FromFile("C:\\Users\\jc suan\\Downloads\\update.png");   // 16x16 icon
                Image deleteIcon = Image.FromFile("C:\\Users\\jc suan\\Downloads\\delete.png"); // 16x16 icon

                // Set icon positions
                int iconPadding = 4;
                int iconY = e.CellBounds.Top + (e.CellBounds.Height - editIcon.Height) / 2;
                int editIconX = e.CellBounds.Left + iconPadding;
                int deleteIconX = editIconX + editIcon.Width + iconPadding;

                // Draw icons
                e.Graphics.DrawImage(editIcon, new Rectangle(editIconX, iconY, editIcon.Width, editIcon.Height));
                e.Graphics.DrawImage(deleteIcon, new Rectangle(deleteIconX, iconY, deleteIcon.Width, deleteIcon.Height));

                e.Handled = true;
            }
        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            Point location = new Point(btnAdd.Width, 0); // Top-right of the button
            toolTip.Show("Add", btnAdd, location);
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(btnAdd);
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

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void chkAvailable_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void dgvRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
