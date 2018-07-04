using Microsoft.EntityFrameworkCore;
using module4.Domain;

namespace module4.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<Product> Product {get; set;}

        public DbSet<Category> Category {get; set;}
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }

    
}