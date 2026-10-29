using Hotel_Reservation_System.Database;
using Hotel_Reservation_System.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Reservation_System.Forms
{
    public partial class AddReservationForm : Form
    {
        private int? editingReservationId = null;
        public Reservation NewReservation { get; private set; }

        public AddReservationForm()
        {
            InitializeComponent();
            LoadCustomers();
            LoadRooms();
            LoadStatuses();

            // Ensure AM/PM is shown in time pickers
            dtpCheckInTime.Format = DateTimePickerFormat.Custom;
            dtpCheckInTime.CustomFormat = "hh:mm tt"; // 12-hour format with AM/PM

            dtpCheckOutTime.Format = DateTimePickerFormat.Custom;
            dtpCheckOutTime.CustomFormat = "hh:mm tt"; // 12-hour format with AM/PM

            // Set default dates and times
            dtpCheckIn.Value = DateTime.Now.Date;
            dtpCheckInTime.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.Date.AddDays(1);
            dtpCheckOutTime.Value = DateTime.Now.AddHours(1);
        }

        private void LoadCustomers()
        {
            var customers = CustomerDAO.GetAllCustomers();
            cmbCustomer.DataSource = customers;
            cmbCustomer.DisplayMember = "FullName";
            cmbCustomer.ValueMember = "CustomerId";
            cmbCustomer.SelectedIndex = -1;
        }

        private void LoadRooms()
        {
            var rooms = RoomDAO.GetAllRooms();
            cmbRoom.DataSource = rooms;
            cmbRoom.DisplayMember = "RoomNumber";
            cmbRoom.ValueMember = "RoomId";
            cmbRoom.SelectedIndex = -1;
        }

        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Confirmed");
            cmbStatus.Items.Add("Cancelled");
            cmbStatus.SelectedIndex = 0;
        }

        private void AddReservationForm_Load(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            // Combine for validation
            DateTime checkIn = dtpCheckIn.Value.Date + dtpCheckInTime.Value.TimeOfDay;
            DateTime checkOut = dtpCheckOut.Value.Date + dtpCheckOutTime.Value.TimeOfDay;

            if (checkOut <= checkIn)
            {
                ShowCustomMessageBox("Invalid Dates", "Check-out time must be after check-in time.", 400, 200);
                return;
            }

            if (cmbCustomer.SelectedIndex < 0 || cmbRoom.SelectedIndex < 0)
            {
                ShowCustomMessageBox("Missing Information", "Please select both customer and room.", 400, 200);
                return;
            }

            // Create Reservation object with time separated
            NewReservation = new Reservation
            {
                ReservationId = editingReservationId ?? 0,
                CustomerId = Convert.ToInt32(cmbCustomer.SelectedValue),
                RoomId = Convert.ToInt32(cmbRoom.SelectedValue),
                EventType = string.IsNullOrWhiteSpace(cmbEventType.Text) ? "Wedding" : cmbEventType.Text,
                CheckInDate = dtpCheckIn.Value.Date,
                CheckInTime = dtpCheckInTime.Value.TimeOfDay,
                CheckOutDate = dtpCheckOut.Value.Date,
                CheckOutTime = dtpCheckOutTime.Value.TimeOfDay,
                Status = cmbStatus.Text,
                DateReserved = DateTime.Now
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbCustomer.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            cmbEventType.SelectedIndex = 3;
            dtpCheckIn.Value = DateTime.Now.Date;
            dtpCheckInTime.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.Date.AddDays(1);
            dtpCheckOutTime.Value = DateTime.Now.AddHours(1);
            cmbStatus.SelectedIndex = 0;
            editingReservationId = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Used to load existing reservation data into the form for editing.
        /// </summary>
        public void SetReservationData(
        int reservationId,
        int customerId,
        int roomId,
        DateTime checkInDate,
        TimeSpan checkInTime,
        DateTime checkOutDate,
        TimeSpan checkOutTime,
        string status,
        string eventType = "Wedding")
        {
            LoadCustomers();
            LoadRooms();
            LoadStatuses();

            editingReservationId = reservationId;

            cmbCustomer.SelectedValue = customerId;
            cmbRoom.SelectedValue = roomId;

            if (!string.IsNullOrWhiteSpace(eventType))
            {
                cmbEventType.Text = eventType;
            }

            dtpCheckIn.Value = checkInDate;
            dtpCheckInTime.Value = checkInDate.Date + checkInTime;

            dtpCheckOut.Value = checkOutDate;
            dtpCheckOutTime.Value = checkOutDate.Date + checkOutTime;

            cmbStatus.Text = status ?? "Pending";
        }

        public void ShowCustomMessageBox(string title, string message, int width, int height)
        {
            Form customBox = new Form()
            {
                Text = title,
                Size = new Size(width, height),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblMessage = new Label()
            {
                Text = message,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Font = new Font("Segoe UI", 10),
                Size = new Size(width - 40, height - 120),
                Location = new Point(20, 20)
            };

            Button okButton = new Button()
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
        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoom.SelectedItem is HotelReservationSystem.Models.Room selectedRoom && !string.IsNullOrWhiteSpace(selectedRoom.EventType))
            {
                cmbEventType.Text = selectedRoom.EventType;
            }
        }
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpCheckIn_ValueChanged(object sender, EventArgs e) { }
        private void dtpCheckOut_ValueChanged(object sender, EventArgs e) { }
        private void dtpCheckInTime_ValueChanged(object sender, EventArgs e) { }
        private void dtpCheckOutTime_ValueChanged(object sender, EventArgs e) { }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
