using Hotel_Reservation_System.Database;
using Hotel_Reservation_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel_Reservation_System.Forms
{
    public partial class HistoryForm : Form
    {
        private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        public HistoryForm()
        {
            InitializeComponent();
            LoadBookingHistory();

            this.dgvHistory.CellFormatting += dgvHistory_CellFormatting;
        }

        private void LoadBookingHistory()
        {
            var history = ReservationDAO.GetAllReservations();
            dgvHistory.DataSource = history;

            if (dgvHistory.Columns["RoomId"] != null) dgvHistory.Columns["RoomId"].Visible = false;
            if (dgvHistory.Columns["CustomerId"] != null) dgvHistory.Columns["CustomerId"].Visible = false;

            if (dgvHistory.Columns["CustomerName"] != null)
            {
                dgvHistory.Columns["CustomerName"].HeaderText = "Customer Name";
                dgvHistory.Columns["CustomerName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvHistory.Columns["CustomerName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvHistory.Columns["CustomerName"].HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                dgvHistory.Columns["CustomerName"].DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
            }

            if (dgvHistory.Columns["RoomNumber"] != null)
            {
                dgvHistory.Columns["RoomNumber"].HeaderText = "Function Hall No";
                dgvHistory.Columns["RoomNumber"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvHistory.Columns["RoomNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvHistory.Columns["EventType"] != null)
            {
                dgvHistory.Columns["EventType"].HeaderText = "Event Type";
                dgvHistory.Columns["EventType"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvHistory.Columns["EventType"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvHistory.Columns["EventType"].HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                dgvHistory.Columns["EventType"].DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
            }

            var typeCol = dgvHistory.Columns["FunctionhallType"] ?? dgvHistory.Columns["RoomType"];
            if (typeCol != null)
            {
                typeCol.HeaderText = "Function Hall Type";
                typeCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                typeCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                typeCol.HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                typeCol.DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
            }

            if (dgvHistory.Columns["CheckInDate"] != null)
            {
                dgvHistory.Columns["CheckInDate"].HeaderText = "Check-In Date";
                dgvHistory.Columns["CheckInDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvHistory.Columns["CheckInDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvHistory.Columns["CheckInDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvHistory.Columns["CheckInTime"] != null)
            {
                dgvHistory.Columns["CheckInTime"].HeaderText = "Check-In Time";
                dgvHistory.Columns["CheckInTime"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvHistory.Columns["CheckInTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvHistory.Columns["CheckOutDate"] != null)
            {
                dgvHistory.Columns["CheckOutDate"].HeaderText = "Check-Out Date";
                dgvHistory.Columns["CheckOutDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvHistory.Columns["CheckOutDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvHistory.Columns["CheckOutDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvHistory.Columns["CheckOutTime"] != null)
            {
                dgvHistory.Columns["CheckOutTime"].HeaderText = "Check-Out Time";
                dgvHistory.Columns["CheckOutTime"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvHistory.Columns["CheckOutTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvHistory.Columns["DateReserved"] != null)
            {
                dgvHistory.Columns["DateReserved"].HeaderText = "Date Reserved";
                dgvHistory.Columns["DateReserved"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvHistory.Columns["DateReserved"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvHistory.Columns["DateReserved"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvHistory.Columns["Status"] != null)
            {
                dgvHistory.Columns["Status"].HeaderText = "Status";
                dgvHistory.Columns["Status"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvHistory.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dgvHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHistory.Columns[e.ColumnIndex].Name == "CheckInTime" ||
                dgvHistory.Columns[e.ColumnIndex].Name == "CheckOutTime")
            {
                if (e.Value != null && TimeSpan.TryParse(e.Value.ToString(), out TimeSpan time))
                {
                    DateTime timeWithDate = DateTime.Today.Add(time);
                    e.Value = timeWithDate.ToString("hh:mm tt"); // e.g., 03:45:00 PM
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBookingHistory();
        }

        private void dgvHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: You can add row click actions here (like view details)
        }

        private void dgvHistory_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            Point location = new Point(btnRefresh.Width, 0); // Top-right of the button
            toolTip.Show("Refresh", btnRefresh, location);
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(btnRefresh);
        }
    }
}
