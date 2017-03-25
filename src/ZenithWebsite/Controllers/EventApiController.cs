using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebsite.Models;
using ZenithWebsite.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithWebsite.Controllers
{
    [Route("api/[controller]")]
    public class EventApiController : Controller
    {
        private ApplicationDbContext _context;

        public EventApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _context.Event.Include(a => a.Activity);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return _context.Event.FirstOrDefault(s => s.EventId == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Event e)
        {
            _context.Event.Add(e);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Event e)
        {
            _context.Event.Update(e);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var _event = _context.Event.FirstOrDefault(t => t.EventId == id);
            if (_event != null)
            {
                _context.Event.Remove(_event);
                _context.SaveChanges();
            }
        }
    }
}
