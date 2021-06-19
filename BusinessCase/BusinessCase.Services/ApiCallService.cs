using BusinessCase.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace BusinessCase.Services
{
    public static class ApiCallService
    {

        private static readonly string _baseUrl = "https://interview-task-api.mca.dev/qr-scanner-codes/alpha-qr-gFpwhsQ8fkY1";
        
        public static string ApiCall()
        {
            using (HttpClient hp = new HttpClient())
            {
                HttpResponseMessage message = hp.GetAsync(_baseUrl).Result;

                if (message.StatusCode == HttpStatusCode.OK)
                {
                    return message.Content.ReadAsStringAsync().Result;
                }

                throw new Exception("Something went wrong");

            }
        }
    }
}
