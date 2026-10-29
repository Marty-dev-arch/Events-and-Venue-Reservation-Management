using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Hotel_Reservation_System.Forms.UserForms
{
    public partial class UserMainForm : Form
    {
        private Guna.UI2.WinForms.Guna2Button currentButton = null;
        private int customerId;
        private string fullName;
        private bool isCoordinator = false;
        public Action OnLogout { get; set; }
        private bool _isLoggingOut = false;

        public UserMainForm(int id, string name, bool isCoordinator = false)
        {
            InitializeComponent();
            this.customerId = id;
            this.fullName = name;
            this.isCoordinator = isCoordinator;

            if (isCoordinator)
            {
                lblWelcome.Text = $"Welcome Coordinator, {fullName}";
                btnBrowseRooms.Text = "Browse Venues";
            }
            else
            {
                lblWelcome.Text = $"Welcome, {fullName}";
            }

            this.Load += UserMainForm_Load;
            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
        }

        public UserMainForm() : this(1, "Guest", false)
        {
        }

        private void LoadForm(Form form)
        {
            panelContainer.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(form);
            form.Show();
        }

        private void HighlightHeaderbarButton(Guna.UI2.WinForms.Guna2Button button)
        {
            // Reset previous button color
            if (currentButton != null)
            {
                currentButton.FillColor = Color.Transparent;
                currentButton.ForeColor = Color.White;
            }

            // Set new button as active
            currentButton = button;
            currentButton.FillColor = Color.FromArgb(0, 51, 51);
            currentButton.ForeColor = Color.White;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            HighlightHeaderbarButton(btnHome);
            LoadForm(new UserDashboardForm(customerId, fullName, isCoordinator));
        }

        private void btnBrowseRooms_Click(object sender, EventArgs e)
        {
            HighlightHeaderbarButton(btnBrowseRooms);
            LoadForm(new BrowseRoomsForm(customerId, fullName, isCoordinator));
        }

        private void btnMyReservations_Click(object sender, EventArgs e)
        {
            HighlightHeaderbarButton(btnMyReservations);
            LoadForm(new MyReservationsForm(customerId, isCoordinator));
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            HighlightHeaderbarButton(btnProfile);
            var profileForm = new ProfileForm(customerId, isCoordinator);
            profileForm.ProfileUpdated += (newName) =>
            {
                UpdateGreeting(newName);
            };
            LoadForm(profileForm);
        }

        public void UpdateGreeting(string newFullName)
        {
            this.fullName = newFullName;
            if (isCoordinator)
            {
                lblWelcome.Text = $"Welcome Coordinator, {fullName}";
            }
            else
            {
                lblWelcome.Text = $"Welcome, {fullName}";
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _isLoggingOut = true;
                this.Close();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (_isLoggingOut)
            {
                OnLogout?.Invoke();
            }
            else
            {
                Application.Exit();
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void UserMainForm_Load(object sender, EventArgs e)
        {
            LoadForm(new UserDashboardForm(customerId, fullName, isCoordinator));
        }
        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
