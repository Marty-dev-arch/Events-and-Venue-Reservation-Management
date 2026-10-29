using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_Reservation_System.Models;

namespace Hotel_Reservation_System.Forms
{
    public partial class ReceiptForm : Form
    {
        private Payment payment;
        private PrintDocument printDoc;
        private PrintPreviewDialog previewDialog;

        public ReceiptForm(Payment payment)
        {
            InitializeComponent();
            this.payment = payment;

            lblPaymentId.Text = "Payment ID: " + payment.PaymentId;
            lblCustomerName.Text = "Customer Name: " + payment.FullName;
            lblAmount.Text = "Amount: ₱" + payment.Amount.ToString("N2");
            lblDate.Text = "Date: " + payment.PaymentDate.ToString("yyyy-MM-dd");
            lblMethod.Text = "Method: " + payment.PaymentMethod;

            SetupPrinting();
        }

        private void SetupPrinting()
        {
            printDoc = new PrintDocument();
            printDoc.DocumentName = $"Receipt_Payment_{payment?.PaymentId}";
            printDoc.PrintPage += PrintDoc_PrintPage;

            previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDoc;
            previewDialog.Width = 600;
            previewDialog.Height = 700;
            previewDialog.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (previewDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Printing error: " + ex.Message, "Print Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float leftMargin = 50;
            float topMargin = 50;
            float width = 450;

            using (Font titleFont = new Font("Segoe UI", 16, FontStyle.Bold))
            using (Font subTitleFont = new Font("Segoe UI", 11, FontStyle.Regular))
            using (Font headerFont = new Font("Segoe UI", 10, FontStyle.Bold))
            using (Font normalFont = new Font("Segoe UI", 10, FontStyle.Regular))
            using (Font totalFont = new Font("Segoe UI", 14, FontStyle.Bold))
            using (Pen linePen = new Pen(Color.FromArgb(200, 200, 200), 1))
            using (Pen borderPen = new Pen(Color.FromArgb(0, 128, 128), 2))
            using (Brush darkBrush = new SolidBrush(Color.FromArgb(30, 30, 30)))
            using (Brush tealBrush = new SolidBrush(Color.FromArgb(0, 128, 128)))
            using (Brush grayBrush = new SolidBrush(Color.FromArgb(100, 100, 100)))
            {
                float y = topMargin;

                // Outer border
                g.DrawRectangle(borderPen, leftMargin - 15, topMargin - 15, width + 30, 480);

                // Header
                g.DrawString("HOTEL RESERVATION & EVENT SYSTEM", titleFont, tealBrush, leftMargin, y);
                y += 30;
                g.DrawString("Official Payment Receipt", subTitleFont, grayBrush, leftMargin, y);
                y += 28;

                g.DrawLine(linePen, leftMargin, y, leftMargin + width, y);
                y += 20;

                // Receipt details
                void DrawRow(string label, string value)
                {
                    g.DrawString(label, headerFont, grayBrush, leftMargin, y);
                    g.DrawString(value, normalFont, darkBrush, leftMargin + 160, y);
                    y += 26;
                }

                DrawRow("Receipt No:", $"REC-{payment.PaymentId:D6}");
                DrawRow("Reservation ID:", $"#{payment.ReservationId}");
                DrawRow("Date & Time:", payment.PaymentDate.ToString("MMMM dd, yyyy hh:mm tt"));
                DrawRow("Customer Name:", payment.FullName ?? "N/A");
                DrawRow("Payment Method:", payment.PaymentMethod ?? "Cash");

                y += 10;
                g.DrawLine(linePen, leftMargin, y, leftMargin + width, y);
                y += 20;

                // Total Amount Paid
                g.DrawString("Total Amount Paid:", totalFont, darkBrush, leftMargin, y);
                string amtStr = $"₱{payment.Amount:N2}";
                g.DrawString(amtStr, totalFont, tealBrush, leftMargin + 220, y);
                y += 35;

                // PAID Badge
                Rectangle badgeRect = new Rectangle((int)leftMargin, (int)y, 90, 28);
                g.FillRectangle(new SolidBrush(Color.FromArgb(230, 245, 230)), badgeRect);
                g.DrawRectangle(new Pen(Color.FromArgb(46, 125, 50), 1.5f), badgeRect);
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString("PAID", new Font("Segoe UI", 10, FontStyle.Bold), new SolidBrush(Color.FromArgb(46, 125, 50)), badgeRect, sf);

                y += 45;
                g.DrawLine(linePen, leftMargin, y, leftMargin + width, y);
                y += 18;

                // Footer note
                g.DrawString("Thank you for choosing our venue and services!", new Font("Segoe UI", 9, FontStyle.Italic), grayBrush, leftMargin, y);
                y += 20;
                g.DrawString("This document serves as your verified proof of transaction.", new Font("Segoe UI", 8, FontStyle.Regular), grayBrush, leftMargin, y);
            }
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {

        }
    }
}
