using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SalesPerson: Employee
    {
        protected double SuccesSaleRevenue { get; set; }

        public SalesPerson()
        {
        }

        public SalesPerson(string firstName , string lastName, double successSalesRevenue): base(firstName , lastName , Role.Sales , 500)
        {
            SuccesSaleRevenue = successSalesRevenue;
        }

        public void AddSuccessRevenue(double revenue)
        {
            SuccesSaleRevenue += revenue;
        }
        public override double GetSalary()
        {
            double bonus = 0;
            if(SuccesSaleRevenue <= 2000)
            {
                bonus = 500;
            }
            else if (SuccesSaleRevenue > 2000 && SuccesSaleRevenue <= 5000)
            {
                bonus = 1000;
            } else if (SuccesSaleRevenue > 5000)
            {
                bonus = 1500;
            }
            // if salary is private 
            // return base.GetSalary() + bonus;
            return Salary + bonus;
        }
    }
}
