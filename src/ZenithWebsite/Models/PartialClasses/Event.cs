using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using ZenithWebsite.Models.CutomValidations;

namespace ZenithWebsite.Models
{
    [ModelMetadataType(typeof(EventMetadata))]
    public partial class Event { }

    public class EventMetadata
    {
        [Required]
        [DateToValidation(ErrorMessage = "DateTo must be later than DateFrom")]
        public DateTime DateTo { get; set; }
    }
}
