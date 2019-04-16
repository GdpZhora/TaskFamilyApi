using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFamilyWeb.Models
{
    public class FakeBudget : IBudget
    {
        public IDictionary<Purse, decimal> Purses
        {
            get
            {
                IDictionary<Purse, decimal> valuePairs = new Dictionary<Purse, decimal>();

                IEnumerable<MoveMoney> moves = Moves;
                //Moves.GroupBy()

                return valuePairs;

            }
        }



        public IEnumerable<MoveMoney> Moves {

            get {
                Purse cash = new Purse { Id = 1, Description = "Наличные деньги" };
                Purse salaryCard = new Purse { Id = 2, Description = "Зарплатная карта" };
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
