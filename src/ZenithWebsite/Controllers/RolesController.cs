using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ZenithWebsite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ZenithWebsite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace ZenithWebsite.Controllers
{
    [EnableCors("CorsPolicy")]
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public RolesController(RoleManager<ApplicationRole> roleManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {
            List<ApplicationRole> roles = new List<ApplicationRole>();
            roles = _roleManager.Roles.Select(r => new ApplicationRole
            {
                Id = r.Id,
                Name = r.Name,
                UserCount = r.Users.Count
            }).ToList();

            return View(roles);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                if (!_context.Roles.Any(r => r.Name == role.Name))
                {
                    await _roleManager.CreateAsync(new ApplicationRole
                    {
                        Name = role.Name,
                    });
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            return View(role);
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Id")] ApplicationRole role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var currentRole = await _roleManager.FindByIdAsync(role.Id);
                    currentRole.Name = role.Name;

                    var result = await _roleManager.UpdateAsync(currentRole);
                    await _roleManager.UpdateAsync(role);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(role.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role.NormalizedName == "ADMIN")
            {
                ModelState.AddModelError(string.Empty, "Admin role cannot be deleted");
                return View(role);
            }

            await _roleManager.DeleteAsync(role);
            await _roleManager.UpdateAsync(role);

            return RedirectToAction("Index");
        }

        private bool RoleExists(string id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}