using System;
using System.Collections.Generic;

namespace Action
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = Employee.GetEmployees();

            Action<Employee> empAction = new Action<Employee>(CalculateAge);
            employees.ForEach(empAction);

            foreach (Employee e in employees)
            {
                Console.WriteLine("Agee of employee: " + e.Age);
            } Console.WriteLine();

            Predicate<Employee> predicate = new Predicate<Employee>(BornInNinteenEightySix);

            Console.WriteLine("First name: " + employees.Find(predicate).FirstName);

            // Or by using Lambda Expressions.
            Console.Write("First name: ");
            Console.WriteLine(employees.Find(e => e.Birthday.Year == 1986).FirstName);
            Console.WriteLine();

            Func<int, string> myFunc = new Func<int, string>(MyMethod);
            Console.WriteLine(myFunc(3));
            Console.WriteLine();
        }

        static void CalculateAge(Employee emp)
        {
            emp.Age = DateTime.Now.Year - emp.Birthday.Year;
        }

        static bool BornInNinteenEightySix(Employee emp)
        {
            return emp.Birthday.Year == 1986;
        }

        static string MyMethod(int i)
        {
            return "You entered: " + i;
        }
    }
}