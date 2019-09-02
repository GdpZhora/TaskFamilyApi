using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFamilyWeb.Models
{
    public class EFBudget : IBudget
    {
        private ApplicationDbContext context;

        public EFBudget(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Purse> Purses => context.Purses;

        public IEnumerable<MoveMoney> Moves => context.MovesMoney;

        public IEnumerable<Currency> Currencies => context.Currencies;

        public void ExpenseFromPurse(Purse purse, decimal sum, string comment = "")
        {
            SaveMoveMoney(purse, DirectMove.expense, sum, comment);
        }

        public void IncomeToPurse(Purse purse, decimal sum, string comment = "")
        {
            SaveMoveMoney(purse, DirectMove.incoming, sum, comment);
        }

        public void ReplaceFromPurseToPurse(Purse purseFrom, Purse purseTo, decimal sum, string comment = "")
        {
            context.MovesMoney.Add(
                new MoveMoney
                {
                    Purse = purseFrom,
                    InMove = DirectMove.expense,
                    Total = sum,
                    Comment = comment
                });

            context.MovesMoney.Add(
                new MoveMoney
                {
                    Purse = purseTo,
                    InMove = DirectMove.incoming,
                    Total = sum,
                    Comment = comment
                });

            context.SaveChanges();
        }

        public void SaveMoveMoney(Purse purse, DirectMove move, decimal sum, string comment = "")
        {
            context.MovesMoney.Add(
                new MoveMoney
                {
                    Purse = purse,
                    InMove = move,
                    Total = sum,
                    Comment = comment
                });

            context.SaveChanges();
        }

        public void SavePurse(Purse purse)
        {
            context.Purses.Add(purse);
            context.SaveChanges();
        }
    }
}
