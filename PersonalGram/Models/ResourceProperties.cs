namespace PersonalGram.Models
{
    public class ResourceProperties
    {
        public string protocolType = "";
        public string quota = "";
        public string cur_size = "";

        public string view { get; set; }
        public string delete{get; set;}
        public string deletedir {get; set;}
        public string makedir { get; set; }
        public string rename { get; set; }
        
        public string share { get; set; }
        public string read {get; set;}
        public string write {get; set;}

        public ResourceProperties()
        {
            protocolType = "";
            deletedir = "0";
            rename = "0";
            view = "0";
            makedir = "0";
            read = "0";
            delete = "0";
            write = "0";
            share = "0";
        }
    }
}