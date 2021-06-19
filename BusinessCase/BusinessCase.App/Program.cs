using BusinessCase.Services;
using System;

namespace BusinessCase.App
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintingServices.FillList();

             Console.WriteLine(PrintReceiptService.PrintBill());


      
        }
    }
}
