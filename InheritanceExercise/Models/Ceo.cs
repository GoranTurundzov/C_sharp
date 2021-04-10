using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ceo : Employee
    {
        public Employee[] Employees { get; set; }

        public int Shares { get; set; }
        
        private double SharePrice { get; set; }

        public void AddSharesPrice(double num)
        {
            SharePrice = num;
        }

        public Ceo(string firstName , string lastName , Employee[] employees , int shares , double salary = 500) : base(firstName , lastName, Role.CEO, salary)
        {
            Shares = shares;
            Employees = employees;
        }

        public Ceo()
        {

        }
        public void GetEmployees()
        {
            Console.WriteLine($"Employees of {FullName}");
            foreach(Employee employee in Employees)
            {
                Console.WriteLine(employee.GetInfo());
            }
            Console.WriteLine("-------------------------");
        }
        public override double GetSalary()
        {
            return base.GetSalary() + SharePrice * Shares;
        }
    }
}
