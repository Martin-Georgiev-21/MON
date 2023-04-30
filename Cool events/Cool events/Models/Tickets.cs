using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cool_events.Models
{
    public class Tickets
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int TicketId { get; set; }

        public int User { get; set; }
        public int Event { get; set; }
    }
}
