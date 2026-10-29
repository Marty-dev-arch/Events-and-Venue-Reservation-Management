namespace Hotel_Reservation_System.Forms
{
    partial class ReceiptForm
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
            lblPaymentId = new Label();
            lblCustomerName = new Label();
            lblAmount = new Label();
            lblDate = new Label();
            lblMethod = new Label();
            btnPrint = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblPaymentId
            // 
            lblPaymentId.AutoSize = true;
            lblPaymentId.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentId.Location = new Point(24, 69);
            lblPaymentId.Name = "lblPaymentId";
            lblPaymentId.Size = new Size(67, 17);
            lblPaymentId.TabIndex = 0;
            lblPaymentId.Text = "Payment:";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerName.Location = new Point(24, 96);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(113, 17);
            lblCustomerName.TabIndex = 1;
            lblCustomerName.Text = "Customer Name:";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAmount.Location = new Point(24, 120);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(60, 17);
            lblAmount.TabIndex = 2;
            lblAmount.Text = "Amount:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.Location = new Point(24, 149);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(101, 17);
            lblDate.TabIndex = 3;
            lblDate.Text = "Payment Date:";
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMethod.Location = new Point(24, 176);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(118, 17);
            lblMethod.TabIndex = 4;
            lblMethod.Text = "Payment method:";
            // 
            // btnPrint
            // 
            btnPrint.BorderRadius = 5;
            btnPrint.CustomizableEdges = customizableEdges1;
            btnPrint.DisabledState.BorderColor = Color.DarkGray;
            btnPrint.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPrint.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPrint.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPrint.FillColor = Color.FromArgb(0, 26, 26);
            btnPrint.Font = new Font("Segoe UI", 9F);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(111, 219);
            btnPrint.Margin = new Padding(3, 2, 3, 2);
            btnPrint.Name = "btnPrint";
            btnPrint.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnPrint.Size = new Size(122, 28);
            btnPrint.TabIndex = 5;
            btnPrint.Text = "Print";
            btnPrint.Click += btnPrint_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(123, 17);
            label1.Name = "label1";
            label1.Size = new Size(99, 30);
            label1.TabIndex = 6;
            label1.Text = "RECEIPT";
            // 
            // ReceiptForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 267);
            Controls.Add(label1);
            Controls.Add(btnPrint);
            Controls.Add(lblMethod);
            Controls.Add(lblDate);
            Controls.Add(lblAmount);
            Controls.Add(lblCustomerName);
            Controls.Add(lblPaymentId);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ReceiptForm";
            RightToLeftLayout = true;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += ReceiptForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnPrint;
        private Label label1;
        private Label lblPaymentId;
        private Label lblCustomerName;
        private Label lblAmount;
        private Label lblDate;
        private Label lblMethod;
    }
}