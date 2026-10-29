using System.Windows.Forms;

namespace Hotel_Reservation_System.Forms
{
    partial class CustomerForm
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
            dgvCustomers = new Guna.UI2.WinForms.Guna2DataGridView();
            Select = new DataGridViewCheckBoxColumn();
            btnDelete = new Guna.UI2.WinForms.Guna2Button();
            btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            label3 = new Label();
            toolTip1 = new ToolTip(components);
            tableLayoutPanel1.SuspendLayout();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
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
            tableLayoutPanel1.Size = new Size(1306, 791);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // guna2Panel1
            // 
            guna2Panel1.AutoScroll = true;
            guna2Panel1.Controls.Add(dgvCustomers);
            guna2Panel1.Controls.Add(btnDelete);
            guna2Panel1.Controls.Add(btnUpdate);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.Controls.Add(label3);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.Dock = DockStyle.Fill;
            guna2Panel1.Location = new Point(3, 2);
            guna2Panel1.Margin = new Padding(3, 2, 3, 2);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(1300, 787);
            guna2Panel1.TabIndex = 0;
            guna2Panel1.Paint += guna2Panel1_Paint;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToOrderColumns = true;
            dgvCustomers.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCustomers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(59, 39, 18);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 153, 153);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCustomers.ColumnHeadersHeight = 50;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.Columns.AddRange(new DataGridViewColumn[] { Select });
            dgvCustomers.Cursor = Cursors.Hand;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.Padding = new Padding(1, 2, 0, 2);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(242, 230, 217);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCustomers.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCustomers.GridColor = Color.FromArgb(59, 39, 18);
            dgvCustomers.Location = new Point(20, 126);
            dgvCustomers.Margin = new Padding(3, 2, 3, 2);
            dgvCustomers.Name = "dgvCustomers";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvCustomers.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Padding = new Padding(2);
            dgvCustomers.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvCustomers.RowTemplate.Height = 60;
            dgvCustomers.Size = new Size(1260, 642);
            dgvCustomers.TabIndex = 8;
            dgvCustomers.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvCustomers.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvCustomers.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvCustomers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvCustomers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvCustomers.ThemeStyle.BackColor = Color.White;
            dgvCustomers.ThemeStyle.GridColor = Color.FromArgb(59, 39, 18);
            dgvCustomers.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvCustomers.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dgvCustomers.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvCustomers.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvCustomers.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvCustomers.ThemeStyle.HeaderStyle.Height = 50;
            dgvCustomers.ThemeStyle.ReadOnly = false;
            dgvCustomers.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvCustomers.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomers.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvCustomers.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvCustomers.ThemeStyle.RowsStyle.Height = 60;
            dgvCustomers.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvCustomers.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
            // 
            // Select
            // 
            Select.HeaderText = "Select";
            Select.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Select.MinimumWidth = 50;
            Select.Name = "Select";
            Select.Width = 50;
            // 
            // btnDelete
            // 
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
            btnDelete.Location = new Point(1180, 94);
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnDelete.Size = new Size(93, 26);
            btnDelete.TabIndex = 23;
            btnDelete.Text = "\U0001f9fe️ Delete";
            btnDelete.Click += btnDelete_Click;
            btnDelete.MouseLeave += btnDelete_MouseLeave;
            btnDelete.MouseHover += btnDelete_MouseHover;
            // 
            // btnUpdate
            // 
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
            btnUpdate.Location = new Point(1082, 94);
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnUpdate.Size = new Size(93, 26);
            btnUpdate.TabIndex = 22;
            btnUpdate.Text = "📝 Update";
            btnUpdate.Click += btnUpdate_Click;
            btnUpdate.MouseLeave += btnUpdate_MouseLeave;
            btnUpdate.MouseHover += btnUpdate_MouseHover;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(26, 26, 0);
            label1.Location = new Point(19, 58);
            label1.Name = "label1";
            label1.Size = new Size(294, 19);
            label1.TabIndex = 21;
            label1.Text = "Easily Manage Guest Information and Records.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 0, 51);
            label3.Location = new Point(16, 20);
            label3.Name = "label3";
            label3.Size = new Size(282, 32);
            label3.TabIndex = 20;
            label3.Text = "Customer Management";
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1306, 791);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CustomerForm";
            ShowIcon = false;
            Load += CustomerForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCustomers;
        private ToolTip toolTip1;
        private Label label3;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private DataGridViewCheckBoxColumn Select;
    }
}