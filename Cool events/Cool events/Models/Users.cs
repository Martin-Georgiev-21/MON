using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cool_events.Models
{
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Admin")]
        public bool IsAdmin { get; set; }

    }
}
