using CarDealership.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarDealership.Domain.Helpers
{
    public class ApplicationConverter : Newtonsoft.Json.JsonConverter
    {
        

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var item = JObject.Load(reader);
            object target = null;

            switch (item["Type"].Value<string>()) // this is the property differentiater
            {
                case "1":
                    target = new Costumer();
                    break;
                case "2":
                    target = new Supplyer();
                    break;
                case "3":
                    target = new Manager();
                    break;
                default:
                    throw new NotImplementedException();
            }

            serializer.Populate(item.CreateReader(), target);

            return target;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}
