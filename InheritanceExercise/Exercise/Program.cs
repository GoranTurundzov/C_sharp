using System;
using Models;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Goran", "Turundzov", Role.Other, 500);
            SalesPerson sitkac = new SalesPerson("Zoran", "Turundzov", 2003);
            Manager gazda = new Manager("Elon", "Musk", 5000);

            sitkac.AddSuccessRevenue(400);
            gazda.AddBonus(5230);
            sitkac.AddSuccessRevenue(3000);

            Console.WriteLine(employee.GetInfo());
            Console.WriteLine(sitkac.GetInfo());
            Console.WriteLine(gazda.GetInfo());

          
        }
    }
}
