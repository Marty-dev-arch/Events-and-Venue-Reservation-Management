using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using HotelReservationSystem.Models;
using Hotel_Reservation_System.Database;
using Hotel_Reservation_System.Models;

namespace Hotel_Reservation_System.Database
{
    public class PaymentDAO
    {
        public static List<Payment> GetAllPayments()
        {
            List<Payment> payments = new List<Payment>();
            string query = @"
            SELECT p.payment_id, p.reservation_id, p.amount, p.payment_date, p.payment_method,
                   c.full_name
            FROM payments p
            JOIN reservations r ON p.reservation_id = r.reservation_id
            JOIN customers c ON r.customer_id = c.customer_id";

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        payments.Add(new Payment
                        {
                            PaymentId = Convert.ToInt32(reader["payment_id"]),
                            ReservationId = Convert.ToInt32(reader["reservation_id"]),
                            FullName = reader["full_name"]?.ToString() ?? "",
                            Amount = Convert.ToDecimal(reader["amount"]),
                            PaymentDate = Convert.ToDateTime(reader["payment_date"]),
                            PaymentMethod = reader["payment_method"]?.ToString() ?? ""
                        });
                    }
                }
            }

            return payments;
        }

        public static bool AddPayment(Payment payment)
        {
            string query = @"INSERT INTO payments (reservation_id, amount, payment_date, payment_method) 
                             VALUES (@reservationId, @amountPaid, @paymentDate, @paymentMethod)";

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@reservationId", payment.ReservationId);
                cmd.Parameters.AddWithValue("@amountPaid", payment.Amount);
                cmd.Parameters.AddWithValue("@paymentDate", payment.PaymentDate);
                cmd.Parameters.AddWithValue("@paymentMethod", payment.PaymentMethod ?? (object)DBNull.Value);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public static bool DeletePayment(int paymentId)
        {
            string query = "DELETE FROM payments WHERE payment_id = @paymentId";

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@paymentId", paymentId);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public static Payment GetPaymentById(int paymentId)
        {
            Payment payment = null;

            string query = @"
        SELECT p.payment_id, p.reservation_id, p.amount, p.payment_date, p.payment_method,
               c.full_name
        FROM payments p
        JOIN reservations r ON p.reservation_id = r.reservation_id
        JOIN customers c ON r.customer_id = c.customer_id
        WHERE p.payment_id = @paymentId";

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@paymentId", paymentId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        payment = new Payment
                        {
                            PaymentId = Convert.ToInt32(reader["payment_id"]),
                            ReservationId = Convert.ToInt32(reader["reservation_id"]),
                            FullName = reader["full_name"]?.ToString() ?? "",
                            Amount = Convert.ToDecimal(reader["amount"]),
                            PaymentDate = Convert.ToDateTime(reader["payment_date"]),
                            PaymentMethod = reader["payment_method"]?.ToString() ?? ""
                        };
                    }
                }
            }

            return payment;
        }
    }
}
