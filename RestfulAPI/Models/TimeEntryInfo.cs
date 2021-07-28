using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Models
{
    public class TimeEntryInfo
    {
        public int UserId { get; set; }
        [Key]
        public int TimeEntryId { get; set; }
        public double? TotalHours { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }

        public virtual UserInfo User { get; set; }
        public virtual ICollection<TimeCardInfo> TimeCards { get; set; }
    }
}
