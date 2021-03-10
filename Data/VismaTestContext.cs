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

        public DbSet<Models.PositionTask> Employees { get; set; }

        public DbSet<Models.Position> Positions { get; set; }

        public DbSet<Models.Task> Tasks { get; set; }



    }
}
