﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagment_311.EF
{
    public class DataContext : DbContext
    {
        public DbSet<Entities.UserData> UsersData { get; private set; }
        public DbSet<Entities.UserRole> UserRoles { get; private set; }
        public DbSet<Entities.UserAccess> UserAccesses { get; private set; }
        public DbSet<Entities.Product> Products { get; private set; }
        public DbSet<Entities.Basket> Baskets { get; private set; }
        public DbSet<Entities.Order> Orders { get; private set; }

        public DataContext():base() { }



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

            modelBuilder.Entity<Entities.UserData>().HasData(
                new Entities.UserData()
                {
                    Id = Guid.Parse("D4E7F2A5-188C-48F5-9DB6-6D8999ED5E42"),
                    Email = "user1@i.ua",
                    Name = "user1",
                    Phone = "555-11-11"
                },
                new Entities.UserData()
                {
                    Id = Guid.Parse("14B16781-27BE-4FB4-804E-803C5A98E986"),
                    Email = "user2@i.ua",
                    Name = "user2",
                    Phone = "555-11-22"
                },
                new Entities.UserData()
                {
                    Id = Guid.Parse("9CAB7A6A-E970-44AE-8E73-58005DCE3A01"),
                    Email = "user3@i.ua",
                    Name = "user3",
                    Phone = "555-11-33"
                },
                new Entities.UserData()
                {
                    Id = Guid.Parse("ECF36CEB-C0D5-4107-9E02-B43F8967038E"),
                    Email = "user4@i.ua",
                    Name = "user4",
                    Phone = "555-11-44"
                },
                new Entities.UserData()
                {
                    Id = Guid.Parse("449A3602-C38B-45D8-A33B-76A88085ABA2"),
                    Email = "user5@i.ua",
                    Name = "user5",
                    Phone = "555-11-55"
                }
            );
            modelBuilder.Entity<Entities.UserRole>().HasData(
                new Entities.UserRole()
                {
                    Id = "guest",
                    Description = "Самостійно зареєстрований користувач",
                    CanCreate = 0,
                    CanRead = 0,
                    CanUpdate = 0,
                    CanDelete = 0
                },
                new Entities.UserRole()
                {
                    Id = "editor",
                    Description = "З правом редагування контенту",
                    CanCreate = 0,
                    CanRead = 1,
                    CanUpdate = 1,
                    CanDelete = 0
                },
                new Entities.UserRole()
                {
                    Id = "admin",
                    Description = "Адміністратор БД",
                    CanCreate = 1,
                    CanRead = 1,
                    CanUpdate = 1,
                    CanDelete = 1
                },
                new Entities.UserRole()
                {
                    Id = "moderator",
                    Description = "З правом блокування контенту",
                    CanCreate = 0,
                    CanRead = 1,
                    CanUpdate = 0,
                    CanDelete = 1
                }
            );
            String Salt = "12345";
            String DefaultPassword = "123";
            modelBuilder.Entity<Entities.UserAccess>().HasData(
                new Entities.UserAccess()
                {
                    Id = Guid.Parse("DAE2716D-610D-415D-9BF3-DD8F58AD8D95"),
                    UserId = Guid.Parse("D4E7F2A5-188C-48F5-9DB6-6D8999ED5E42"),
                    RoleId = "guest",
                    Login = "user1",
                    Salt = Salt,
                    Dk = Salt + DefaultPassword,
                },
                new Entities.UserAccess()
                {
                    Id = Guid.Parse("711F2D8F-2494-4272-A667-36886035E2C8"),
                    UserId = Guid.Parse("D4E7F2A5-188C-48F5-9DB6-6D8999ED5E42"),
                    RoleId = "moderator",
                    Login = "user1-m",
                    Salt = Salt,
                    Dk = Salt + DefaultPassword,
                },
                new Entities.UserAccess()
                {
                    Id = Guid.Parse("E50AD259-367F-4CB9-8F0C-D9C9A462DFE5"),
                    UserId = Guid.Parse("14B16781-27BE-4FB4-804E-803C5A98E986"),
                    RoleId = "guest",
                    Login = "user2",
                    Salt = Salt,
                    Dk = Salt + DefaultPassword,
                },
                new Entities.UserAccess()
                {
                    Id = Guid.Parse("16F5BBF5-226B-4796-ABE2-87E6FBCB0C76"),
                    UserId = Guid.Parse("9CAB7A6A-E970-44AE-8E73-58005DCE3A01"),
                    RoleId = "guest",
                    Login = "user3",
                    Salt = Salt,
                    Dk = Salt + DefaultPassword,
                },
                new Entities.UserAccess()
                {
                    Id = Guid.Parse("94E352B6-F348-42F6-A35A-8FCBEF2D4B47"),
                    UserId = Guid.Parse("ECF36CEB-C0D5-4107-9E02-B43F8967038E"),
                    RoleId = "guest",
                    Login = "user4",
                    Salt = Salt,
                    Dk = Salt + DefaultPassword,
                },
                new Entities.UserAccess()
                {
                    Id = Guid.Parse("37D22E1D-4C73-4418-99B6-7A496D00780F"),
                    UserId = Guid.Parse("ECF36CEB-C0D5-4107-9E02-B43F8967038E"),
                    RoleId = "editor",
                    Login = "user4-e",
                    Salt = Salt,
                    Dk = Salt + DefaultPassword,
                },
                new Entities.UserAccess()
                {
                    Id = Guid.Parse("AF04F9B1-3F7F-4705-8233-9EF271CF39EF"),
                    UserId = Guid.Parse("449A3602-C38B-45D8-A33B-76A88085ABA2"),
                    RoleId = "guest",
                    Login = "user5",
                    Salt = Salt,
                    Dk = Salt + DefaultPassword,
                },
                new Entities.UserAccess()
                {
                    Id = Guid.Parse("89754503-2FE6-4D63-8420-3503D6D857D6"),
                    UserId = Guid.Parse("449A3602-C38B-45D8-A33B-76A88085ABA2"),
                    RoleId = "admin",
                    Login = "user5-a",
                    Salt = Salt,
                    Dk = Salt + DefaultPassword,
                },
                new Entities.UserAccess()
                {
                    Id = Guid.Parse("C2AE1D8C-DA5D-4EA6-9458-E859F15F002A"),
                    UserId = Guid.Parse("449A3602-C38B-45D8-A33B-76A88085ABA2"),
                    RoleId = "editor",
                    Login = "user5-e",
                    Salt = Salt,
                    Dk = Salt + DefaultPassword,
                }
            );
        }
    }
    
}
