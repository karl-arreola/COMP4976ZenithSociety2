using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ZenithWebsite.Models;

namespace ZenithWebsite.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;

        public RolesController(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            List<ApplicationRole> roles = new List<ApplicationRole>();
            roles = roleManager.Roles.Select(r => new ApplicationRole
            {
                Name = r.Name,
                UserCount = r.Users.Count
            }).ToList();
            return View(roles);
        }
    }
}