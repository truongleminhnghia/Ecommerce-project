using Microsoft.EntityFrameworkCore;
using ShoppEcommerce_WebApp.Common.Entities;

namespace ShoppEcommerce_WebApp.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(o => o.EnumAccountStatus)
                .HasConversion<string>();
            modelBuilder.Entity<Role>()
                .Property(o => o.RoleName)
                .HasConversion<string>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
