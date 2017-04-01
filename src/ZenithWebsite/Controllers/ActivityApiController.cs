using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebsite.Models;
using ZenithWebsite.Data;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithWebsite.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ActivityApiController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public ActivityApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return _context.Activity.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Activity Get(int id)
        {
            return _context.Activity.FirstOrDefault(s => s.ActivityId == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Activity activity)
        {
            _context.Activity.Add(activity);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Activity activity)
        {
            _context.Activity.Update(activity);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var activity = _context.Activity.FirstOrDefault(t => t.ActivityId == id);
            if (activity != null)
            {
                _context.Activity.Remove(activity);
                _context.SaveChanges();
            }
        }
    }
}
