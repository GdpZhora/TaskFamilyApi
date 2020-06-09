using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFamilyWeb.Models
{
    public class FakeBudget : IBudget
    {
        private Purse cash;
        private Purse salaryCard;
        private Purse creditCard;

        public IEnumerable<Purse> Purses { get; set; }
        public IEnumerable<MoveMoney> Moves {get;set;}

        public FakeBudget()
        {
            cash = new Purse { PurseId = 1, Description = "Наличные деньги" };
            salaryCard = new Purse { PurseId = 2, Description = "Зарплатная карта" };
            creditCard = new Purse { PurseId = 3, Description = "Кредитная карта" };
            Purses = new List<Purse>
            {
                cash,
                salaryCard,
                creditCard
            };
            Moves = new List<MoveMoney>
            {
                 new MoveMoney { Purse = salaryCard, InMove = DirectMove.incoming, Total = 100000},
                 new MoveMoney { Purse = salaryCard, InMove = DirectMove.expense, Total = 50000},
                 new MoveMoney { Purse = cash, InMove = DirectMove.incoming, Total = 50000}
            };
        }

        public IEnumerable<Currency> Currencies => throw new NotImplementedException();

        public void ExpenseFromPurse(Purse purse, decimal sum, string comment = "")
        {
            throw new NotImplementedException();
        }

        public void IncomeToPurse(Purse purse, decimal sum, string comment = "")
        {
            throw new NotImplementedException();
        }

        public void ReplaceFromPurseToPurse(Purse purseFrom, Purse purseTo, decimal sum, string comment = "")
        {
            throw new NotImplementedException();
        }

        public void SaveMoveMoney(Purse purse, DirectMove move, decimal sum, string comment = "")
        {
            throw new NotImplementedException();
        }

        public void SavePurse(Purse purse)
        {
            throw new NotImplementedException();
        }
    }
}
