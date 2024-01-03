using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppEndProject.Models;

namespace WebAppEndProject.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext (DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppEndProject.Models.DeptMaster> DeptMaster { get; set; } = default!;

        public DbSet<WebAppEndProject.Models.EmpProfile>? EmpProfile { get; set; }
    }
}
