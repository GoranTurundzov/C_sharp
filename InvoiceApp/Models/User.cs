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
        public List<Invoice> Invoices { get; set; }
        public User(string firstName, string lastName, long phone, string username, string password) : base(firstName, lastName, username, password, false)
        {
            Phone = phone;
            Invoices = new List<Invoice>();
        }



        public string GetInvoices()
        {
            string invoice = $"Invoices: \n  {"No."}. {"Company",10} | {"Bill",10} | {"Date Issued",10} | {"Due Date"} | Payed \n";

            for (int i = 0; i < Invoices.Count; i++)
            {
                string info = Invoices[i].Payed ? "Payed" : "Unpayed";
                invoice += $"{i + 1}. {Invoices[i].Company,10} | {Invoices[i].Bill,10} | {Invoices[i].DateIssued.ToString("dd. MM. yyyy")} | {Invoices[i].DueDate.ToString("dd. MM.yyyy")} | {info} \n  \n";
            }

            return invoice;
        }

        public string GetUnpayedInvoices()
        {
            List<Invoice> unpayedInvoices = Helper.ClearPayed(Invoices);
            string invoice = $"Unpayed Invoices: \n{"No." , 4}. {"Company",10} | {"Bill",10} | {"Date Issued",10} | {"Due Date" , 10} | \n";
            int i = 0;

            foreach (Invoice unpayed in unpayedInvoices)
            {
                invoice += $"{i + 1 , 4}. {unpayed.Company,10} | {unpayed.Bill,10} | {unpayed.DateIssued.ToString("dd. MM. yyyy")} | {unpayed.DueDate.ToString("dd. MM. yyyy")}  \n  \n";
                i++;

            }

            return invoice;
        }

        public Invoice PayInvoice()
        {
            List<Invoice> tbp = Helper.ClearPayed(Invoices);
            while (true)
            {
                int num = -5;
                Console.WriteLine("Select an invoice to pay                                            Press X to exit");
                string selected = Console.ReadLine();
                if (int.TryParse(selected, out num) && num > 0 && num <= tbp.Count)
                {
                    if (PayInvoice(tbp[num - 1]))
                    {
                        tbp[num - 1].Payed = true;
                        Console.WriteLine($"Succesfully payed {tbp[num - 1].Descriiption}");
                        Balance -= (int)tbp[num - 1].Bill;
                        return tbp[num - 1];
                    }
                    else
                    {

                        throw new Exception("Insufficient Funds");
                    }

                } else if (selected.ToLower() == "x")
                {
                    throw new Exception("Exiting");
                }
                else
                {
                    Console.WriteLine("Invalid Selection");
                }


            }

        }

        public void AddFunds(int num)
        {
            Balance += num;
        }

        public bool PayInvoice(Invoice invoice)
        {

            if (invoice.Intrest() <= Balance) return true;
            else return false;



        }

        public string GetInfo()
        {
            return $"{FullName} : {Balance}";
        }
        
    }
}
