namespace Hotel_Reservation_System.Forms.UserForms
{
    partial class UserMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tableLayoutPanel1 = new TableLayoutPanel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            panelContainer = new Guna.UI2.WinForms.Guna2Panel();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            btnLogout = new Guna.UI2.WinForms.Guna2Button();
            btnProfile = new Guna.UI2.WinForms.Guna2Button();
            btnMyReservations = new Guna.UI2.WinForms.Guna2Button();
            btnBrowseRooms = new Guna.UI2.WinForms.Guna2Button();
            btnHome = new Guna.UI2.WinForms.Guna2Button();
            pictureBox1 = new PictureBox();
            lblWelcome = new Label();
            tableLayoutPanel1.SuspendLayout();
            guna2Panel1.SuspendLayout();
            guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(guna2Panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1673, 796);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(panelContainer);
            guna2Panel1.Controls.Add(guna2ShadowPanel1);
            guna2Panel1.CustomizableEdges = customizableEdges17;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Margin = new Padding(0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges18;
            guna2Panel1.Size = new Size(1673, 796);
            guna2Panel1.TabIndex = 0;
            // 
            // panelContainer
            // 
            panelContainer.CustomizableEdges = customizableEdges15;
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 58);
            panelContainer.Margin = new Padding(0);
            panelContainer.Name = "panelContainer";
            panelContainer.ShadowDecoration.CustomizableEdges = customizableEdges16;
            panelContainer.Size = new Size(1673, 738);
            panelContainer.TabIndex = 5;
            panelContainer.Paint += panelContainer_Paint;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(btnLogout);
            guna2ShadowPanel1.Controls.Add(btnProfile);
            guna2ShadowPanel1.Controls.Add(btnMyReservations);
            guna2ShadowPanel1.Controls.Add(btnBrowseRooms);
            guna2ShadowPanel1.Controls.Add(btnHome);
            guna2ShadowPanel1.Controls.Add(pictureBox1);
            guna2ShadowPanel1.Controls.Add(lblWelcome);
            guna2ShadowPanel1.Dock = DockStyle.Top;
            guna2ShadowPanel1.FillColor = Color.FromArgb(0, 26, 26);
            guna2ShadowPanel1.Location = new Point(0, 0);
            guna2ShadowPanel1.Margin = new Padding(0);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.ShadowColor = Color.FromArgb(0, 26, 26);
            guna2ShadowPanel1.ShadowDepth = 50;
            guna2ShadowPanel1.ShadowShift = 2;
            guna2ShadowPanel1.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.Dropped;
            guna2ShadowPanel1.Size = new Size(1673, 58);
            guna2ShadowPanel1.TabIndex = 4;
            guna2ShadowPanel1.Paint += guna2ShadowPanel1_Paint;
            // 
            // btnLogout
            // 
            btnLogout.BorderRadius = 5;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.CustomizableEdges = customizableEdges19;
            btnLogout.DisabledState.BorderColor = Color.DarkGray;
            btnLogout.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogout.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogout.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogout.FillColor = Color.DarkRed;
            btnLogout.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1566, 19);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.CustomizableEdges = customizableEdges20;
            btnLogout.Size = new Size(88, 26);
            btnLogout.TabIndex = 11;
            btnLogout.Text = "Logout";
            btnLogout.Click += btnLogout_Click;
            // 
            // btnProfile
            // 
            btnProfile.Cursor = Cursors.Hand;
            btnProfile.CustomizableEdges = customizableEdges21;
            btnProfile.DisabledState.BorderColor = Color.DarkGray;
            btnProfile.DisabledState.CustomBorderColor = Color.DarkGray;
            btnProfile.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnProfile.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnProfile.FillColor = Color.Transparent;
            btnProfile.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(966, 20);
            btnProfile.Margin = new Padding(3, 2, 3, 2);
            btnProfile.Name = "btnProfile";
            btnProfile.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnProfile.Size = new Size(112, 29);
            btnProfile.TabIndex = 10;
            btnProfile.Text = "My Profile";
            btnProfile.Click += btnProfile_Click;
            // 
            // btnMyReservations
            // 
            btnMyReservations.Cursor = Cursors.Hand;
            btnMyReservations.CustomizableEdges = customizableEdges23;
            btnMyReservations.DisabledState.BorderColor = Color.DarkGray;
            btnMyReservations.DisabledState.CustomBorderColor = Color.DarkGray;
            btnMyReservations.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnMyReservations.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnMyReservations.FillColor = Color.Transparent;
            btnMyReservations.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            btnMyReservations.ForeColor = Color.White;
            btnMyReservations.Location = new Point(820, 19);
            btnMyReservations.Margin = new Padding(3, 2, 3, 2);
            btnMyReservations.Name = "btnMyReservations";
            btnMyReservations.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnMyReservations.Size = new Size(150, 29);
            btnMyReservations.TabIndex = 9;
            btnMyReservations.Text = "My Reservations";
            btnMyReservations.Click += btnMyReservations_Click;
            // 
            // btnBrowseRooms
            // 
            btnBrowseRooms.Cursor = Cursors.Hand;
            btnBrowseRooms.CustomizableEdges = customizableEdges25;
            btnBrowseRooms.DisabledState.BorderColor = Color.DarkGray;
            btnBrowseRooms.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBrowseRooms.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBrowseRooms.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBrowseRooms.FillColor = Color.Transparent;
            btnBrowseRooms.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            btnBrowseRooms.ForeColor = Color.White;
            btnBrowseRooms.Location = new Point(677, 19);
            btnBrowseRooms.Margin = new Padding(3, 2, 3, 2);
            btnBrowseRooms.Name = "btnBrowseRooms";
            btnBrowseRooms.ShadowDecoration.CustomizableEdges = customizableEdges26;
            btnBrowseRooms.Size = new Size(137, 29);
            btnBrowseRooms.TabIndex = 8;
            btnBrowseRooms.Text = "Browse Venue";
            btnBrowseRooms.Click += btnBrowseRooms_Click;
            // 
            // btnHome
            // 
            btnHome.Cursor = Cursors.Hand;
            btnHome.CustomizableEdges = customizableEdges27;
            btnHome.DisabledState.BorderColor = Color.DarkGray;
            btnHome.DisabledState.CustomBorderColor = Color.DarkGray;
            btnHome.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnHome.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnHome.FillColor = Color.Transparent;
            btnHome.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(585, 20);
            btnHome.Margin = new Padding(3, 2, 3, 2);
            btnHome.Name = "btnHome";
            btnHome.ShadowDecoration.CustomizableEdges = customizableEdges28;
            btnHome.Size = new Size(86, 29);
            btnHome.TabIndex = 7;
            btnHome.Text = "Home";
            btnHome.Click += btnHome_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.Aroma2;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(20, 19);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(33, 26);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(57, 21);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(144, 21);
            lblWelcome.TabIndex = 4;
            lblWelcome.Text = "Welcome Message!";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // UserMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1673, 796);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UserMainForm";
            ShowIcon = false;
            Load += UserMainForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel panelContainer;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button btnProfile;
        private Guna.UI2.WinForms.Guna2Button btnMyReservations;
        private Guna.UI2.WinForms.Guna2Button btnBrowseRooms;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private PictureBox pictureBox1;
        private Label lblWelcome;
    }
}