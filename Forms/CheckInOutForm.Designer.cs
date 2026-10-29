namespace Hotel_Reservation_System.Forms
{
    partial class CheckInOutForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInOutForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            btnCheckOut = new Guna.UI2.WinForms.Guna2Button();
            btnCheckIn = new Guna.UI2.WinForms.Guna2Button();
            dgvReservations = new Guna.UI2.WinForms.Guna2DataGridView();
            Select = new DataGridViewCheckBoxColumn();
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
            tableLayoutPanel1.Size = new Size(1318, 796);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            guna2Panel1.AutoScroll = true;
            guna2Panel1.Controls.Add(btnRefresh);
            guna2Panel1.Controls.Add(btnCheckOut);
            guna2Panel1.Controls.Add(btnCheckIn);
            guna2Panel1.Controls.Add(dgvReservations);
            guna2Panel1.Controls.Add(label2);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.Location = new Point(3, 2);
            guna2Panel1.Margin = new Padding(3, 2, 3, 2);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(1312, 792);
            guna2Panel1.TabIndex = 0;
            guna2Panel1.Paint += guna2Panel1_Paint;
            // 
            // btnRefresh
            // 
            btnRefresh.BorderRadius = 5;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.CustomizableEdges = customizableEdges1;
            btnRefresh.DisabledState.BorderColor = Color.DarkGray;
            btnRefresh.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRefresh.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRefresh.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRefresh.FillColor = SystemColors.MenuHighlight;
            btnRefresh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.Location = new Point(1166, 49);
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Margin = new Padding(3, 2, 3, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnRefresh.Size = new Size(107, 26);
            btnRefresh.TabIndex = 25;
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            btnRefresh.MouseLeave += btnRefresh_MouseLeave;
            btnRefresh.MouseHover += btnRefresh_MouseHover;
            // 
            // btnCheckOut
            // 
            btnCheckOut.BorderRadius = 5;
            btnCheckOut.Cursor = Cursors.Hand;
            btnCheckOut.CustomizableEdges = customizableEdges3;
            btnCheckOut.DisabledState.BorderColor = Color.DarkGray;
            btnCheckOut.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCheckOut.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCheckOut.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCheckOut.FillColor = Color.FromArgb(192, 0, 0);
            btnCheckOut.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheckOut.ForeColor = Color.White;
            btnCheckOut.Location = new Point(1054, 49);
            btnCheckOut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCheckOut.Margin = new Padding(3, 2, 3, 2);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCheckOut.Size = new Size(107, 26);
            btnCheckOut.TabIndex = 24;
            btnCheckOut.Text = "❎Check-Out";
            btnCheckOut.TextAlign = HorizontalAlignment.Left;
            btnCheckOut.Click += btnCheckOut_Click;
            btnCheckOut.MouseLeave += btnCheckOut_MouseLeave;
            btnCheckOut.MouseHover += btnCheckOut_MouseHover;
            // 
            // btnCheckIn
            // 
            btnCheckIn.BorderRadius = 5;
            btnCheckIn.Cursor = Cursors.Hand;
            btnCheckIn.CustomizableEdges = customizableEdges5;
            btnCheckIn.DisabledState.BorderColor = Color.DarkGray;
            btnCheckIn.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCheckIn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCheckIn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCheckIn.FillColor = Color.DarkCyan;
            btnCheckIn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheckIn.ForeColor = Color.White;
            btnCheckIn.ImageAlign = HorizontalAlignment.Left;
            btnCheckIn.Location = new Point(942, 49);
            btnCheckIn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCheckIn.Margin = new Padding(3, 2, 3, 2);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnCheckIn.Size = new Size(107, 26);
            btnCheckIn.TabIndex = 23;
            btnCheckIn.Text = "✅ Check-In";
            btnCheckIn.TextAlign = HorizontalAlignment.Left;
            btnCheckIn.Click += btnCheckIn_Click;
            btnCheckIn.MouseLeave += btnCheckIn_MouseLeave;
            btnCheckIn.MouseHover += btnCheckIn_MouseHover;
            // 
            // dgvReservations
            // 
            dgvReservations.AllowUserToOrderColumns = true;
            dgvReservations.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvReservations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            dgvReservations.Location = new Point(19, 89);
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
            dgvReservations.Size = new Size(1274, 684);
            dgvReservations.TabIndex = 22;
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
            dgvReservations.CellContentClick += dgvReservations_CellContentClick;
            // 
            // Select
            // 
            Select.HeaderText = "Select";
            Select.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Select.MinimumWidth = 50;
            Select.Name = "Select";
            Select.Width = 50;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(26, 26, 0);
            label2.Location = new Point(19, 58);
            label2.Name = "label2";
            label2.Size = new Size(332, 19);
            label2.TabIndex = 11;
            label2.Text = "Manage Guest Check-Ins and Check-Outs Efficiently.";
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
            label1.Size = new Size(322, 32);
            label1.TabIndex = 10;
            label1.Text = "Check In/Out Management";
            // 
            // CheckInOutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1318, 796);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CheckInOutForm";
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
        private Guna.UI2.WinForms.Guna2DataGridView dgvReservations;
        private DataGridViewCheckBoxColumn Select;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnCheckOut;
        private Guna.UI2.WinForms.Guna2Button btnCheckIn;
        private ToolTip toolTip1;
    }
}