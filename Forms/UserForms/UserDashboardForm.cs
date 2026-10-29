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
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;


namespace Hotel_Reservation_System.Forms.UserForms
{
    public partial class UserDashboardForm : Form
    {
        private int customerId;
        private string fullName;
        private Dictionary<string, Label> statusLabels;
        private readonly Dictionary<string, Color> statusColors = new()
        {
            { "Confirmed", Color.White },
            { "Checked In", Color.White },
            { "Checked Out", Color.White },
            { "Cancelled", Color.Red },
            { "Pending", Color.White }
        };

        private void InitializeStatusLabelMap()
        {
            statusLabels = new Dictionary<string, Label>
        {
            { "Confirmed", lblConfirmed },
            { "Checked In", lblCheckedIn },
            { "Checked Out", lblCheckedOut },
            { "Cancelled", lblCancelled },
            { "Pending", lblPending }
        };
        }




        private bool isCoordinator = false;

        public UserDashboardForm(int id, string name, bool isCoordinator = false)
        {
            InitializeComponent();
            this.customerId = id;
            this.fullName = name;
            this.isCoordinator = isCoordinator;
        }

        private void UserDashboardForm_Load(object sender, EventArgs e)
        {
            LoadReservationStats();
            InitializeStatusLabelMap();
            LoadReservationStatusSummary(false);

            btnViewStatusSummary.MouseEnter += BtnViewStatusSummary_MouseEnter;
            btnViewStatusSummary.MouseLeave += BtnViewStatusSummary_MouseLeave;
            panelStatusSummary.MouseEnter += PanelStatusSummary_MouseEnter;
            panelStatusSummary.MouseLeave += PanelStatusSummary_MouseLeave;
        }

        private void LoadReservationStats()
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                // Total reservations
                string query1 = isCoordinator
                    ? "SELECT COUNT(*) FROM reservations"
                    : "SELECT COUNT(*) FROM reservations WHERE customer_id = @customerId";
                SqlCommand cmd1 = new SqlCommand(query1, conn);
                if (!isCoordinator) cmd1.Parameters.AddWithValue("@customerId", customerId);
                int totalReservations = Convert.ToInt32(cmd1.ExecuteScalar());
                lblTotalReservations.Text = totalReservations.ToString();

