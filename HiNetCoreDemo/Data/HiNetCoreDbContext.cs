using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiNetCoreDemo.Data
{
    public class HiNetCoreDbContext : DbContext
    {
        public HiNetCoreDbContext(DbContextOptions<HiNetCoreDbContext> options) : base(options)
        {

        }
        public DbSet<HiNetCoreDemo.Models.Student> Student { get; set; }
        public DbSet<HiNetCoreDemo.Models.Subject> Subject { get; set; }

    }
}
