namespace Hotel_Reservation_System.Forms
{
    partial class PaymentForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tableLayoutPanel1 = new TableLayoutPanel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnPrintReceipt = new Guna.UI2.WinForms.Guna2Button();
            btnDeletePayment = new Guna.UI2.WinForms.Guna2Button();
            dgvPayments = new Guna.UI2.WinForms.Guna2DataGridView();
            Select = new DataGridViewCheckBoxColumn();
            btnAddPayment = new Guna.UI2.WinForms.Guna2Button();
            label2 = new Label();
            label1 = new Label();
            toolTip1 = new ToolTip(components);
            tableLayoutPanel1.SuspendLayout();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
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
            tableLayoutPanel1.Size = new Size(1316, 796);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            guna2Panel1.AutoScroll = true;
            guna2Panel1.Controls.Add(btnPrintReceipt);
            guna2Panel1.Controls.Add(btnDeletePayment);
            guna2Panel1.Controls.Add(dgvPayments);
            guna2Panel1.Controls.Add(btnAddPayment);
            guna2Panel1.Controls.Add(label2);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.Location = new Point(3, 2);
            guna2Panel1.Margin = new Padding(3, 2, 3, 2);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(1310, 792);
            guna2Panel1.TabIndex = 0;
            guna2Panel1.Paint += guna2Panel1_Paint;
            // 
            // btnPrintReceipt
            // 
            btnPrintReceipt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrintReceipt.BorderRadius = 5;
            btnPrintReceipt.Cursor = Cursors.Hand;
            btnPrintReceipt.CustomizableEdges = customizableEdges1;
            btnPrintReceipt.DisabledState.BorderColor = Color.DarkGray;
            btnPrintReceipt.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPrintReceipt.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPrintReceipt.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPrintReceipt.FillColor = Color.DodgerBlue;
            btnPrintReceipt.Font = new Font("Segoe UI", 9F);
            btnPrintReceipt.ForeColor = Color.White;
            btnPrintReceipt.Location = new Point(1043, 94);
            btnPrintReceipt.Margin = new Padding(3, 2, 3, 2);
            btnPrintReceipt.Name = "btnPrintReceipt";
            btnPrintReceipt.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnPrintReceipt.Size = new Size(149, 26);
            btnPrintReceipt.TabIndex = 24;
            btnPrintReceipt.Text = "\U0001f9fe️ Generate Receipt";
            btnPrintReceipt.Click += btnPrintReceipt_Click;
            // 
            // btnDeletePayment
            // 
            btnDeletePayment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeletePayment.BorderRadius = 5;
            btnDeletePayment.Cursor = Cursors.Hand;
            btnDeletePayment.CustomizableEdges = customizableEdges3;
            btnDeletePayment.DisabledState.BorderColor = Color.DarkGray;
            btnDeletePayment.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDeletePayment.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDeletePayment.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDeletePayment.FillColor = Color.FromArgb(192, 0, 0);
            btnDeletePayment.Font = new Font("Segoe UI", 9F);
            btnDeletePayment.ForeColor = Color.White;
            btnDeletePayment.Location = new Point(1198, 94);
            btnDeletePayment.Margin = new Padding(3, 2, 3, 2);
            btnDeletePayment.Name = "btnDeletePayment";
            btnDeletePayment.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnDeletePayment.Size = new Size(93, 26);
            btnDeletePayment.TabIndex = 23;
            btnDeletePayment.Text = "\U0001f9fe️ Delete";
            btnDeletePayment.Click += btnDeletePayment_Click;
            btnDeletePayment.MouseLeave += btnDeletePayment_MouseLeave;
            btnDeletePayment.MouseHover += btnDeletePayment_MouseHover;
            // 
            // dgvPayments
            // 
            dgvPayments.AllowUserToOrderColumns = true;
            dgvPayments.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvPayments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPayments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPayments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(59, 39, 18);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 153, 153);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPayments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPayments.ColumnHeadersHeight = 50;
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvPayments.Columns.AddRange(new DataGridViewColumn[] { Select });
            dgvPayments.Cursor = Cursors.Hand;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.Padding = new Padding(1, 2, 0, 2);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(242, 230, 217);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPayments.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPayments.GridColor = Color.FromArgb(59, 39, 18);
            dgvPayments.Location = new Point(19, 126);
            dgvPayments.Margin = new Padding(3, 2, 3, 2);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvPayments.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Padding = new Padding(2);
            dgvPayments.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvPayments.RowTemplate.Height = 60;
            dgvPayments.Size = new Size(1272, 647);
            dgvPayments.TabIndex = 22;
            dgvPayments.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvPayments.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvPayments.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvPayments.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvPayments.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvPayments.ThemeStyle.BackColor = Color.White;
            dgvPayments.ThemeStyle.GridColor = Color.FromArgb(59, 39, 18);
            dgvPayments.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvPayments.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dgvPayments.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvPayments.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvPayments.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvPayments.ThemeStyle.HeaderStyle.Height = 50;
            dgvPayments.ThemeStyle.ReadOnly = false;
            dgvPayments.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvPayments.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPayments.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvPayments.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvPayments.ThemeStyle.RowsStyle.Height = 60;
            dgvPayments.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvPayments.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvPayments.CellContentClick += dgvPayments_CellContentClick;
            // 
            // Select
            // 
            Select.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Select.HeaderText = "Select";
            Select.MinimumWidth = 50;
            Select.Name = "Select";
            Select.Width = 50;
            // 
            // btnAddPayment
            // 
            btnAddPayment.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddPayment.BorderRadius = 5;
            btnAddPayment.Cursor = Cursors.Hand;
            btnAddPayment.CustomizableEdges = customizableEdges5;
            btnAddPayment.DisabledState.BorderColor = Color.DarkGray;
            btnAddPayment.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddPayment.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddPayment.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddPayment.FillColor = Color.FromArgb(58, 38, 19);
            btnAddPayment.Font = new Font("Segoe UI", 9F);
            btnAddPayment.ForeColor = Color.White;
            btnAddPayment.Location = new Point(1248, 40);
            btnAddPayment.Margin = new Padding(3, 2, 3, 2);
            btnAddPayment.Name = "btnAddPayment";
            btnAddPayment.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnAddPayment.Size = new Size(43, 37);
            btnAddPayment.TabIndex = 18;
            btnAddPayment.Text = "✚";
            btnAddPayment.Click += btnAddPayment_Click;
            btnAddPayment.MouseLeave += btnAddPayment_MouseLeave;
            btnAddPayment.MouseHover += btnAddPayment_MouseHover;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(26, 26, 0);
            label2.Location = new Point(19, 58);
            label2.Name = "label2";
            label2.Size = new Size(218, 19);
            label2.TabIndex = 11;
            label2.Text = "Here is the procedure of payment.";
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
            label1.Size = new Size(227, 32);
            label1.TabIndex = 10;
            label1.Text = "Payment Overview";
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1316, 796);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PaymentForm";
            ShowIcon = false;
            tableLayoutPanel1.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2Button btnAddPayment;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPayments;
        private DataGridViewCheckBoxColumn Select;
        private Guna.UI2.WinForms.Guna2Button btnDeletePayment;
        private ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2Button btnPrintReceipt;
    }
}