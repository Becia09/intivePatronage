using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace WebCoreApi.Models
{
    public class WebCoreContext : DbContext
    {
        public WebCoreContext(DbContextOptions<WebCoreContext> options)
            : base(options)
        {
        }

        public DbSet<WebCoreItem> WebCoreItems { get; set; }
    }
}
