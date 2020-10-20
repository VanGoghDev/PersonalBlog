using System.Data.Entity;
using PersonalGram.Models.PhotoModels;

namespace PersonalGram.Models.Context
{
    public class PhotoContext : DbContext
    {
        public PhotoContext ()
            : base("mssql")
            {
                
            }
        
        public DbSet<Photo> Photos { get; set; }
    }
}