namespace Hotel_Reservation_System.Forms
{
    partial class ReservationForm
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tableLayoutPanel1 = new TableLayoutPanel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            dgvReservations = new Guna.UI2.WinForms.Guna2DataGridView();
            Select = new DataGridViewCheckBoxColumn();
            btnDelete = new Guna.UI2.WinForms.Guna2Button();
            btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            btnAccept = new Guna.UI2.WinForms.Guna2Button();
            lblPendingAlert = new Label();
            label2 = new Label();
            label1 = new Label();
            toolTip1 = new ToolTip(components);
            tableLayoutPanel1.SuspendLayout();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(guna2Panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1350, 791);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            guna2Panel1.AutoScroll = true;
            guna2Panel1.Controls.Add(dgvReservations);
            guna2Panel1.Controls.Add(btnDelete);
            guna2Panel1.Controls.Add(btnUpdate);
            guna2Panel1.Controls.Add(btnAccept);
            guna2Panel1.Controls.Add(lblPendingAlert);
            guna2Panel1.Controls.Add(label2);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.Location = new Point(3, 2);
            guna2Panel1.Margin = new Padding(3, 2, 3, 2);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(1344, 787);
            guna2Panel1.TabIndex = 0;
            guna2Panel1.Paint += guna2Panel1_Paint;
            // 
            // dgvReservations
            // 
            dgvReservations.AllowUserToOrderColumns = true;
            dgvReservations.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvReservations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvReservations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReservations.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(59, 39, 18);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 153, 153);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvReservations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvReservations.ColumnHeadersHeight = 50;
            dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvReservations.Columns.AddRange(new DataGridViewColumn[] { Select });
            dgvReservations.Cursor = Cursors.Hand;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.Padding = new Padding(1, 2, 0, 2);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(242, 230, 217);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvReservations.DefaultCellStyle = dataGridViewCellStyle3;
            dgvReservations.GridColor = Color.FromArgb(59, 39, 18);
            dgvReservations.Location = new Point(19, 126);
            dgvReservations.Margin = new Padding(3, 2, 3, 2);
            dgvReservations.Name = "dgvReservations";
            dgvReservations.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvReservations.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Padding = new Padding(2);
            dgvReservations.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvReservations.RowTemplate.Height = 60;
            dgvReservations.Size = new Size(1306, 642);
            dgvReservations.TabIndex = 21;
            dgvReservations.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvReservations.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvReservations.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvReservations.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvReservations.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvReservations.ThemeStyle.BackColor = Color.White;
            dgvReservations.ThemeStyle.GridColor = Color.FromArgb(59, 39, 18);
            dgvReservations.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvReservations.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dgvReservations.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvReservations.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvReservations.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvReservations.ThemeStyle.HeaderStyle.Height = 50;
            dgvReservations.ThemeStyle.ReadOnly = false;
            dgvReservations.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvReservations.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReservations.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvReservations.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvReservations.ThemeStyle.RowsStyle.Height = 60;
            dgvReservations.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvReservations.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvReservations.CellClick += dgvReservations_CellClick;
            dgvReservations.CellContentClick += dgvReservations_CellContentClick;
            // 
            // Select
            // 
            Select.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Select.HeaderText = "Select";
            Select.MinimumWidth = 50;
            Select.Name = "Select";
            Select.Width = 50;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BorderRadius = 5;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.CustomizableEdges = customizableEdges1;
            btnDelete.DisabledState.BorderColor = Color.DarkGray;
            btnDelete.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDelete.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDelete.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDelete.FillColor = Color.FromArgb(192, 0, 0);
            btnDelete.Font = new Font("Segoe UI", 9F);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(1232, 96);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnDelete.Size = new Size(93, 26);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "\U0001f9fe️ Delete";
            btnDelete.Click += btnDelete_Click;
            btnDelete.MouseLeave += btnDelete_MouseLeave;
            btnDelete.MouseHover += btnDelete_MouseHover;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.BorderRadius = 5;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.CustomizableEdges = customizableEdges3;
            btnUpdate.DisabledState.BorderColor = Color.DarkGray;
            btnUpdate.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUpdate.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUpdate.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUpdate.FillColor = Color.DarkGoldenrod;
            btnUpdate.Font = new Font("Segoe UI", 9F);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(1133, 94);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnUpdate.Size = new Size(93, 26);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "📝 Update";
            btnUpdate.Click += btnUpdate_Click;
            btnUpdate.MouseLeave += btnUpdate_MouseLeave;
            btnUpdate.MouseHover += btnUpdate_MouseHover;
            // 
            // btnAccept
            // 
            btnAccept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAccept.BorderRadius = 5;
            btnAccept.Cursor = Cursors.Hand;
            btnAccept.CustomizableEdges = customizableEdges5;
            btnAccept.DisabledState.BorderColor = Color.DarkGray;
            btnAccept.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAccept.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAccept.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAccept.FillColor = Color.FromArgb(0, 153, 112);
            btnAccept.Font = new Font("Segoe UI", 9F);
            btnAccept.ForeColor = Color.White;
            btnAccept.Location = new Point(1017, 96);
            btnAccept.Margin = new Padding(3, 2, 3, 2);
            btnAccept.Name = "btnAccept";
            btnAccept.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnAccept.Size = new Size(110, 26);
            btnAccept.TabIndex = 17;
            btnAccept.Text = "✓ Accept";
            btnAccept.Click += btnAccept_Click;
            btnAccept.MouseLeave += btnAccept_MouseLeave;
            btnAccept.MouseHover += btnAccept_MouseHover;
            // 
            // lblPendingAlert
            // 
            lblPendingAlert.AutoSize = true;
            lblPendingAlert.BackColor = Color.FromArgb(255, 244, 229);
            lblPendingAlert.BorderStyle = BorderStyle.FixedSingle;
            lblPendingAlert.Cursor = Cursors.Hand;
            lblPendingAlert.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPendingAlert.ForeColor = Color.FromArgb(180, 80, 0);
            lblPendingAlert.Location = new Point(471, 50);
            lblPendingAlert.Name = "lblPendingAlert";
            lblPendingAlert.Padding = new Padding(8, 4, 8, 4);
            lblPendingAlert.Size = new Size(402, 27);
            lblPendingAlert.TabIndex = 20;
            lblPendingAlert.Text = "🔔 Notice: You have 1 pending reservation awaiting approval.";
            lblPendingAlert.Visible = false;
            lblPendingAlert.Click += lblPendingAlert_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(26, 26, 0);
            label2.Location = new Point(19, 58);
            label2.Name = "label2";
            label2.Size = new Size(261, 19);
            label2.TabIndex = 11;
            label2.Text = "Manage and Track All Reservations Easily.";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 0, 51);
            label1.Location = new Point(16, 20);
            label1.Name = "label1";
            label1.Size = new Size(263, 32);
            label1.TabIndex = 10;
            label1.Text = "Reservation Overview";
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 791);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ReservationForm";
            ShowIcon = false;
            tableLayoutPanel1.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label label1;
        private Label label2;
        private Label lblPendingAlert;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2Button btnAccept;
        private Guna.UI2.WinForms.Guna2DataGridView dgvReservations;
        private DataGridViewCheckBoxColumn Select;
        private ToolTip toolTip1;
    }
}