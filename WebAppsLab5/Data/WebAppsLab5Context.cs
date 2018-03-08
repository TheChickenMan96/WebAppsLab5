using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppsLab5.Models;

namespace WebAppsLab5.Models
{
    public class WebAppsLab5Context : DbContext
    {
        public WebAppsLab5Context (DbContextOptions<WebAppsLab5Context> options)
            : base(options)
        {
        }

        public DbSet<WebAppsLab5.Models.Movie> Movie { get; set; }

        public DbSet<WebAppsLab5.Models.Review> Review { get; set; }
    }
}
