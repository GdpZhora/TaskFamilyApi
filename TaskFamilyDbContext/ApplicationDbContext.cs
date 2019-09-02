using System;
using Microsoft.EntityFrameworkCore;

namespace TaskFamilyWeb.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Family> Families { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Purse> Purses { get; set; }
        public DbSet<MoveMoney> MovesMoney { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
