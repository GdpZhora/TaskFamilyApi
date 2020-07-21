using System;
using System.Collections.Generic;
using System.Text;
using TaskFamilyApi.DL.Entityes;

namespace TaskFamilyApi.BL.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        ICatalogRepository<ExpenseItem> ExpenseItems { get; }
        ICatalogRepository<IncomeItem> IncomeItems { get; }
        ICatalogRepository<Purse> Purses { get; }
        IDocumentRepository<Expense> Expenses { get; }
        IDocumentRepository<Income> Incomes { get; }
        IDocumentRepository<Transfer> Transfers { get; }
    }
}
