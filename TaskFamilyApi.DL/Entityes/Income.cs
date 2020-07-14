using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFamilyApi.DL.Entityes
{
    public class Income : Document
    {
        public int FromId { get; set; }
        public virtual Purse From { get; set; }
        public int ToId { get; set; }
        public virtual IncomeItem To { get; set; }
        public decimal Total { get; set; }

    }
}
