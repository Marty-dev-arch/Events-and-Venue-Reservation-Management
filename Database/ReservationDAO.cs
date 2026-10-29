using Hotel_Reservation_System.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Hotel_Reservation_System.Database
{
    public class ReservationDAO
    {
        public static List<Reservation> GetAllReservations()
        {
            var reservations = new List<Reservation>();
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT r.reservation_id, r.customer_id, r.room_id, r.check_in_date, r.check_in_time, 
                                r.check_out_date, r.check_out_time, r.status, r.date_reserved,
                                c.full_name AS customer_name, ro.room_number,
                                COALESCE(r.event_type, ro.event_type, 'Wedding') AS event_type,
                                ro.room_type,
                                ro.venue_location
                         FROM reservations r
                         JOIN customers c ON r.customer_id = c.customer_id
                         JOIN rooms ro ON r.room_id = ro.room_id
                         ORDER BY r.reservation_id DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TimeSpan? checkInTime = reader.IsDBNull(reader.GetOrdinal("check_in_time"))
                            ? (TimeSpan?)null
                            : reader.GetTimeSpan(reader.GetOrdinal("check_in_time"));

                        TimeSpan? checkOutTime = reader.IsDBNull(reader.GetOrdinal("check_out_time"))
                            ? (TimeSpan?)null
                            : reader.GetTimeSpan(reader.GetOrdinal("check_out_time"));

                        DateTime dateReserved = reader.IsDBNull(reader.GetOrdinal("date_reserved"))
                            ? DateTime.MinValue
                            : reader.GetDateTime(reader.GetOrdinal("date_reserved"));

                        reservations.Add(new Reservation
                        {
                            ReservationId = Convert.ToInt32(reader["reservation_id"]),
                            CustomerId = Convert.ToInt32(reader["customer_id"]),
                            RoomId = Convert.ToInt32(reader["room_id"]),
                            CustomerName = reader["customer_name"]?.ToString() ?? "",
                            RoomNumber = reader["room_number"]?.ToString() ?? "",
                            VenueLocation = reader.IsDBNull(reader.GetOrdinal("venue_location")) ? "Big 8" : reader["venue_location"].ToString(),
                            EventType = reader.IsDBNull(reader.GetOrdinal("event_type")) ? "Wedding" : reader["event_type"].ToString(),
                            FunctionhallType = reader["room_type"]?.ToString() ?? "",
                            CheckInDate = Convert.ToDateTime(reader["check_in_date"]),
                            CheckInTime = checkInTime,
                            CheckOutDate = Convert.ToDateTime(reader["check_out_date"]),
                            CheckOutTime = checkOutTime,
                            Status = reader["status"]?.ToString() ?? "",
                            DateReserved = dateReserved
                        });
                    }
                }
            }
            return reservations;
        }

        public static List<Reservation> GetPastReservations()
        {
            List<Reservation> reservations = new List<Reservation>();
            string query = @"
                            SELECT r.reservation_id, c.full_name AS customer_name, rm.room_number,
                                   COALESCE(r.event_type, rm.event_type, 'Wedding') AS event_type,
                                   rm.room_type,
                                   r.check_in_date, r.check_in_time, r.check_out_date, r.check_out_time, r.status,
                                   CASE WHEN p.payment_id IS NOT NULL THEN 'Paid' ELSE 'Unpaid' END AS payment_status
                            FROM reservations r
                            JOIN customers c ON r.customer_id = c.customer_id
                            JOIN rooms rm ON r.room_id = rm.room_id
                            LEFT JOIN payments p ON r.reservation_id = p.reservation_id
                            WHERE r.check_out_date < CAST(GETDATE() AS DATE)
                            ORDER BY r.check_out_date DESC";

            using (SqlConnection conn = DbConnection.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TimeSpan? checkInTime = reader.IsDBNull(reader.GetOrdinal("check_in_time"))
                            ? (TimeSpan?)null
                            : reader.GetTimeSpan(reader.GetOrdinal("check_in_time"));

                        TimeSpan? checkOutTime = reader.IsDBNull(reader.GetOrdinal("check_out_time"))
                            ? (TimeSpan?)null
                            : reader.GetTimeSpan(reader.GetOrdinal("check_out_time"));

                        reservations.Add(new Reservation
                        {
                            ReservationId = Convert.ToInt32(reader["reservation_id"]),
                            CustomerName = reader["customer_name"]?.ToString() ?? "",
                            RoomNumber = reader["room_number"]?.ToString() ?? "",
                            EventType = reader.IsDBNull(reader.GetOrdinal("event_type")) ? "Wedding" : reader["event_type"].ToString(),
                            FunctionhallType = reader["room_type"]?.ToString() ?? "",
                            CheckInDate = Convert.ToDateTime(reader["check_in_date"]),
                            CheckInTime = checkInTime,
                            CheckOutDate = Convert.ToDateTime(reader["check_out_date"]),
                            CheckOutTime = checkOutTime,
                            Status = reader["status"]?.ToString() ?? ""
                        });
                    }
                }
            }

            return reservations;
        }

        public static bool AddReservation(Reservation reservation)
        {
            string query = @"INSERT INTO reservations (customer_id, room_id, event_type, check_in_date, check_in_time, check_out_date, check_out_time, status, date_reserved)
                     VALUES (@CustomerId, @RoomId, @EventType, @CheckInDate, @CheckInTime, @CheckOutDate, @CheckOutTime, @Status, @DateReserved)";

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", reservation.CustomerId);
                    cmd.Parameters.AddWithValue("@RoomId", reservation.RoomId);
                    cmd.Parameters.AddWithValue("@EventType", string.IsNullOrWhiteSpace(reservation.EventType) ? "Wedding" : reservation.EventType);
                    cmd.Parameters.AddWithValue("@CheckInDate", reservation.CheckInDate);
                    cmd.Parameters.AddWithValue("@CheckInTime", reservation.CheckInTime.HasValue ? reservation.CheckInTime.Value : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CheckOutDate", reservation.CheckOutDate);
                    cmd.Parameters.AddWithValue("@CheckOutTime", reservation.CheckOutTime.HasValue ? reservation.CheckOutTime.Value : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", reservation.Status ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateReserved", reservation.DateReserved);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static bool UpdateReservation(Reservation reservation)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE reservations 
                         SET customer_id=@CustomerId, room_id=@RoomId, event_type=@EventType, check_in_date=@CheckInDate, check_in_time=@CheckInTime,
                             check_out_date=@CheckOutDate, check_out_time=@CheckOutTime, status=@Status
                         WHERE reservation_id=@ReservationId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", reservation.CustomerId);
                    cmd.Parameters.AddWithValue("@RoomId", reservation.RoomId);
                    cmd.Parameters.AddWithValue("@EventType", string.IsNullOrWhiteSpace(reservation.EventType) ? "Wedding" : reservation.EventType);
                    cmd.Parameters.AddWithValue("@CheckInDate", reservation.CheckInDate);
                    cmd.Parameters.AddWithValue("@CheckInTime", reservation.CheckInTime.HasValue ? reservation.CheckInTime.Value : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CheckOutDate", reservation.CheckOutDate);
                    cmd.Parameters.AddWithValue("@CheckOutTime", reservation.CheckOutTime.HasValue ? reservation.CheckOutTime.Value : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", reservation.Status ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReservationId", reservation.ReservationId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static bool DeleteReservation(int reservationId)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM reservations WHERE reservation_id = @reservationId";

                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@reservationId", reservationId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (SqlException ex) when (ex.Number == 547 || ex.Message.Contains("REFERENCE constraint"))
                {
                    MessageBox.Show("Cannot delete this reservation because it has related payment records.",
                                    "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting the reservation: " + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public static DataTable GetReservationsForCheckInOut()
        {
            string query = @"SELECT r.reservation_id AS ReservationId, c.full_name AS FullName, ro.room_number AS RoomNumber,
                                   r.check_in_date AS CheckInDate, r.check_in_time AS CheckInTime,
                                   r.check_out_date AS CheckOutDate, r.check_out_time AS CheckOutTime, r.status AS Status
                            FROM reservations r
                            JOIN customers c ON r.customer_id = c.customer_id
                            JOIN rooms ro ON r.room_id = ro.room_id
                            WHERE r.status IN ('Confirmed', 'Checked In')";
            return DatabaseHelper.ExecuteQuery(query);
        }

        public static Reservation GetReservationById(int reservationId)
        {
            string query = "SELECT * FROM reservations WHERE reservation_id = @ReservationId";
            var parameters = new Dictionary<string, object> { { "@ReservationId", reservationId } };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];

            // Safely parse times
            TimeSpan? checkInTime = TimeSpan.TryParse(row["check_in_time"]?.ToString(), out var inTime) ? inTime : (TimeSpan?)null;
            TimeSpan? checkOutTime = TimeSpan.TryParse(row["check_out_time"]?.ToString(), out var outTime) ? outTime : (TimeSpan?)null;
            string eventType = dt.Columns.Contains("event_type") && !row.IsNull("event_type") ? row["event_type"].ToString() : "Wedding";

            return new Reservation
            {
                ReservationId = Convert.ToInt32(row["reservation_id"]),
                CustomerId = Convert.ToInt32(row["customer_id"]),
                RoomId = Convert.ToInt32(row["room_id"]),
                EventType = eventType,
                CheckInDate = Convert.ToDateTime(row["check_in_date"]),
                CheckInTime = checkInTime,
                CheckOutDate = Convert.ToDateTime(row["check_out_date"]),
                CheckOutTime = checkOutTime,
                Status = row["status"]?.ToString() ?? ""
            };
        }

        public static bool AcceptReservation(int reservationId)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_AcceptReservation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@reservation_id", reservationId);
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value && Convert.ToBoolean(result);
                }
            }
        }

        public static bool CancelReservation(int reservationId)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CancelReservation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@reservation_id", reservationId);
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value && Convert.ToBoolean(result);
                }
            }
        }

        public static int GetPendingReservationsCount()
        {
            try
            {
                using (SqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM reservations WHERE status = 'Pending'", conn))
                    {
                        object res = cmd.ExecuteScalar();
                        return (res != null && res != DBNull.Value) ? Convert.ToInt32(res) : 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public static void UpdateReservationStatus(int reservationId, string status)
        {
            string query = "UPDATE reservations SET status = @Status WHERE reservation_id = @ReservationId";
            var parameters = new Dictionary<string, object> {
                { "@Status", status },
                { "@ReservationId", reservationId }
            };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public static (int pending, int confirmed, int checkedIn, int cancelled) GetCoordinatorStatusCounts()
        {
            int pending = 0, confirmed = 0, checkedIn = 0, cancelled = 0;

            string query = @"
                SELECT status, COUNT(*) as total
                FROM reservations
                GROUP BY status;
            ";

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string status = reader["status"]?.ToString().ToLower() ?? "";
                        int count = Convert.ToInt32(reader["total"]);

                        switch (status)
                        {
                            case "pending": pending = count; break;
                            case "confirmed": confirmed = count; break;
                            case "checked-in":
                            case "checked in": checkedIn = count; break;
                            case "cancelled": cancelled = count; break;
                        }
                    }
                }
            }

            return (pending, confirmed, checkedIn, cancelled);
        }

        public (int pending, int confirmed, int checkedIn, int cancelled) GetReservationStatusCounts(int customerId)
        {
            int pending = 0, confirmed = 0, checkedIn = 0, cancelled = 0;

            string query = @"
                SELECT status, COUNT(*) as total
                FROM reservations
                WHERE customer_id = @customerId
                GROUP BY status;
            ";

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string status = reader["status"]?.ToString().ToLower() ?? "";
                            int count = Convert.ToInt32(reader["total"]);

                            switch (status)
                            {
                                case "pending": pending = count; break;
                                case "confirmed": confirmed = count; break;
                                case "checked-in":
                                case "checked in": checkedIn = count; break;
                                case "cancelled": cancelled = count; break;
                            }
                        }
                    }
                }
            }

            return (pending, confirmed, checkedIn, cancelled);
        }
    }
}
