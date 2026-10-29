using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Hotel_Reservation_System.Database
{
    public static class DbConnection
    {
        // Default connection string (Windows Authentication for SSMS).
        // If your instance is named SQLEXPRESS, use: Server=localhost\SQLEXPRESS;Database=events_and_venue_reservation;Trusted_Connection=True;TrustServerCertificate=True;
        private static string defaultConnectionString =
            @"Server=localhost\SQLEXPRESS;Database=events_and_venue_reservation;Trusted_Connection=True;TrustServerCertificate=True;";

        public static string ConnectionString
        {
            get
            {
                try
                {
                    string configConn = ConfigurationManager.ConnectionStrings["SqlServerConnection"]?.ConnectionString;
                    if (!string.IsNullOrWhiteSpace(configConn))
                    {
                        return configConn;
                    }
                }
                catch
                {
                    // Fall back to default
                }
                return defaultConnectionString;
            }
            set
            {
                defaultConnectionString = value;
            }
        }

        private static bool _schemaEnsured = false;
        private static readonly object _schemaLock = new object();

        public static void EnsureSchema()
        {
            if (_schemaEnsured) return;
            lock (_schemaLock)
            {
                if (_schemaEnsured) return;
                try
                {
                    using (var conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        string sql = @"
IF COL_LENGTH('rooms', 'event_type') IS NULL
BEGIN
    ALTER TABLE rooms ADD event_type NVARCHAR(100) NULL DEFAULT 'Wedding';
END

IF COL_LENGTH('reservations', 'event_type') IS NULL
BEGIN
    ALTER TABLE reservations ADD event_type NVARCHAR(100) NULL DEFAULT 'Wedding';
END

IF COL_LENGTH('customers', 'status') IS NULL
BEGIN
    ALTER TABLE customers ADD status NVARCHAR(50) NULL CONSTRAINT DF_customers_status DEFAULT 'Active';
    EXEC('UPDATE customers SET status = ''Active'' WHERE status IS NULL');
END

-- Ensure CASCADE on reservations -> rooms foreign key
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_reservations_rooms' AND delete_referential_action_desc = 'CASCADE')
BEGIN
    DECLARE @fk_rooms NVARCHAR(200);
    SELECT @fk_rooms = name FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('reservations') AND referenced_object_id = OBJECT_ID('rooms');
    IF @fk_rooms IS NOT NULL EXEC('ALTER TABLE reservations DROP CONSTRAINT ' + @fk_rooms);
    ALTER TABLE reservations ADD CONSTRAINT FK_reservations_rooms FOREIGN KEY (room_id) REFERENCES rooms(room_id) ON DELETE CASCADE ON UPDATE CASCADE;
END

-- Ensure CASCADE on payments -> reservations foreign key
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_payments_reservations' AND delete_referential_action_desc = 'CASCADE')
BEGIN
    DECLARE @fk_pmt NVARCHAR(200);
    SELECT @fk_pmt = name FROM sys.foreign_keys WHERE parent_object_id = OBJECT_ID('payments') AND referenced_object_id = OBJECT_ID('reservations');
    IF @fk_pmt IS NOT NULL EXEC('ALTER TABLE payments DROP CONSTRAINT ' + @fk_pmt);
    ALTER TABLE payments ADD CONSTRAINT FK_payments_reservations FOREIGN KEY (reservation_id) REFERENCES reservations(reservation_id) ON DELETE CASCADE ON UPDATE CASCADE;
END
";
                        using (var cmd = new SqlCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    _schemaEnsured = true;
                }
                catch
                {
                    // Fail gracefully if database is not reachable yet
                }
            }
        }

        public static SqlConnection GetConnection()
        {
            EnsureSchema();
            return new SqlConnection(ConnectionString);
        }
    }
}
