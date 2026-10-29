namespace Hotel_Reservation_System.Forms.UserForms
{
    partial class SuccessAlertForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblTitle = new Label();
            lblMessage = new Label();
            pictureBox1 = new PictureBox();
            btnOK = new Guna.UI2.WinForms.Guna2GradientButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(3, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(203, 26);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "label1";
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Top;
            lblMessage.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMessage.Location = new Point(0, 36);
            lblMessage.Name = "lblMessage";
            lblMessage.RightToLeft = RightToLeft.No;
            lblMessage.Size = new Size(592, 23);
            lblMessage.TabIndex = 1;
            lblMessage.Text = "label1";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.checked__1_1;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(231, 89);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(133, 82);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btnOK
            // 
            btnOK.BorderRadius = 5;
            btnOK.Cursor = Cursors.Hand;
            btnOK.CustomizableEdges = customizableEdges1;
            btnOK.DisabledState.BorderColor = Color.DarkGray;
            btnOK.DisabledState.CustomBorderColor = Color.DarkGray;
            btnOK.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnOK.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnOK.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnOK.FillColor = Color.Black;
            btnOK.FillColor2 = Color.FromArgb(0, 77, 77);
            btnOK.Font = new Font("Segoe UI", 9F);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(237, 190);
            btnOK.Name = "btnOK";
            btnOK.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnOK.Size = new Size(122, 39);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.Click += btnOK_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblTitle, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(592, 36);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.BorderRadius = 20;
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges3;
            guna2CustomGradientPanel1.Dock = DockStyle.Fill;
            guna2CustomGradientPanel1.FillColor = Color.FromArgb(242, 242, 242);
            guna2CustomGradientPanel1.FillColor2 = Color.FromArgb(242, 242, 242);
            guna2CustomGradientPanel1.FillColor3 = Color.FromArgb(242, 242, 242);
            guna2CustomGradientPanel1.Location = new Point(0, 0);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2CustomGradientPanel1.Size = new Size(592, 257);
            guna2CustomGradientPanel1.TabIndex = 5;
            // 
            // SuccessAlertForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(592, 257);
            Controls.Add(btnOK);
            Controls.Add(pictureBox1);
            Controls.Add(lblMessage);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(guna2CustomGradientPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SuccessAlertForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SuccessAlertForm";
            Load += SuccessAlertForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblMessage;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2GradientButton btnOK;
        private TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
    }
}