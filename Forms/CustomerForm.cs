using Hotel_Reservation_System.Database;
using Hotel_Reservation_System.Models;
using HotelReservationSystem.Models;
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
    public partial class CustomerForm : Form
    {
        private System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private System.Windows.Forms.TextBox txtFullName = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.TextBox txtContactNumber = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.TextBox txtEmail = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.TextBox txtAddress = new System.Windows.Forms.TextBox();
        System.Windows.Forms.Button okButton = new System.Windows.Forms.Button();

        private List<Customer> customers;
        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            //this.Controls.Add(txtFullName);
            //this.Controls.Add(txtContactNumber);
            //this.Controls.Add(txtEmail);
            //this.Controls.Add(txtAddress);
            // You can set options here if you want
            toolTip.AutoPopDelay = 2000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 100;
            toolTip.ShowAlways = true;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdate_MouseHover(object sender, EventArgs e)
        {
            Point location = new Point(btnUpdate.Width, 0); // Top-right of the button
            toolTip.Show("Update", btnUpdate, location);
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(btnUpdate);
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            Point location = new Point(btnDelete.Width, 0); // Top-right of the button
            toolTip.Show("Delete", btnDelete, location);
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(btnDelete);
        }

        private void LoadCustomers()
        {
            customers = CustomerDAO.GetAllCustomers();
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = customers;
            if (dgvCustomers.Columns["CustomerId"] != null)
            {
                dgvCustomers.Columns["CustomerId"].Visible = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<int> selectedIds = new List<int>();
            DataGridViewRow selectedRow = null;

            foreach (DataGridViewRow row in dgvCustomers.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                {
                    int customerId = Convert.ToInt32(row.Cells["CustomerId"].Value);
                    selectedIds.Add(customerId);
                    selectedRow = row;
                }
            }

            if (selectedIds.Count == 0)
            {
                ShowCustomMessageBox("Selection Needed", "Please select one customer to update.", 500, 200);
                return;
            }

            if (selectedIds.Count > 1)
            {
                ShowCustomMessageBox("Reminder", "Please select only one customer to update at a time.", 500, 200);
                return;
            }

            // Get customer data from selected row
            int id = Convert.ToInt32(selectedRow.Cells["CustomerId"].Value);
            string fullName = selectedRow.Cells["FullName"].Value.ToString();
            string contactNumber = selectedRow.Cells["ContactNumber"].Value.ToString();
            string email = selectedRow.Cells["Email"].Value.ToString();
            string address = selectedRow.Cells["Address"].Value.ToString();

            // Open AddCustomerForm with pre-filled data
            AddCustomerForm updateForm = new AddCustomerForm();
            updateForm.SetCustomerData(fullName, contactNumber, email, address);

            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                // Get updated customer from form
                Customer updatedCustomer = updateForm.NewCustomer;
                updatedCustomer.CustomerId = id; // important to keep the ID

                bool success = CustomerDAO.UpdateCustomer(updatedCustomer);
                if (success)
                {
                    ShowCustomMessageBox("Success", "Customer updated successfully!", 500, 200);
                }
                else
                {
                    ShowCustomMessageBox("Error", "Failed to update customer.", 500, 200);
                }

                LoadCustomers();
                ClearFields();
            }
        }

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //if (dgvCustomers.CurrentRow == null)
        //{
        //MessageBox.Show("Please select a room to delete.");
        //return;
        //}

        //int selectedId = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["CustomerId"].Value);

        //DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //if (result == DialogResult.Yes)
        //{
        //bool success = CustomerDAO.DeleteCustomer(selectedId);
        //if (success)
        //{
        //MessageBox.Show("Customer deleted successfully!");
        //}
        //else
        //{
        //MessageBox.Show("Failed to delete customer.");
        //}

        //LoadCustomers();
        //ClearFields();
        //}
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<int> selectedIds = new List<int>();

            foreach (DataGridViewRow row in dgvCustomers.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                {
                    int customerId = Convert.ToInt32(row.Cells["CustomerId"].Value);
                    selectedIds.Add(customerId);
                }
            }

            if (selectedIds.Count == 0)
            {
                ShowCustomMessageBox("Selection Needed", "Please select at least one customer to delete.", 500, 200);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected customers?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool allDeleted = true;
                foreach (int id in selectedIds)
                {
                    bool success = CustomerDAO.DeleteCustomer(id);
                    if (!success)
                    {
                        allDeleted = false;
                    }
                }

                if (allDeleted)
                {
                    ShowCustomMessageBox("Success", "Selected customers deleted successfully!", 500, 200);
                }
                else
                {
                    ShowCustomMessageBox("Error", "Some customers failed to delete.", 500, 200);
                }

                LoadCustomers();
                ClearFields();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                ShowCustomMessageBox("Selection Needed", "Please select a customer to update.", 500, 200);
                return;
            }

            int selectedId = Convert.ToInt32(dgvCustomers.CurrentRow.Cells["CustomerId"].Value);


            Customer updatedCustomer = new Customer
            {
                CustomerId = selectedId,
                FullName = txtFullName.Text,
                ContactNumber = txtContactNumber.Text,
                Email = txtEmail.Text,
                Address = txtAddress.Text
            };

            DialogResult result = MessageBox.Show("Are you sure you want to clear this customer information?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool success = CustomerDAO.UpdateCustomer(updatedCustomer);
                if (success)
                {
                    MessageBox.Show("Customer information cleared successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to clear customer information.");
                }
                LoadCustomers();
                ClearFields();
            }

        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtFullName.Text = dgvCustomers.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                txtContactNumber.Text = dgvCustomers.Rows[e.RowIndex].Cells["ContactNumber"].Value.ToString();
                txtEmail.Text = dgvCustomers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtAddress.Text = dgvCustomers.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            }
        }

        private void ClearFields()
        {
            txtFullName.Clear();
            txtContactNumber.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //foreach (DataGridViewRow row in dgvCustomers.Rows)
            //{
                //bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                //if (isSelected)
                //{
                    // Example: Get FullName of selected customer
                    //string fullName = row.Cells["FullName"].Value.ToString();
                    //string contactNumber = row.Cells["ContactNumber"].Value.ToString();
                    //string email = row.Cells["Email"].Value.ToString();
                    //string address = row.Cells["Address"].Value.ToString();
                    //MessageBox.Show(fullName);
                    //MessageBox.Show(contactNumber);
                    //MessageBox.Show(email);
                    //MessageBox.Show(address);
                //}
            //}
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
