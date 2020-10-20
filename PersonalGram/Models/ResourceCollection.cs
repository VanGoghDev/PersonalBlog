using System.Collections.Generic;
using Newtonsoft.Json;

namespace PersonalGram.Models
{
    [JsonConverter(typeof(MyRequestConverter))]
    public class ResourceCollection
    {
        public List<Resource> resoures { get; set; }

        public ResourceCollection()
        {
            resoures = new List<Resource>();
        }
    }
}