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

            foreach (var prop in jo.Children())
            {
                var prp = prop.First;
                // по всем директориям которые есть в ресурсе
                foreach (JProperty child in prp.Children())
                {
                    // получаем все логины для директории
                    var logins = child.First;
                
                    // Для каждого логина создаем ресурс с полями
                    foreach (JProperty login in logins)
                    {
                        var test = 2;
                        var ftpJson = login.First.SelectToken("FTP");
                        if (ftpJson == null)
                            ftpJson = "";
                        Resource resource = new Resource
                        {
                            Name = login.Name,
                            FTP = JsonConvert.DeserializeObject<ResourceProperties>(ftpJson.ToString())
                        };
                        resourceCollection.resoures.Add(resource);
                    }
                }
            }
            
            //var prop = jo.First.First;

            
            
            
            return resourceCollection;
        }
    }
}