
using HRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Database
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
    "Server=.;Database=HRMS;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
            );
        }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Training> Trainings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Employee
            modelBuilder.Entity<Employee>()
                .Property(e => e.name)
                .HasMaxLength(25);

            modelBuilder.Entity<Employee>()
                .Property(e => e.position)
                .HasMaxLength(25);
            #endregion

            #region Department
            modelBuilder.Entity<Department>()
                .Property(e => e.name)
                .HasMaxLength(25);
            #endregion


            #region Payroll
            modelBuilder.Entity<Payroll>()
                .Property(p => p.netpay)
                .HasComputedColumnSql("salary - (salary * 0.1)");
            #endregion

            #region Relationships
            modelBuilder.Entity<Employee>()
                .HasOne(d => d.department)
                .WithMany(e => e.employees)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasMany(t => t.training)
                .WithMany(e => e.employees)
                .UsingEntity(j => j.ToTable("EmployeeTraining"));

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.payroll)
                .WithOne(e => e.employee)
                .HasForeignKey<Payroll>(e => e.employeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.attendance)
                .WithOne(a => a.employee)
                .HasForeignKey(a => a.employeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.leaves)
                .WithOne(l => l.employee)
                .HasForeignKey(l => l.employeeId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}