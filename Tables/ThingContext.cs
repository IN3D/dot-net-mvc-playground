using WebAPIApplication.Models;
using Microsoft.Data.Entity;

namespace WebAPIApplication.Tables
{
    // A "context" to wrap a table. I'm not 100% positive on this. But
    // basically the idea as far as I can tell, is to create an object
    // wrapper over a database table. The "OnModelCreating" seems to
    // need to be overriden.
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
