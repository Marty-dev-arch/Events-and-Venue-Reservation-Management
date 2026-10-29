using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_Reservation_System.Models;
using Microsoft.Data.SqlClient;

namespace Hotel_Reservation_System.Database
{
    public static class ReportDAO
    {
        public static Report GetReportData()
        {
            Report report = new Report();

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                // Get total rooms
                string totalRoomsQuery = "SELECT COUNT(*) FROM rooms";
                using (SqlCommand cmd = new SqlCommand(totalRoomsQuery, conn))
                {
                    report.TotalRooms = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Get occupied rooms (reservations that are currently checked-in or ongoing)
                string occupiedRoomsQuery = @"
                    SELECT COUNT(DISTINCT room_id) 
                    FROM reservations 
                    WHERE check_in_date <= CAST(GETDATE() AS DATE) AND check_out_date >= CAST(GETDATE() AS DATE)";
                using (SqlCommand cmd = new SqlCommand(occupiedRoomsQuery, conn))
                {
                    report.OccupiedRooms = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Available rooms exclude maintenance halls and halls with active reservations.
                string availableRoomsQuery = @"
                    SELECT COUNT(*)
                    FROM rooms ro
                    WHERE ro.availability = 1
                      AND (ro.maintenance IS NULL OR ro.maintenance = 0)
                      AND NOT EXISTS (
                          SELECT 1
                          FROM reservations r
                          WHERE r.room_id = ro.room_id
                            AND LOWER(LTRIM(RTRIM(ISNULL(r.status, '')))) IN ('pending', 'confirmed', 'checked in', 'checked-in')
                            AND r.check_out_date >= CAST(GETDATE() AS DATE)
                      )";
                using (SqlCommand cmd = new SqlCommand(availableRoomsQuery, conn))
                {
                    report.AvailableRooms = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Get total revenue
                string revenueQuery = "SELECT COALESCE(SUM(amount), 0) FROM payments";
                using (SqlCommand cmd = new SqlCommand(revenueQuery, conn))
                {
                    report.TotalRevenue = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }

            return report;
        }
    }
}
