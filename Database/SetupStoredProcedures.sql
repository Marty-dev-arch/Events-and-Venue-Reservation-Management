USE events_and_venue_reservation;
GO

-- 1. Ensure 'status' column exists in customers table
IF COL_LENGTH('customers', 'status') IS NULL
BEGIN
    ALTER TABLE customers ADD status NVARCHAR(50) NULL CONSTRAINT DF_customers_status DEFAULT 'Active';
END
GO
UPDATE customers SET status = 'Active' WHERE status IS NULL;
GO

-- Ensure 'venue_location' column exists in rooms table
IF COL_LENGTH('rooms', 'venue_location') IS NULL
BEGIN
    ALTER TABLE rooms ADD venue_location NVARCHAR(150) NULL CONSTRAINT DF_rooms_venue_location DEFAULT 'Big 8';
END
GO
UPDATE rooms SET venue_location = 'Big 8' WHERE venue_location IS NULL;
GO

-- Ensure profile columns exist in admins table
IF COL_LENGTH('admins', 'full_name') IS NULL
BEGIN
    ALTER TABLE admins ADD full_name NVARCHAR(150) NULL CONSTRAINT DF_admins_full_name DEFAULT 'System Administrator';
END
GO
IF COL_LENGTH('admins', 'email') IS NULL
BEGIN
    ALTER TABLE admins ADD email NVARCHAR(150) NULL CONSTRAINT DF_admins_email DEFAULT 'admin@example.com';
END
GO
IF COL_LENGTH('admins', 'contact_number') IS NULL
BEGIN
    ALTER TABLE admins ADD contact_number NVARCHAR(50) NULL;
END
GO
UPDATE admins SET full_name = 'System Administrator', email = 'admin@example.com' WHERE full_name IS NULL;
GO

-- 2. Stored Procedure: sp_AddCustomer
CREATE OR ALTER PROCEDURE sp_AddCustomer
    @full_name NVARCHAR(150),
    @email NVARCHAR(150) = NULL,
    @contact_number NVARCHAR(50) = NULL,
    @address NVARCHAR(255) = NULL,
    @status NVARCHAR(50) = 'Active',
    @customer_id INT = NULL OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @customer_id = customer_id FROM customers WHERE email = @email OR full_name = @full_name;
    IF @customer_id IS NULL
    BEGIN
        INSERT INTO customers (full_name, email, contact_number, address, status)
        VALUES (@full_name, @email, @contact_number, @address, @status);
        SET @customer_id = CAST(SCOPE_IDENTITY() AS INT);
    END
    ELSE
    BEGIN
        UPDATE customers 
        SET contact_number = COALESCE(@contact_number, contact_number),
            address = COALESCE(@address, address),
            status = COALESCE(@status, status)
        WHERE customer_id = @customer_id;
    END

    SELECT @customer_id AS customer_id;
END
GO

-- 3. Stored Procedure: sp_AddReservation
CREATE OR ALTER PROCEDURE sp_AddReservation
    @customer_id INT,
    @room_id INT,
    @event_type NVARCHAR(100),
    @check_in_date DATE,
    @check_in_time TIME,
    @check_out_date DATE,
    @check_out_time TIME,
    @status NVARCHAR(50) = 'Pending',
    @reservation_id INT = NULL OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO reservations 
        (customer_id, room_id, event_type, check_in_date, check_in_time, check_out_date, check_out_time, status, date_reserved, created_at)
    VALUES 
        (@customer_id, @room_id, @event_type, @check_in_date, @check_in_time, @check_out_date, @check_out_time, @status, GETDATE(), GETDATE());
    
    SET @reservation_id = CAST(SCOPE_IDENTITY() AS INT);

    IF @status = 'Confirmed'
    BEGIN
        UPDATE rooms SET availability = 0 WHERE room_id = @room_id;
    END

    SELECT @reservation_id AS reservation_id;
END
GO

-- 4. Stored Procedure: sp_AcceptReservation
CREATE OR ALTER PROCEDURE sp_AcceptReservation
    @reservation_id INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @room_id INT, @customer_id INT;
    SELECT @room_id = room_id, @customer_id = customer_id FROM reservations WHERE reservation_id = @reservation_id;

    IF @room_id IS NOT NULL
    BEGIN
        UPDATE reservations SET status = 'Confirmed' WHERE reservation_id = @reservation_id;
        UPDATE rooms SET availability = 0 WHERE room_id = @room_id;
        IF @customer_id IS NOT NULL
        BEGIN
            UPDATE customers SET status = 'Active' WHERE customer_id = @customer_id;
        END
    END

    SELECT CONVERT(BIT, CASE WHEN @room_id IS NULL THEN 0 ELSE 1 END) AS success;
END
GO

