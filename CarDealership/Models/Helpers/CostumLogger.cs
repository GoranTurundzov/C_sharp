using System;
using System.Collections.Generic;
using System.IO;
using CarDealership.Domain.Database;
using Newtonsoft.Json;
using CarDealership.Domain.Models;
using Models;
using ClosedXML.Excel;

namespace CarDealership.Domain.Helpers
{
    public static class CostumLogger
    {



        public static void WriteContent(string content , string filePath)
        {
            if (!string.IsNullOrEmpty(content))
            {

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(content);
                }


            }
        }
        public static string ReadContent(string path)
        {
            string json = "";
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }
            return json;
        }

        public static void LogDataBase()
        {
            string supplyers = JsonConvert.SerializeObject(ShopDB.Supplyers);
            WriteContent(supplyers, @"..\..\..\supplyers.json");
            string costumers = JsonConvert.SerializeObject(ShopDB.Costumers);
            WriteContent(costumers, @"..\..\..\costumers.json");
            string managers = JsonConvert.SerializeObject(ShopDB.Managers);
            WriteContent(managers, @"..\..\..\managers.json");
            string automobiles = JsonConvert.SerializeObject(ShopDB.Automobiles);
            WriteContent(automobiles, @"..\..\..\automobiles.json");
            string vans = JsonConvert.SerializeObject(ShopDB.Vans);
            WriteContent(vans, @"..\..\..\vans.json");
            string trucks = JsonConvert.SerializeObject(ShopDB.Trucks);
            WriteContent(trucks, @"..\..\..\trucks.json");
        }
        public static void FillDataBase()
        {
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Auto;

            string automobiles = ReadContent(@"..\..\..\automobiles.json");
            List<Automobile> automobileOutput = JsonConvert.DeserializeObject<List<Automobile>>(automobiles, settings);
            ShopDB.Automobiles.AddRange(automobileOutput);
            string vans = ReadContent(@"..\..\..\vans.json");
            List<Van> vansOutput = JsonConvert.DeserializeObject<List<Van>>(vans, settings);
            ShopDB.Vans.AddRange(vansOutput);
            string trucks = ReadContent(@"..\..\..\trucks.json");
            List<Truck> trucksOutput = JsonConvert.DeserializeObject<List<Truck>>(trucks, settings);
            ShopDB.Trucks.AddRange(trucksOutput);
            string costumers = ReadContent(@"..\..\..\costumers.json");
            List<Costumer> costumersOutput = JsonConvert.DeserializeObject<List<Costumer>>(costumers, settings);
            ShopDB.Costumers.AddRange(costumersOutput);
            string managers = ReadContent(@"..\..\..\managers.json");
            List<Manager> managerOutput = JsonConvert.DeserializeObject<List<Manager>>(managers, settings);
            ShopDB.Managers.AddRange(managerOutput);
            string supplyers = ReadContent(@"..\..\..\supplyers.json");
            List<Supplyer> supplyerOutput = JsonConvert.DeserializeObject<List<Supplyer>>(supplyers, settings);
            ShopDB.Supplyers.AddRange(supplyerOutput);
        }


        public static void LogToExcelFIle()
        {
            if (!File.Exists(@"..\..\..\data.xlsx"))
            {
                File.Create(@"..\..\..\data.xlsx");
            }
            string path = @"..\..\..\data.xlsx";

            XLWorkbook workbook = new XLWorkbook();
            WriteCostumersToSheet(workbook);
            WriteManagersToSheet(workbook);
            WriteSupplyersToSheet(workbook);
            WriteAutomobilesToSheet(workbook);
            WriteVansToSHeet(workbook);
            WriteTrucksToSheet(workbook);


            workbook.SaveAs(path);


        }
        public static XLWorkbook WriteCostumersToSheet(XLWorkbook workbook)
        {
            
            bool exists = false;
            foreach (IXLWorksheet worksheet in workbook.Worksheets)
            {
                if (worksheet.Name == "Costumers")
                {
                    exists = true;
                }
            }
            if (!exists)
            {
                workbook.AddWorksheet("Costumers");
            }
            
            IXLWorksheet costumerWs = workbook.Worksheet("Costumers");
            int row = 2;
            costumerWs.Cell("A1").Value = "Name";
            costumerWs.Cell("B1").Value = "LastName";
            costumerWs.Cell("C1").Value = "Email";
            costumerWs.Cell("D1").Value = "Age";
            costumerWs.Cell("E1").Value = "Balance";
            costumerWs.Cell("F1").Value = "Username";
            costumerWs.Cell("G1").Value = "Password";


            foreach (Costumer costumer in ShopDB.Costumers)
            {
                costumerWs.Cell($"A{row}").Value = costumer.FirstName;
                costumerWs.Cell($"B{row}").Value = costumer.LastName;
                costumerWs.Cell($"C{row}").Value = costumer.Email;
                costumerWs.Cell($"D{row}").Value = $"{costumer.Age}";
                costumerWs.Cell($"E{row}").Value = $"{costumer.Balance}";
                costumerWs.Cell($"F{row}").Value = costumer.Username;
                costumerWs.Cell($"G{row}").Value = costumer.Password;
                row++;
            }
             return workbook;

        }
        public static XLWorkbook WriteManagersToSheet(XLWorkbook workbook)
        {
            
            bool exists = false;
            foreach (IXLWorksheet worksheet in workbook.Worksheets)
            {
                if (worksheet.Name == "Managers") exists = true;
            }
            if (!exists)
            {
                workbook.AddWorksheet("Managers");
            }
            IXLWorksheet ws = workbook.Worksheet("Managers");
            int row = 2;
        ws.Cell("A1").Value = "Name";
        ws.Cell("B1").Value = "LastName";
        ws.Cell("C1").Value = "Email";
        ws.Cell("D1").Value = "Age";
        ws.Cell("E1").Value = "Experience";
        ws.Cell("F1").Value = "Username";
        ws.Cell("G1").Value = "Password";


            foreach (Manager manager in ShopDB.Managers)
            {
                ws.Cell($"A{row}").Value = manager.FirstName;
                ws.Cell($"B{row}").Value = manager.LastName;
                ws.Cell($"C{row}").Value = manager.Email;
                ws.Cell($"D{row}").Value = $"{manager.Age}";
                ws.Cell($"E{row}").Value = $"{manager.YearsExperience}";
                ws.Cell($"F{row}").Value = manager.Username;
                ws.Cell($"G{row}").Value = manager.Password;
                row++;
            }
            return workbook;
        }

        
        public static XLWorkbook WriteSupplyersToSheet(XLWorkbook workbook)
        {
           
            bool exists = false;
            foreach (IXLWorksheet worksheet in workbook.Worksheets)
            {
                if (worksheet.Name == "Supplyers") exists = true;
            }
            if (!exists)
            {
                workbook.AddWorksheet("Supplyers");

            }
            IXLWorksheet ws = workbook.Worksheet("Supplyers");
            int row = 2;
            ws.Cell("A1").Value = "Name";
            ws.Cell("B1").Value = "LastName";
            ws.Cell("C1").Value = "Email";
            ws.Cell("D1").Value = "Age";
            ws.Cell("E1").Value = "Salary (euros)";
            ws.Cell("F1").Value = "Username";
            ws.Cell("G1").Value = "Password";


            foreach (Supplyer supplyer in ShopDB.Supplyers)
            {
                ws.Cell($"A{row}").Value = supplyer.FirstName;
                ws.Cell($"B{row}").Value = supplyer.LastName;
                ws.Cell($"C{row}").Value = supplyer.Email;
                ws.Cell($"D{row}").Value = $"{supplyer.Age}";
                ws.Cell($"E{row}").Value = $"{supplyer.Salary}";
                ws.Cell($"F{row}").Value = supplyer.Username;
                ws.Cell($"G{row}").Value = supplyer.Password;
                row++;
            }
            return workbook;
        }

        //Znam deka bi mozel da iskoristam generika no zaglaviv na toa kako da dodadam razlicnite elementi
        public static XLWorkbook WriteAutomobilesToSheet(XLWorkbook workbook)
        {
           
            bool exists = false;
            foreach (IXLWorksheet worksheet in workbook.Worksheets)
            {
                if (worksheet.Name == "Automobiles")
                {
                    exists = true;
                }
            }
            if (!exists)
            {
                workbook.AddWorksheet("Automobiles");
            }

            IXLWorksheet costumerWs = workbook.Worksheet("Automobiles");
            int row = 2;
            costumerWs.Cell("A1").Value = "Manufacturer";
            costumerWs.Cell("B1").Value = "Model";
            costumerWs.Cell("C1").Value = "Year";
            costumerWs.Cell("D1").Value = "KM passed";
            costumerWs.Cell("E1").Value = "CC";
            costumerWs.Cell("F1").Value = "Horse Power";
            costumerWs.Cell("G1").Value = "Color";
            costumerWs.Cell("H1").Value = "Color Type";
            costumerWs.Cell("I1").Value = "Hook";
            costumerWs.Cell("J1").Value = "Price";


            foreach (Automobile automobile in ShopDB.Automobiles)
            {
                costumerWs.Cell($"A{row}").Value = automobile.Name;
                costumerWs.Cell($"B{row}").Value = automobile.Model;
                costumerWs.Cell($"C{row}").Value = $"{automobile.ManufactureYear}";
                costumerWs.Cell($"D{row}").Value = $"{automobile.KmPassed}";
                costumerWs.Cell($"E{row}").Value = $"{automobile.CC}";
                costumerWs.Cell($"F{row}").Value = $"{automobile.HorsePower}";
                costumerWs.Cell($"G{row}").Value = automobile.Color;
                costumerWs.Cell($"H{row}").Value = automobile.Paint;
                costumerWs.Cell($"I{row}").Value = automobile.HasTrailerHook ? "Yes" : "No";
                costumerWs.Cell($"I{row}").Value = $"{automobile.Price}";
                row++;
            }
            return workbook;

        }

        public static XLWorkbook WriteTrucksToSheet(XLWorkbook workbook)
        {
            
            bool exists = false;
            foreach (IXLWorksheet worksheet in workbook.Worksheets)
            {
                if (worksheet.Name == "Trucks")
                {
                    exists = true;
                }
            }
            if (!exists)
            {
                workbook.AddWorksheet("Trucks");
            }

            IXLWorksheet costumerWs = workbook.Worksheet("Trucks");
            int row = 2;
            costumerWs.Cell("A1").Value = "Manufacturer";
            costumerWs.Cell("B1").Value = "Model";
            costumerWs.Cell("C1").Value = "Year";
            costumerWs.Cell("D1").Value = "KM passed";
            costumerWs.Cell("E1").Value = "CC";
            costumerWs.Cell("F1").Value = "Horse Power";
            costumerWs.Cell("G1").Value = "Color";
            costumerWs.Cell("H1").Value = "Color Type";
            costumerWs.Cell("I1").Value = "Is PickUp";
            costumerWs.Cell("J1").Value = "Price";


            foreach (Truck truck in ShopDB.Trucks)
            {
                costumerWs.Cell($"A{row}").Value =    truck.Name;
                costumerWs.Cell($"B{row}").Value =    truck.Model;
                costumerWs.Cell($"C{row}").Value = $"{truck.ManufactureYear}";
                costumerWs.Cell($"D{row}").Value = $"{truck.KmPassed}";
                costumerWs.Cell($"E{row}").Value = $"{truck.CC}";
                costumerWs.Cell($"F{row}").Value = $"{truck.HorsePower}";
                costumerWs.Cell($"G{row}").Value =    truck.Color;
                costumerWs.Cell($"H{row}").Value =    truck.Paint;
                costumerWs.Cell($"I{row}").Value =    truck.IsPickUp ? "Yes" : "No";
                costumerWs.Cell($"I{row}").Value = $"{truck.Price}";
                row++;
            }
            return workbook;

        }

        public static XLWorkbook WriteVansToSHeet(XLWorkbook workbook)
        {
        
            bool exists = false;
            foreach (IXLWorksheet worksheet in workbook.Worksheets)
            {
                if (worksheet.Name == "Vans")
                {
                    exists = true;
                }
            }
            if (!exists)
            {
                workbook.AddWorksheet("Vans");
                

            }

            IXLWorksheet costumerWs = workbook.Worksheet("Vans");
            int row = 2;
            costumerWs.Cell("A1").Value = "Manufacturer";
            costumerWs.Cell("B1").Value = "Model";
            costumerWs.Cell("C1").Value = "Year";
            costumerWs.Cell("D1").Value = "KM passed";
            costumerWs.Cell("E1").Value = "CC";
            costumerWs.Cell("F1").Value = "Horse Power";
            costumerWs.Cell("G1").Value = "Color";
            costumerWs.Cell("H1").Value = "Color Type";
            costumerWs.Cell("I1").Value = "Has Back Windows";
            costumerWs.Cell("J1").Value = "Price";


            foreach (Van van in ShopDB.Vans)
            {
                costumerWs.Cell($"A{row}").Value =    van.Name;
                costumerWs.Cell($"B{row}").Value =    van.Model;
                costumerWs.Cell($"C{row}").Value = $"{van.ManufactureYear}";
                costumerWs.Cell($"D{row}").Value = $"{van.KmPassed}";
                costumerWs.Cell($"E{row}").Value = $"{van.CC}";
                costumerWs.Cell($"F{row}").Value = $"{van.HorsePower}";
                costumerWs.Cell($"G{row}").Value =    van.Color;
                costumerWs.Cell($"H{row}").Value =    van.Paint;
                costumerWs.Cell($"I{row}").Value =    van.HasBackWindows ? "Yes" : "No";
                costumerWs.Cell($"I{row}").Value = $"{van.Price}";
                row++;
            }
            return workbook;

        }

    }
}
