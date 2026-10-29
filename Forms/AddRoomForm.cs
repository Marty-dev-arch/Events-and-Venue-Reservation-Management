using Hotel_Reservation_System.Database;
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
    public partial class AddRoomForm : Form
    {
        public string RoomNumber => txtRoomNumber.Text;
        public string VenueLocation => cmbVenueLocation.SelectedItem?.ToString() ?? cmbVenueLocation.Text ?? "Big 8";
        public string EventType => "Wedding";
        public string RoomType => txtRoomType.Text;
        public decimal Rate => decimal.Parse(txtRate.Text);
        public bool Availability => chkAvailable.Checked;
        public bool Maintenance => chkMaintenance.Checked;
        public byte[] ImageData { get; private set; }
        public int Capacity => (int)nudCapacity.Value;
        public int Beds => (int)nudBeds.Value;

        private string selectedImagePath = null;

        System.Windows.Forms.Button okButton = new System.Windows.Forms.Button();

        public Room NewRoom { get; private set; }

        public AddRoomForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.AcceptButton = btnAdd;
            this.CancelButton = btnCancel;

            // When adding a new venue in admin, default to Available (NOT booked)
            chkAvailable.Checked = true;
            chkMaintenance.Checked = false;
        }

        public void SetRoomData(string roomNumber, string roomType, decimal rate, bool availability, bool maintenance, byte[] imageData, int capacity, int beds, string venueLocation = "Big 8", string eventType = "Wedding")
        {
            txtRoomNumber.Text = roomNumber;
            txtRoomType.Text = roomType;
            txtRate.Text = rate.ToString();
            chkAvailable.Checked = availability; 
            chkMaintenance.Checked = maintenance;
            chkAvailable.Enabled = !maintenance;
            ImageData = imageData;
            nudCapacity.Value = capacity;
            nudBeds.Value = beds;

            if (!string.IsNullOrWhiteSpace(venueLocation))
            {
                int idx = cmbVenueLocation.FindStringExact(venueLocation);
                if (idx >= 0) cmbVenueLocation.SelectedIndex = idx;
                else cmbVenueLocation.Text = venueLocation;
            }

            if (imageData != null)
            {
                using (var ms = new MemoryStream(imageData))
                {
                    pictureBoxPreview.Image = Image.FromStream(ms);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomType.Text) || string.IsNullOrWhiteSpace(txtRate.Text) || string.IsNullOrWhiteSpace(txtRoomNumber.Text))
            {
                ShowCustomMessageBox("Missing Information", "Please fill out all fields.", 500, 200);
                return;
            }

            if (!decimal.TryParse(txtRate.Text, out _))
            {
                ShowCustomMessageBox("Error", "Invalid rate.", 500, 200);
                return;
            }

            byte[] imageBytes = null;

            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                try
                {
                    imageBytes = File.ReadAllBytes(selectedImagePath); // Load image as byte array
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading image: " + ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            NewRoom = new Room
            {
                RoomNumber = txtRoomNumber.Text,
                VenueLocation = VenueLocation,
                EventType = EventType,
                FunctionhallType = txtRoomType.Text,
                Rate = decimal.Parse(txtRate.Text),
                Availability = chkAvailable.Checked,
                Maintenance = chkMaintenance.Checked,
                ImageData = imageBytes,
                Capacity = (int)nudCapacity.Value,
                Beds = (int)nudBeds.Value
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void SetImageData(byte[] imageData)
        {
            if (imageData != null)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBoxPreview.Image = Image.FromStream(ms);
                    pictureBoxPreview.SizeMode = PictureBoxSizeMode.StretchImage;
                    ImageData = imageData;
                }
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtRoomNumber_TextChanged(object sender, EventArgs e)
        {

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

        private void chkMaintenance_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMaintenance.Checked)
            {
                chkAvailable.Checked = false;
                chkAvailable.Enabled = false;
            }
            else
            {
                chkAvailable.Enabled = true;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                ImageData = File.ReadAllBytes(selectedImagePath);
                pictureBoxPreview.Image = Image.FromFile(selectedImagePath);
                pictureBoxPreview.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
