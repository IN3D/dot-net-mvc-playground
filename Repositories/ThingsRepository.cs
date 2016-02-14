using System.Collections.Generic;
using System.Linq;
using WebAPIApplication.Models;
using WebAPIApplication.Tables;
using Microsoft.AspNet.Mvc;

namespace WebAPIApplication.Repositories
{
    // So far as I can tell, this thing seems to be a convenience
    // wrapper. I'm pretty sure any of this _could_ be accomplished
    // from the controller (if that's a good idea not withstanding).
    // It just seems like a best practice abstraction.
    public class ThingsRepository
    {
        private readonly ThingContext _context;
        
        public ThingsRepository(ThingContext context)
        {
            _context = context;
        }
        
        public List<Thing> GetAll()
        {
            return _context.ThingTable.ToList();
        }
        
        public Thing Get(long id)
        {
            return _context.ThingTable.First(t => t.id == id);
        }
        
        [HttpPost]
        public void Post(Thing thing)
        {
            _context.ThingTable.Add(thing);
            _context.SaveChanges();
        }
        
        public void Put(long id, [FromBody]Thing thing)
        {
            _context.ThingTable.Update(thing);
            _context.SaveChanges();
        }
        
        public void Delete(long id)
        {
            var entity = _context.ThingTable.First(t => t.id == id);
            _context.ThingTable.Remove(entity);
            _context.SaveChanges();
        }
    }
}