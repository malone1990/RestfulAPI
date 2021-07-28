using Microsoft.EntityFrameworkCore;
using RestfulAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPI.Models
{
    public class TimeCardContext : DbContext
    {
        public TimeCardContext(DbContextOptions<TimeCardContext> options)
            : base(options)
        {
        }

        public DbSet<UserInfo> Users { get; set; }
        public DbSet<TimeEntryInfo> TimeEntrys { get; set; }

        public DbSet<TimeCardInfo> TimeCards { get; set; }
    }
}
