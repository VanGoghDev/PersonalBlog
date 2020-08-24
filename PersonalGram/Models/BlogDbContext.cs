using System;
using System.Data.Entity;

namespace PersonalGram.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext()
            : base("mssql")
        {
            
        }
        
        public DbSet<Post> Posts { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Published { get; set; }
    }
}