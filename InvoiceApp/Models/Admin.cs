using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Admin : Person
    {
        public EnumCompany Company { get; set; }
        public Admin(string from,  string username, string password , EnumCompany company): base (from, string.Empty, username, password , true)
        {
            Company = company;
        }


        public string GetInvoicesByMyCompany(List<Person> list)
        {
            string invoices = $"Invoices by {Company} : \n \n";

            foreach(User user in list)
            {
                foreach(Invoice invoice in user.Invoices)
                {
                    invoices += invoice.Company == Company ? $"{user.FullName} {invoice.Bill} {invoice.DueDate} \n" : string.Empty;
                }
            }

            return invoices;
        }
    }
}
