
-- Database  for SQL Server (SSMS)
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'events_and_venue_reservation')
BEGIN
    CREATE DATABASE events_and_venue_reservation;
END
GO

USE events_and_venue_reservation;
GO

-- 1. Admins Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'admins')
BEGIN
    CREATE TABLE admins (
        admin_id INT IDENTITY(1,1) PRIMARY KEY,
        username NVARCHAR(100) NOT NULL UNIQUE,
        password NVARCHAR(100) NOT NULL
    );

    -- Default admin account
    INSERT INTO admins (username, password) VALUES ('admin', 'CHANGE_ME_BEFORE_USE');
END
GO

-- 2. Coordinators Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'coordinators')
BEGIN
    CREATE TABLE coordinators (
        coordinator_id INT IDENTITY(1,1) PRIMARY KEY,
        username NVARCHAR(100) NOT NULL UNIQUE,
        password NVARCHAR(100) NOT NULL,
        full_name NVARCHAR(150) NOT NULL,
        email NVARCHAR(150) NULL,
        contact_number NVARCHAR(50) NULL,
        address NVARCHAR(255) NULL
    );

END
GO

DELETE FROM coordinators
WHERE username = 'jdelacruz'
   OR email IN ('maria.santos@example.com', 'jose.delacruz@example.com');

IF EXISTS (SELECT 1 FROM coordinators WHERE username = 'coordinator')
BEGIN
    UPDATE coordinators
    SET password = 'CHANGE_ME_BEFORE_USE',
        full_name = 'Coordinator',
        email = 'coordinator@example.com'
    WHERE username = 'coordinator';
END
ELSE IF EXISTS (SELECT 1 FROM coordinators WHERE email = 'coordinator@example.com')
BEGIN
    UPDATE coordinators
    SET username = 'coordinator',
        password = 'CHANGE_ME_BEFORE_USE',
        full_name = 'Coordinator'
    WHERE email = 'coordinator@example.com';
END
ELSE
BEGIN
    INSERT INTO coordinators (username, password, full_name, email)
    VALUES ('coordinator', 'CHANGE_ME_BEFORE_USE', 'Coordinator', 'coordinator@example.com');
END
GO

-- 3. Customers Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'customers')
BEGIN
    CREATE TABLE customers (
        customer_id INT IDENTITY(1,1) PRIMARY KEY,
        full_name NVARCHAR(150) NOT NULL,
        email NVARCHAR(150) NOT NULL,
        contact_number NVARCHAR(50) NULL,
        address NVARCHAR(255) NULL
    );

END
GO

-- Ensure event_type columns exist if tables were created previously
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'rooms') AND COL_LENGTH('rooms', 'event_type') IS NULL
BEGIN
    ALTER TABLE rooms ADD event_type NVARCHAR(100) NULL DEFAULT 'Wedding';
END
GO

IF EXISTS (SELECT * FROM sys.tables WHERE name = 'reservations') AND COL_LENGTH('reservations', 'event_type') IS NULL
BEGIN
    ALTER TABLE reservations ADD event_type NVARCHAR(100) NULL DEFAULT 'Wedding';
END
GO

-- 3. Rooms Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'rooms')
BEGIN
    CREATE TABLE rooms (
        room_id INT IDENTITY(1,1) PRIMARY KEY,
        room_number NVARCHAR(50) NOT NULL UNIQUE,
        event_type NVARCHAR(100) NULL DEFAULT 'Wedding',
        room_type NVARCHAR(100) NOT NULL,
        rate DECIMAL(18,2) NOT NULL,
        availability BIT NOT NULL DEFAULT 1,
        maintenance BIT NOT NULL DEFAULT 0,
        capacity INT NOT NULL DEFAULT 50,
        beds INT NOT NULL DEFAULT 10,
        image_data VARBINARY(MAX) NULL,
        status NVARCHAR(50) NULL DEFAULT 'Available'
    );

END
GO

-- 4. Reservations Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'reservations')
BEGIN
    CREATE TABLE reservations (
        reservation_id INT IDENTITY(1,1) PRIMARY KEY,
        customer_id INT NOT NULL FOREIGN KEY REFERENCES customers(customer_id) ON DELETE CASCADE ON UPDATE CASCADE,
        room_id INT NOT NULL FOREIGN KEY REFERENCES rooms(room_id) ON DELETE CASCADE ON UPDATE CASCADE,
        event_type NVARCHAR(100) NULL DEFAULT 'Wedding',
        check_in_date DATE NOT NULL,
        check_in_time TIME NULL,
        check_out_date DATE NOT NULL,
        check_out_time TIME NULL,
        status NVARCHAR(50) NOT NULL DEFAULT 'Confirmed',
        date_reserved DATETIME NULL DEFAULT GETDATE(),
        created_at DATETIME NULL DEFAULT GETDATE()
    );
END
GO

-- 5. Payments Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'payments')
BEGIN
    CREATE TABLE payments (
        payment_id INT IDENTITY(1,1) PRIMARY KEY,
        reservation_id INT NOT NULL FOREIGN KEY REFERENCES reservations(reservation_id) ON DELETE CASCADE ON UPDATE CASCADE,
        amount DECIMAL(18,2) NOT NULL,
        payment_date DATETIME NOT NULL DEFAULT GETDATE(),
        payment_method NVARCHAR(50) NOT NULL
    );
END
GO

-- 6. Ensure status column in customers table
IF COL_LENGTH('customers', 'status') IS NULL
BEGIN
    ALTER TABLE customers ADD status NVARCHAR(50) NULL CONSTRAINT DF_customers_status DEFAULT 'Active';
END
GO
UPDATE customers SET status = 'Active' WHERE status IS NULL;
GO

