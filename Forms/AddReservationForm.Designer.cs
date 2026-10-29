namespace Hotel_Reservation_System.Forms
{
    partial class AddReservationForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            cmbCustomer = new Guna.UI2.WinForms.Guna2ComboBox();
            cmbRoom = new Guna.UI2.WinForms.Guna2ComboBox();
            lblEventType = new Label();
            cmbEventType = new Guna.UI2.WinForms.Guna2ComboBox();
            cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            dtpCheckIn = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dtpCheckOut = new Guna.UI2.WinForms.Guna2DateTimePicker();
            btnAdd = new Guna.UI2.WinForms.Guna2Button();
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnClear = new Guna.UI2.WinForms.Guna2Button();
            dtpCheckInTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dtpCheckOutTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            SuspendLayout();
            // 
            // cmbCustomer
            // 
            cmbCustomer.BackColor = Color.Transparent;
            cmbCustomer.BorderRadius = 5;
            cmbCustomer.Cursor = Cursors.Hand;
            cmbCustomer.CustomizableEdges = customizableEdges1;
            cmbCustomer.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomer.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbCustomer.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbCustomer.Font = new Font("Segoe UI", 10F);
            cmbCustomer.ForeColor = Color.Black;
            cmbCustomer.ItemHeight = 30;
            cmbCustomer.Location = new Point(23, 84);
            cmbCustomer.Margin = new Padding(3, 2, 3, 2);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cmbCustomer.Size = new Size(255, 36);
            cmbCustomer.TabIndex = 13;
            cmbCustomer.Tag = "";
            cmbCustomer.SelectedIndexChanged += cmbCustomer_SelectedIndexChanged;
            // 
            // cmbRoom
            // 
            cmbRoom.BackColor = Color.Transparent;
            cmbRoom.Cursor = Cursors.Hand;
            cmbRoom.CustomizableEdges = customizableEdges3;
            cmbRoom.DrawMode = DrawMode.OwnerDrawFixed;
            cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbRoom.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbRoom.Font = new Font("Segoe UI", 10F);
            cmbRoom.ForeColor = Color.Black;
            cmbRoom.ItemHeight = 30;
            cmbRoom.Location = new Point(21, 148);
            cmbRoom.Margin = new Padding(3, 2, 3, 2);
            cmbRoom.Name = "cmbRoom";
            cmbRoom.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cmbRoom.Size = new Size(254, 36);
            cmbRoom.TabIndex = 14;
            cmbRoom.SelectedIndexChanged += cmbRoom_SelectedIndexChanged;
            // 
            // lblEventType
            // 
            lblEventType.AutoSize = true;
            lblEventType.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEventType.Location = new Point(21, 193);
            lblEventType.Name = "lblEventType";
            lblEventType.Size = new Size(76, 19);
            lblEventType.TabIndex = 31;
            lblEventType.Text = "Event Type";
            // 
            // cmbEventType
            // 
            cmbEventType.BackColor = Color.Transparent;
            cmbEventType.BorderRadius = 5;
            cmbEventType.Cursor = Cursors.Hand;
            cmbEventType.CustomizableEdges = customizableEdges21;
            cmbEventType.DrawMode = DrawMode.OwnerDrawFixed;
            cmbEventType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEventType.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbEventType.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbEventType.Font = new Font("Segoe UI", 10F);
            cmbEventType.ForeColor = Color.Black;
            cmbEventType.ItemHeight = 30;
            cmbEventType.Items.AddRange(new object[] {
            "Birthday",
            "Anniversary",
            "Baptism",
            "Wedding",
            "Team Building"});
            cmbEventType.Location = new Point(21, 214);
            cmbEventType.Margin = new Padding(3, 2, 3, 2);
            cmbEventType.Name = "cmbEventType";
            cmbEventType.ShadowDecoration.CustomizableEdges = customizableEdges22;
            cmbEventType.Size = new Size(254, 36);
            cmbEventType.StartIndex = 3;
            cmbEventType.TabIndex = 32;
            // 
            // cmbStatus
            // 
            cmbStatus.BackColor = Color.Transparent;
            cmbStatus.Cursor = Cursors.Hand;
            cmbStatus.CustomizableEdges = customizableEdges5;
            cmbStatus.DrawMode = DrawMode.OwnerDrawFixed;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbStatus.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.ForeColor = Color.Black;
            cmbStatus.ItemHeight = 30;
            cmbStatus.Location = new Point(297, 214);
            cmbStatus.Margin = new Padding(3, 2, 3, 2);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cmbStatus.Size = new Size(254, 36);
            cmbStatus.TabIndex = 17;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.BorderRadius = 5;
            dtpCheckIn.Checked = true;
            dtpCheckIn.Cursor = Cursors.Hand;
            dtpCheckIn.CustomizableEdges = customizableEdges7;
            dtpCheckIn.FillColor = Color.White;
            dtpCheckIn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpCheckIn.ForeColor = Color.Black;
            dtpCheckIn.Format = DateTimePickerFormat.Long;
            dtpCheckIn.Location = new Point(297, 84);
            dtpCheckIn.Margin = new Padding(3, 2, 3, 2);
            dtpCheckIn.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpCheckIn.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.ShadowDecoration.CustomizableEdges = customizableEdges8;
            dtpCheckIn.Size = new Size(254, 37);
            dtpCheckIn.TabIndex = 18;
            dtpCheckIn.Value = new DateTime(2025, 5, 4, 0, 22, 9, 786);
            dtpCheckIn.ValueChanged += dtpCheckIn_ValueChanged;
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.BorderRadius = 5;
            dtpCheckOut.Checked = true;
            dtpCheckOut.Cursor = Cursors.Hand;
            dtpCheckOut.CustomizableEdges = customizableEdges9;
            dtpCheckOut.FillColor = Color.White;
            dtpCheckOut.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpCheckOut.ForeColor = Color.Black;
            dtpCheckOut.Format = DateTimePickerFormat.Long;
            dtpCheckOut.Location = new Point(297, 148);
            dtpCheckOut.Margin = new Padding(3, 2, 3, 2);
            dtpCheckOut.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpCheckOut.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.ShadowDecoration.CustomizableEdges = customizableEdges10;
            dtpCheckOut.Size = new Size(254, 37);
            dtpCheckOut.TabIndex = 19;
            dtpCheckOut.Value = new DateTime(2025, 5, 4, 0, 22, 53, 706);
            dtpCheckOut.ValueChanged += dtpCheckOut_ValueChanged;
            // 
            // btnAdd
            // 
            btnAdd.BorderRadius = 5;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.CustomizableEdges = customizableEdges11;
            btnAdd.DisabledState.BorderColor = Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd.FillColor = Color.FromArgb(57, 38, 19);
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(23, 275);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnAdd.Size = new Size(113, 30);
            btnAdd.TabIndex = 20;
            btnAdd.Text = "📄Save ";
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.Control;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.CustomizableEdges = customizableEdges13;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.FillColor = Color.Transparent;
            btnCancel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.FromArgb(57, 38, 19);
            btnCancel.Location = new Point(260, 270);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnCancel.Size = new Size(131, 30);
            btnCancel.TabIndex = 21;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(57, 38, 19);
            label1.Location = new Point(18, 20);
            label1.Name = "label1";
            label1.Size = new Size(203, 32);
            label1.TabIndex = 22;
            label1.Text = "Add Reservation";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 61);
            label2.Name = "label2";
            label2.Size = new Size(110, 19);
            label2.TabIndex = 23;
            label2.Text = "Customer Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 126);
            label3.Name = "label3";
            label3.Size = new Size(150, 19);
            label3.TabIndex = 24;
            label3.Text = "Function Hall Number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(297, 193);
            label4.Name = "label4";
            label4.Size = new Size(48, 19);
            label4.TabIndex = 25;
            label4.Text = "Status";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(297, 61);
            label5.Name = "label5";
            label5.Size = new Size(159, 19);
            label5.TabIndex = 26;
            label5.Text = "Check-In Date and Time";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(297, 126);
            label6.Name = "label6";
            label6.Size = new Size(171, 19);
            label6.TabIndex = 27;
            label6.Text = "Check-Out Date and Time";
            // 
            // btnClear
            // 
            btnClear.BorderRadius = 5;
            btnClear.Cursor = Cursors.Hand;
            btnClear.CustomizableEdges = customizableEdges15;
            btnClear.DisabledState.BorderColor = Color.DarkGray;
            btnClear.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClear.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClear.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(142, 275);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnClear.Size = new Size(113, 30);
            btnClear.TabIndex = 28;
            btnClear.Text = "✂ Clear";
            btnClear.Click += btnClear_Click;
            // 
            // dtpCheckInTime
            // 
            dtpCheckInTime.BorderRadius = 5;
            dtpCheckInTime.Checked = true;
            dtpCheckInTime.Cursor = Cursors.Hand;
            dtpCheckInTime.CustomizableEdges = customizableEdges17;
            dtpCheckInTime.FillColor = Color.White;
            dtpCheckInTime.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpCheckInTime.ForeColor = Color.Black;
            dtpCheckInTime.Format = DateTimePickerFormat.Time;
            dtpCheckInTime.Location = new Point(574, 84);
            dtpCheckInTime.Margin = new Padding(3, 2, 3, 2);
            dtpCheckInTime.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpCheckInTime.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpCheckInTime.Name = "dtpCheckInTime";
            dtpCheckInTime.ShadowDecoration.CustomizableEdges = customizableEdges18;
            dtpCheckInTime.ShowUpDown = true;
            dtpCheckInTime.Size = new Size(255, 37);
            dtpCheckInTime.TabIndex = 29;
            dtpCheckInTime.Value = new DateTime(2025, 5, 4, 0, 22, 9, 786);
            dtpCheckInTime.ValueChanged += dtpCheckInTime_ValueChanged;
            // 
            // dtpCheckOutTime
            // 
            dtpCheckOutTime.BorderRadius = 5;
            dtpCheckOutTime.Checked = true;
            dtpCheckOutTime.Cursor = Cursors.Hand;
            dtpCheckOutTime.CustomizableEdges = customizableEdges19;
            dtpCheckOutTime.FillColor = Color.White;
            dtpCheckOutTime.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpCheckOutTime.ForeColor = Color.Black;
            dtpCheckOutTime.Format = DateTimePickerFormat.Time;
            dtpCheckOutTime.Location = new Point(574, 148);
            dtpCheckOutTime.Margin = new Padding(3, 2, 3, 2);
            dtpCheckOutTime.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpCheckOutTime.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpCheckOutTime.Name = "dtpCheckOutTime";
            dtpCheckOutTime.ShadowDecoration.CustomizableEdges = customizableEdges20;
            dtpCheckOutTime.ShowUpDown = true;
            dtpCheckOutTime.Size = new Size(255, 37);
            dtpCheckOutTime.TabIndex = 30;
            dtpCheckOutTime.Value = new DateTime(2025, 5, 4, 0, 22, 53, 706);
            dtpCheckOutTime.ValueChanged += dtpCheckOutTime_ValueChanged;
            // 
            // AddReservationForm
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(854, 335);
            Controls.Add(dtpCheckOutTime);
            Controls.Add(dtpCheckInTime);
            Controls.Add(btnClear);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(dtpCheckOut);
            Controls.Add(dtpCheckIn);
            Controls.Add(cmbStatus);
            Controls.Add(cmbEventType);
            Controls.Add(lblEventType);
            Controls.Add(cmbRoom);
            Controls.Add(cmbCustomer);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddReservationForm";
            StartPosition = FormStartPosition.CenterParent;
            Load += AddReservationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cmbCustomer;
        private Guna.UI2.WinForms.Guna2ComboBox cmbRoom;
        private Label lblEventType;
        private Guna.UI2.WinForms.Guna2ComboBox cmbEventType;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatus;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckIn;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckOut;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckInTime;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckOutTime;
    }
}