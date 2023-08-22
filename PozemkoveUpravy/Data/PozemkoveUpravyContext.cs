using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PozemkoveUpravy.Models;

namespace PozemkoveUpravy.Data
{
    public class PozemkoveUpravyContext : DbContext
    {
        public PozemkoveUpravyContext (DbContextOptions<PozemkoveUpravyContext> options)
            : base(options)
        {
        }

        public DbSet<PozemkovaUprava> PozemkoveUpravy { get; set; } = default!;

        public DbSet<Vlastnik> Vlastnici { get; set; }

        public DbSet<Pozemek> Pozemky { get; set; }

        public DbSet<OceneniPozemku> OceneniPozemkuA { get; set; }

        public DbSet<OceneniPorostu> OceneniPorostuA { get; set; }
    }
}
