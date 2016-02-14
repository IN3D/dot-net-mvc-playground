using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using WebAPIApplication.Models;
using WebAPIApplication.Tables;
using WebAPIApplication.Repositories;

namespace WebAPIApplication.Controllers
{
    [Route("api/[controller]")]
    public class ThingsController: Controller
    {
        private readonly ThingsRepository _repo;
        // defaults
        Thing[] things = new Thing[]
        {
            new Thing { id = 1, name = "wat", category = "question" },
            new Thing { id = 2, name = "wat 2", category = "question" },
            new Thing { id = 3, name = "cat", category = "animal" },
            new Thing { id = 4, name = "python", category = "animal" }
        };
        
        public ThingsController(ThingsRepository repo)
        {
            _repo = repo;
        }

        // GET: api/things
        [HttpGet]
        public IEnumerable<Thing> Get()
        {
            return _repo.GetAll();
        }

        // GET api/things/4
        [HttpGet("{id}")]
        public Object Get(int id)
        {
            if(id >= things.Length)
            {
                Response.StatusCode = 400;
                return new { error = "Invalid index" };
            }
            else
            {
                return things[id - 1];
            }
        }
    }
}
