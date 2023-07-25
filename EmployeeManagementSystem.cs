using System;
using System.Collections.Generic;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}

public interface IEmployeeManagementSystem
{
    void AddEmployee(Employee employee);
    void UpdateEmployee(Employee employee);
    void RemoveEmployee(int id);
    Employee GetEmployeeById(int id);
    List<Employee> GetAllEmployees();
}

public class EmployeeManagementSystem : IEmployeeManagementSystem
{
    private List<Employee> employees;

    public EmployeeManagementSystem()
    {
        employees = new List<Employee>();
    }

    public void AddEmployee(Employee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee), "Employee cannot be null.");
        }

        employees.Add(employee);
    }

    public void UpdateEmployee(Employee updatedEmployee)
    {
        Employee existingEmployee = employees.Find(emp => emp.Id == updatedEmployee.Id);
        if (existingEmployee != null)
        {
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Department = updatedEmployee.Department;
            existingEmployee.Salary = updatedEmployee.Salary;
        }
        else
        {
            throw new ArgumentException("Employee with specified ID not found.", nameof(updatedEmployee));
        }
    }

    public Employee GetEmployeeById(int id)
    {
        Employee employee = employees.Find(emp => emp.Id == id);
        return employee;
    }

    public List<Employee> GetAllEmployees()
    {
        return employees;
    }

    public void RemoveEmployee(int id)
    {
        Employee employee = employees.Find(emp => emp.Id == id);
        if (employee != null)
        {
            employees.Remove(employee);
        }
        else
        {
            throw new ArgumentException("Employee with specified ID not found.", nameof(id));
        }
    }
}

class Program
{
    static void Main()
    {
        EmployeeManagementSystem empManagementSystem = new EmployeeManagementSystem();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nEmployee Management System");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. View Employee Details");
            Console.WriteLine("3. View All Employees");
            Console.WriteLine("4. Update Employee Details");
            Console.WriteLine("5. Remove Employee");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice (1-6): ");
            string choiceStr = Console.ReadLine();
            int choice;

            if (!int.TryParse(choiceStr, out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid choice.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddEmployee(empManagementSystem);
                    break;
                case 2:
                    ViewEmployeeDetails(empManagementSystem);
                    break;
                case 3:
                    ViewAllEmployees(empManagementSystem);
                    break;
                case 4:
                    UpdateEmployeeDetails(empManagementSystem);
                    break;
                case 5:
                    RemoveEmployee(empManagementSystem);
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    static void AddEmployee(EmployeeManagementSystem empManagementSystem)
    {
        Employee newEmployee = new Employee();

        Console.Write("Enter Employee ID: ");
        newEmployee.Id = int.Parse(Console.ReadLine());

        Console.Write("Enter Employee Name: ");
        newEmployee.Name = Console.ReadLine();

        Console.Write("Enter Employee Department: ");
        newEmployee.Department = Console.ReadLine();

        Console.Write("Enter Employee Salary: ");
        newEmployee.Salary = double.Parse(Console.ReadLine());

        empManagementSystem.AddEmployee(newEmployee);
        Console.WriteLine("Employee added successfully.");
    }

    static void ViewEmployeeDetails(EmployeeManagementSystem empManagementSystem)
    {
        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());

        Employee employee = empManagementSystem.GetEmployeeById(id);
        if (employee != null)
        {
            DisplayEmployee(employee);
        }
        else
        {
            Console.WriteLine($"Employee with ID {id} not found.");
        }
    }

    static void ViewAllEmployees(EmployeeManagementSystem empManagementSystem)
    {
        List<Employee> allEmployees = empManagementSystem.GetAllEmployees();
        if (allEmployees.Count > 0)
        {
            Console.WriteLine("All Employees:");
            DisplayEmployees(allEmployees);
        }
        else
        {
            Console.WriteLine("No employees found.");
        }
    }

    static void UpdateEmployeeDetails(EmployeeManagementSystem empManagementSystem)
    {
        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine());

        Employee existingEmployee = empManagementSystem.GetEmployeeById(id);
        if (existingEmployee != null)
        {
            Employee updatedEmployee = new Employee();

            Console.Write("Enter Updated Name: ");
            updatedEmployee.Name = Console.ReadLine();

            Console.Write("Enter Updated Department: ");
            updatedEmployee.Department = Console.ReadLine();

            Console.Write("Enter Updated Salary: ");
            updatedEmployee.Salary = double.Parse(Console.ReadLine());

            updatedEmployee.Id = id;
            empManagementSystem.UpdateEmployee(updatedEmployee);
            Console.WriteLine($"Employee with ID {id} updated successfully.");
        }
        else
        {
            Console.WriteLine($"Employee with ID {id} not found.");
        }
    }

    static void RemoveEmployee(EmployeeManagementSystem empManagementSystem)
    {
        Console.Write("Enter Employee ID to remove: ");
        int id = int.Parse(Console.ReadLine());

        try
        {
            empManagementSystem.RemoveEmployee(id);
            Console.WriteLine($"Employee with ID {id} removed successfully.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void DisplayEmployee(Employee employee)
    {
        Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Department: {employee.Department}, Salary: {employee.Salary}");
    }

    static void DisplayEmployees(List<Employee> employees)
    {
        foreach (Employee emp in employees)
        {
            DisplayEmployee(emp);
        }
    }
}
