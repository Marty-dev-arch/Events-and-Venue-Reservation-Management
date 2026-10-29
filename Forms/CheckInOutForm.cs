using Hotel_Reservation_System.Database;
using Hotel_Reservation_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_Reservation_System.Forms
{
    public partial class CheckInOutForm : Form
    {
        private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        public CheckInOutForm()
        {
            InitializeComponent();
            LoadReservations();

            this.dgvReservations.CellFormatting += dgvReservations_CellFormatting;
        }

        private void LoadReservations()
        {
            var reservations = ReservationDAO.GetAllReservations(); // You already have this DAO method

            dgvReservations.DataSource = reservations.Select(r => new
            {
                r.ReservationId,
                CustomerName = CustomerDAO.GetCustomerById(r.CustomerId)?.FullName,
                FunctionhallNumber = RoomDAO.GetRoomById(r.RoomId)?.RoomNumber,
                r.CheckInDate,
                r.CheckInTime,
                r.CheckOutDate,
                r.CheckOutTime,
                r.Status
            }).ToList();

            if (dgvReservations.Columns["ReservationId"] != null)
                dgvReservations.Columns["ReservationId"].Visible = false; // Hide ID column

            if (dgvReservations.Columns["CustomerName"] != null)
            {
                dgvReservations.Columns["CustomerName"].HeaderText = "Customer Name";
                dgvReservations.Columns["CustomerName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservations.Columns["CustomerName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservations.Columns["CustomerName"].HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                dgvReservations.Columns["CustomerName"].DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
            }

            if (dgvReservations.Columns["FunctionhallNumber"] != null)
            {
                dgvReservations.Columns["FunctionhallNumber"].HeaderText = "Function Hall No";
                dgvReservations.Columns["FunctionhallNumber"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["FunctionhallNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvReservations.Columns["CheckInDate"] != null)
            {
                dgvReservations.Columns["CheckInDate"].HeaderText = "Check-In Date";
                dgvReservations.Columns["CheckInDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvReservations.Columns["CheckInDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["CheckInDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvReservations.Columns["CheckInTime"] != null)
            {
                dgvReservations.Columns["CheckInTime"].HeaderText = "Check-In Time";
                dgvReservations.Columns["CheckInTime"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["CheckInTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvReservations.Columns["CheckOutDate"] != null)
            {
                dgvReservations.Columns["CheckOutDate"].HeaderText = "Check-Out Date";
                dgvReservations.Columns["CheckOutDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvReservations.Columns["CheckOutDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["CheckOutDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvReservations.Columns["CheckOutTime"] != null)
            {
                dgvReservations.Columns["CheckOutTime"].HeaderText = "Check-Out Time";
                dgvReservations.Columns["CheckOutTime"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["CheckOutTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvReservations.Columns["Status"] != null)
            {
                dgvReservations.Columns["Status"].HeaderText = "Status";
                dgvReservations.Columns["Status"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
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

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow == null)
            {
                MessageBox.Show("Please select a reservation.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int reservationId = Convert.ToInt32(dgvReservations.CurrentRow.Cells["ReservationId"].Value);
            var reservation = ReservationDAO.GetReservationById(reservationId);

            if (reservation.Status != "Confirmed")
            {
                MessageBox.Show("Only confirmed reservations can be checked in.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            reservation.Status = "Checked In";
            bool success = ReservationDAO.UpdateReservation(reservation);

            if (success)
            {
                ShowCustomMessageBox("Success", "Guest checked in successfully.", 500, 200);
                LoadReservations();
            }
            else
            {
                ShowCustomMessageBox("Error", "Failed to check in guest.", 500, 200);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow == null)
            {
                MessageBox.Show("Please select a reservation.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int reservationId = Convert.ToInt32(dgvReservations.CurrentRow.Cells["ReservationId"].Value);
            var reservation = ReservationDAO.GetReservationById(reservationId);

            if (reservation.Status != "Checked In")
            {
                MessageBox.Show("Only checked-in guests can be checked out.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            reservation.Status = "Checked Out";
            bool success = ReservationDAO.UpdateReservation(reservation);

            if (success)
            {
                ShowCustomMessageBox("Success", "Guest checked out successfully.", 500, 200);
                LoadReservations();
            }
            else
            {
                ShowCustomMessageBox("Error", "Failed to check out guest.", 500, 200);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReservations();
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

            Button okButton = new Button();
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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCheckIn_MouseHover(object sender, EventArgs e)
        {
            Point location = new Point(btnCheckIn.Width, 0);
            toolTip.Show("Check-In", btnCheckIn, location);
        }

        private void btnCheckIn_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(btnCheckOut);
        }

        private void btnCheckOut_MouseHover(object sender, EventArgs e)
        {
            Point location = new Point(btnCheckOut.Width, 0);
            toolTip.Show("Check-Out", btnCheckOut, location);
        }

        private void btnCheckOut_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(btnCheckOut);
        }

        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            Point location = new Point(btnRefresh.Width, 0);
            toolTip.Show("Refresh", btnRefresh, location);
        }

        private void btnRefresh_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(btnRefresh);
        }

        private void dgvReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
