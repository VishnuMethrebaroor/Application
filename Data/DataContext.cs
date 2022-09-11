using Application.Model;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<App> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<App>().HasData(
               new App()
               {
                   Id = 121,
                   Name = "sanju"
               },
               new App()
               {
                   Id = 123,
                   Name = "satish"
               },
               new App()
               {
                   Id = 120,
                   Name = "sagar"
               });
        }
    }
}
