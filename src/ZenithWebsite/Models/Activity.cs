using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebsite.Models
{
    public partial class Activity
    {
        public int ActivityId { get; set; }

        [Required]
        public string ActivityDescription { get; set; }
        public DateTime CreationDate { get; set; }

        //public List<Event> Events { get; set; }
    }
}
