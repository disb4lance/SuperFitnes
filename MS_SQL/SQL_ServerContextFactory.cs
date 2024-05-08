using Classes.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MS_SQL
{
    public class SQL_ServerContextFactory : IDesignTimeDbContextFactory<DataContext>
    {

        private const string DbContextString = "Server=localhost,1433;Database=SuperFitnes;User ID=sa;Password=<YourStrong@Passw0rd>;MultipleActiveResultSets=true;TrustServerCertificate=True";
        public DataContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<DataContext>();

            optionBuilder.UseSqlServer(DbContextString, b => b.MigrationsAssembly(typeof(SQL_ServerContextFactory).Namespace));

            return new DataContext(optionBuilder.Options);

        }
    }
}
