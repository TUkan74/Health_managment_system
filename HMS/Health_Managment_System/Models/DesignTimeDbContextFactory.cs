using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using HealthcareManagementSystem.Models;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HealthcareManagementSystem;Trusted_Connection=True;");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
