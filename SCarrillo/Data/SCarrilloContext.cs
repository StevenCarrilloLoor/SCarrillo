using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SCarrillo.Models;

namespace SCarrillo.Data
{
    public class SCarrilloContext : DbContext
    {
        public SCarrilloContext (DbContextOptions<SCarrilloContext> options)
            : base(options)
        {
        }

        public DbSet<SCarrillo.Models.Carrera> Carrera { get; set; } = default!;
        public DbSet<SCarrillo.Models.SCarrilloModel> SCarrillo { get; set; } = default!;
    }
}
