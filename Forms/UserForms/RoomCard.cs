using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Reservation_System.Forms.UserForms
{
    public partial class RoomCard : UserControl
    {
        public int RoomId { get; set; }



        private string roomType;
        private int capacity;
        private int beds;
        private string venueLocation = "Big 8";

        public string RoomNumber
        {
            get { return lblRoomNumber.Text; }
            set { lblRoomNumber.Text = "Function Hall No: " + value; }
        }

        public string VenueLocation
        {
            get => venueLocation;
            set
            {
                venueLocation = string.IsNullOrWhiteSpace(value) ? "Big 8" : value;
                lblVenueLocation.Text = $"Venue Location: {venueLocation}";
            }
        }

        public string RoomType
        {
            set
            {
                roomType = value;
                lblType.Text = $"Function Hall Type: {value}";
            }
        }

        public decimal Rate
        {
            set => lblRate.Text = $"Hall Rate: ₱{value:N2}";
        }

        public int Capacity
        {
            get => capacity;
            set
            {
                capacity = value;
                lblCapacity.Text = $"Capacity: {value} Person{(value == 1 ? "" : "s")}";
            }
        }

        public int Beds
        {
            get => beds;
            set
            {
                beds = value;
                UpdateBeds();
            }
        }

        public bool IsAvailable
        {
            set => SetAvailability(value);
        }

        public Image RoomImage
        {
            set => pictureBoxRoom.Image = value;
        }

        public RoomCard()
        {
            InitializeComponent();
        }

        public void SetRoomDetails(int roomId, string roomNumber, string type, decimal rate, bool available, byte[] imageData, int capacity, int beds = 0, string venueLocation = "Big 8", string unavailableReason = null)
        {
            RoomId = roomId;
            RoomNumber = roomNumber;
            VenueLocation = venueLocation;
            RoomType = type;
            Rate = rate;
            SetAvailability(available, unavailableReason);
            Capacity = capacity;
            Beds = beds;

            if (imageData != null)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pictureBoxRoom.Image = Image.FromStream(ms);
                }
            }
        }

        private void SetAvailability(bool available, string unavailableReason = null)
        {
            lblAvailable.Text = available
                ? "Available"
                : string.IsNullOrWhiteSpace(unavailableReason)
                    ? "Unavailable"
                    : $"Unavailable: {unavailableReason}";
            lblAvailable.ForeColor = available ? Color.Green : Color.Red;
            btnReserve.Enabled = available;
        }

        private void UpdateBeds()
        {
            lblBeds.Text = $"Tables: {beds} Table{(beds == 1 ? "" : "s")}";
        }

        public event EventHandler<int> ReserveClicked;

        private void btnReserve_Click(object sender, EventArgs e)
        {
            ReserveClicked?.Invoke(this, RoomId);
        }

        private void RoomCard_Load(object sender, EventArgs e) { }

        private void panelMain_Paint(object sender, PaintEventArgs e) { }

        private void pictureBoxRoom_Click(object sender, EventArgs e) { }

        private void lblBeds_Click(object sender, EventArgs e) { }
    }
}
