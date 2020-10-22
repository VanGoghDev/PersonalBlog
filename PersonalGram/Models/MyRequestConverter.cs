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

            foreach (JProperty prop in jo.Children())
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
                        var ftpJson = login.First.SelectToken("FTP") ?? "";
                        var webJson = login.First.SelectToken("WEB") ?? "";
                        var lanJson = login.First.SelectToken("INT") ?? "";
                        Resource resource = new Resource
                        {
                            Name = prop.Name,
                            Login = login.Name,
                            FTP = JsonConvert.DeserializeObject<ResourceProperties>(ftpJson.ToString()),
                            WEB = JsonConvert.DeserializeObject<ResourceProperties>(webJson.ToString()),
                            LAN = JsonConvert.DeserializeObject<ResourceProperties>(lanJson.ToString())
                        };
                        
                        if (resource.FTP != null) 
                            resource.FTP.protocolType = "FTP/";
                        if (resource.WEB != null) 
                            resource.WEB.protocolType = "WEB/";
                        if (resource.LAN != null) 
                            resource.LAN.protocolType = "LAN/";
                        
                        if (resource.FTP == null) 
                            resource.FTP = new ResourceProperties();
                        if (resource.WEB == null) 
                            resource.WEB = new ResourceProperties();
                        if (resource.LAN == null) 
                            resource.LAN = new ResourceProperties();

                        resource.SetFromProtocolString();
                        resource.SetActionString();
                        resourceCollection.resoures.Add(resource);
                    }
                }
            }
            
            //var prop = jo.First.First;

            
            
            
            return resourceCollection;
        }
    }
}