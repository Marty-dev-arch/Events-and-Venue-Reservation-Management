using Hotel_Reservation_System.Database;
using Hotel_Reservation_System.Models;
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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hotel_Reservation_System.Forms
{
    public partial class PaymentForm : Form
    {
        private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private Payment selectedPayment;
        public PaymentForm()
        {
            InitializeComponent();
            LoadPayments();
        }

        private void LoadPayments()
        {
            var payments = PaymentDAO.GetAllPayments();
            dgvPayments.DataSource = payments;

            if (dgvPayments.Columns["Select"] != null)
            {
                dgvPayments.Columns["Select"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPayments.Columns["Select"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPayments.Columns["PaymentId"] != null)
            {
                dgvPayments.Columns["PaymentId"].HeaderText = "Payment ID";
                dgvPayments.Columns["PaymentId"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPayments.Columns["PaymentId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPayments.Columns["ReservationId"] != null)
            {
                dgvPayments.Columns["ReservationId"].HeaderText = "Reservation ID";
                dgvPayments.Columns["ReservationId"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPayments.Columns["ReservationId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPayments.Columns["FullName"] != null)
            {
                dgvPayments.Columns["FullName"].HeaderText = "Customer Name";
                dgvPayments.Columns["FullName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvPayments.Columns["FullName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvPayments.Columns["FullName"].HeaderCell.Style.Padding = new Padding(12, 0, 0, 0);
                dgvPayments.Columns["FullName"].DefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
            }

            if (dgvPayments.Columns["Amount"] != null)
            {
                dgvPayments.Columns["Amount"].DefaultCellStyle.Format = "N2";
                dgvPayments.Columns["Amount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPayments.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPayments.Columns["Amount"].HeaderCell.Style.Padding = new Padding(0, 0, 16, 0);
                dgvPayments.Columns["Amount"].DefaultCellStyle.Padding = new Padding(0, 0, 16, 0);
            }

            if (dgvPayments.Columns["PaymentDate"] != null)
            {
                dgvPayments.Columns["PaymentDate"].HeaderText = "Payment Date";
                dgvPayments.Columns["PaymentDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvPayments.Columns["PaymentDate"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPayments.Columns["PaymentDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPayments.Columns["PaymentMethod"] != null)
            {
                dgvPayments.Columns["PaymentMethod"].HeaderText = "Payment Method";
                dgvPayments.Columns["PaymentMethod"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPayments.Columns["PaymentMethod"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private int? GetSelectedReservationId()
        {
            if (dgvPayments.CurrentRow != null)
            {
                object value = dgvPayments.CurrentRow.Cells["ReservationId"].Value;  // Ensure column Name is "ReservationId"
                if (value != DBNull.Value && value != null)
                {
                    return Convert.ToInt32(value);
                }
            }
            return null;
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddPaymentForm())  // No need to pass reservationId yet
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadPayments();
                }
            }
        }

        private void btnDeletePayment_Click(object sender, EventArgs e)
        {
            List<int> selectedPaymentIds = GetSelectedPaymentIds();

            if (selectedPaymentIds.Count == 0)
            {
                ShowCustomMessageBox("Selection Needed", "Please select at least one payment to delete.", 500, 200);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected payments?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool allDeleted = true;
                foreach (int id in selectedPaymentIds)
                {
                    bool success = PaymentDAO.DeletePayment(id);
                    if (!success)
                    {
                        allDeleted = false;
                    }
                }

                if (allDeleted)
                {
                    ShowCustomMessageBox("Success", "Selected payments deleted successfully!", 500, 200);
                }
                else
                {
                    ShowCustomMessageBox("Error", "Some payments failed to delete.", 500, 200);
                }

                LoadPayments();
            }
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

            Button okButton = new Button();
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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvPayments.Columns[e.ColumnIndex].Name == "Select")
            {
                dgvPayments.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnDeletePayment_MouseHover(object sender, EventArgs e)
        {
            Point location = new Point(btnDeletePayment.Width, 0); // Top-right of the button
            toolTip.Show("Delete", btnDeletePayment, location);
        }

        private void btnDeletePayment_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(btnDeletePayment);
        }

        private void btnAddPayment_MouseHover(object sender, EventArgs e)
        {
            Point location = new Point(btnAddPayment.Width, 0); // Top-right of the button
            toolTip.Show("Add", btnAddPayment, location);
        }

        private void btnAddPayment_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(btnAddPayment);
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            List<int> selectedPaymentIds = GetSelectedPaymentIds();
            if (selectedPaymentIds.Count == 0)
            {
                ShowCustomMessageBox("Selection Needed", "Please select a payment to generate a receipt.", 500, 200);
                return;
            }

            if (selectedPaymentIds.Count > 1)
            {
                ShowCustomMessageBox("Select One Payment", "Select exactly one payment to generate a receipt.", 500, 200);
                return;
            }

            try
            {
                var payment = PaymentDAO.GetPaymentById(selectedPaymentIds[0]);
                if (payment == null)
                {
                    ShowCustomMessageBox("Not Found", "Payment details not found.", 400, 180);
                    return;
                }

                using var receiptForm = new ReceiptForm(payment);
                receiptForm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                ShowCustomMessageBox("Receipt Error", ex.Message, 500, 200);
            }
        }

        private List<int> GetSelectedPaymentIds()
        {
            dgvPayments.EndEdit();
            var selectedPaymentIds = new List<int>();

            foreach (DataGridViewRow row in dgvPayments.Rows)
            {
                if (row.IsNewRow)
                    continue;

                object? selectedValue = row.Cells["Select"].Value;
                if (selectedValue != null && selectedValue != DBNull.Value && Convert.ToBoolean(selectedValue))
                {
                    selectedPaymentIds.Add(Convert.ToInt32(row.Cells["PaymentId"].Value));
                }
            }

            return selectedPaymentIds;
        }
    }
}
