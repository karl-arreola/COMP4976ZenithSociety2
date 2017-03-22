using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebsite.Models
{
    public partial class Event
    {
        public int EventId { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        public string EventMadeBy { get; set; }
        public bool IsActive { get; set; }

        public virtual Activity Activity { get; set; }
        public int ActivityId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
