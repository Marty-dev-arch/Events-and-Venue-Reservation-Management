using Hotel_Reservation_System.Database;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Hotel_Reservation_System.Forms.UserForms
{
    public partial class MyReservationsForm : Form
    {
        private int customerId;
        private bool isCoordinator = false;

        public MyReservationsForm(int customerId, bool isCoordinator = false)
        {
            InitializeComponent();
            this.customerId = customerId;
            this.isCoordinator = isCoordinator;
            dgvReservations.AllowUserToAddRows = false;
        }

        private void MyReservationsForm_Load(object sender, EventArgs e)
        {
            if (isCoordinator)
            {
                label1.Text = "Venue and Events Reservations Bookings";
                label2.Text = "Manage and monitor reservations across all event types and function halls.";
            }
            LoadReservations();
        }

        private void LoadReservations()
        {
            dgvReservations.Rows.Clear();
            dgvReservations.Columns.Clear();

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = (isCoordinator || customerId <= 0)
                    ? @"SELECT 
                            res.reservation_id, 
                            c.full_name AS customer_name,
                            r.room_number,
                            ISNULL(res.event_type, ISNULL(r.event_type, 'Wedding')) AS event_type,
                            r.room_type, 
                            res.check_in_date,
                            res.check_in_time,
                            res.check_out_date,
                            res.check_out_time,
                            res.status,
                            res.date_reserved
                         FROM reservations res
                         JOIN customers c ON res.customer_id = c.customer_id
                         JOIN rooms r ON res.room_id = r.room_id
                         ORDER BY res.reservation_id DESC"
                    : @"SELECT 
                            res.reservation_id, 
                            c.full_name AS customer_name,
                            r.room_number,
                            ISNULL(res.event_type, ISNULL(r.event_type, 'Wedding')) AS event_type,
                            r.room_type, 
                            res.check_in_date,
                            res.check_in_time,
                            res.check_out_date,
                            res.check_out_time,
                            res.status,
                            res.date_reserved
                         FROM reservations res
                         JOIN customers c ON res.customer_id = c.customer_id
                         JOIN rooms r ON res.room_id = r.room_id
                         WHERE res.customer_id = @customerId
                         ORDER BY res.reservation_id DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!isCoordinator && customerId > 0)
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                }

                SqlDataReader reader = cmd.ExecuteReader();

                dgvReservations.Columns.Add("reservationId", "Reservation ID");
                dgvReservations.Columns["reservationId"].Visible = false;

                dgvReservations.Columns.Add("customerName", "Customer Name");
                dgvReservations.Columns["customerName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservations.Columns["customerName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservations.Columns["customerName"].HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                dgvReservations.Columns["customerName"].DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);

                dgvReservations.Columns.Add("roomNumber", "Function Hall No");
                dgvReservations.Columns["roomNumber"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["roomNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvReservations.Columns.Add("eventType", "Event Type");
                dgvReservations.Columns["eventType"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservations.Columns["eventType"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservations.Columns["eventType"].HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                dgvReservations.Columns["eventType"].DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);

                dgvReservations.Columns.Add("roomType", "Function Hall Type");
                dgvReservations.Columns["roomType"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservations.Columns["roomType"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvReservations.Columns["roomType"].HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                dgvReservations.Columns["roomType"].DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);

                dgvReservations.Columns.Add("checkIn", "Check-in Date");
                dgvReservations.Columns["checkIn"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["checkIn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvReservations.Columns.Add("checkInTime", "Check-in Time");
                dgvReservations.Columns["checkInTime"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["checkInTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvReservations.Columns.Add("checkOut", "Check-out Date");
                dgvReservations.Columns["checkOut"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["checkOut"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvReservations.Columns.Add("checkOutTime", "Check-out Time");
                dgvReservations.Columns["checkOutTime"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["checkOutTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvReservations.Columns.Add("status", "Status");
                dgvReservations.Columns["status"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvReservations.Columns.Add("date_reserved", "Date Reserved");
                dgvReservations.Columns["date_reserved"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns["date_reserved"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewButtonColumn cancelButton = new DataGridViewButtonColumn();
                cancelButton.Name = "cancel";
                cancelButton.HeaderText = "Action";
                cancelButton.Text = "Cancel";
                cancelButton.UseColumnTextForButtonValue = true;
                cancelButton.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                cancelButton.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvReservations.Columns.Add(cancelButton);

                while (reader.Read())
                {
                    string checkInTimeStr = reader["check_in_time"].ToString();
                    string checkOutTimeStr = reader["check_out_time"].ToString();

                    string formattedCheckInTime = string.IsNullOrEmpty(checkInTimeStr)
                        ? "N/A"
                        : TimeSpan.TryParse(checkInTimeStr, out TimeSpan checkInTime)
                            ? DateTime.Today.Add(checkInTime).ToString("hh:mm tt")
                            : "Invalid";

                    string formattedCheckOutTime = string.IsNullOrEmpty(checkOutTimeStr)
                        ? "N/A"
                        : TimeSpan.TryParse(checkOutTimeStr, out TimeSpan checkOutTime)
                            ? DateTime.Today.Add(checkOutTime).ToString("hh:mm tt")
                            : "Invalid";
                    string dateReservedStr = Convert.ToDateTime(reader["date_reserved"]).ToString("dd/MM/yyyy hh:mm tt");

                    int rowIndex = dgvReservations.Rows.Add(
                        reader["reservation_id"],
                        reader["customer_name"],
                        reader["room_number"],
                        reader["event_type"],
                        reader["room_type"],
                        Convert.ToDateTime(reader["check_in_date"]).ToShortDateString(),
                        formattedCheckInTime,
                        Convert.ToDateTime(reader["check_out_date"]).ToShortDateString(),
                        formattedCheckOutTime,
                        reader["status"],
                        dateReservedStr
                    );

                    // Disable cancel button if cancelled or completed
                    string status = reader["status"].ToString();

                    if (status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase) || 
                        status.Equals("Checked-In", StringComparison.OrdinalIgnoreCase))
                    {
                        DataGridViewDisableButtonCell buttonCell = new DataGridViewDisableButtonCell();
                        buttonCell.Value = "Cancel";
                        buttonCell.Enabled = false;
                        dgvReservations.Rows[rowIndex].Cells["cancel"] = buttonCell;
                    }
                }
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvReservations.Columns["cancel"].Index && e.RowIndex >= 0)
            {
                string status = dgvReservations.Rows[e.RowIndex].Cells["status"].Value?.ToString() ?? "";
                
                if (status.Equals("Pending", StringComparison.OrdinalIgnoreCase) || 
                    status.Equals("Confirmed", StringComparison.OrdinalIgnoreCase))
                {
                    int reservationId = Convert.ToInt32(dgvReservations.Rows[e.RowIndex].Cells["reservationId"].Value);

                    DialogResult confirm = MessageBox.Show(
                        $"Are you sure you want to cancel reservation #{reservationId}?\n\nThis will notify admin and restore venue availability.",
                        "Confirm Cancellation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        ReservationDAO.CancelReservation(reservationId);
                        MessageBox.Show($"Reservation #{reservationId} has been cancelled.", "Cancellation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadReservations(); // Refresh
                    }
                }
                else
                {
                    MessageBox.Show("This reservation cannot be cancelled because it is already " + status + ".", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

        public class DataGridViewDisableButtonCell : DataGridViewButtonCell
        {
            public bool Enabled { get; set; } = true;

            protected override void Paint(Graphics graphics,
            Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value,
            object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
            {
                if (!this.Enabled)
                {
                    ButtonRenderer.DrawButton(graphics, cellBounds,
                        value?.ToString() ?? "",
                        this.DataGridView.Font,
                        false, PushButtonState.Disabled);
                }
                else
                {
                    using (Brush brush = new SolidBrush(Color.LightCoral)) // Your desired color
                    {
                        graphics.FillRectangle(brush, cellBounds);
                    }

                    TextRenderer.DrawText(
                        graphics,
                        value?.ToString(),
                        this.DataGridView.Font,
                        cellBounds,
                        Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );

                    base.PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
                }
        }

        public override object Clone()
        {
            var cell = (DataGridViewDisableButtonCell)base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }
    }
}

