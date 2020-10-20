using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace PersonalGram.Models
{
    public class MyRequestConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Resource);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ResourceCollection resourceCollection = new ResourceCollection();
            JObject jo = JObject.Load(reader);
            string quota = (string)jo["qouta"];
            var prop = jo.First.First;

            // по всем директориям которые есть в ресурсе
            foreach (JProperty child in prop.Children())
            {
                // получаем все логины для директории
                var logins = child.First;
                
                // Для каждого логина создаем ресурс с полями
                foreach (JProperty login in logins)
                {
                    var test = 2;
                    Resource resource = new Resource
                    {
                        Name = login.Name,
                        ResourceProperties = JsonConvert.DeserializeObject<ResourceProperties>(login.First.ToString())
                    };
                    resourceCollection.resoures.Add(resource);
                }
            }
            
            
            return resourceCollection;
        }
    }
}