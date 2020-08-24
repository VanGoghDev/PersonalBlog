
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PersonalGram.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PersonalGram.Models.BlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}