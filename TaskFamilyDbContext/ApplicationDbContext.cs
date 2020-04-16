using System;
using Microsoft.EntityFrameworkCore;

namespace TaskFamilyWeb.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions)
        {
           Database.EnsureCreated();
        }

        public DbSet<Family> Families { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Purse> Purses { get; set; }
        public DbSet<MoveMoney> MovesMoney { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<CurrencyRates> CurrencyRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Currency>().ToTable("currencies").Property(c => c.MarkRemoval).HasColumnType("bit(1)");
            modelBuilder.Entity<Event>().ToTable("events").Property(c => c.MarkRemoval).HasColumnType("bit(1)");
            modelBuilder.Entity<Purse>().ToTable("purses").Property(c => c.MarkRemoval).HasColumnType("bit(1)");
            modelBuilder.Entity<Purse>().ToTable("purses").Property(c => c.Draft).HasColumnType("bit(1)");
            modelBuilder.Entity<ToDo>().ToTable("todos").Property(c => c.Draft).HasColumnType("bit(1)");
            modelBuilder.Entity<ToDo>().ToTable("todos").Property(c => c.Complete).HasColumnType("bit(1)");
            modelBuilder.Entity<CurrencyRates>().HasKey(u => new { u.BaseCurrencyId, u.CurrencyId, u.Period });

        }

    }
}
