namespace Hotel_Reservation_System.Forms.UserForms
{
    partial class ReserveRoomForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges31 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges32 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges33 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges34 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges35 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges36 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges37 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges38 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges39 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges40 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges41 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges42 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges43 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges44 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            dateCheckIn = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label1 = new Label();
            dateCheckOut = new Guna.UI2.WinForms.Guna2DateTimePicker();
            btnConfirmReservation = new Guna.UI2.WinForms.Guna2Button();
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            label2 = new Label();
            label3 = new Label();
            lblCheckInTime = new Label();
            cmbCheckInTime = new Guna.UI2.WinForms.Guna2ComboBox();
            lblCheckOutTime = new Label();
            cmbCheckOutTime = new Guna.UI2.WinForms.Guna2ComboBox();
            lblCustomer = new Label();
            lblEventType = new Label();
            cmbEventType = new Guna.UI2.WinForms.Guna2ComboBox();
            txtboxCustomerName = new Guna.UI2.WinForms.Guna2TextBox();
            txtBoxEmail = new Guna.UI2.WinForms.Guna2TextBox();
            txtBoxPhone = new Guna.UI2.WinForms.Guna2TextBox();
            lblEmail = new Label();
            lblPhone = new Label();
            lblAddress = new Label();
            txtBoxAddress = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // dateCheckIn
            // 
            dateCheckIn.BorderRadius = 5;
            dateCheckIn.Checked = true;
            dateCheckIn.CustomFormat = "";
            dateCheckIn.CustomizableEdges = customizableEdges23;
            dateCheckIn.FillColor = Color.White;
            dateCheckIn.Font = new Font("Segoe UI", 9.5F);
            dateCheckIn.ForeColor = Color.Black;
            dateCheckIn.Format = DateTimePickerFormat.Long;
            dateCheckIn.Location = new Point(22, 75);
            dateCheckIn.Margin = new Padding(3, 2, 3, 2);
            dateCheckIn.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateCheckIn.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateCheckIn.Name = "dateCheckIn";
            dateCheckIn.ShadowDecoration.CustomizableEdges = customizableEdges24;
            dateCheckIn.Size = new Size(315, 30);
            dateCheckIn.TabIndex = 0;
            dateCheckIn.Value = new DateTime(2025, 5, 27, 0, 0, 0, 0);
            dateCheckIn.ValueChanged += dateCheckIn_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 51, 51);
            label1.Location = new Point(18, 14);
            label1.Name = "label1";
            label1.Size = new Size(218, 32);
            label1.TabIndex = 16;
            label1.Text = "Make Reservation";
            // 
            // dateCheckOut
            // 
            dateCheckOut.BorderRadius = 5;
            dateCheckOut.Checked = true;
            dateCheckOut.CustomizableEdges = customizableEdges25;
            dateCheckOut.FillColor = Color.White;
            dateCheckOut.Font = new Font("Segoe UI", 9.5F);
            dateCheckOut.ForeColor = Color.Black;
            dateCheckOut.Format = DateTimePickerFormat.Long;
            dateCheckOut.Location = new Point(22, 131);
            dateCheckOut.Margin = new Padding(3, 2, 3, 2);
            dateCheckOut.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dateCheckOut.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dateCheckOut.Name = "dateCheckOut";
            dateCheckOut.ShadowDecoration.CustomizableEdges = customizableEdges26;
            dateCheckOut.Size = new Size(315, 30);
            dateCheckOut.TabIndex = 17;
            dateCheckOut.Value = new DateTime(2025, 5, 18, 14, 7, 5, 260);
            dateCheckOut.ValueChanged += dateCheckOut_ValueChanged;
            // 
            // btnConfirmReservation
            // 
            btnConfirmReservation.BorderRadius = 5;
            btnConfirmReservation.Cursor = Cursors.Hand;
            btnConfirmReservation.CustomizableEdges = customizableEdges27;
            btnConfirmReservation.DisabledState.BorderColor = Color.DarkGray;
            btnConfirmReservation.DisabledState.CustomBorderColor = Color.DarkGray;
            btnConfirmReservation.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnConfirmReservation.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnConfirmReservation.FillColor = Color.FromArgb(0, 26, 26);
            btnConfirmReservation.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmReservation.ForeColor = Color.White;
            btnConfirmReservation.Location = new Point(22, 477);
            btnConfirmReservation.Margin = new Padding(3, 2, 3, 2);
            btnConfirmReservation.Name = "btnConfirmReservation";
            btnConfirmReservation.ShadowDecoration.CustomizableEdges = customizableEdges28;
            btnConfirmReservation.Size = new Size(122, 32);
            btnConfirmReservation.TabIndex = 21;
            btnConfirmReservation.Text = "📄Confirm";
            btnConfirmReservation.Click += btnConfirmReservation_Click;
            // 
            // btnCancel
            // 
            btnCancel.BorderRadius = 5;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.CustomizableEdges = customizableEdges29;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.FillColor = Color.Transparent;
            btnCancel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.FromArgb(57, 38, 19);
            btnCancel.Location = new Point(172, 477);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges30;
            btnCancel.Size = new Size(114, 32);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(22, 56);
            label2.Name = "label2";
            label2.Size = new Size(100, 19);
            label2.TabIndex = 23;
            label2.Text = "Check-In Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(22, 112);
            label3.Name = "label3";
            label3.Size = new Size(112, 19);
            label3.TabIndex = 24;
            label3.Text = "Check-Out Date:";
            // 
            // lblCheckInTime
            // 
            lblCheckInTime.AutoSize = true;
            lblCheckInTime.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCheckInTime.Location = new Point(363, 56);
            lblCheckInTime.Name = "lblCheckInTime";
            lblCheckInTime.Size = new Size(102, 19);
            lblCheckInTime.TabIndex = 29;
            lblCheckInTime.Text = "Check-In Time:";
            // 
            // cmbCheckInTime
            // 
            cmbCheckInTime.BackColor = Color.Transparent;
            cmbCheckInTime.BorderRadius = 5;
            cmbCheckInTime.Cursor = Cursors.Hand;
            cmbCheckInTime.CustomizableEdges = customizableEdges31;
            cmbCheckInTime.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCheckInTime.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCheckInTime.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbCheckInTime.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbCheckInTime.Font = new Font("Segoe UI", 10F);
            cmbCheckInTime.ForeColor = Color.Black;
            cmbCheckInTime.ItemHeight = 34;
            cmbCheckInTime.Location = new Point(363, 75);
            cmbCheckInTime.Margin = new Padding(3, 2, 3, 2);
            cmbCheckInTime.MaxDropDownItems = 10;
            cmbCheckInTime.Name = "cmbCheckInTime";
            cmbCheckInTime.ShadowDecoration.CustomizableEdges = customizableEdges32;
            cmbCheckInTime.Size = new Size(316, 40);
            cmbCheckInTime.TabIndex = 30;
            // 
            // lblCheckOutTime
            // 
            lblCheckOutTime.AutoSize = true;
            lblCheckOutTime.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCheckOutTime.Location = new Point(363, 112);
            lblCheckOutTime.Name = "lblCheckOutTime";
            lblCheckOutTime.Size = new Size(114, 19);
            lblCheckOutTime.TabIndex = 31;
            lblCheckOutTime.Text = "Check-Out Time:";
            // 
            // cmbCheckOutTime
            // 
            cmbCheckOutTime.BackColor = Color.Transparent;
            cmbCheckOutTime.BorderRadius = 5;
            cmbCheckOutTime.Cursor = Cursors.Hand;
            cmbCheckOutTime.CustomizableEdges = customizableEdges33;
            cmbCheckOutTime.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCheckOutTime.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCheckOutTime.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbCheckOutTime.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbCheckOutTime.Font = new Font("Segoe UI", 10F);
            cmbCheckOutTime.ForeColor = Color.Black;
            cmbCheckOutTime.ItemHeight = 34;
            cmbCheckOutTime.Location = new Point(363, 131);
            cmbCheckOutTime.Margin = new Padding(3, 2, 3, 2);
            cmbCheckOutTime.MaxDropDownItems = 10;
            cmbCheckOutTime.Name = "cmbCheckOutTime";
            cmbCheckOutTime.ShadowDecoration.CustomizableEdges = customizableEdges34;
            cmbCheckOutTime.Size = new Size(316, 40);
            cmbCheckOutTime.TabIndex = 32;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCustomer.Location = new Point(22, 188);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(113, 19);
            lblCustomer.TabIndex = 33;
            lblCustomer.Text = "Customer Name:";
            // 
            // lblEventType
            // 
            lblEventType.AutoSize = true;
            lblEventType.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEventType.Location = new Point(22, 273);
            lblEventType.Name = "lblEventType";
            lblEventType.Size = new Size(79, 19);
            lblEventType.TabIndex = 27;
            lblEventType.Text = "Event Type:";
            // 
            // cmbEventType
            // 
            cmbEventType.BackColor = Color.Transparent;
            cmbEventType.BorderRadius = 5;
            cmbEventType.Cursor = Cursors.Hand;
            cmbEventType.CustomizableEdges = customizableEdges35;
            cmbEventType.DrawMode = DrawMode.OwnerDrawFixed;
            cmbEventType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEventType.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbEventType.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbEventType.Font = new Font("Segoe UI", 10F);
            cmbEventType.ForeColor = Color.Black;
            cmbEventType.ItemHeight = 34;
            cmbEventType.Items.AddRange(new object[] { "Wedding", "Birthday", "Anniversary", "Baptism", "Team Building", "Conference / Seminar" });
            cmbEventType.Location = new Point(18, 297);
            cmbEventType.Margin = new Padding(3, 2, 3, 2);
            cmbEventType.Name = "cmbEventType";
            cmbEventType.ShadowDecoration.CustomizableEdges = customizableEdges36;
            cmbEventType.Size = new Size(319, 40);
            cmbEventType.StartIndex = 0;
            cmbEventType.TabIndex = 28;
            cmbEventType.SelectedIndexChanged += cmbEventType_SelectedIndexChanged;
            // 
            // txtboxCustomerName
            // 
            txtboxCustomerName.BorderColor = Color.FromArgb(180, 190, 205);
            txtboxCustomerName.BorderRadius = 5;
            txtboxCustomerName.CustomizableEdges = customizableEdges37;
            txtboxCustomerName.DefaultText = "";
            txtboxCustomerName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtboxCustomerName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtboxCustomerName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtboxCustomerName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtboxCustomerName.FillColor = Color.White;
            txtboxCustomerName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtboxCustomerName.FocusedState.ForeColor = Color.Black;
            txtboxCustomerName.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtboxCustomerName.ForeColor = Color.Black;
            txtboxCustomerName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtboxCustomerName.Location = new Point(22, 210);
            txtboxCustomerName.Name = "txtboxCustomerName";
            txtboxCustomerName.PlaceholderText = "";
            txtboxCustomerName.SelectedText = "";
            txtboxCustomerName.ShadowDecoration.CustomizableEdges = customizableEdges38;
            txtboxCustomerName.Size = new Size(315, 36);
            txtboxCustomerName.TabIndex = 35;
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.BorderColor = Color.FromArgb(180, 190, 205);
            txtBoxEmail.BorderRadius = 5;
            txtBoxEmail.CustomizableEdges = customizableEdges39;
            txtBoxEmail.DefaultText = "";
            txtBoxEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtBoxEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtBoxEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtBoxEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtBoxEmail.FillColor = Color.White;
            txtBoxEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBoxEmail.FocusedState.ForeColor = Color.Black;
            txtBoxEmail.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxEmail.ForeColor = Color.Black;
            txtBoxEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBoxEmail.Location = new Point(363, 210);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.PlaceholderText = "";
            txtBoxEmail.SelectedText = "";
            txtBoxEmail.ShadowDecoration.CustomizableEdges = customizableEdges40;
            txtBoxEmail.Size = new Size(316, 36);
            txtBoxEmail.TabIndex = 36;
            // 
            // txtBoxPhone
            // 
            txtBoxPhone.BorderColor = Color.FromArgb(180, 190, 205);
            txtBoxPhone.BorderRadius = 5;
            txtBoxPhone.CustomizableEdges = customizableEdges41;
            txtBoxPhone.DefaultText = "";
            txtBoxPhone.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtBoxPhone.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtBoxPhone.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtBoxPhone.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtBoxPhone.FillColor = Color.White;
            txtBoxPhone.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBoxPhone.FocusedState.ForeColor = Color.Black;
            txtBoxPhone.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxPhone.ForeColor = Color.Black;
            txtBoxPhone.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBoxPhone.Location = new Point(363, 298);
            txtBoxPhone.Name = "txtBoxPhone";
            txtBoxPhone.PlaceholderText = "";
            txtBoxPhone.SelectedText = "";
            txtBoxPhone.ShadowDecoration.CustomizableEdges = customizableEdges42;
            txtBoxPhone.Size = new Size(316, 36);
            txtBoxPhone.TabIndex = 37;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.FromArgb(20, 30, 45);
            lblEmail.Location = new Point(363, 188);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 19);
            lblEmail.TabIndex = 38;
            lblEmail.Text = "Email:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhone.ForeColor = Color.FromArgb(20, 30, 45);
            lblPhone.Location = new Point(364, 273);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(107, 19);
            lblPhone.TabIndex = 39;
            lblPhone.Text = "Phone Number:";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddress.ForeColor = Color.FromArgb(20, 30, 45);
            lblAddress.Location = new Point(198, 378);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(61, 19);
            lblAddress.TabIndex = 40;
            lblAddress.Text = "Address:";
            // 
            // txtBoxAddress
            // 
            txtBoxAddress.BorderColor = Color.FromArgb(180, 190, 205);
            txtBoxAddress.BorderRadius = 5;
            txtBoxAddress.CustomizableEdges = customizableEdges43;
            txtBoxAddress.DefaultText = "";
            txtBoxAddress.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtBoxAddress.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtBoxAddress.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtBoxAddress.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtBoxAddress.FillColor = Color.White;
            txtBoxAddress.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBoxAddress.FocusedState.ForeColor = Color.Black;
            txtBoxAddress.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxAddress.ForeColor = Color.Black;
            txtBoxAddress.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBoxAddress.Location = new Point(198, 400);
            txtBoxAddress.Name = "txtBoxAddress";
            txtBoxAddress.PlaceholderText = "";
            txtBoxAddress.SelectedText = "";
            txtBoxAddress.ShadowDecoration.CustomizableEdges = customizableEdges44;
            txtBoxAddress.Size = new Size(316, 36);
            txtBoxAddress.TabIndex = 41;
            // 
            // ReserveRoomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(709, 520);
            Controls.Add(txtBoxAddress);
            Controls.Add(lblAddress);
            Controls.Add(lblPhone);
            Controls.Add(lblEmail);
            Controls.Add(txtBoxPhone);
            Controls.Add(txtBoxEmail);
            Controls.Add(txtboxCustomerName);
            Controls.Add(lblCustomer);
            Controls.Add(lblCheckOutTime);
            Controls.Add(cmbCheckOutTime);
            Controls.Add(lblCheckInTime);
            Controls.Add(cmbCheckInTime);
            Controls.Add(cmbEventType);
            Controls.Add(lblEventType);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirmReservation);
            Controls.Add(dateCheckOut);
            Controls.Add(label1);
            Controls.Add(dateCheckIn);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReserveRoomForm";
            StartPosition = FormStartPosition.CenterParent;
            Load += ReserveRoomForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker dateCheckIn;
        private Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateCheckOut;
        private Guna.UI2.WinForms.Guna2Button btnConfirmReservation;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Label label2;
        private Label label3;
        private Label lblCheckInTime;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCheckInTime;
        private Label lblCheckOutTime;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCheckOutTime;
        private Label lblCustomer;
        private Label lblEventType;
        private Guna.UI2.WinForms.Guna2ComboBox cmbEventType;
        private Guna.UI2.WinForms.Guna2TextBox txtboxCustomerName;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxPhone;
        private Label lblEmail;
        private Label lblPhone;
        private Label lblAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxAddress;
    }
}