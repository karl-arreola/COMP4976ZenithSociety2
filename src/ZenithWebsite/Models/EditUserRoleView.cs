using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebsite.Models
{
    public class EditUserRoleView
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string RoleToBeAdded { get; set; }
    }
}
