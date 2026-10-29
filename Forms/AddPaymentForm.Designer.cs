namespace Hotel_Reservation_System.Forms
{
    partial class AddPaymentForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            label3 = new Label();
            txtAmount = new Guna.UI2.WinForms.Guna2TextBox();
            label2 = new Label();
            cmbPaymentMethod = new Guna.UI2.WinForms.Guna2ComboBox();
            lblPaymentMethod = new Label();
            btnSave = new Guna.UI2.WinForms.Guna2Button();
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            dtpPaymentDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label4 = new Label();
            cmbReservation = new Guna.UI2.WinForms.Guna2ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(57, 38, 19);
            label1.Location = new Point(15, 22);
            label1.Name = "label1";
            label1.Size = new Size(167, 32);
            label1.TabIndex = 16;
            label1.Text = "Add Payment";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 68);
            label3.Name = "label3";
            label3.Size = new Size(101, 19);
            label3.TabIndex = 17;
            label3.Text = "Reservation ID";
            // 
            // txtAmount
            // 
            txtAmount.BorderRadius = 5;
            txtAmount.Cursor = Cursors.Hand;
            txtAmount.CustomizableEdges = customizableEdges1;
            txtAmount.DefaultText = "";
            txtAmount.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtAmount.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtAmount.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAmount.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAmount.ForeColor = Color.Black;
            txtAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAmount.Location = new Point(20, 151);
            txtAmount.Margin = new Padding(3, 4, 3, 4);
            txtAmount.Name = "txtAmount";
            txtAmount.PlaceholderText = "0,000.00";
            txtAmount.SelectedText = "";
            txtAmount.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtAmount.Size = new Size(394, 37);
            txtAmount.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 132);
            label2.Name = "label2";
            label2.Size = new Size(59, 19);
            label2.TabIndex = 19;
            label2.Text = "Amount";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.BackColor = Color.Transparent;
            cmbPaymentMethod.BorderRadius = 5;
            cmbPaymentMethod.Cursor = Cursors.Hand;
            cmbPaymentMethod.CustomizableEdges = customizableEdges3;
            cmbPaymentMethod.DrawMode = DrawMode.OwnerDrawFixed;
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbPaymentMethod.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbPaymentMethod.Font = new Font("Segoe UI", 10F);
            cmbPaymentMethod.ForeColor = Color.Black;
            cmbPaymentMethod.ItemHeight = 30;
            cmbPaymentMethod.Location = new Point(438, 88);
            cmbPaymentMethod.Margin = new Padding(3, 2, 3, 2);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cmbPaymentMethod.Size = new Size(394, 36);
            cmbPaymentMethod.TabIndex = 20;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPaymentMethod.Location = new Point(434, 68);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(116, 19);
            lblPaymentMethod.TabIndex = 21;
            lblPaymentMethod.Text = "Payment Method";
            // 
            // btnSave
            // 
            btnSave.BorderRadius = 5;
            btnSave.Cursor = Cursors.Hand;
            btnSave.CustomizableEdges = customizableEdges5;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.FillColor = Color.FromArgb(57, 38, 19);
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(20, 206);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSave.Size = new Size(113, 30);
            btnSave.TabIndex = 24;
            btnSave.Text = "📄Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.CustomizableEdges = customizableEdges7;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.FillColor = Color.Transparent;
            btnCancel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.FromArgb(57, 38, 19);
            btnCancel.Location = new Point(138, 206);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCancel.Size = new Size(131, 30);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.BorderRadius = 5;
            dtpPaymentDate.Checked = true;
            dtpPaymentDate.Cursor = Cursors.Hand;
            dtpPaymentDate.CustomizableEdges = customizableEdges9;
            dtpPaymentDate.FillColor = Color.White;
            dtpPaymentDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpPaymentDate.ForeColor = Color.Black;
            dtpPaymentDate.Format = DateTimePickerFormat.Long;
            dtpPaymentDate.Location = new Point(438, 152);
            dtpPaymentDate.Margin = new Padding(3, 2, 3, 2);
            dtpPaymentDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpPaymentDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.ShadowDecoration.CustomizableEdges = customizableEdges10;
            dtpPaymentDate.Size = new Size(394, 37);
            dtpPaymentDate.TabIndex = 26;
            dtpPaymentDate.Value = new DateTime(2025, 5, 7, 18, 3, 17, 395);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(434, 130);
            label4.Name = "label4";
            label4.Size = new Size(96, 19);
            label4.TabIndex = 27;
            label4.Text = "Payment Date";
            // 
            // cmbReservation
            // 
            cmbReservation.BackColor = Color.Transparent;
            cmbReservation.BorderRadius = 5;
            cmbReservation.Cursor = Cursors.Hand;
            cmbReservation.CustomizableEdges = customizableEdges11;
            cmbReservation.DrawMode = DrawMode.OwnerDrawFixed;
            cmbReservation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReservation.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbReservation.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbReservation.Font = new Font("Segoe UI", 10F);
            cmbReservation.ForeColor = Color.Black;
            cmbReservation.ItemHeight = 30;
            cmbReservation.Location = new Point(19, 88);
            cmbReservation.Margin = new Padding(3, 2, 3, 2);
            cmbReservation.Name = "cmbReservation";
            cmbReservation.ShadowDecoration.CustomizableEdges = customizableEdges12;
            cmbReservation.Size = new Size(394, 36);
            cmbReservation.TabIndex = 28;
            // 
            // AddPaymentForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(851, 261);
            Controls.Add(cmbReservation);
            Controls.Add(label4);
            Controls.Add(dtpPaymentDate);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblPaymentMethod);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(label2);
            Controls.Add(txtAmount);
            Controls.Add(label3);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddPaymentForm";
            StartPosition = FormStartPosition.CenterParent;
            Load += AddPaymentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtAmount;
        private Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbPaymentMethod;
        private Label lblPaymentMethod;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpPaymentDate;
        private Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cmbReservation;
    }
}