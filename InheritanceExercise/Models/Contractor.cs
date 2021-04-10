using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Contractor : Employee
    {
        public double WorkHours { get; set; }

        public int PayPerHour { get; set; }

        public double TheSalary => WorkHours * PayPerHour;

        public Manager Responsible { get; set; }
        public Contractor()
        {

        }
        public Contractor(string firstName , string lastName , double workHours , int payPerHour , Manager responsible): base(firstName , lastName , Role.Contractor , payPerHour*workHours)
        {

            Responsible = responsible;
            PayPerHour = payPerHour;
            WorkHours = workHours;

        }
        public override double GetSalary()
        {
            return TheSalary;
        }

        public string CurrentPosition()
        {
            return Responsible.GetInfo();
        }
    }
}
