# DatabaseToExcel-

This project is a .NET Core Web API application that reads data from a SQL Server database and exports it to an Excel file using the **EPPlus** library. 
It demonstrates how to integrate Entity Framework Core for data access and generate Excel reports via an API endpoint.

DatabaseToExcel/
│
├── Controllers/
│ └── ExcelController.cs // API controller to handle Excel export
│
├── Data/
│ └── AppDbContext.cs // EF Core DB context
│
├── Models/
│ └── Player.cs // Define your data models
│
├── Program.cs // Main entry point (service config)
├── appsettings.json // DB connection string
