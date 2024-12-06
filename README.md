# Hotel Reservation System

This project simulates a hotel reservation system using PostgreSQL and C# Windows Forms. The application allows you to perform CRUD (Create, Read, Update, Delete) operations on hotel rooms, customers, and reservations.

## Features

- *Room CRUD Operations*: 
  - You can add, update, delete, and view room details.
  
- *Customer CRUD Operations*:
  - You can add, update, delete, and view customer details.
  
- *Reservation CRUD Operations*:
  - You can create, update, cancel, and view reservations.

## Requirements

- PostgreSQL
- Visual Studio
- .NET Framework (C#)

## Installation

1. *Database Setup*
   - Add your database connection details to the app.config file.
   - In your PostgreSQL database, create the following tables:
     - *Rooms*: Room number, capacity, price, etc.
     - *Customers*: First name, last name, phone, email, etc.
     - *Reservations*: Room number, customer details, date, etc.
   
2. *Project Setup*
   - Open the project in Visual Studio.
   - Build and run the project.

## Usage

- *Room Operations*: Click the Add Room button to add a new room. To view, update, or delete existing rooms, select the respective operations.
  
- *Customer Operations*: Click the Add Customer button to add a new customer. To view, update, or delete customer details, select the respective operations.

- *Reservation Operations*: Click the Add Reservation button to create a new reservation. To view, update, or cancel existing reservations, select the respective operations.

## Author

- *Zeynep Dilara Kurnaz*

## Contributing

If you'd like to contribute to this project, feel free to open a pull request.
