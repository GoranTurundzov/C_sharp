using System;
using System.Collections.Generic;
using System.IO;
using CarDealership.Domain.Database;
using Newtonsoft.Json;
using CarDealership.Domain.Models;
using Models;


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
            ShopDB.Users.AddRange(supplyerOutput);
        }
    }
}
