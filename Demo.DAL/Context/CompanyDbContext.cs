using System.Reflection;

namespace Demo.DAL.Context;
public class CompanyDbContext(DbContextOptions<CompanyDbContext> options) : DbContext(options)
{
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
