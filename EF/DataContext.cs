using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagment_311.EF
{
    public class DataContext:DbContext
    {
        public DbSet<Entities.UserData> UsersData { get; private set; }
        public DbSet<Entities.UserRole> UserRoles { get; private set; }
        public DbSet<Entities.UserAccess> UserAccesses { get; private set; }
        public DbSet<Entities.Product> Products { get; private set; }
        public DbSet<Entities.Basket> Baskets { get; private set; }
        public DbSet<Entities.Order> Orders { get; private set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
               "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=dm-ef-321;Integrated Security=True"
                );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Demo");
            modelBuilder.Entity<Entities.UserAccess>()
                .HasIndex(x => x.Login)
                .IsUnique();
        }
    }
}
