using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ZenithWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using ZenithWebsite.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ZenithWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager, 
            ApplicationDbContext context, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<ActionResult> Index()
        {
            var users = _userManager.Users.ToList();

            var usersList = new List<UserRoleView>();
            foreach (ApplicationUser usr in users)
            {
                var roles = await _userManager.GetRolesAsync(usr);
                var userView = new UserRoleView()
                {
                    Id = usr.Id,
                    UserName = usr.UserName,
                    Email = usr.Email,
                    RolesAssigned = roles
                };

                usersList.Add(userView);
            }

            return View(usersList);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var editUserView = new EditUserRoleView()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };

            ViewData["Roles"] = new SelectList(_roleManager.Roles.ToList());

            return View(editUserView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditUserRoleView user)
        {
            if (ModelState.IsValid)
            {
                // Fast exit if trying to modify user 'a' or role 'admin'
                var toBeAdded = user.RoleToBeAdded;

                if (id != user.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        var currentUser = await _userManager.FindByIdAsync(user.Id);
                        var result = await _userManager.AddToRoleAsync(currentUser, toBeAdded);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UserExists(user.Id))
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
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);

            var userView = new UserRoleView()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                RolesAssigned = roles
            };

            ViewData["Roles"] = new SelectList(userView.RolesAssigned);

            return View(userView);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, UserRoleView user)
        {
            if (ModelState.IsValid)
            {
                var toBeDeleted = user.RoleToBeDeleted;

                if (user.UserName == "a" || toBeDeleted.ToUpper() == "ADMIN")
                {
                    ModelState.AddModelError(string.Empty, "Cannot remove Admin role from User 'a'");
                    ViewData["Roles"] = new SelectList(_roleManager.Roles.ToList());
                    return View(user);
                }

                if (id != user.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        var currentUser = await _userManager.FindByIdAsync(user.Id);
                        var result = await _userManager.RemoveFromRoleAsync(currentUser, toBeDeleted);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UserExists(user.Id))
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
            }

            return View();
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

    }
}