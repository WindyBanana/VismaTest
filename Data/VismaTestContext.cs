using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VismaTest.Models;

namespace VismaTest.Data
{
    public class VismaTestContext : DbContext
    {
        public VismaTestContext(DbContextOptions<VismaTestContext> options)
            : base(options)
        { 
        }

        public DbSet<Ansatt> Ansatt { get; set; }

        public DbSet<Stilling> Stilling { get; set; }

        public DbSet<Oppgave> Oppgave { get; set; }
        public DbSet<StillingsOppgave> StillingsOppgave { get; set; }


    }
}
