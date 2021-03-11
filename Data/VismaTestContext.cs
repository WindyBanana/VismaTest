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

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<PositionMission> PosiotionMissions { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }

    }
}
