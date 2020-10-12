using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace SeguimientoApi.Models
{
    public class SegimientoDbContext : DbContext
    {
        public SegimientoDbContext(DbContextOptions<SegimientoDbContext> options)
            :base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
