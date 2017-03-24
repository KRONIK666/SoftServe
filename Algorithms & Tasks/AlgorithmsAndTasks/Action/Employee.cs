using System;
using System.Collections.Generic;

namespace Action
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }

        public static List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    FirstName = "Jaliya",
                    LastName = "Udagedara",
                    Birthday =  Convert.ToDateTime("1986-09-11")
                },
                new Employee()
                {
                    FirstName = "Gary",
                    LastName = "Smith",
                    Birthday = Convert.ToDateTime("1988-03-20")
                }
            };
        }
    }
}