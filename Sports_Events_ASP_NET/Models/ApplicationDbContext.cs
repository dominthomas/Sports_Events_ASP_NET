using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
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
            modelBuilder.Entity<Event>().ToTable("Events");
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EventID);
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Price);
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Event> Events { get; set; }
    }
}
