using Hotel_Reservation_System.Database;
using Hotel_Reservation_System.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hotel_Reservation_System.Forms
{
    public partial class AddPaymentForm : Form
    {
        public AddPaymentForm()
        {
            InitializeComponent();
        }

        private void AddPaymentForm_Load(object sender, EventArgs e)
        {
            LoadReservations();

            cmbPaymentMethod.Items.AddRange(new string[] { "Cash", "Credit Card", "GCash", "PayPal" });
            cmbPaymentMethod.SelectedIndex = 0;
        }

        public class ReservationComboItem
        {
            public int ReservationId { get; set; }
            public string DisplayText { get; set; } = string.Empty;
        }

        private void LoadReservations()
        {
            var reservations = ReservationDAO.GetAllReservations();
            var reservationList = new List<ReservationComboItem>();

            foreach (var res in reservations)
            {
                reservationList.Add(new ReservationComboItem
                {
                    DisplayText = $"Reservation #{res.ReservationId} - {res.CustomerName}",
                    ReservationId = res.ReservationId
                });
            }

            cmbReservation.DisplayMember = "DisplayText";
            cmbReservation.ValueMember = "ReservationId";
            cmbReservation.DataSource = reservationList;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbReservation.SelectedItem == null)
            {
                ShowCustomMessageBox("Validation", "Please select a reservation.", 500, 200);
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                ShowCustomMessageBox("Validation", "Please enter a valid amount.", 500, 200);
                return;
            }

            string paymentMethod = cmbPaymentMethod.Text.Trim();
            if (string.IsNullOrEmpty(paymentMethod))
            {
                ShowCustomMessageBox("Validation", "Please enter a payment method.", 500, 200);
                return;
            }

            int reservationId = (int)cmbReservation.SelectedValue;
            DateTime paymentDate = dtpPaymentDate.Value;

            var payment = new Payment
            {
                ReservationId = reservationId,
                Amount = amount,
                PaymentDate = paymentDate,
                PaymentMethod = paymentMethod
            };

            PaymentDAO.AddPayment(payment);
            ShowCustomMessageBox("Success", "Payment added successfully.", 500, 200);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowCustomMessageBox(string title, string message, int width, int height)
        {
            Form customBox = new Form();
            customBox.Text = title;
            customBox.Size = new Size(width, height);
            customBox.StartPosition = FormStartPosition.CenterScreen;
            customBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            customBox.MaximizeBox = false;
            customBox.MinimizeBox = false;

            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.AutoSize = false;
            lblMessage.Font = new Font("Segoe UI", 10);
            lblMessage.Size = new Size(width - 40, height - 120);
            lblMessage.Location = new Point(20, 20);

            System.Windows.Forms.Button okButton = new System.Windows.Forms.Button();
            okButton.Text = "OK";
            okButton.Size = new Size(80, 30);
            okButton.Cursor = Cursors.Hand;
            okButton.Click += (s, e) => customBox.Close();

            customBox.Controls.Add(lblMessage);
            customBox.Controls.Add(okButton);

            customBox.Shown += (s, e) =>
            {
                int padding = 15;
                okButton.Location = new Point(
                    customBox.ClientSize.Width - okButton.Width - padding,
                    customBox.ClientSize.Height - okButton.Height - padding
                );
            };

            customBox.ShowDialog();
        }
    }
}
