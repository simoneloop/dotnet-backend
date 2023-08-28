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
        //con le many to many
        modelBuilder.Entity<EmployeeDepartment>()
                    .HasKey(e => new {e.EmployeeId,e.DepartmentId});
        modelBuilder.Entity<EmployeeDepartment>()
                    .HasOne(e => e.Employee)
                    .WithMany(e => e.EmployeeDepartments)
                    .HasForeignKey(e => e.DepartmentId);
        modelBuilder.Entity<EmployeeDepartment>()
                    .HasOne(e => e.Department)
                    .WithMany(e => e.EmployeeDepartments)
                    .HasForeignKey(e=> e.EmployeeId);
    }
}
}
