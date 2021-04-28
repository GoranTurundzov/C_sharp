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


        public void Intrest()
        { 
                int days = 0;
                DateTime start = DueDate;
                while (start < DateTime.Now)
                {
                    days++;
                    start = start.AddDays(1);
                }
            Bill += (days / 30) * 10;

        }


        public double FullBill()
        {
            Intrest();
            return Bill;
        }
    }
}
