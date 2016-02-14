using WebAPIApplication.Models;
using Microsoft.Data.Entity;

namespace WebAPIApplication.Tables
{
    public class ThingContext: DbContext
    {
        public DbSet<Thing> ThingTable { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Thing>().HasKey(t => t.id);
            base.OnModelCreating(builder);
        }
    }
}
