using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.IO;
using CarDealership.Domain.Database;
using Newtonsoft.Json;
using CarDealership.Domain.Models;
using Models;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

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
           
            string users = JsonConvert.SerializeObject(ShopDB.Users);
            WriteContent(users, "users.json");
            string vehicles = JsonConvert.SerializeObject(ShopDB.Vehicles);
            WriteContent(vehicles, "vehicles.json");
        }
        public static void FillDataBase()
        {
            
           
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Objects;

            string vehicles = ReadContent("vehicles.json");
            List<Vehicle> output = JsonConvert.DeserializeObject<List<Vehicle>>(vehicles, settings);
            ShopDB.Vehicles.AddRange(output);
           // string users = ReadContent("users.json");
           // List<User> usersoutput = JsonConvert.DeserializeObject<List<User>>(users, settings);
           // ShopDB.Users.AddRange(usersoutput);
        }
    }
}
