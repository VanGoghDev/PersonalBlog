using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
        
        public string Action { get; set; }
        public string FromProtocol { get; set; }

        public void SetActionString()
        {
            List<string> rights = new List<string>();
            
            foreach (var property in FTP.GetType().GetProperties())
            {
                string res = $"{property.GetValue(FTP)}{property.GetValue(WEB)}{property.GetValue(LAN)}";
                res = res.Replace("0", "-").Replace("1", "+");
                if (res.All(x => x == res.First()))
                    res = res.First().ToString();
                rights.Add(res);
            }
            var test = 3;
            Action = $"{rights[0]}/{rights[1]}/{rights[2]}/{rights[3]}/{rights[4]}/{rights[5]}/{rights[6]}/{rights[7]}/";
        }

        public void SetFromProtocolString()
        {
            FromProtocol = $"{FTP.protocolType}{WEB.protocolType}{LAN.protocolType}";
        }
    }
}