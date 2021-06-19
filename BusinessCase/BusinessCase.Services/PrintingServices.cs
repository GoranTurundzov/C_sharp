using BusinessCase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;

namespace BusinessCase.Services
{
    public static class PrintingServices
    {
        public static  string productTemplate = @"..\..\..\..\BusinessCase.Services\Templates\ProductTemplate.txt";
        public static  string receiptTamplatePath = @"..\..\..\..\BusinessCase.Services\Templates\ReceiptTemplate.txt";
        public static List<Product> ProductList { get; set; }


        public static void FillList()
        {
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Auto;
            ProductList = JsonConvert.DeserializeObject<List<Product>>(ApiCallService.ApiCall(), settings);
        }
      
        
        public static string PrintProducts(List<Product> products)
        {
            
            string output = "";
            foreach(Product product in products)
            {
                //string description = string.Empty;
                //string weight = "";
                //if(product.Description.Length > 30)
                //{
                //    description = product.Description.Substring(0, 30) + "...";
                //} else 
                //{ 
                //    description = product.Description;
                //}
                //if(product.Weight == null) { weight = "N/A"; } else { weight = product.Weight.ToString() + "g"; }
                //output += $" ... { product.Name} \n  Price: ${ product.Price.ToString("C", new CultureInfo("en-US"))} \n {description} \n Weight: {weight}";
                output += TemplateProduct(product.Name, product.Price, product.Description, product.Weight);
            }
            return output;
        }
        public static string TemplateProduct(string name, double price, string description, double? weight)
        {
            StringBuilder pb = new StringBuilder(ReadTemplate(productTemplate));

            string product = pb
                .Replace("{name}", name)
                .Replace("{price}", price.ToString("C", new CultureInfo("en-US")))
                .Replace("{description}", description.Length > 30 ? description.Substring(0, 30) + "..." : description)
                .Replace("{weight}", weight == null ? "N/A" : weight.ToString())
                .ToString();

            return product;
        }

        public static string ReadTemplate(string path)
        {
            using (var sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }

      
    }
}
