using Hotel_Reservation_System.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Database
{
    class CustomerDAO
    {
        public static List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT customer_id, full_name, contact_number, email, address FROM customers WHERE status = 'Active' OR status IS NULL OR status = '' ORDER BY customer_id DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer
                        {
                            CustomerId = Convert.ToInt32(reader["customer_id"]),
                            FullName = reader["full_name"]?.ToString() ?? "",
                            ContactNumber = reader["contact_number"]?.ToString() ?? "",
                            Email = reader["email"]?.ToString() ?? "",
                            Address = reader["address"]?.ToString() ?? ""
                        };
                        customers.Add(customer);
                    }
                }
            }

            return customers;
        }

        public static bool AddCustomer(Customer customer)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_AddCustomer", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@full_name", customer.FullName ?? "");
                    cmd.Parameters.AddWithValue("@email", customer.Email ?? "");
                    cmd.Parameters.AddWithValue("@contact_number", customer.ContactNumber ?? "");
                    cmd.Parameters.AddWithValue("@address", customer.Address ?? "");
                    cmd.Parameters.AddWithValue("@status", "Active");
                    SqlParameter outParam = new SqlParameter("@customer_id", System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output,
                        Value = DBNull.Value
                    };
                    cmd.Parameters.Add(outParam);

                    object res = cmd.ExecuteScalar();
                    return (outParam.Value != null && outParam.Value != DBNull.Value) || (res != null && res != DBNull.Value);
                }
            }
        }

        public static bool UpdateCustomer(Customer customer)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE customers SET full_name=@name, contact_number=@contact, email=@mail, address=@addr WHERE customer_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", customer.FullName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@contact", customer.ContactNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@mail", customer.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@addr", customer.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id", customer.CustomerId);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public static bool DeleteCustomer(int customerId)
        {
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM customers WHERE customer_id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", customerId);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public static Customer GetCustomerById(int customerId)
        {
            Customer customer = null;
            using (SqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT customer_id, full_name, contact_number, email, address FROM customers WHERE customer_id = @CustomerId";
                using (var command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                CustomerId = Convert.ToInt32(reader["customer_id"]),
                                FullName = reader["full_name"]?.ToString() ?? "",
                                ContactNumber = reader["contact_number"]?.ToString() ?? "",
                                Email = reader["email"]?.ToString() ?? "",
                                Address = reader["address"]?.ToString() ?? "",
                            };
                        }
                    }
                }
            }
            return customer;
        }
    }
}