using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebsite.Models
{
    public class UserRoleView
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public ICollection<string> RolesAssigned
        {
            get; set;
        }

        public string RoleToBeDeleted { get; set; }
    }
}
