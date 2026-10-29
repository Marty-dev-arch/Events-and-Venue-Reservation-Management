using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using HotelReservationSystem.Models;
using Hotel_Reservation_System.Database;

namespace Hotel_Reservation_System.Database
{
    public class RoomDAO
    {
        public static List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT room_id, room_number, event_type, room_type, rate, availability, maintenance, capacity, beds, venue_location FROM rooms";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Room room = new Room
                        {
                            RoomId = Convert.ToInt32(reader["room_id"]),
                            RoomNumber = reader["room_number"]?.ToString() ?? "",
                            EventType = reader.IsDBNull(reader.GetOrdinal("event_type")) ? "Wedding" : reader["event_type"].ToString(),
                            FunctionhallType = reader["room_type"]?.ToString() ?? "",
                            Rate = Convert.ToDecimal(reader["rate"]),
                            Availability = Convert.ToBoolean(reader["availability"]),
                            Maintenance = reader.IsDBNull(reader.GetOrdinal("maintenance")) ? false : Convert.ToBoolean(reader["maintenance"]),
                            Capacity = reader.IsDBNull(reader.GetOrdinal("capacity")) ? 0 : Convert.ToInt32(reader["capacity"]),
                            Beds = reader.IsDBNull(reader.GetOrdinal("beds")) ? 0 : Convert.ToInt32(reader["beds"]),
                            VenueLocation = reader.IsDBNull(reader.GetOrdinal("venue_location")) ? "Big 8" : reader["venue_location"].ToString()
                        };
                        rooms.Add(room);
                    }
                }
            }

            return rooms;
        }

        public static bool SetMaintenance(int roomId, bool isUnderMaintenance)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                string query = @"
                    UPDATE rooms
                    SET maintenance = @maintenance,
                        availability = CASE
                            WHEN @maintenance = 1 THEN 0
                            ELSE availability
                        END
                    WHERE room_id = @roomId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maintenance", isUnderMaintenance ? 1 : 0);
                    cmd.Parameters.AddWithValue("@roomId", roomId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static bool AddRoom(Room room)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO rooms (room_number, event_type, room_type, rate, availability, maintenance, image_data, capacity, beds, venue_location) 
                         VALUES (@room_number, @event_type, @room_type, @rate, @availability, @maintenance, @imageData, @capacity, @beds, @venue_location)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@room_number", room.RoomNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@event_type", string.IsNullOrWhiteSpace(room.EventType) ? "Wedding" : room.EventType);
                    cmd.Parameters.AddWithValue("@room_type", room.FunctionhallType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@rate", room.Rate);
                    cmd.Parameters.AddWithValue("@availability", room.Availability ? 1 : 0);
                    cmd.Parameters.AddWithValue("@maintenance", room.Maintenance ? 1 : 0);
                    cmd.Parameters.Add("@imageData", SqlDbType.VarBinary, -1).Value = room.ImageData is null ? DBNull.Value : room.ImageData;
                    cmd.Parameters.AddWithValue("@capacity", room.Capacity);
                    cmd.Parameters.AddWithValue("@beds", room.Beds);
                    cmd.Parameters.AddWithValue("@venue_location", string.IsNullOrWhiteSpace(room.VenueLocation) ? "Big 8" : room.VenueLocation);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool UpdateRoom(Room room)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE rooms SET room_number = @number, event_type = @event_type, room_type = @type, rate = @rate, availability = @avail, maintenance = @main, image_data = @imageData, capacity = @capacity, beds = @beds, venue_location = @venue_location WHERE room_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@number", room.RoomNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@event_type", string.IsNullOrWhiteSpace(room.EventType) ? "Wedding" : room.EventType);
                cmd.Parameters.AddWithValue("@type", room.FunctionhallType ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@rate", room.Rate);
                cmd.Parameters.AddWithValue("@avail", room.Availability ? 1 : 0);
                cmd.Parameters.AddWithValue("@main", room.Maintenance ? 1 : 0);
                cmd.Parameters.Add("@imageData", SqlDbType.VarBinary, -1).Value = room.ImageData is null ? DBNull.Value : room.ImageData;
                cmd.Parameters.AddWithValue("@capacity", room.Capacity);
                cmd.Parameters.AddWithValue("@beds", room.Beds);
                cmd.Parameters.AddWithValue("@venue_location", string.IsNullOrWhiteSpace(room.VenueLocation) ? "Big 8" : room.VenueLocation);
                cmd.Parameters.AddWithValue("@id", room.RoomId);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public static bool DeleteRoom(int roomId)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM rooms WHERE room_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", roomId);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Update room status (Available or Occupied)
        public static void UpdateRoomStatus(int roomId, string status)
        {
            string query = "UPDATE rooms SET Status = @Status WHERE room_id = @RoomId";
            var parameters = new Dictionary<string, object> {
                { "@Status", status },
                { "@RoomId", roomId }
            };
            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        public static Room GetRoomById(int roomId)
        {
            Room room = null;
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT room_id, room_number, event_type, room_type, rate, availability, maintenance, capacity, beds FROM rooms WHERE room_id = @roomId";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            room = new Room
                            {
                                RoomId = Convert.ToInt32(reader["room_id"]),
                                RoomNumber = reader["room_number"]?.ToString() ?? "",
                                EventType = reader.IsDBNull(reader.GetOrdinal("event_type")) ? "Wedding" : reader["event_type"].ToString(),
                                FunctionhallType = reader["room_type"]?.ToString() ?? "",
                                Rate = Convert.ToDecimal(reader["rate"]),
                                Availability = Convert.ToBoolean(reader["availability"]),
                                Maintenance = reader.IsDBNull(reader.GetOrdinal("maintenance")) ? false : Convert.ToBoolean(reader["maintenance"]),
                                Capacity = reader.IsDBNull(reader.GetOrdinal("capacity")) ? 0 : Convert.ToInt32(reader["capacity"]),
                                Beds = reader.IsDBNull(reader.GetOrdinal("beds")) ? 0 : Convert.ToInt32(reader["beds"])
                            };
                        }
                    }
                }
            }
            return room;
        }

        public static byte[] GetRoomImageById(int roomId)
        {
            string query = "SELECT image_data FROM rooms WHERE room_id = @RoomId";
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomId", roomId);
                    var result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? (byte[])result : null;
                }
            }
        }

        public static bool RoomNumberExists(string RoomNumber)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM rooms WHERE room_number = @roomNumber", conn))
                {
                    cmd.Parameters.AddWithValue("@roomNumber", RoomNumber);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }
    }
}
