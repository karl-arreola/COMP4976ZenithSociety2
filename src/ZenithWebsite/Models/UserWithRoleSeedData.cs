using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithWebsite.Data;

namespace ZenithWebsite.Models
{
    public static class UserWithRoleSeedData
    {
        public static void Initialize(ApplicationDbContext db, IServiceProvider serviceProvider)
        {
            createRoles(db);
            createUsers(db, serviceProvider);
        }

        private static void createRoles(ApplicationDbContext context)
        {
            var roleStore = new RoleStore<ApplicationRole>(context);

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleStore.CreateAsync(new ApplicationRole
                {
                    Name = "Admin",
                });
            }

            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                roleStore.CreateAsync(new ApplicationRole
                {
                    Name = "Member",
                });
            }

            context.SaveChanges();
        }

        private static void createUsers(ApplicationDbContext context, IServiceProvider services)
        {

            var user1 = new ApplicationUser
            {
                UserName = "a",
                Email = "a@a.a"
            };

            if (!context.Users.Any(u => u.UserName == user1.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user1, "P@$$w0rd");
                user1.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(context);
                userStore.CreateAsync(user1);
                userStore.AddToRoleAsync(user1, "Admin");
            }

            var user2 = new ApplicationUser
            {
                UserName = "m",
                Email = "m@m.m"
            };

            if (!context.Users.Any(u => u.UserName == user2.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user2, "P@$$w0rd");
                user2.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(context);
                userStore.CreateAsync(user2);
                userStore.AddToRoleAsync(user2, "Member");
            }

            context.SaveChanges();
        }
    }
}
