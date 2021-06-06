using CarDealership.Domain.Database;
using CarDealership.Domain.Helpers;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace CarDealership
{
    class Program
    {
        static void Main(string[] args)
        {

          
            CostumLogger.FillDataBase();

            Helper.JoinData();

            try
            {
                UserUI.HomeScreen();
                CostumLogger.LogDataBase();
                CostumLogger.LogToExcelFIle();
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
