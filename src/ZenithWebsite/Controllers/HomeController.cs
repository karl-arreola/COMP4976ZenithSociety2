using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebsite.Data;
using Microsoft.EntityFrameworkCore;

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
            var events = _context.Event
                          .Include(a => a.Activity)
                          .OrderBy(a => a.DateFrom);
            return View(events.ToList());
            
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
