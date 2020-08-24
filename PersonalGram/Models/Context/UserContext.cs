using System.Data.Entity;

namespace PersonalGram.Models.Context
{
    public class UserContext: DbContext
    {
        public UserContext() 
            : base("mssql")
        {
            
        }
        
        public DbSet<User> Users { get; set; }
    }
}