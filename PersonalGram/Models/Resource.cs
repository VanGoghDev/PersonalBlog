using Newtonsoft.Json;

namespace PersonalGram.Models
{
    public class Resource
    {
        public string Name { get; set; }
        
        public ResourceProperties FTP { get; set; }
        //public ResourceProperties ResourceProperties { get; set; }
    }
}