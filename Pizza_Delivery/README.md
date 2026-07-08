# 🍕 Pizza Delivery

A Windows Forms application developed in **C# (.NET Framework)** for managing a pizza delivery business. The application uses **ADO.NET** and **SQL Server LocalDB** for data storage and management.

## Features

- Pizza management (add, edit, delete)
- Customer management
- Delivery address management
- Order management
- Add multiple pizzas to an order
- Quantity selection for each pizza
- Total order calculation

## Technologies

- C#
- Windows Forms (.NET Framework)
- ADO.NET
- SQL Server LocalDB
- Git & GitHub

## Database

The application uses a LocalDB database (`PizzaDB.mdf`) with the following tables:

- Pizza
- Client
- Adresa
- Comanda
- RandComanda

Connection string:

```csharp
Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=|DataDirectory|\PizzaDB.mdf;
Integrated Security=True;
```

## Running the project

### Requirements

- Visual Studio 2022
- .NET Framework
- SQL Server LocalDB

### Steps

1. Clone the repository.
2. Open `Pizza_Delivery.sln` in Visual Studio.
3. Build the solution.
4. Run the application.