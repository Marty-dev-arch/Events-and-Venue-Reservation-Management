using System.Drawing;
using System.Windows.Forms;

namespace Hotel_Reservation_System.Forms
{
    partial class CoordinatorLoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // ── Form properties ──────────────────────────────────
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1280, 800);
            this.Name = "CoordinatorLoginForm";
            this.Text = "Genoma Hotel — Coordinator Login";
            this.FormClosing += CoordinatorLoginForm_FormClosing;

            // ── Background ───────────────────────────────────────
            var pnlBg = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(10, 12, 28) };
            pnlBg.Paint += (s, e) =>
            {
                using var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    pnlBg.ClientRectangle,
                    Color.FromArgb(18, 10, 45),
                    Color.FromArgb(8, 8, 22),
                    System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal);
                e.Graphics.FillRectangle(brush, pnlBg.ClientRectangle);
            };
            this.Controls.Add(pnlBg);

            // ── Card shadow panel ────────────────────────────────
            var pnlCard = new Panel
            {
                Size = new Size(1000, 500),
                BackColor = Color.FromArgb(22, 15, 55),
            };
            pnlCard.Location = new Point((1280 - 1000) / 2, (800 - 500) / 2);
            pnlCard.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                // Border glow - purple
                using var pen = new Pen(Color.FromArgb(120, 80, 200), 2);
                var rect = new Rectangle(1, 1, pnlCard.Width - 3, pnlCard.Height - 3);
                e.Graphics.DrawRoundedRectangleCoord(pen, rect, 18);
            };
            pnlCard.Anchor = AnchorStyles.None;
            pnlBg.Controls.Add(pnlCard);
            pnlBg.Resize += (s, e) =>
            {
                pnlCard.Location = new Point(
                    (pnlBg.ClientSize.Width - pnlCard.Width) / 2,
                    (pnlBg.ClientSize.Height - pnlCard.Height) / 2);
            };

            // ── Left panel (branding) ────────────────────────────
            var pnlLeft = new Panel
            {
                Size = new Size(460, 500),
                Location = new Point(0, 0),
                BackColor = Color.FromArgb(45, 20, 100),
            };
            pnlLeft.Paint += (s, e) =>
            {
                // Purple gradient left panel
                using var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                    pnlLeft.ClientRectangle,
                    Color.FromArgb(80, 40, 160),
                    Color.FromArgb(30, 15, 80),
                    System.Drawing.Drawing2D.LinearGradientMode.Vertical);
                e.Graphics.FillRectangle(brush, pnlLeft.ClientRectangle);

                // Top accent stripe
                using var stripBrush = new SolidBrush(Color.FromArgb(147, 89, 220));
                e.Graphics.FillRectangle(stripBrush, 0, 0, pnlLeft.Width, 5);
            };
            pnlCard.Controls.Add(pnlLeft);

            // Hotel logo/icon
            var lblIcon = new Label
            {
                Text = "📋",
                Font = new Font("Segoe UI Emoji", 52F),
                ForeColor = Color.FromArgb(180, 140, 255),
                AutoSize = true,
                BackColor = Color.Transparent,
            };
            lblIcon.Location = new Point((460 - lblIcon.PreferredWidth) / 2, 100);
            pnlLeft.Controls.Add(lblIcon);
            lblIcon.Paint += (s, e) =>
            {
                lblIcon.Location = new Point((pnlLeft.Width - lblIcon.PreferredWidth) / 2, 100);
            };

            var lblHotel = new Label
            {
                Text = "Genoma Hotel",
                Font = new Font("Script MT Bold", 22F, FontStyle.Bold),
                ForeColor = Color.FromArgb(180, 140, 255),
                AutoSize = true,
                BackColor = Color.Transparent,
            };
            lblHotel.Location = new Point(80, 230);
            pnlLeft.Controls.Add(lblHotel);

            var lblRole = new Label
            {
                Text = "Coordinator Portal",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent,
            };
            lblRole.Location = new Point(115, 275);
            pnlLeft.Controls.Add(lblRole);

            var lblDesc = new Label
            {
                Text = "Manage guests, reservations,\ncheck-ins, and payments.",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(180, 160, 220),
                Size = new Size(380, 60),
                Location = new Point(40, 320),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
            };
            pnlLeft.Controls.Add(lblDesc);

            // ── Right panel (form) ────────────────────────────────
            var pnlRight = new Panel
            {
                Size = new Size(540, 500),
                Location = new Point(460, 0),
                BackColor = Color.FromArgb(22, 15, 55),
            };
            pnlCard.Controls.Add(pnlRight);

            // Title
            var lblTitle = new Label
            {
                Text = "Coordinator Login",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Size = new Size(440, 40),
                Location = new Point(50, 50),
                TextAlign = ContentAlignment.MiddleCenter,
            };
            pnlRight.Controls.Add(lblTitle);

            // Username label
            var lblUser = new Label
            {
                Text = "Username",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(160, 140, 200),
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point(50, 130),
            };
            pnlRight.Controls.Add(lblUser);

            // Username textbox
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox
            {
                PlaceholderText = "coordinator",
                Location = new Point(50, 155),
                Size = new Size(440, 50),
                BorderRadius = 10,
                BorderColor = Color.FromArgb(100, 60, 180),
                FillColor = Color.FromArgb(35, 25, 70),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F),
                TabIndex = 1,
            };
            txtUsername.FocusedState.BorderColor = Color.FromArgb(147, 89, 220);
            pnlRight.Controls.Add(txtUsername);

            // Password label
            var lblPass = new Label
            {
                Text = "Password",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(160, 140, 200),
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point(50, 215),
            };
            pnlRight.Controls.Add(lblPass);

            // Password textbox
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox
            {
                PlaceholderText = "••••••••",
                Location = new Point(50, 240),
                Size = new Size(440, 50),
                BorderRadius = 10,
                BorderColor = Color.FromArgb(100, 60, 180),
                FillColor = Color.FromArgb(35, 25, 70),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F),
                UseSystemPasswordChar = true,
                TabIndex = 2,
            };
            txtPassword.FocusedState.BorderColor = Color.FromArgb(147, 89, 220);
            pnlRight.Controls.Add(txtPassword);

            // Eye toggle
            picTogglePassword = new PictureBox
            {
                Image = Properties.Resources.eye_closed,
                Size = new Size(24, 23),
                Location = new Point(463, 254),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                SizeMode = PictureBoxSizeMode.StretchImage,
                TabStop = false,
            };
            picTogglePassword.Click += picTogglePassword_Click;
            picTogglePassword.MouseDown += picTogglePassword_MouseDown;
            picTogglePassword.MouseUp += picTogglePassword_MouseUp;
            pnlRight.Controls.Add(picTogglePassword);

            // Demo hint
            var lblHint = new Label
            {
                Text = "Demo: coordinator / coord123",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Italic),
                ForeColor = Color.FromArgb(120, 90, 180),
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point(50, 300),
            };
            pnlRight.Controls.Add(lblHint);

            // Login button
            btnLogin = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Login as Coordinator",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.White,
                FillColor = Color.FromArgb(100, 55, 190),
                BorderRadius = 10,
                Size = new Size(440, 52),
                Location = new Point(50, 325),
                Cursor = Cursors.Hand,
                TabIndex = 3,
            };
            btnLogin.HoverState.FillColor = Color.FromArgb(130, 80, 220);
            btnLogin.Click += btnLogin_Click;
            pnlRight.Controls.Add(btnLogin);

            // Back button
            btnBackToPortal = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "← Back to Portal Selection",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(147, 89, 220),
                FillColor = Color.Transparent,
                BorderColor = Color.FromArgb(80, 50, 140),
                BorderRadius = 8,
                BorderThickness = 1,
                Size = new Size(200, 36),
                Location = new Point(50, 430),
                Cursor = Cursors.Hand,
                TabIndex = 4,
            };
            btnBackToPortal.Click += btnBackToPortal_Click;
            pnlRight.Controls.Add(btnBackToPortal);

            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2Button btnBackToPortal;
        private PictureBox picTogglePassword;
    }

    // Extension for coordinator form rounded rect drawing
    internal static class CoordGraphicsExtensions
    {
        public static void DrawRoundedRectangleCoord(this System.Drawing.Graphics g,
            Pen pen, Rectangle rect, int radius)
        {
            int d = radius * 2;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            g.DrawPath(pen, path);
        }
    }
}
