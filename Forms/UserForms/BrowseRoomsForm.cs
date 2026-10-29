using Hotel_Reservation_System.Models;
using HotelReservationSystem.Models;
using Hotel_Reservation_System.Database;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // Required for MemoryStream
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Reservation_System.Forms.UserForms
{
    public partial class BrowseRoomsForm : Form
    {
        private int customerId;
        private string fullName;
        private bool isCoordinator;
        private System.Windows.Forms.Timer searchDebounceTimer;

        public BrowseRoomsForm(int customerId, string fullName, bool isCoordinator = false)
        {
            InitializeComponent();
            this.customerId = customerId;
            this.fullName = fullName;
            this.isCoordinator = isCoordinator;
            LoadRooms();

            searchDebounceTimer = new System.Windows.Forms.Timer();
            searchDebounceTimer.Interval = 300; // 300 ms debounce
            searchDebounceTimer.Tick += SearchDebounceTimer_Tick;

            txtRoomTypeSearch.TextChanged += (s, ev) =>
            {
                searchDebounceTimer.Stop();
                searchDebounceTimer.Start();
            };
        }

        private void LoadRooms(string roomTypeFilter = "")
        {
            flowLayoutRooms.Controls.Clear();

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT room_id, room_number, room_type, rate, availability, maintenance, image_data, capacity, beds, venue_location,
                                        CASE WHEN EXISTS (
                                            SELECT 1
                                            FROM reservations r
                                            WHERE r.room_id = rooms.room_id
                                              AND LOWER(LTRIM(RTRIM(ISNULL(r.status, '')))) IN ('pending', 'confirmed', 'checked in', 'checked-in')
                                              AND r.check_out_date >= CAST(GETDATE() AS DATE)
                                        ) THEN 1 ELSE 0 END AS has_active_reservation
                                 FROM rooms";

                if (!string.IsNullOrWhiteSpace(roomTypeFilter))
                {
                    query += " WHERE (room_type LIKE @filter OR venue_location LIKE @filter)";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(roomTypeFilter))
                    {
                        cmd.Parameters.AddWithValue("@filter", "%" + roomTypeFilter + "%");
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bool hasRooms = false;

                        while (reader.Read())
                        {
                            hasRooms = true;

                            int roomId = Convert.ToInt32(reader["room_id"]);
                            string roomNumber = reader.IsDBNull(reader.GetOrdinal("room_number")) ? "N/A" : reader["room_number"]?.ToString();
                            string type = reader["room_type"]?.ToString() ?? "";
                            decimal rate = Convert.ToDecimal(reader["rate"]);
                            bool roomAvailability = Convert.ToBoolean(reader["availability"]);
                            bool maintenance = !reader.IsDBNull(reader.GetOrdinal("maintenance")) && Convert.ToBoolean(reader["maintenance"]);
                            bool hasActiveReservation = Convert.ToBoolean(reader["has_active_reservation"]);
                            bool available = roomAvailability && !maintenance && !hasActiveReservation;
                            string unavailableReason = maintenance
                                ? "Maintenance"
                                : hasActiveReservation || !roomAvailability
                                    ? "Reservation"
                                    : null;
                            int capacity = reader.IsDBNull(reader.GetOrdinal("capacity")) ? 0 : Convert.ToInt32(reader["capacity"]);
                            int beds = reader.IsDBNull(reader.GetOrdinal("beds")) ? 0 : Convert.ToInt32(reader["beds"]);
                            byte[] imageData = reader.IsDBNull(reader.GetOrdinal("image_data")) ? null : (byte[])reader["image_data"];
                            string venueLocation = reader.IsDBNull(reader.GetOrdinal("venue_location")) ? "Big 8" : reader["venue_location"]?.ToString();

                            RoomCard card = new RoomCard();
                            card.SetRoomDetails(roomId, roomNumber, type, rate, available, imageData, capacity, beds, venueLocation,
                                isCoordinator ? unavailableReason : null);

                            card.ReserveClicked += (s, roomIdFromCard) =>
                            {
                                using (ReserveRoomForm modal = new ReserveRoomForm(customerId, roomIdFromCard, fullName))
                                {
                                    modal.ShowDialog();
                                    LoadRooms(roomTypeFilter); // Refresh with same filter
                                }
                            };

                            flowLayoutRooms.Controls.Add(card);
                        }

                        // 🟡 Show message if no matching rooms found
                        if (!hasRooms)
                        {
                            Panel containerPanel = new Panel();
                            containerPanel.Width = 1800;
                            containerPanel.Height = 50; // Adjust height as needed
                            containerPanel.BackColor = Color.Transparent;
                            containerPanel.Margin = new Padding(0, 50, 0, 0);

                            Label noRoomsLabel = new Label();
                            noRoomsLabel.Text = isCoordinator ? "No venues found." : "No rooms found.";
                            noRoomsLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                            noRoomsLabel.ForeColor = Color.Gray;
                            noRoomsLabel.TextAlign = ContentAlignment.MiddleCenter;
                            noRoomsLabel.Dock = DockStyle.Fill;

                            containerPanel.Controls.Add(noRoomsLabel);
                            flowLayoutRooms.Controls.Add(containerPanel);
                        }
                    }
                }
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string roomType = txtRoomTypeSearch.Text.Trim();
            LoadRooms(roomType);
        }

        private void TxtRoomTypeSearch_TextChanged(object sender, EventArgs e)
        {
            string roomType = txtRoomTypeSearch.Text.Trim();
            LoadRooms(roomType); // Filter rooms live as user types
        }

        private void SearchDebounceTimer_Tick(object sender, EventArgs e)
        {
            searchDebounceTimer.Stop();
            LoadRooms(txtRoomTypeSearch.Text.Trim());
        }

        // Reuse these if needed
        private void ShowReservationModal(int roomId)
        {
            Form modal = new Form
            {
                Text = "Reserve Room",
                Size = new Size(300, 250),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent
            };

            Label lblIn = new Label { Text = "Check-in:", Location = new Point(20, 30) };
            DateTimePicker dpIn = new DateTimePicker { Location = new Point(100, 25), Width = 150 };

            Label lblOut = new Label { Text = "Check-out:", Location = new Point(20, 80) };
            DateTimePicker dpOut = new DateTimePicker { Location = new Point(100, 75), Width = 150 };

            Button btnConfirm = new Button
            {
                Text = "Confirm",
                Location = new Point(100, 130),
                BackColor = Color.Green,
                ForeColor = Color.White
            };
            btnConfirm.Click += (s, e) =>
            {
                if (dpIn.Value >= dpOut.Value)
                {
                    MessageBox.Show("Check-out must be after check-in.");
                    return;
                }
                SaveReservation(roomId, dpIn.Value, dpOut.Value);
                modal.Close();
            };

            modal.Controls.Add(lblIn);
            modal.Controls.Add(dpIn);
            modal.Controls.Add(lblOut);
            modal.Controls.Add(dpOut);
            modal.Controls.Add(btnConfirm);

            modal.ShowDialog();
        }

        private void SaveReservation(int roomId, DateTime checkIn, DateTime checkOut)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string insert = "INSERT INTO reservations (customer_id, room_id, check_in, check_out, status) VALUES (@cid, @rid, @in, @out, 'Confirmed')";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@cid", customerId);
                cmd.Parameters.AddWithValue("@rid", roomId);
                cmd.Parameters.AddWithValue("@in", checkIn);
                cmd.Parameters.AddWithValue("@out", checkOut);
                cmd.ExecuteNonQuery();

                string update = "UPDATE rooms SET availability = 0 WHERE room_id = @id";
                SqlCommand cmd2 = new SqlCommand(update, conn);
                cmd2.Parameters.AddWithValue("@id", roomId);
                cmd2.ExecuteNonQuery();

                ShowCustomMessageBox("Success", "Room reserved successfully!", 500, 200);
                LoadRooms(); // Refresh room list
            }
        }

        public void ShowCustomMessageBox(string title, string message, int width, int height)
        {
            Form customBox = new Form
            {
                Text = title,
                Size = new Size(width, height),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblMessage = new Label
            {
                Text = message,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Font = new Font("Segoe UI", 10),
                Size = new Size(width - 40, height - 120),
                Location = new Point(20, 20)
            };

            Button okButton = new Button
            {
                Text = "OK",
                Size = new Size(80, 30),
                Cursor = Cursors.Hand
            };
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

        // Unused default event handlers (optional: remove)
        private void BrowseRoomsForm_Load(object sender, EventArgs e) { }
        private void dgvRooms_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void flowLayoutRooms_Paint(object sender, PaintEventArgs e) { }
        private void flowLayoutRooms_Paint_1(object sender, PaintEventArgs e) { }
        private void flowLayoutRooms_Paint_2(object sender, PaintEventArgs e) { }
    }
}
