using Newtonsoft.Json;

namespace PersonalGram.Models
{
    public class Resource
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public ResourceProperties FTP { get; set; }
        public ResourceProperties WEB { get; set; }
        public ResourceProperties LAN { get; set; }
    }
}