DECLARE @DemoRoomIds TABLE (room_id INT PRIMARY KEY);
DECLARE @DemoCustomerIds TABLE (customer_id INT PRIMARY KEY);

INSERT INTO @DemoRoomIds (room_id)
SELECT room_id
FROM rooms
WHERE (room_number = '101' AND event_type = 'Birthday' AND room_type = 'Standard Single Hall' AND rate = 1500.00)
   OR (room_number = '102' AND event_type = 'Anniversary' AND room_type = 'Deluxe Double Hall' AND rate = 2500.00)
   OR (room_number = '201' AND event_type = 'Wedding' AND room_type = 'Executive Grand Ballroom' AND rate = 4500.00)
   OR (room_number = '202' AND event_type = 'Team Building' AND room_type = 'Family & Corporate Hall' AND rate = 3500.00);

INSERT INTO @DemoCustomerIds (customer_id)
SELECT customer_id
FROM customers
WHERE full_name = 'John Doe' AND email = 'john@example.com';

DELETE FROM payments
WHERE reservation_id IN (
    SELECT reservation_id
    FROM reservations
    WHERE customer_id IN (SELECT customer_id FROM @DemoCustomerIds)
       OR room_id IN (SELECT room_id FROM @DemoRoomIds)
);

DELETE FROM reservations
WHERE customer_id IN (SELECT customer_id FROM @DemoCustomerIds)
   OR room_id IN (SELECT room_id FROM @DemoRoomIds);

DELETE FROM customers
WHERE customer_id IN (SELECT customer_id FROM @DemoCustomerIds);

DELETE FROM rooms
WHERE room_id IN (SELECT room_id FROM @DemoRoomIds);
GO

-- =============================================================
-- STORED PROCEDURES
-- =============================================================

CREATE OR ALTER PROCEDURE sp_AddCustomer
    @full_name NVARCHAR(150),
    @email NVARCHAR(150),
    @contact_number NVARCHAR(50) = NULL,
    @address NVARCHAR(255) = NULL,
    @status NVARCHAR(50) = 'Active',
    @customer_id INT OUTPUT
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
END
GO

CREATE OR ALTER PROCEDURE sp_AddReservation
    @customer_id INT,
    @room_id INT,
    @event_type NVARCHAR(100),
    @check_in_date DATE,
    @check_in_time TIME,
    @check_out_date DATE,
    @check_out_time TIME,
    @status NVARCHAR(50) = 'Pending',
    @reservation_id INT OUTPUT
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
END
GO

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

CREATE OR ALTER PROCEDURE sp_AddRoom
    @room_number NVARCHAR(50),
    @room_type NVARCHAR(100),
    @rate DECIMAL(18,2),
    @availability BIT = 1,
    @maintenance BIT = 0,
    @capacity INT = 50,
    @beds INT = 10,
    @image_data VARBINARY(MAX) = NULL,
    @room_id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO rooms (room_number, event_type, room_type, rate, availability, maintenance, capacity, beds, image_data, status)
    VALUES (@room_number, NULL, @room_type, @rate, @availability, @maintenance, @capacity, @beds, @image_data, 
            CASE WHEN @maintenance = 1 THEN 'Under Maintenance' WHEN @availability = 1 THEN 'Available' ELSE 'Booked' END);
    SET @room_id = CAST(SCOPE_IDENTITY() AS INT);
END
GO

CREATE OR ALTER PROCEDURE sp_UpdateRoom
    @room_id INT,
    @room_number NVARCHAR(50),
    @room_type NVARCHAR(100),
    @rate DECIMAL(18,2),
    @availability BIT,
    @maintenance BIT,
    @capacity INT,
    @beds INT,
    @image_data VARBINARY(MAX) = NULL
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
        status = CASE WHEN @maintenance = 1 THEN 'Under Maintenance' WHEN @availability = 1 THEN 'Available' ELSE 'Booked' END
    WHERE room_id = @room_id;
END
GO

CREATE OR ALTER PROCEDURE sp_GetAllReservations
AS
BEGIN
    SET NOCOUNT ON;
    SELECT r.reservation_id, r.customer_id, r.room_id, r.check_in_date, r.check_in_time, 
           r.check_out_date, r.check_out_time, r.status, r.date_reserved,
           c.full_name AS customer_name, ro.room_number,
           COALESCE(r.event_type, ro.event_type, 'Wedding') AS event_type,
           ro.room_type AS functionhall_type
    FROM reservations r
    JOIN customers c ON r.customer_id = c.customer_id
    JOIN rooms ro ON r.room_id = ro.room_id
    ORDER BY r.reservation_id DESC;
END
GO

CREATE OR ALTER PROCEDURE sp_GetPendingReservations
AS
BEGIN
    SET NOCOUNT ON;
    SELECT r.reservation_id, r.customer_id, r.room_id, r.check_in_date, r.check_in_time, 
           r.check_out_date, r.check_out_time, r.status, r.date_reserved,
           c.full_name AS customer_name, c.email, c.contact_number, ro.room_number,
           COALESCE(r.event_type, 'Wedding') AS event_type,
           ro.room_type AS functionhall_type
    FROM reservations r
    JOIN customers c ON r.customer_id = c.customer_id
    JOIN rooms ro ON r.room_id = ro.room_id
    WHERE r.status = 'Pending'
    ORDER BY r.reservation_id DESC;
END
GO

CREATE OR ALTER PROCEDURE sp_AddPayment
    @reservation_id INT,
    @amount DECIMAL(18,2),
    @payment_method NVARCHAR(50),
    @payment_id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO payments (reservation_id, amount, payment_date, payment_method)
    VALUES (@reservation_id, @amount, GETDATE(), @payment_method);
    SET @payment_id = CAST(SCOPE_IDENTITY() AS INT);
END
GO

