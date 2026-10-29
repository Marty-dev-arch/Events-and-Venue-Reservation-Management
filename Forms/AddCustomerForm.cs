using Hotel_Reservation_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Reservation_System.Forms
{
    public partial class AddCustomerForm : Form
    {
        //public string FullName => txtFullName.Text;
        //public string Email => txtEmail.Text;
        //public string ContactNumber => txtContactNumber.Text;
        //public string Address => txtAddress.Text;

        public string FullName { get; private set; }
        public string ContactNumber { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public Customer NewCustomer { get; private set; }

        public AddCustomerForm()
        {
            InitializeComponent();

            // Set modal properties
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.AcceptButton = btnAdd;
            this.CancelButton = btnCancel;
        }
        public void SetCustomerData(string fullName, string contactNumber, string email, string address)
        {
            txtFullName.Text = fullName;
            txtContactNumber.Text = contactNumber;
            txtEmail.Text = email;
            txtAddress.Text = address;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtContactNumber.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                ShowCustomMessageBox("Missing Information", "Please fill in all fields.", 500, 200);
                return;
            }

            // Pass values back to CustomerForm
            FullName = txtFullName.Text;
            ContactNumber = txtContactNumber.Text;
            Email = txtEmail.Text;
            Address = txtAddress.Text;

            NewCustomer = new Customer
            {
                FullName = txtFullName.Text,
                ContactNumber = txtContactNumber.Text,
                Email = txtEmail.Text,
                Address = txtAddress.Text
            };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtContactNumber.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContactNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
