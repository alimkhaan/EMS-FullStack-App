using Microsoft.EntityFrameworkCore;
using WebAPIEMS.Models;

namespace WebAPIEMS.Data
{
    public class EMSDbContext : DbContext
    {
        public EMSDbContext(DbContextOptions<EMSDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPIEMS.Models.EmpProfile> EmpProfile { get; set; } = default!;

        public DbSet<WebAPIEMS.Models.DeptMaster>? DeptMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed DeptMaster data
            modelBuilder.Entity<DeptMaster>().HasData(
                new DeptMaster { DeptCode = 1, DeptName = "Human Resources" },
                new DeptMaster { DeptCode = 2, DeptName = "Finance" },
                new DeptMaster { DeptCode = 3, DeptName = "IT" },
                new DeptMaster { DeptCode = 4, DeptName = "Marketing" },
                new DeptMaster { DeptCode = 5, DeptName = "Sales" }
            );

            // Seed EmpProfile data
            modelBuilder.Entity<EmpProfile>().HasData(
                new EmpProfile { EmpCode = 101, EmpName = "John Doe", Email = "johndoe@example.com", DeptCode = 1, DateOfBirth = new DateTime(1985, 4, 12) },
                new EmpProfile { EmpCode = 102, EmpName = "Jane Doe", Email = "janedoe@example.com", DeptCode = 2, DateOfBirth = new DateTime(1990, 7, 23) },
                new EmpProfile { EmpCode = 103, EmpName = "Jim Beam", Email = "jimbeam@example.com", DeptCode = 3, DateOfBirth = new DateTime(1988, 9, 18) },
                new EmpProfile { EmpCode = 104, EmpName = "Jack Daniels", Email = "jackdaniels@example.com", DeptCode = 4, DateOfBirth = new DateTime(1992, 1, 15) },
                new EmpProfile { EmpCode = 105, EmpName = "Jose Cuervo", Email = "josecuervo@example.com", DeptCode = 5, DateOfBirth = new DateTime(1986, 11, 5) }
            );
        }
    }
}
