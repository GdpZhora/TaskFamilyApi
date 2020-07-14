using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFamilyApi.DL.Entityes
{
    public class Expense : Document
    {
        public int FromId { get; set; }
        public virtual ExpenseItem From { get; set; }
        public int ToId { get; set; }
        public virtual Purse To { get; set; }
        public decimal Total { get; set; }

    }
}
