using System;
using System.Collections.Generic;

namespace HK2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Display();
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}");
        }
    }

    class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee emp)
        {
            if (employees.Exists(e => e.Id == emp.Id))
            {
                Console.WriteLine("ID already exists!");
                return;
            }
            employees.Add(emp);
            Console.WriteLine("Added successfully!");
        }

        public void ShowAll()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees yet.");
                return;
            }

            Console.WriteLine("\n--- Employee List ---");
            foreach (var e in employees)
                e.ShowInfo();
        }

        public void EditEmployee(int id, string newName)
        {
            var emp = employees.Find(e => e.Id == id);
            if (emp == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            emp.Name = newName;
            Console.WriteLine("Updated successfully!");
        }
    }

    class Menu
    {
        EmployeeManager manager = new EmployeeManager();

        public void Display()
        {
            while (true)
            {
                Console.WriteLine("\n=== Employee Menu ===");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Show All");
                Console.WriteLine("3. Edit Employee");
                Console.WriteLine("4. Exit");
                Console.Write("Your choice: ");
                string choice = Console.ReadLine()!;

                if (choice == "1") Add();
                else if (choice == "2") manager.ShowAll();
                else if (choice == "3") Edit();
                else if (choice == "4") break;
                else Console.WriteLine("Invalid choice!");
            }
        }

        void Add()
        {
            Employee emp = new Employee();

            Console.Write("Enter ID: ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Invalid ID! Please enter a number.");
                return;
            }
            emp.Id = id;

            Console.Write("Enter Name: ");
            emp.Name = Console.ReadLine() ?? "";

            manager.AddEmployee(emp);
        }

        void Edit()
        {
            Console.Write("Enter ID to edit: ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Invalid ID! Please enter a number.");
                return;
            }

            Console.Write("Enter new name: ");
            string newName = Console.ReadLine() ?? "";

            manager.EditEmployee(id, newName);
        }
    }
}
