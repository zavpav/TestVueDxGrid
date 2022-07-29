using Microsoft.EntityFrameworkCore;
using TestApi.Domain;

//dotnet ef migrations add Intial -c Context -o Database 
//dotnet ef database update
//docker run -d -p 5440:5432 --name TestGraphQl -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=123456 postgres:14
namespace TestApi.Db
{
    public class Context : DbContext
    {
        public DbSet<Document> Documents { get; set; } = null!;

        public Context() : base() { }
        
        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().HasData(
                new Document { Id = 1, Title = "Title 1", Context = "Context 1" },
                new Document { Id = 2, Title = "Title 2", Context = "Context 2" },
                new Document { Id = 3, Title = "Title 3", Context = "Context 3" },
                new Document { Id = 4, Title = "Title 4", Context = "Context 4" }
                );
        }
    }
}
