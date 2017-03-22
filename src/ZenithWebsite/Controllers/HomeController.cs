using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebsite.Data;

namespace ZenithWebsite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            /*var events = _context.Event
                          .Select(a => a.Activity)
                          .OrderBy(a => a.DateFrom);
           return View(events.ToList());*/

            return View(_context.Event.ToList());
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
