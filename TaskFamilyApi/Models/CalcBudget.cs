using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFamilyWeb.Models;
     

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
            decimal Total = budget.Moves.Sum(m =>
            {
                if (m.InMove == DirectMove.expense)
                    return (-1) * m.Total;
                else return m.Total;
            });
            return Total;
        }

        public decimal BalancePurse(Purse purse, DateTime dateTime )
        {
            /*decimal Sum = budget.Moves.Sum(m =>
            {
                if (m.Purse == purse && m.Date <= dateTime)
                {
                    if (m.InMove == DirectMove.expense)
                        return (-1) * m.Total;
                    else return m.Total; }
                else { return 0; }
            }
            );*/
            decimal Sum = budget.Moves.Select(m => m)
                                        .Where(m => (m.Purse == purse && m.Date <= dateTime))
                                        .Sum(m =>
                                        {
                                            if (m.InMove == DirectMove.expense)
                                                return (-1) * m.Total;
                                            else return m.Total;
                                        });
            return Sum;
        }

        public IEnumerable<PurseBalance> PursesBalances(DateTime dateTime)
        {
            List<PurseBalance> purseBalances = new List<PurseBalance>();


            foreach (Purse purse in budget.Purses)
            {
                purseBalances.Add(
                    new PurseBalance
                    {
                        PurseId = purse.PurseId,
                        PurseDescription = purse.Description,
                        Balance = BalancePurse(purse, dateTime)
                    }) ;
            }
                
            return purseBalances;
        }
    }
}
