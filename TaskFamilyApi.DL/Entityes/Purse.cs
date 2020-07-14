using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFamilyApi.DL.Entityes
{
    public class Purse : Catalog
    {
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }

    }
}
