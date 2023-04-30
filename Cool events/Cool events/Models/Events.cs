using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Cool_events.Models
{
    public class Events
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int EventId { get; set; }

        [Required]
        [StringLength(64)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Discription")]
        public string Discription { get; set; }

        public string Photo { get; set; }

        [Required]
        [DisplayName("Event Date")]
        [DataType(DataType.Date)]
        public string EventDate { get; set; }
    }
}
