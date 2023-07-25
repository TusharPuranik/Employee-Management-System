# Employee Management System

This repository contains a simple Employee Management System implemented in C#. The system allows users to perform various operations related to employee management, such as adding, viewing, updating, and removing employee records. The system is built using an interface and class structure to ensure modularity and extensibility.

## Features
- Add Employee: Allows users to add a new employee to the system by providing necessary details like ID, Name, Department, and Salary.

- View Employee Details: Users can view the details of a specific employee by entering their ID.

- View All Employees: Displays a list of all employees currently stored in the system.

- Update Employee Details: Enables users to update an existing employee's information, including their Name, Department, and Salary, by specifying the employee's ID.

- Remove Employee: Allows users to remove an employee from the system by providing their ID.

- User-Friendly Interface: The program offers an interactive command-line interface for smooth user interactions.

## How to Use
1. Clone this repository to your local machine.
2. Open the project in a C# compatible development environment.
3. Build and run the project to launch the Employee Management System.
4. Follow the on-screen instructions to perform various operations related to employee management.

## Code Structure
- `Employee`: A class representing an individual employee with properties such as ID, Name, Department, and Salary.

- `IEmployeeManagementSystem`: An interface defining the contract for the Employee Management System.

- `EmployeeManagementSystem`: A class implementing the `IEmployeeManagementSystem` interface. It provides methods for adding, updating, removing, and retrieving employee details.

- `Program`: The entry point of the application. Contains the main menu and methods for handling user input and interactions.

