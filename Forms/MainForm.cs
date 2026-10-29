using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Hotel_Reservation_System.Database;

namespace Hotel_Reservation_System.Forms
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private Guna.UI2.WinForms.Guna2Button currentButton = null;
        public Action OnLogout { get; set; }
        private bool _isLoggingOut = false;
        private bool isSidebarCollapsed = false;
        private System.Windows.Forms.Timer badgeTimer;
        private int adminId = 1;
        private string adminUsername = "admin";

        public MainForm() : this(1, "admin")
        {
        }

        public MainForm(int adminId, string adminUsername = "admin")
        {
            this.adminId = adminId;
            this.adminUsername = adminUsername;
            InitializeComponent();
            this.Load += MainForm_Load;
            panelSidebar.Resize += PanelSidebar_Resize;
            this.WindowState = FormWindowState.Maximized;
        }

        private Image CreateHamburgerIcon(int width = 28, int height = 24)
        {
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.Clear(Color.Transparent);

                float barHeight = 4f;
                float[] yPositions = { 2f, 9.5f, 17f };

                for (int i = 0; i < 3; i++)
                {
                    float y = yPositions[i];
                    RectangleF rect = new RectangleF(1f, y, width - 2f, barHeight);
                    using (LinearGradientBrush lgb = new LinearGradientBrush(
                        rect,
                        Color.FromArgb(28, 220, 180), // turquoise cyan
                        Color.FromArgb(55, 90, 240),  // vivid blue
                        LinearGradientMode.Horizontal))
                    {
                        using (GraphicsPath path = new GraphicsPath())
                        {
                            path.AddArc(rect.X, rect.Y, barHeight, barHeight, 90, 180);
                            path.AddArc(rect.Right - barHeight, rect.Y, barHeight, barHeight, 270, 180);
                            path.CloseFigure();
                            g.FillPath(lgb, path);
                        }
                    }
                }
            }
            return bmp;
        }

        public void UpdatePendingBadge()
        {
            try
            {
                int count = ReservationDAO.GetPendingReservationsCount();
                if (!isSidebarCollapsed)
                {
                    btnReservation.Text = count > 0 ? $"Reservation ({count} Pending)" : "Reservation";
                    btnReservation.ForeColor = count > 0 ? Color.Gold : Color.White;
                }
                else
                {
                    btnReservation.Text = "";
                }
            }
            catch
            {
            }
        }

        private void btnToggleSidebar_Click(object sender, EventArgs e)
        {
            isSidebarCollapsed = !isSidebarCollapsed;
            if (isSidebarCollapsed)
            {
                panelSidebar.Width = 72;
                tableLayoutPanel2.Width = 72;
                tableLayoutPanel3.Visible = false;
                btnHome.Text = "";
                btnRoomManagement.Text = "";
                btnCustomerManagement.Text = "";
                btnReservation.Text = "";
                btnCheckInOut.Text = "";
                btnPayment.Text = "";
                btnHistory.Text = "";
                btnReports.Text = "";
                btnHome.ImageAlign = HorizontalAlignment.Center;
                btnRoomManagement.ImageAlign = HorizontalAlignment.Center;
                btnCustomerManagement.ImageAlign = HorizontalAlignment.Center;
                btnReservation.ImageAlign = HorizontalAlignment.Center;
                btnCheckInOut.ImageAlign = HorizontalAlignment.Center;
                btnPayment.ImageAlign = HorizontalAlignment.Center;
                btnHistory.ImageAlign = HorizontalAlignment.Center;
                btnReports.ImageAlign = HorizontalAlignment.Center;
            }
            else
            {
                panelSidebar.Width = 353;
                tableLayoutPanel2.Width = 335;
                tableLayoutPanel3.Visible = true;
                btnHome.Text = "Home";
                btnRoomManagement.Text = "Function Hall Venue Management";
                btnCustomerManagement.Text = "Customer Management";
                btnCheckInOut.Text = "Check-In / Out";
                btnPayment.Text = "Payment";
                btnHistory.Text = "History";
                btnReports.Text = "Reports";
                btnHome.ImageAlign = HorizontalAlignment.Left;
                btnRoomManagement.ImageAlign = HorizontalAlignment.Left;
                btnCustomerManagement.ImageAlign = HorizontalAlignment.Left;
                btnReservation.ImageAlign = HorizontalAlignment.Left;
                btnCheckInOut.ImageAlign = HorizontalAlignment.Left;
                btnPayment.ImageAlign = HorizontalAlignment.Left;
                btnHistory.ImageAlign = HorizontalAlignment.Left;
                btnReports.ImageAlign = HorizontalAlignment.Left;
                UpdatePendingBadge();
            }
            ApplyBottomRightRadius(panelSidebar, 20);
        }

        private void LoadForm(Form form)
        {
            panelContainer.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(form);
            form.Show();
        }

        private void HighlightSidebarButton(Guna.UI2.WinForms.Guna2Button button)
        {
            if (currentButton != null)
            {
                currentButton.FillColor = Color.FromArgb(0, 153, 153);
                currentButton.ForeColor = Color.White;
            }

            currentButton = button;
            currentButton.FillColor = Color.FromArgb(0, 51, 51);
            currentButton.ForeColor = Color.White;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnToggleSidebar.Image = CreateHamburgerIcon(26, 22);
            LoadForm(new HomeForm());
            ApplyBottomRightRadius(panelSidebar, 20);
            UpdatePendingBadge();

            badgeTimer = new System.Windows.Forms.Timer();
            badgeTimer.Interval = 4000;
            badgeTimer.Tick += (s, ev) => UpdatePendingBadge();
            badgeTimer.Start();
        }

        private void PanelSidebar_Resize(object sender, EventArgs e)
        {
            ApplyBottomRightRadius(panelSidebar, 20);
        }

        private void ApplyBottomRightRadius(Panel pnl, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            var bounds = pnl.ClientRectangle;
            int d = radius * 2;

            // Top edge: straight line across
            path.AddLine(bounds.Left, bounds.Top, bounds.Right, bounds.Top);
            // Right edge: straight line down to bottom‑radius
            path.AddLine(bounds.Right, bounds.Top, bounds.Right, bounds.Bottom - radius);
            // Bottom‑right corner arc
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            // Bottom edge: straight line back to left
            path.AddLine(bounds.Right, bounds.Bottom, bounds.Left, bounds.Bottom);
            // Left edge: straight line up to top
            path.AddLine(bounds.Left, bounds.Bottom, bounds.Left, bounds.Top);

            path.CloseFigure();
            pnl.Region = new Region(path);
        }

        private void PanelSidebar_Paint(object sender, PaintEventArgs e)
        {
            var pnl = (Panel)sender;
            int shadowWidth = 20;                 // how wide you want the shadow
            float alphaStart = 0.3f;              // opacity at the very edge
            float alphaEnd = 0.0f;                // fade to transparent inward

            // Rectangle along the sidebar’s right edge
            Rectangle gradientRect = new Rectangle(
                pnl.ClientSize.Width - shadowWidth,
                0,
                shadowWidth,
                pnl.ClientSize.Height);

            using (var brush = new LinearGradientBrush(
                       gradientRect,
                       Color.FromArgb((int)(alphaStart * 255), 0, 0, 0),
                       Color.FromArgb((int)(alphaEnd * 255), 0, 0, 0),
                       LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, gradientRect);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            HighlightSidebarButton(btnHome);
            LoadForm(new HomeForm());
        }

        private void btnRoomManagement_Click(object sender, EventArgs e)
        {
            HighlightSidebarButton(btnRoomManagement);
            LoadForm(new RoomForm());
        }

        private void btnCustomerManagement_Click(object sender, EventArgs e)
        {
            HighlightSidebarButton(btnCustomerManagement);
            LoadForm(new CustomerForm());
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            HighlightSidebarButton(btnReservation);
            ReservationForm resForm = new ReservationForm();
            resForm.FormClosed += (s, ev) => UpdatePendingBadge();
            LoadForm(resForm);
            UpdatePendingBadge();
        }

        private void btnCheckInOut_Click(object sender, EventArgs e)
        {
            HighlightSidebarButton(btnCheckInOut);
            LoadForm(new CheckInOutForm());
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            HighlightSidebarButton(btnPayment);
            LoadForm(new PaymentForm());
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            HighlightSidebarButton(btnHistory);
            LoadForm(new HistoryForm());
        }

        private void Reports_Click(object sender, EventArgs e)
        {
            HighlightSidebarButton(btnReports);
            LoadForm(new ReportsForm());
        }

        private void btnAdminProfile_Click(object sender, EventArgs e)
        {
            using (var profileModal = new AdminProfileForm(adminId))
            {
                profileModal.ProfileUpdated += (newUsername) =>
                {
                    this.adminUsername = newUsername;
                };
                profileModal.ShowDialog(this);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _isLoggingOut = true;
                this.Close();
            }
            // If No, do nothing
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (_isLoggingOut)
            {
                OnLogout?.Invoke();
            }
            else
            {
                Application.Exit();
            }
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSidebar_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panelContainer_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panelContainer_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
