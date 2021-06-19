using BusinessCase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCase.Services
{
    public static class PrintReceiptService
    {
        public static string PrintBill()
        {
            if (PrintingServices.ProductList.Count == 0) throw new Exception("No products were found");
            List<Product> domesticPorducts = PrintingServices.ProductList.Where(x => x.Domestic).OrderBy(x => x.Name).ToList();
            List<Product> importedProducts = PrintingServices.ProductList.Where(x => !x.Domestic).OrderBy(x => x.Name).ToList();

            StringBuilder sb = new StringBuilder(PrintingServices.ReadTemplate(PrintingServices.receiptTamplatePath));
            string output = sb
                .Replace("{domesticproducts}", PrintingServices.PrintProducts(domesticPorducts))
                .Replace("{importedproducts}", PrintingServices.PrintProducts(importedProducts))
                .Replace("{domesticcost}", domesticPorducts.Sum(x => x.Price).ToString())
                .Replace("{importedcost}", importedProducts.Sum(x => x.Price).ToString())
                .Replace("{domesticcount}", domesticPorducts.Count.ToString())
                .Replace("{importedcount}", importedProducts.Count.ToString())
                .ToString();

            return output;
        }
    }
}
