namespace Hotel_Reservation_System.Forms.UserForms
{
    partial class BrowseRoomsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowseRoomsForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnSearch = new PictureBox();
            txtRoomTypeSearch = new Guna.UI2.WinForms.Guna2TextBox();
            label2 = new Label();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            flowLayoutRooms = new FlowLayoutPanel();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnSearch).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            guna2Panel2.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.AutoScroll = true;
            guna2Panel1.BackgroundImage = (Image)resources.GetObject("guna2Panel1.BackgroundImage");
            guna2Panel1.BackgroundImageLayout = ImageLayout.Stretch;
            guna2Panel1.Controls.Add(btnSearch);
            guna2Panel1.Controls.Add(txtRoomTypeSearch);
            guna2Panel1.Controls.Add(label2);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Margin = new Padding(0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(1657, 364);
            guna2Panel1.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(242, 242, 242);
            btnSearch.BackgroundImage = (Image)resources.GetObject("btnSearch.BackgroundImage");
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Location = new Point(1092, 101);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(37, 28);
            btnSearch.TabIndex = 4;
            btnSearch.TabStop = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtRoomTypeSearch
            // 
            txtRoomTypeSearch.BackColor = Color.Transparent;
            txtRoomTypeSearch.BorderColor = Color.FromArgb(0, 26, 26);
            txtRoomTypeSearch.BorderRadius = 10;
            txtRoomTypeSearch.Cursor = Cursors.Hand;
            txtRoomTypeSearch.CustomizableEdges = customizableEdges1;
            txtRoomTypeSearch.DefaultText = "";
            txtRoomTypeSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtRoomTypeSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtRoomTypeSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtRoomTypeSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtRoomTypeSearch.FillColor = Color.FromArgb(242, 242, 242);
            txtRoomTypeSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRoomTypeSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRoomTypeSearch.ForeColor = Color.Black;
            txtRoomTypeSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRoomTypeSearch.Location = new Point(537, 95);
            txtRoomTypeSearch.Margin = new Padding(438, 15, 3, 4);
            txtRoomTypeSearch.Name = "txtRoomTypeSearch";
            txtRoomTypeSearch.PlaceholderForeColor = Color.FromArgb(125, 137, 149);
            txtRoomTypeSearch.PlaceholderText = "Search by function hall type... (Single, Double, Deluxe, Super Deluxe)";
            txtRoomTypeSearch.SelectedText = "";
            txtRoomTypeSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtRoomTypeSearch.Size = new Size(603, 40);
            txtRoomTypeSearch.TabIndex = 2;
            txtRoomTypeSearch.TextChanged += TxtRoomTypeSearch_TextChanged;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(46, 56);
            label2.Name = "label2";
            label2.Size = new Size(796, 58);
            label2.TabIndex = 1;
            label2.Text = resources.GetString("label2.Text");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(42, 21);
            label1.Name = "label1";
            label1.Size = new Size(354, 37);
            label1.TabIndex = 0;
            label1.Text = "Discover Your Perfect Stay";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(guna2Panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1657, 791);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // guna2Panel2
            // 
            guna2Panel2.AutoScroll = true;
            guna2Panel2.AutoSize = true;
            guna2Panel2.Controls.Add(flowLayoutRooms);
            guna2Panel2.Controls.Add(guna2Panel1);
            guna2Panel2.CustomizableEdges = customizableEdges5;
            guna2Panel2.Dock = DockStyle.Fill;
            guna2Panel2.Location = new Point(0, 0);
            guna2Panel2.Margin = new Padding(0);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.Padding = new Padding(0, 0, 0, 38);
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel2.Size = new Size(1657, 791);
            guna2Panel2.TabIndex = 0;
            // 
            // flowLayoutRooms
            // 
            flowLayoutRooms.AutoScroll = true;
            flowLayoutRooms.AutoSize = true;
            flowLayoutRooms.Dock = DockStyle.Fill;
            flowLayoutRooms.Location = new Point(0, 364);
            flowLayoutRooms.Margin = new Padding(3, 2, 3, 2);
            flowLayoutRooms.Name = "flowLayoutRooms";
            flowLayoutRooms.Padding = new Padding(44, 0, 18, 15);
            flowLayoutRooms.Size = new Size(1657, 389);
            flowLayoutRooms.TabIndex = 2;
            flowLayoutRooms.Paint += flowLayoutRooms_Paint_2;
            // 
            // BrowseRoomsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(1657, 791);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "BrowseRoomsForm";
            ShowIcon = false;
            Load += BrowseRoomsForm_Load;
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnSearch).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            guna2Panel2.ResumeLayout(false);
            guna2Panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label label2;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private FlowLayoutPanel flowLayoutRooms;
        private Guna.UI2.WinForms.Guna2TextBox txtRoomTypeSearch;
        private PictureBox btnSearch;
    }
}