using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class EmployeeContextFactory : IDesignTimeDbContextFactory<EmployeeContext>
{
    public EmployeeContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<EmployeeContext>();
        var connectionString = configuration.GetConnectionString("EmployeeDB");

        optionsBuilder.UseSqlServer(connectionString);

        return new EmployeeContext(optionsBuilder.Options);
    }
}
