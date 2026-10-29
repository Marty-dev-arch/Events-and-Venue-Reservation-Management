using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Hotel_Reservation_System.Database;
using Hotel_Reservation_System.Models;
using Microsoft.Data.SqlClient;


namespace Hotel_Reservation_System.Forms
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
            panel1.Resize += panel1_Resize;
            pictureBox1.Anchor = pictureBox2.Anchor = pictureBox3.Anchor = pictureBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LayoutDashboard();
            LoadHomeStats();
            LoadRoomChart();
        }

        private void panel1_Resize(object? sender, EventArgs e)
        {
            LayoutDashboard();
        }

        private void LayoutDashboard()
        {
            if (panel1.ClientSize.Width <= 0)
                return;

            const int margin = 19;
            const int gap = 12;
            const int cardTop = 109;
            const int secondRowTop = 247;
            const int chartTop = 386;

            int contentWidth = Math.Max(1, panel1.ClientSize.Width - margin * 2);
            int cardWidth = Math.Max(200, (contentWidth - gap * 2) / 3);

            guna2CustomGradientPanel1.Location = new Point(margin, cardTop);
            guna2CustomGradientPanel1.Size = new Size(cardWidth, 120);
            guna2CustomGradientPanel2.Location = new Point(margin + cardWidth + gap, cardTop);
            guna2CustomGradientPanel2.Size = new Size(cardWidth, 120);
            guna2CustomGradientPanel3.Location = new Point(margin + (cardWidth + gap) * 2, cardTop);
            guna2CustomGradientPanel3.Size = new Size(cardWidth, 120);

            guna2CustomGradientPanel4.Location = new Point(margin, secondRowTop);
            guna2CustomGradientPanel4.Size = new Size(cardWidth, 120);
            tableLayoutPanel2.Location = new Point(margin + cardWidth + gap, secondRowTop);
            tableLayoutPanel2.Size = new Size(Math.Max(1, contentWidth - cardWidth - gap), 122);

            tableLayoutPanel4.Location = new Point(margin, chartTop);
            tableLayoutPanel4.Size = new Size(contentWidth, Math.Max(300, panel1.ClientSize.Height - chartTop - margin));
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            LoadDashboardStats();
            LoadRoomChart();
            LoadLatestReservations();
        }

        private void LoadLatestReservations()
        {
            string query = @"SELECT TOP 5 
                        customers.full_name AS [Guest Name], 
                        ISNULL(reservations.event_type, ISNULL(rooms.event_type, 'Wedding')) AS [Event Type], 
                        rooms.room_type AS [FunctionhallType], 
                        reservations.check_in_date AS [Check In Date], 
                        reservations.status AS [Status]
                    FROM reservations
                    JOIN customers ON reservations.customer_id = customers.customer_id
                    JOIN rooms ON reservations.room_id = rooms.room_id
                    ORDER BY reservations.reservation_id DESC";

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvLatestReservations.DataSource = dt;

                if (dgvLatestReservations.Columns["Guest Name"] != null)
                {
                    dgvLatestReservations.Columns["Guest Name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvLatestReservations.Columns["Guest Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvLatestReservations.Columns["Guest Name"].HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                    dgvLatestReservations.Columns["Guest Name"].DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
                }

                if (dgvLatestReservations.Columns["Event Type"] != null)
                {
                    dgvLatestReservations.Columns["Event Type"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvLatestReservations.Columns["Event Type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvLatestReservations.Columns["Event Type"].HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                    dgvLatestReservations.Columns["Event Type"].DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
                }

                if (dgvLatestReservations.Columns["FunctionhallType"] != null)
                {
                    dgvLatestReservations.Columns["FunctionhallType"].HeaderText = "Function Hall Type";
                    dgvLatestReservations.Columns["FunctionhallType"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvLatestReservations.Columns["FunctionhallType"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgvLatestReservations.Columns["FunctionhallType"].HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                    dgvLatestReservations.Columns["FunctionhallType"].DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
                }

                if (dgvLatestReservations.Columns["Check In Date"] != null)
                {
                    dgvLatestReservations.Columns["Check In Date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    dgvLatestReservations.Columns["Check In Date"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvLatestReservations.Columns["Check In Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvLatestReservations.Columns["Status"] != null)
                {
                    dgvLatestReservations.Columns["Status"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvLatestReservations.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void LoadHomeStats()
        {
            HomeDAO dao = new HomeDAO();
            Home stats = dao.GetHomeStats();

            lblTitleTotalRooms.Text = "Active Function Halls";
            lblTotalRooms.Text = stats.TotalRooms.ToString();
            lblTotalCustomers.Text = stats.TotalCustomers.ToString();
            lblCurrentReservations.Text = stats.CurrentReservations.ToString();
            lblCheckInGuests.Text = stats.CheckInGuests.ToString();
        }

        private void LoadRoomChart()
        {
            HomeDAO dao = new HomeDAO();
            var (available, booked, maintenance) = dao.GetRoomStatusCounts();

            roomChart.Series.Clear();
            roomChart.Titles.Clear();

            // Elegant Top Title
            Title chartTitle = new Title("Function Hall Status", Docking.Top, new Font("Segoe UI", 12F, FontStyle.Bold), Color.FromArgb(40, 40, 60));
            chartTitle.Alignment = ContentAlignment.MiddleLeft;
            roomChart.Titles.Add(chartTitle);

            Series series = new Series("Status");
            series.ChartType = SeriesChartType.Pie;

            int total = available + booked + maintenance;

            // Configure Legend with custom items showing all statuses & counts
            if (roomChart.Legends.Count > 0)
            {
                var legend = roomChart.Legends[0];
                legend.Enabled = true;
                legend.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                legend.Title = "Status Breakdown";
                legend.TitleFont = new Font("Segoe UI", 10F, FontStyle.Bold);
                legend.TitleForeColor = Color.FromArgb(50, 50, 60);
                legend.BackColor = Color.Transparent;
                legend.CustomItems.Clear();

                legend.CustomItems.Add(new LegendItem
                {
                    Name = $"Available ({available})",
                    Color = Color.FromArgb(46, 125, 50)
                });

                legend.CustomItems.Add(new LegendItem
                {
                    Name = $"Booked ({booked})",
                    Color = Color.FromArgb(230, 126, 34)
                });

                legend.CustomItems.Add(new LegendItem
                {
                    Name = $"Under Maintenance ({maintenance})",
                    Color = Color.FromArgb(192, 57, 43)
                });
            }

            if (total == 0)
            {
                // When there are no rooms registered in the database:
                // Disable outside callout lines to completely eliminate overlapping 0-degree text and lines
                series["PieLabelStyle"] = "Disabled";

                var pEmpty = series.Points.Add(1);
                pEmpty.Color = Color.FromArgb(238, 242, 246);
                pEmpty.BorderColor = Color.FromArgb(203, 213, 225);
                pEmpty.BorderWidth = 1;
                pEmpty.Label = "";
                pEmpty.IsVisibleInLegend = false;

                Title noDataSubtitle = new Title("No Function Halls Found (Add halls in Venue Management)", Docking.Bottom, new Font("Segoe UI", 9.5F, FontStyle.Italic), Color.FromArgb(120, 130, 140));
                roomChart.Titles.Add(noDataSubtitle);
            }
            else
            {
                // Pie chart styling with leader lines and outside callout
                series["PieLabelStyle"] = "Outside";
                series["PieLineColor"] = "Gray";
                series["CollectedThreshold"] = "0";
                series.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                series.LabelForeColor = Color.FromArgb(40, 40, 50);

                // Anti-collision SmartLabel configuration:
                series.SmartLabelStyle.Enabled = true;
                series.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
                series.SmartLabelStyle.IsOverlappedHidden = false;
                series.SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Top | LabelAlignmentStyles.Bottom | LabelAlignmentStyles.Left | LabelAlignmentStyles.Right;
                series.SmartLabelStyle.MinMovingDistance = 15;
                series.SmartLabelStyle.MaxMovingDistance = 60;
                series.SmartLabelStyle.CalloutStyle = LabelCalloutStyle.Underlined;
                series.SmartLabelStyle.CalloutLineColor = Color.FromArgb(160, 174, 192);
                series.SmartLabelStyle.CalloutLineWidth = 1;

                // ONLY add slices that have value > 0!
                // Slices with 0 are never added to the pie, completely eliminating overlapping 0-degree text!
                if (available > 0)
                {
                    var p = series.Points.Add(available);
                    double pct = (available * 100.0) / total;
                    p.Label = $"Available: {available} ({pct:0.0}%)";
                    p.Color = Color.FromArgb(46, 125, 50);
                    p.BorderColor = Color.White;
                    p.BorderWidth = 2;
                    p.IsVisibleInLegend = false;
                }

                if (booked > 0)
                {
                    var p = series.Points.Add(booked);
                    double pct = (booked * 100.0) / total;
                    p.Label = $"Booked: {booked} ({pct:0.0}%)";
                    p.Color = Color.FromArgb(230, 126, 34);
                    p.BorderColor = Color.White;
                    p.BorderWidth = 2;
                    p.IsVisibleInLegend = false;
                }

                if (maintenance > 0)
                {
                    var p = series.Points.Add(maintenance);
                    double pct = (maintenance * 100.0) / total;
                    p.Label = $"Under Maintenance: {maintenance} ({pct:0.0}%)";
                    p.Color = Color.FromArgb(192, 57, 43);
                    p.BorderColor = Color.White;
                    p.BorderWidth = 2;
                    p.IsVisibleInLegend = false;
                }
            }

            roomChart.Series.Add(series);
        }

        private void LoadDashboardStats()
        {
            int activeRooms = GetCount("rooms", "(maintenance IS NULL OR maintenance = 0)");
            int totalCustomers = GetCount("customers");
            int totalReservations = GetCount("reservations");
            int totalCheckins = GetCount("reservations", "status = 'Checked-in'"); // adjust table name if different

            CreateStatCard("Active Function Halls", activeRooms, Properties.Resources.room_icon, Color.SkyBlue, new Point(20, 80));
            CreateStatCard("Total Customer", totalCustomers, Properties.Resources.customer_icon, Color.LightGreen, new Point(270, 80));
            CreateStatCard("Current Reservations", totalReservations, Properties.Resources.reservation_icon, Color.LightSalmon, new Point(520, 80));
            CreateStatCard("Check-in Guests", totalCheckins, Properties.Resources.checkin_icon, Color.Khaki, new Point(770, 80));
        }

        private int GetCount(string tableName, string condition = "")
        {
            int count = 0;
            string query = $"SELECT COUNT(*) FROM {tableName}";

            if (!string.IsNullOrEmpty(condition))
            {
                query += $" WHERE {condition}";
            }

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return count;
        }

        private void CreateStatCard(string title, int value, Image iconImage, Color backColor, Point location)
        {
            // Sanitize title to generate valid control names
            string cleanTitle = title.Replace(" ", "").Replace("-", "").Trim();

            // Main panel/card
            Panel panel = new Panel();
            panel.Size = new Size(220, 130);
            panel.BackColor = backColor;
            panel.Location = location;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Name = $"card{cleanTitle}";

            // Title label
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(10, 10);
            lblTitle.AutoSize = true;
            lblTitle.Name = $"lblTitle{cleanTitle}";

            // Value label
            Label lblValue = new Label();
            lblValue.Text = value.ToString();
            lblValue.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblValue.ForeColor = Color.Black;
            lblValue.Location = new Point(10, 30);
            lblValue.AutoSize = true;
            lblValue.Name = $"lblValue{cleanTitle}";

            // Icon box
            PictureBox icon = new PictureBox();
            icon.Image = iconImage;
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            icon.Size = new Size(60, 60);
            icon.Location = new Point(145, 30);
            icon.Name = $"picIcon{cleanTitle}";

            // Add dot indicator if you want
            PictureBox dot = new PictureBox();
            dot.BackColor = Color.MediumPurple;
            dot.Size = new Size(10, 10);
            dot.Location = new Point(panel.Width - 15, 5);
            dot.Name = $"dot{cleanTitle}";
            dot.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Add controls to panel
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblValue);
            panel.Controls.Add(icon);
            panel.Controls.Add(dot);

            // Add card to the form
            this.Controls.Add(panel);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void roomChart_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadHomeStats();
            LoadRoomChart();
            LoadLatestReservations();
        }

        private void dgvLatestReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
