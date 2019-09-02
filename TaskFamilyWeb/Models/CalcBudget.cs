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
            decimal Total = budget.Moves.Sum(m => m.Total);
            return Total;
        }

        public decimal BalancePurse(Purse purse, DateTime dateTime )
        {
            decimal Sum = budget.Moves.Sum(m => m.Purse == purse && m.Date <= dateTime ? m.Total : 0);
            return Sum;
        }
    }
}
