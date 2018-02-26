using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAppsLab5.Models
{
    public class WebAppsLab5Context : DbContext
    {
        public WebAppsLab5Context (DbContextOptions<WebAppsLab5Context> options)
            : base(options)
        {
        }

        public DbSet<WebAppsLab5.Models.Movie> Movie { get; set; }
    }
}
