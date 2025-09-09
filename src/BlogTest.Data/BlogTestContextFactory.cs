using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace BlogTest.Data
{
    public class BlogTestContextFactory : IDesignTimeDbContextFactory<BlogTestContext>
    {
        public BlogTestContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            var builder = new DbContextOptionsBuilder<BlogTestContext>();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            return new BlogTestContext(builder.Options);
        }
    }
}
