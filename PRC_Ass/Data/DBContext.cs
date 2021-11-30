using Microsoft.EntityFrameworkCore;
using PRC_Ass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC_Ass.Data
{
    public class DBContext : DbContext
    {
       public DBContext(DbContextOptions<DBContext> options) : base(options)
       {
            Database.Migrate();
       }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<CheckFinger> CheckFinger { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employee { get; set; }

    }
}
