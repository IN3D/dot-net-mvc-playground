using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using WebAPIApplication.Models;
using WebAPIApplication.Repositories;

namespace WebAPIApplication.Controllers
{
    [Route("api/[controller]")]
    public class ThingsController: Controller
    {
        private readonly ThingsRepository _repo;
        // Some default static data, a Thing class can
        // be made with an object literal, and it doesn't have
        // to come from the DB.
        Thing[] things = new Thing[]
        {
            new Thing { id = 1, name = "wat", category = "question" },
            new Thing { id = 2, name = "wat 2", category = "question" },
            new Thing { id = 3, name = "cat", category = "animal" },
            new Thing { id = 4, name = "python", category = "animal" }
        };
        
        public ThingsController(ThingsRepository repo)
        {
            // Creates the Thing repository object
            _repo = repo;
        }

        // GET: api/things
        [HttpGet]
        public IEnumerable<Thing> Get()
        {
            // Uses the table object in the repository to call the GetAll() method
            return _repo.GetAll();
        }

        // GET api/things/4
        // Returns an object, as opposed to thing, so that an error Object can be returned.
        [HttpGet("{id}")]
        public Object Get(int id)
        {
            if(id >= things.Length)
            {
                Response.StatusCode = 400;
                // returns an object literal
                return new { error = "Invalid index" };
            }
            else
            {
                return things[id - 1];
            }
        }
    }
}
