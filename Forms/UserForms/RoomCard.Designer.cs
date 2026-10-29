namespace Hotel_Reservation_System.Forms.UserForms
{
    partial class RoomCard
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelMain = new Guna.UI2.WinForms.Guna2Panel();
            lblRoomNumber = new Label();
            lblVenueLocation = new Label();
            lblBeds = new Label();
            lblCapacity = new Label();
            btnReserve = new Guna.UI2.WinForms.Guna2Button();
            lblAvailable = new Label();
            lblRate = new Label();
            lblType = new Label();
            pictureBoxRoom = new PictureBox();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRoom).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.BorderColor = Color.Silver;
            panelMain.BorderRadius = 10;
            panelMain.BorderThickness = 1;
            panelMain.Controls.Add(lblRoomNumber);
            panelMain.Controls.Add(lblVenueLocation);
            panelMain.Controls.Add(lblBeds);
            panelMain.Controls.Add(lblCapacity);
            panelMain.Controls.Add(btnReserve);
            panelMain.Controls.Add(lblAvailable);
            panelMain.Controls.Add(lblRate);
            panelMain.Controls.Add(lblType);
            panelMain.Controls.Add(pictureBoxRoom);
            panelMain.CustomizableEdges = customizableEdges3;
            panelMain.Location = new Point(3, 10);
            panelMain.Margin = new Padding(3, 2, 3, 2);
            panelMain.Name = "panelMain";
            panelMain.ShadowDecoration.CustomizableEdges = customizableEdges4;
            panelMain.Size = new Size(375, 378);
            panelMain.TabIndex = 0;
            panelMain.Paint += panelMain_Paint;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblRoomNumber.ForeColor = Color.Black;
            lblRoomNumber.Location = new Point(8, 184);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(119, 19);
            lblRoomNumber.TabIndex = 7;
            lblRoomNumber.Text = "Function hall No.:";
            // 
            // lblVenueLocation
            // 
            lblVenueLocation.AutoSize = true;
            lblVenueLocation.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblVenueLocation.ForeColor = Color.FromArgb(0, 102, 102);
            lblVenueLocation.Location = new Point(8, 205);
            lblVenueLocation.Name = "lblVenueLocation";
            lblVenueLocation.Size = new Size(106, 19);
            lblVenueLocation.TabIndex = 8;
            lblVenueLocation.Text = "Venue Location:";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            lblType.Location = new Point(8, 226);
            lblType.Name = "lblType";
            lblType.Size = new Size(38, 17);
            lblType.TabIndex = 1;
            lblType.Text = "Type:";
            // 
            // lblRate
            // 
            lblRate.AutoSize = true;
            lblRate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            lblRate.Location = new Point(8, 247);
            lblRate.Name = "lblRate";
            lblRate.Size = new Size(37, 17);
            lblRate.TabIndex = 2;
            lblRate.Text = "Rate:";
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            lblCapacity.Location = new Point(8, 268);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(60, 17);
            lblCapacity.TabIndex = 5;
            lblCapacity.Text = "Capacity:";
            // 
            // lblBeds
            // 
            lblBeds.AutoSize = true;
            lblBeds.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
            lblBeds.Location = new Point(8, 289);
            lblBeds.Name = "lblBeds";
            lblBeds.Size = new Size(84, 17);
            lblBeds.TabIndex = 6;
            lblBeds.Text = "No. of Tables:";
            lblBeds.Click += lblBeds_Click;
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblAvailable.Location = new Point(8, 310);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new Size(74, 17);
            lblAvailable.TabIndex = 3;
            lblAvailable.Text = "Availability";
            // 
            // btnReserve
            // 
            btnReserve.BorderRadius = 5;
            btnReserve.Cursor = Cursors.Hand;
            btnReserve.CustomizableEdges = customizableEdges1;
            btnReserve.DisabledState.BorderColor = Color.DarkGray;
            btnReserve.DisabledState.CustomBorderColor = Color.DarkGray;
            btnReserve.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnReserve.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnReserve.FillColor = Color.FromArgb(0, 77, 77);
            btnReserve.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnReserve.ForeColor = Color.White;
            btnReserve.Location = new Point(8, 335);
            btnReserve.Margin = new Padding(3, 2, 3, 2);
            btnReserve.Name = "btnReserve";
            btnReserve.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnReserve.Size = new Size(110, 30);
            btnReserve.TabIndex = 4;
            btnReserve.Text = "📜 Reserve";
            btnReserve.Click += btnReserve_Click;
            // 
            // pictureBoxRoom
            // 
            pictureBoxRoom.Dock = DockStyle.Top;
            pictureBoxRoom.Location = new Point(0, 0);
            pictureBoxRoom.Margin = new Padding(3, 2, 3, 2);
            pictureBoxRoom.Name = "pictureBoxRoom";
            pictureBoxRoom.Size = new Size(375, 178);
            pictureBoxRoom.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRoom.TabIndex = 0;
            pictureBoxRoom.TabStop = false;
            pictureBoxRoom.Click += pictureBoxRoom_Click;
            // 
            // RoomCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelMain);
            Margin = new Padding(3, 2, 3, 2);
            Name = "RoomCard";
            Size = new Size(385, 400);
            Load += RoomCard_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRoom).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelMain;
        private Label lblRate;
        private Label lblType;
        private PictureBox pictureBoxRoom;
        private Guna.UI2.WinForms.Guna2Button btnReserve;
        private Label lblAvailable;
        private Label lblCapacity;
        private Label lblBeds;
        private Label lblRoomNumber;
        private Label lblVenueLocation;
    }
}