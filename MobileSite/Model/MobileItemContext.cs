using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileSite.Model
{
    public class MobileItemContext : DbContext
    {
        public MobileItemContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<MobileItem> MobileItem { get; set; }
    }
}
