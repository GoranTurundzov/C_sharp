using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Invoice
    {
        public string Descriiption { get; set; }

        public EnumCompany Company { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime DateIssued { get; set; }

        public double Bill { get; set; }

        public bool Payed { get; set; } = false;

        public Invoice(string description, EnumCompany company , DateTime issued , DateTime dueDate, double bill)
        {
            Descriiption = description;
            Company = company;
            DateIssued = issued;
            DueDate = dueDate;
            Bill = bill;
        }
        public Invoice(string description, EnumCompany company, DateTime issued, DateTime dueDate, double bill , bool payed)
        {
            Descriiption = description;
            Company = company;
            DateIssued = issued;
            DueDate = dueDate;
            Bill = bill;
            Payed = payed;
        }

        public double Intrest()
        { 
                int days = 0;
                DateTime start = DueDate;
            if(start < DateTime.Now)
            {
                while (start < DateTime.Now)
                {
                    days++;
                    start = start.AddDays(1);
                }
                double full = Bill + (days / 30) * 10;
                Console.WriteLine($"You are {days} days late on payment. Intrest of {(days / 30) * 10} added. New BIll is {Bill}");
                return full;
            }
            return Bill;

           
        }


        
    }
}