                string query2 = isCoordinator
                    ? @"SELECT COUNT(*) 
                    FROM reservations 
                    WHERE check_in_date > CAST(GETDATE() AS DATE) 
                      AND status != 'Cancelled'"
                    : @"SELECT COUNT(*) 
                    FROM reservations 
                    WHERE customer_id = @customerId 
                      AND check_in_date > CAST(GETDATE() AS DATE) 
                      AND status != 'Cancelled'";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                if (!isCoordinator) cmd2.Parameters.AddWithValue("@customerId", customerId);
                int upcomingReservations = Convert.ToInt32(cmd2.ExecuteScalar());
                lblUpcoming.Text = upcomingReservations.ToString();
            }
        }


        private void LoadUpcomingReservationsDetails()
        {
            List<string> upcomingDetails = new List<string>();

            string query = isCoordinator
                ? @"SELECT TOP 3 check_in_date, check_in_time, check_out_date, check_out_time 
                   FROM reservations 
                   WHERE (check_in_date > CAST(GETDATE() AS DATE) OR (check_in_date = CAST(GETDATE() AS DATE) AND check_in_time >= CAST(GETDATE() AS TIME)))
                   AND status != 'Cancelled'
                   ORDER BY check_in_date ASC, check_in_time ASC"
                : @"SELECT TOP 3 check_in_date, check_in_time, check_out_date, check_out_time 
                   FROM reservations 
                   WHERE customer_id = @CustomerId 
                   AND (check_in_date > CAST(GETDATE() AS DATE) OR (check_in_date = CAST(GETDATE() AS DATE) AND check_in_time >= CAST(GETDATE() AS TIME)))
                   AND status != 'Cancelled'
                   ORDER BY check_in_date ASC, check_in_time ASC";

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!isCoordinator) cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime checkInDate = Convert.ToDateTime(reader["check_in_date"]).Date;
                            TimeSpan checkInTime = reader["check_in_time"] is TimeSpan tIn ? tIn : (TimeSpan.TryParse(reader["check_in_time"]?.ToString(), out var pIn) ? pIn : TimeSpan.Zero);
                            DateTime checkIn = checkInDate + checkInTime;

                            DateTime checkOutDate = Convert.ToDateTime(reader["check_out_date"]).Date;
                            TimeSpan checkOutTime = reader["check_out_time"] is TimeSpan tOut ? tOut : (TimeSpan.TryParse(reader["check_out_time"]?.ToString(), out var pOut) ? pOut : TimeSpan.Zero);
                            DateTime checkOut = checkOutDate + checkOutTime;

                            upcomingDetails.Add($"Check-In: {checkIn:MMM dd, yyyy hh:mm tt} - Check-Out: {checkOut:MMM dd, yyyy hh:mm tt}");
                        }
                    }
                }
            }

            lblUpcomingDetails.Text = upcomingDetails.Count > 0
                ? string.Join(Environment.NewLine, upcomingDetails)
                : "No upcoming reservations.";
        }


        private void btnViewUpcomingReservations_MouseEnter(object sender, EventArgs e)
        {
            LoadUpcomingReservationsDetails();
            panelUpcomingReservations.Visible = true;
        }

        private void btnViewUpcomingReservations_MouseLeave(object sender, EventArgs e)
        {
            Task.Delay(200).ContinueWith(t =>
            {
                Invoke(new Action(() =>
                {
                    if (!panelUpcomingReservations.Bounds.Contains(PointToClient(System.Windows.Forms.Cursor.Position)))
                    {
                        panelUpcomingReservations.Visible = false;
                    }
                }));
            });
        }

        private void panelUpcomingReservations_MouseEnter(object sender, EventArgs e)
        {
            panelUpcomingReservations.Visible = true;
        }

        private void panelUpcomingReservations_MouseLeave(object sender, EventArgs e)
        {
            Task.Delay(200).ContinueWith(t =>
            {
                Invoke(new Action(() =>
                {
                    if (!btnViewUpcomingReservations.Bounds.Contains(PointToClient(System.Windows.Forms.Cursor.Position)))
                    {
                        panelUpcomingReservations.Visible = false;
                    }
                }));
            });
        }

        private void LoadReservationStatusSummary(bool showAllStatuses = true)
        {
            var statusCounts = new Dictionary<string, int>();
            int total = 0;

            string query = isCoordinator
                ? "SELECT status, COUNT(*) as count FROM reservations GROUP BY status"
                : "SELECT status, COUNT(*) as count FROM reservations WHERE customer_id = @CustomerId GROUP BY status";

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!isCoordinator) cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string status = reader["status"]?.ToString() ?? "";
                            int count = Convert.ToInt32(reader["count"]);
                            statusCounts[status] = count;
                            total += count;
                        }
                    }
                }
            }

            // Update total label always
            lblTotalStatuses.Text = $"{total}";
            lblTotalStatuses.ForeColor = Color.White;

            // Update individual status labels only if requested
            if (showAllStatuses)
            {
                foreach (var status in statusLabels.Keys)
                {
                    int count = statusCounts.ContainsKey(status) ? statusCounts[status] : 0;
                    statusLabels[status].Text = $"{status}: {count}";
                    statusLabels[status].ForeColor = statusColors[status];
                }
            }
        }


        private void BtnViewStatusSummary_MouseEnter(object sender, EventArgs e)
        {
            LoadReservationStatusSummary();
            if (panelStatusSummary.InvokeRequired)
            {
                panelStatusSummary.Invoke(new MethodInvoker(() =>
                {
                    panelStatusSummary.Visible = true;
                }));
            }
            else
            {
                panelStatusSummary.Visible = true;
            }
        }

        private void BtnViewStatusSummary_MouseLeave(object sender, EventArgs e)
        {
            // Delay and check if the mouse is not over the panel
            Task.Delay(200).ContinueWith(t =>
            {
                Invoke(new Action(() =>
                {
                    if (!panelStatusSummary.Bounds.Contains(PointToClient(System.Windows.Forms.Cursor.Position)))
                    {
                        panelStatusSummary.Visible = false;
                    }
                }));
            });
        }

        private void PanelStatusSummary_MouseEnter(object sender, EventArgs e)
        {
            // Ensure this runs on the UI thread
            if (panelStatusSummary.InvokeRequired)
            {
                panelStatusSummary.Invoke(new MethodInvoker(() =>
                {
                    panelStatusSummary.Visible = true;
                }));
            }
            else
            {
                panelStatusSummary.Visible = true;
            }
        }

        private void PanelStatusSummary_MouseLeave(object sender, EventArgs e)
        {
            Task.Delay(200).ContinueWith(t =>
            {
                Invoke(new Action(() =>
                {
                    if (!btnViewStatusSummary.Bounds.Contains(PointToClient(System.Windows.Forms.Cursor.Position)))
                    {
                        panelStatusSummary.Visible = false;
                    }
                }));
            });
        }





        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void chartStatusSummary_Click(object sender, EventArgs e)
        {

        }

        private void panelStatusSummary_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
