using System;
using System.Linq;
using System.Collections.Generic;
namespace Models
{
    public class User : Person
    {

       

        public string FullName => $"{FirstName} {LastName}";

        private long Phone { get; set; }

        public int Balance { get; set; } = 1000;
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
        public User (string firstName , string lastName ,long phone, string username , string password): base (firstName , lastName , username , password , false)
        {
            Phone = phone;
        }
       
       

        public string GetInvoices()
        {
            string invoice = $"Invoices: \n  {"No."}. {"Company" , 10} | {"Bill" , 10} | {"Date Issued" , 10} | {"Due Date"}"  ;

            for(int i = 0; i < Invoices.Count; i++)
            {
                invoice += $"{i + 1}. {Invoices[i].Company,10} | {Invoices[i].Bill,10} | {Invoices[i].DateIssued} | {Invoices[i].DueDate} \n  \n";
            }

            return invoice;
        }

        public string GetUnpayedInvoices()
        {
            string invoice = $"Unpayed Invoices: \n  {"No."}. {"Company",10} | {"Bill",10} | {"Date Issued",10} | {"Due Date"}";
            int i = 1;
            foreach(Invoice unpayed in Invoices)
            {
                if (!unpayed.Payed)
                {
                    invoice += $"{i}. {unpayed.Company,10} | {unpayed.Bill,10} | {unpayed.DateIssued} | {unpayed.DueDate} \n  \n";
                    i++;
                }
                
            }

            return invoice;
        }

        public void AddFunds(int num)
        {
            Balance += num;
        }

        public bool PayInvoice(int index)
        {

            if (Invoices[index].FullBill() <= Balance) return true;
            else return false;
        }

    }
}
