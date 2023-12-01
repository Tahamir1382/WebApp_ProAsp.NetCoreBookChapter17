using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class DataContext : DbContext //inherits from the DbContext class which represents a connection to the database and is used to query the data
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) { }  
        public DbSet<Product> Products => Set<Product>(); //wow this set thingi here is kinda nuts; from what i understand it puts the data in the context? or in the database? im not sure
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
    }
}
