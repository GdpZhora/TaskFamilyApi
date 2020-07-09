using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using TaskFamilyApi.DL.Entityes;

namespace TaskFamilyApi.DL
{
    public class EFDBContext : DbContext
    {

        public DbSet<Purse> Purses { get; set; }
        public DbSet<ExpenseItem> ExpenseItems { get; set; }
        public DbSet<IncomeItem> IncomeItems { get; set; }

        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Transfer> Transfers { get; set; }


        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {

        }

    }

    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TaskFamilyApi;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));

            return new EFDBContext(optionsBuilder.Options);
        }
    }

}
