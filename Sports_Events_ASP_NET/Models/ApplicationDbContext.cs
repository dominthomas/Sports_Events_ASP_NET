using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Sports_Events_ASP_NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SportsEvents.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=sports_events_sqlite_db.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EventID);
                entity.HasIndex(e => e.Title);
                entity.Property(e => e.Price);
                entity.Property(e => e.AddressID);
                entity.Property(e => e.Category);
                entity.Property(e => e.Description);
            });

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserID);
                entity.HasIndex(u => u.Password);
                entity.Property(u => u.Name);
                entity.Property(u => u.Phone);
                entity.Property(u => u.Email);
                entity.Property(u => u.AddressID);
                entity.Property(u => u.DateOfBirth);
                entity.Property(u => u.Gender);
                entity.Property(u => u.WorkLocation);
                entity.Property(u => u.Bio);
                entity.Property(u => u.Skills);
            });

            modelBuilder.Entity<Address>().ToTable("Addresses");
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(a => a.AddressID);
                entity.HasIndex(a => a.FirstLine);
                entity.Property(a => a.Town);
                entity.Property(a => a.PostCode);
                entity.Property(a => a.Country);
            });

            modelBuilder.Entity<Administrator>().ToTable("Administrators");
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(a => a.UserID);
            });

            modelBuilder.Entity<Organisation>().ToTable("Organisations");
            modelBuilder.Entity<Organisation>(entity =>
            {
                entity.HasKey(o => o.OrgID);
                entity.HasIndex(o => o.Name).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
    }
}
