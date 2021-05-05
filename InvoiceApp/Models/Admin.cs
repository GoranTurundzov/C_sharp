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
        public Admin(string from,  string username, string password , EnumCompany company , string pin): base (from, string.Empty, username, password , true , pin)
        {
            Company = company;
        }


        public string GetInvoicesByMyCompany( )
        {
            string invoices = $"Invoices issued by {Company}  \n{ "Issued To",25} | { "Date Issued",8} | { "Due Date",8} | { "Bill",6} | Payed  \n ";

            foreach (User user in DataBase.Users.Where(x => !x.Admin).ToList())
            {
                  
                    foreach (Invoice invoice in user.Invoices)
                    {
                    string payed = invoice.Payed ? "Payed" : "NOT-PAYED";
                        invoices += invoice.Company == Company ? $"{ user.FullName,25} | { invoice.DateIssued.ToString("dd, MM , yyyy"),8} | { invoice.DueDate.ToString("dd, MM , yyyy"),8} | { invoice.Bill,6} | {payed} \n " : string.Empty;
                    }
                
            }

            return invoices;
        }

        public string GetInfo()
        {
            return $"{FirstName} {Company} ";
        }
    }
}
