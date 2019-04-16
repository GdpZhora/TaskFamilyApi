using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFamilyWeb.Models
{
    public class FakeBudget : IBudget
    {
        public IEnumerable<Purse> Purses => new List<Purse>
        {
            new Purse { Id = 1, Description = "Наличные деньги" },
            new Purse { Id = 2, Description = "Зарплатная карта" },
            new Purse { Id = 3, Description = "Кредитная карта" }
        };



        public IEnumerable<MoveMoney> Moves {

            get {
                Purse cash = new Purse();
                Purse salaryCard = cash;
                foreach (Purse purse in Purses)
                {
                    if (purse.Id == 1)
                    {
                        cash = purse;
                    }
                    else if(purse.Id == 2 )
                    {
                        salaryCard = purse;
                    }
                }
                IEnumerable<MoveMoney> moves = new List<MoveMoney>
                {
                    new MoveMoney { PurseMoney = salaryCard, InMove = DirectMove.incoming, Total = 100000},
                    new MoveMoney { PurseMoney = salaryCard, InMove = DirectMove.expense, Total = 50000},
                    new MoveMoney { PurseMoney = cash, InMove = DirectMove.incoming, Total = 50000}
                };
                return moves;
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
