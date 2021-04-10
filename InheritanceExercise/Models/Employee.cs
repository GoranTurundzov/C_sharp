using System;

namespace Models
{
    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public string FullName
        //{
        //    get
        //    {
        //        return $"{FirstName} {LastName}";
        //    }
        //}

        // ISTATA FUNKCIJA TO ISKOMENTIRANOTO POGORE!
        public string FullName => $"{FirstName} {LastName}";

        public Role Role { get; set; }

        protected double Salary { get; set; }

        public Employee()
        {

        }
        public Employee(string firstName , string lastName , Role role , double salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Salary = salary;
        }
        public string GetInfo()
        {
            //Get Salary e povikano za da Vrakja so + bonusi ! oti ako e samo Salary ke vrakja fiksno.
            return $" {FullName} ({Role}) : {GetSalary()}";
        }
        public virtual double GetSalary()
        {
            return Salary;
        }
    }
}
