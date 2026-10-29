namespace Hotel_Reservation_System.Forms
{
    partial class AdminProfileForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesCard1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesCard2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesFull1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesFull2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesUser1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesUser2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesEmail1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesEmail2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesContact1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesContact2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesPass1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesPass2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesUpdate1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesUpdate2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesClose1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdgesClose2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            panelCard = new Guna.UI2.WinForms.Guna2Panel();
            picAvatar = new PictureBox();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblFullName = new Label();
            txtFullName = new Guna.UI2.WinForms.Guna2TextBox();
            lblUsername = new Label();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            lblEmail = new Label();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            lblContact = new Label();
            txtContact = new Guna.UI2.WinForms.Guna2TextBox();
            lblPassword = new Label();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            chkShowPassword = new CheckBox();
            btnUpdate = new Guna.UI2.WinForms.Guna2GradientButton();
            btnClose = new Guna.UI2.WinForms.Guna2Button();

            panelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();

            // panelCard
            panelCard.BackColor = Color.White;
            panelCard.BorderColor = Color.FromArgb(215, 225, 230);
            panelCard.BorderRadius = 12;
            panelCard.BorderThickness = 1;
            panelCard.Controls.Add(picAvatar);
            panelCard.Controls.Add(lblTitle);
            panelCard.Controls.Add(lblSubtitle);
            panelCard.Controls.Add(lblFullName);
            panelCard.Controls.Add(txtFullName);
            panelCard.Controls.Add(lblUsername);
            panelCard.Controls.Add(txtUsername);
            panelCard.Controls.Add(lblEmail);
            panelCard.Controls.Add(txtEmail);
            panelCard.Controls.Add(lblContact);
            panelCard.Controls.Add(txtContact);
            panelCard.Controls.Add(lblPassword);
            panelCard.Controls.Add(txtPassword);
            panelCard.Controls.Add(chkShowPassword);
            panelCard.Controls.Add(btnUpdate);
            panelCard.Controls.Add(btnClose);
            panelCard.CustomizableEdges = customizableEdgesCard1;
            panelCard.Dock = DockStyle.Fill;
            panelCard.Location = new Point(0, 0);
            panelCard.Name = "panelCard";
            panelCard.ShadowDecoration.CustomizableEdges = customizableEdgesCard2;
            panelCard.Size = new Size(460, 620);
            panelCard.TabIndex = 0;

            // picAvatar
            picAvatar.Image = Properties.Resources.admin_profile;
            picAvatar.Location = new Point(190, 20);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(80, 80);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;

            // lblTitle
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 77, 77);
            lblTitle.Location = new Point(20, 105);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(420, 30);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Administrator Profile";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblSubtitle
            lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblSubtitle.ForeColor = Color.FromArgb(120, 130, 140);
            lblSubtitle.Location = new Point(20, 135);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(420, 20);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Update administrator credentials and contact details";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblFullName
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(40, 50, 60);
            lblFullName.Location = new Point(32, 165);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(68, 17);
            lblFullName.TabIndex = 3;
            lblFullName.Text = "Full Name";

            // txtFullName
            txtFullName.BorderColor = Color.FromArgb(210, 220, 230);
            txtFullName.BorderRadius = 5;
            txtFullName.CustomizableEdges = customizableEdgesFull1;
            txtFullName.DefaultText = "";
            txtFullName.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtFullName.ForeColor = Color.Black;
            txtFullName.Location = new Point(32, 186);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "System Administrator";
            txtFullName.ShadowDecoration.CustomizableEdges = customizableEdgesFull2;
            txtFullName.Size = new Size(396, 36);
            txtFullName.TabIndex = 4;

            // lblUsername
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(40, 50, 60);
            lblUsername.Location = new Point(32, 230);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(69, 17);
            lblUsername.TabIndex = 5;
            lblUsername.Text = "Username";

            // txtUsername
            txtUsername.BorderColor = Color.FromArgb(210, 220, 230);
            txtUsername.BorderRadius = 5;
            txtUsername.CustomizableEdges = customizableEdgesUser1;
            txtUsername.DefaultText = "";
            txtUsername.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtUsername.ForeColor = Color.Black;
            txtUsername.Location = new Point(32, 251);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "admin";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdgesUser2;
            txtUsername.Size = new Size(396, 36);
            txtUsername.TabIndex = 6;

            // lblEmail
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(40, 50, 60);
            lblEmail.Location = new Point(32, 295);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(93, 17);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email Address";

            // txtEmail
            txtEmail.BorderColor = Color.FromArgb(210, 220, 230);
            txtEmail.BorderRadius = 5;
            txtEmail.CustomizableEdges = customizableEdgesEmail1;
            txtEmail.DefaultText = "";
            txtEmail.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(32, 316);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "admin@eventvenue.com";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdgesEmail2;
            txtEmail.Size = new Size(396, 36);
            txtEmail.TabIndex = 8;

            // lblContact
            lblContact.AutoSize = true;
            lblContact.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblContact.ForeColor = Color.FromArgb(40, 50, 60);
            lblContact.Location = new Point(32, 360);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(108, 17);
            lblContact.TabIndex = 9;
            lblContact.Text = "Contact Number";

            // txtContact
            txtContact.BorderColor = Color.FromArgb(210, 220, 230);
            txtContact.BorderRadius = 5;
            txtContact.CustomizableEdges = customizableEdgesContact1;
            txtContact.DefaultText = "";
            txtContact.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtContact.ForeColor = Color.Black;
            txtContact.Location = new Point(32, 381);
            txtContact.Name = "txtContact";
            txtContact.PlaceholderText = "09123456789";
            txtContact.ShadowDecoration.CustomizableEdges = customizableEdgesContact2;
            txtContact.Size = new Size(396, 36);
            txtContact.TabIndex = 10;

            // lblPassword
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(40, 50, 60);
            lblPassword.Location = new Point(32, 425);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(99, 17);
            lblPassword.TabIndex = 11;
            lblPassword.Text = "Password (Key)";

            // txtPassword
            txtPassword.BorderColor = Color.FromArgb(210, 220, 230);
            txtPassword.BorderRadius = 5;
            txtPassword.CustomizableEdges = customizableEdgesPass1;
            txtPassword.DefaultText = "";
            txtPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtPassword.ForeColor = Color.Black;
            txtPassword.Location = new Point(32, 446);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.PlaceholderText = "••••••••";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdgesPass2;
            txtPassword.Size = new Size(396, 36);
            txtPassword.TabIndex = 12;

            // chkShowPassword
            chkShowPassword.AutoSize = true;
            chkShowPassword.Cursor = Cursors.Hand;
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = Color.FromArgb(100, 110, 120);
            chkShowPassword.Location = new Point(32, 488);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(107, 19);
            chkShowPassword.TabIndex = 13;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;

            // btnUpdate
            btnUpdate.BorderRadius = 6;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.CustomizableEdges = customizableEdgesUpdate1;
            btnUpdate.FillColor = Color.FromArgb(0, 153, 153);
            btnUpdate.FillColor2 = Color.FromArgb(0, 102, 102);
            btnUpdate.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(32, 525);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.ShadowDecoration.CustomizableEdges = customizableEdgesUpdate2;
            btnUpdate.Size = new Size(250, 42);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "💾 Save Changes";
            btnUpdate.Click += btnUpdate_Click;

            // btnClose
            btnClose.BorderColor = Color.FromArgb(210, 220, 230);
            btnClose.BorderRadius = 6;
            btnClose.BorderThickness = 1;
            btnClose.Cursor = Cursors.Hand;
            btnClose.CustomizableEdges = customizableEdgesClose1;
            btnClose.FillColor = Color.White;
            btnClose.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(70, 80, 90);
            btnClose.HoverState.FillColor = Color.FromArgb(245, 248, 250);
            btnClose.Location = new Point(292, 525);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdgesClose2;
            btnClose.Size = new Size(136, 42);
            btnClose.TabIndex = 15;
            btnClose.Text = "Close";
            btnClose.Click += btnClose_Click;

            // AdminProfileForm
            AcceptButton = btnUpdate;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(460, 600);
            Controls.Add(panelCard);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdminProfileForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Administrator Profile";
            Load += AdminProfileForm_Load;

            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelCard;
        private PictureBox picAvatar;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblFullName;
        private Guna.UI2.WinForms.Guna2TextBox txtFullName;
        private Label lblUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Label lblContact;
        private Guna.UI2.WinForms.Guna2TextBox txtContact;
        private Label lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private CheckBox chkShowPassword;
        private Guna.UI2.WinForms.Guna2GradientButton btnUpdate;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}
