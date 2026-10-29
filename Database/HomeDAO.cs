using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation_System.Models;
using Microsoft.Data.SqlClient;

namespace Hotel_Reservation_System.Database
{
    public class HomeDAO
    {
        public Home GetHomeStats()
        {
            Home stats = new Home();

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                // Active Function Halls (not in maintenance)
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM rooms WHERE (maintenance IS NULL OR maintenance = 0)", conn))
                {
                    stats.TotalRooms = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Total Customers
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM customers", conn))
                {
                    stats.TotalCustomers = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Current Reservations (reservations with status = 'Confirmed')
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM reservations WHERE status = 'Confirmed'", conn))
                {
                    stats.CurrentReservations = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Check-In Guests (reservations with status = 'Checked In')
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM reservations WHERE status = 'Checked In'", conn))
                {
                    stats.CheckInGuests = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return stats;
        }

        public (int available, int booked, int maintenance) GetRoomStatusCounts()
        {
            int available = 0, booked = 0, maintenance = 0;
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                            SELECT
                                SUM(CASE WHEN availability = 1 AND (maintenance IS NULL OR maintenance = 0) THEN 1 ELSE 0 END) AS available,
                                SUM(CASE WHEN availability = 0 AND (maintenance IS NULL OR maintenance = 0) THEN 1 ELSE 0 END) AS booked,
                                SUM(CASE WHEN maintenance = 1 THEN 1 ELSE 0 END) AS maintenance
                            FROM rooms";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        available = reader["available"] == DBNull.Value ? 0 : Convert.ToInt32(reader["available"]);
                        booked = reader["booked"] == DBNull.Value ? 0 : Convert.ToInt32(reader["booked"]);
                        maintenance = reader["maintenance"] == DBNull.Value ? 0 : Convert.ToInt32(reader["maintenance"]);
                    }
                }
            }
            return (available, booked, maintenance);
        }
    }
}