-- 5. Stored Procedure: sp_CancelReservation
CREATE OR ALTER PROCEDURE sp_CancelReservation
    @reservation_id INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @room_id INT;
    SELECT @room_id = room_id FROM reservations WHERE reservation_id = @reservation_id;

    UPDATE reservations SET status = 'Cancelled' WHERE reservation_id = @reservation_id;
    IF @room_id IS NOT NULL
    BEGIN
        UPDATE rooms SET availability = 1 WHERE room_id = @room_id;
    END

    SELECT CONVERT(BIT, CASE WHEN @room_id IS NULL THEN 0 ELSE 1 END) AS success;
END
GO

-- 6. Stored Procedure: sp_AddRoom
CREATE OR ALTER PROCEDURE sp_AddRoom
    @room_number NVARCHAR(50),
    @room_type NVARCHAR(100),
    @rate DECIMAL(18,2),
    @availability BIT = 1,
    @maintenance BIT = 0,
    @capacity INT = 50,
    @beds INT = 10,
    @image_data VARBINARY(MAX) = NULL,
    @venue_location NVARCHAR(150) = 'Big 8',
    @room_id INT = NULL OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO rooms (room_number, event_type, room_type, rate, availability, maintenance, capacity, beds, image_data, venue_location, status)
    VALUES (@room_number, NULL, @room_type, @rate, @availability, @maintenance, @capacity, @beds, @image_data, @venue_location,
            CASE WHEN @maintenance = 1 THEN 'Under Maintenance' WHEN @availability = 1 THEN 'Available' ELSE 'Booked' END);
    SET @room_id = CAST(SCOPE_IDENTITY() AS INT);
    SELECT @room_id AS room_id;
END
GO

-- 7. Stored Procedure: sp_UpdateRoom
CREATE OR ALTER PROCEDURE sp_UpdateRoom
    @room_id INT,
    @room_number NVARCHAR(50),
    @room_type NVARCHAR(100),
    @rate DECIMAL(18,2),
    @availability BIT,
    @maintenance BIT,
    @capacity INT,
    @beds INT,
    @image_data VARBINARY(MAX) = NULL,
    @venue_location NVARCHAR(150) = 'Big 8'
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE rooms 
    SET room_number = @room_number,
        room_type = @room_type,
        rate = @rate,
        availability = @availability,
        maintenance = @maintenance,
        capacity = @capacity,
        beds = @beds,
        image_data = COALESCE(@image_data, image_data),
        venue_location = COALESCE(@venue_location, venue_location, 'Big 8'),
        status = CASE WHEN @maintenance = 1 THEN 'Under Maintenance' WHEN @availability = 1 THEN 'Available' ELSE 'Booked' END
    WHERE room_id = @room_id;
END
GO

-- 8. Stored Procedure: sp_GetAllReservations
CREATE OR ALTER PROCEDURE sp_GetAllReservations
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        r.reservation_id,
        c.full_name,
        ro.room_number,
        r.event_type,
        ro.room_type,
        ro.venue_location,
        r.check_in_date,
        r.check_in_time,
        r.check_out_date,
        r.check_out_time,
        r.created_at,
        r.status
    FROM reservations r
    LEFT JOIN customers c ON r.customer_id = c.customer_id
    LEFT JOIN rooms ro ON r.room_id = ro.room_id
    ORDER BY r.reservation_id DESC;
END
GO

-- 9. Stored Procedure: sp_GetPendingReservations
CREATE OR ALTER PROCEDURE sp_GetPendingReservations
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        r.reservation_id,
        c.full_name,
        ro.room_number,
        r.event_type,
        ro.room_type,
        ro.venue_location,
        r.check_in_date,
        r.check_in_time,
        r.check_out_date,
        r.check_out_time,
        r.created_at,
        r.status
    FROM reservations r
    LEFT JOIN customers c ON r.customer_id = c.customer_id
    LEFT JOIN rooms ro ON r.room_id = ro.room_id
    WHERE r.status = 'Pending'
    ORDER BY r.reservation_id DESC;
END
GO

-- 10. Stored Procedure: sp_AddPayment
CREATE OR ALTER PROCEDURE sp_AddPayment
    @reservation_id INT,
    @amount DECIMAL(18,2),
    @payment_date DATETIME,
    @payment_method NVARCHAR(50),
    @payment_id INT = NULL OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO payments (reservation_id, amount, payment_date, payment_method)
    VALUES (@reservation_id, @amount, @payment_date, @payment_method);
    SET @payment_id = CAST(SCOPE_IDENTITY() AS INT);
    SELECT @payment_id AS payment_id;
END
GO

-- 11. Stored Procedure: sp_UpdateAdminProfile
CREATE OR ALTER PROCEDURE sp_UpdateAdminProfile
    @admin_id INT,
    @username NVARCHAR(100),
    @password NVARCHAR(100),
    @full_name NVARCHAR(150),
    @email NVARCHAR(150),
    @contact_number NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE admins
    SET username = @username,
        password = @password,
        full_name = @full_name,
        email = @email,
        contact_number = @contact_number
    WHERE admin_id = @admin_id;
END
GO
