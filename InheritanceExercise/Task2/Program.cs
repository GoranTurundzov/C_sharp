using System;
using Models;
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager Bob = new Manager("Bob", "Bobsky", 2542);
            Manager John = new Manager("John", "Jonissimo", 5000);
            Contractor Mona = new Contractor("Mona", "Monalisa", 80, 120, Bob);
            Contractor Igor = new Contractor("Igor", "Igorski", 85, 100, John);
            SalesPerson Lea = new SalesPerson("Lea", "Leova", 87);
            Employee[] company = {Bob, John , Mona , Igor , Lea};
            Ceo Ron = new Ceo("Ron" , "Ronsky" , company , 1500 );
            Ron.AddSharesPrice(103);
            Console.WriteLine("Info " + Ron.GetInfo());
            Console.WriteLine("Salary " + Ron.GetSalary());
            Ron.GetEmployees();
        }
    }
}
