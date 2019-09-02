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

        public FakeBudget()
        {
            cash = new Purse { PurseId = 1, Description = "Наличные деньги" };
            salaryCard = new Purse { PurseId = 2, Description = "Зарплатная карта" };
            creditCard = new Purse { PurseId = 3, Description = "Кредитная карта" };
        }

        public IEnumerable<Purse> Purses => new List<Purse>
        {
            cash,
            salaryCard,
            creditCard
        };



        public IEnumerable<MoveMoney> Moves {

            get {
                IEnumerable<MoveMoney> moves = new List<MoveMoney>
                {
                    new MoveMoney { Purse = salaryCard, InMove = DirectMove.incoming, Total = 100000},
                    new MoveMoney { Purse = salaryCard, InMove = DirectMove.expense, Total = 50000},
                    new MoveMoney { Purse = cash, InMove = DirectMove.incoming, Total = 50000}
                };
                return moves;
            }

            set
            {

            }

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
