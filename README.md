# Event and Venue Reservation System

A Windows desktop application for managing venue rooms, reservations, customers, payments, check-in/check-out, and reports. It is built with .NET 8 Windows Forms and Microsoft SQL Server.

## Architecture

The application uses a layered desktop architecture:

- **Presentation:** Windows Forms screens in `Forms/`, including administrator/coordinator workflows and customer-facing screens in `Forms/UserForms/`.
- **Data access:** SQL Server connection and schema handling in `Database/DbConnection.cs`, with domain-specific data access objects (DAOs) in `Database/`.
- **Models:** Reservation, room, customer, payment, and report data types in `Models/`.
- **Utilities:** Input validation and report generation in `Utils/`.
- **Persistence:** SQL Server schema and seed script at the repository root, plus stored procedures in `Database/SetupStoredProcedures.sql`.
- **Assets:** Embedded resources in `Properties/` and application images in `Resources/`.

The main flow is `Forms -> Database DAOs -> SQL Server`; models carry application data, while utility classes provide shared validation and reporting behavior.

## Project structure

```text
.
├── Database/                 # SQL connection, DAOs, and stored procedures
├── Forms/                    # Administrator, coordinator, and customer UI
│   └── UserForms/            # Customer-facing workflows
├── Models/                   # Application data models
├── Properties/               # Embedded resource definitions
├── Resources/                # UI images and other assets
├── Utils/                    # Validation and report generation
├── App.config                # SQL Server connection string
├── EventsAndVenueReservationSystem.csproj
├── EventsAndVenueReservationSystem.slnx
└── events_and_venue_reservation_sql_server.sql
```

## Requirements

- Windows
- .NET 8 SDK
- Microsoft SQL Server or SQL Server Express

## Setup and run

1. Create the database and tables by running `events_and_venue_reservation_sql_server.sql` in SQL Server Management Studio.
2. Run `Database/SetupStoredProcedures.sql` against the created database.
3. Update the `SqlServerConnection` value in `App.config` for your SQL Server instance. The default uses Windows Authentication with `localhost\SQLEXPRESS`.
4. Before initializing the database, replace the `CHANGE_ME_BEFORE_USE` seed passwords with unique passwords for your local environment.
5. Restore, build, and run the Windows Forms project:

   ```powershell
   dotnet restore EventsAndVenueReservationSystem.csproj
   dotnet build EventsAndVenueReservationSystem.csproj
   dotnet run --project EventsAndVenueReservationSystem.csproj
   ```
