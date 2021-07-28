using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Models
{
    public class UserInfo
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
       
        public bool IsAdmin { get; set; }

        public virtual ICollection<TimeEntryInfo> TimeEntries { get; set; }
    }
}
