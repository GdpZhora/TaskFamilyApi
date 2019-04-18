using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFamilyWeb.Models
{
    public class CalcBudget
    {
        IBudget budget;

        public CalcBudget(IBudget budget)
        {
            this.budget = budget;
        }

        public decimal TotalBalance(DateTime dateTime)
        {

            return budget.Moves.Sum(m => m.Total);
        }

        public decimal BalancePurse(Purse purse, DateTime dateTime )
        {
            return 0;
        }
    }
}
