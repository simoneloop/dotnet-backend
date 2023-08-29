using Microsoft.EntityFrameworkCore;

using Backend.Entities;
namespace Backend.Data{
    public class BackendDbContext: DbContext{
    public BackendDbContext(DbContextOptions<BackendDbContext> options): base(options){}

    public DbSet<Employee> Employees {get; set;}

    public DbSet<Job> Jobs {get; set;}
    public DbSet<Department> Departments{get; set;}

    public DbSet<EmployeeDepartment> EmployeeDepartments{get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            // Configurazione per le relazioni many-to-many
            modelBuilder.Entity<EmployeeDepartment>()
                .HasKey(ed => new { ed.EmployeeId, ed.DepartmentId });

            modelBuilder.Entity<EmployeeDepartment>()
                .HasOne(e => e.Employee)
                .WithMany(ed => ed.EmployeeDepartments)
                .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<EmployeeDepartment>()
                .HasOne(e => e.Department)
                .WithMany(ed => ed.EmployeeDepartments)
                .HasForeignKey(d => d.DepartmentId);
    }
}
}
