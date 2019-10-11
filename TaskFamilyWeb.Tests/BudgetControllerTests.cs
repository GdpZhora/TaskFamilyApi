using System;
using Xunit;
using Moq;
using System.Linq;
using TaskFamilyWeb.Controllers;
using TaskFamilyWeb.Models;
using System.Collections.Generic;

namespace TaskFamilyWeb.Tests
{
    public class BudgetControllerTests
    {
        [Fact]
        public void IndexBudgetController()
        {
            Purse purse1 = new Purse { PurseId = 1, Description = "Purse1" };
            Purse purse2 = new Purse { PurseId = 2, Description = "Purse2" };
            Purse purse3 = new Purse { PurseId = 3, Description = "Purse3" };

            Mock<IBudget> mock = new Mock<IBudget>();
            mock.Setup(m => m.Purses).Returns(new Purse[]{

                purse1,
                purse2,
                purse3

            });
            mock.Setup(m => m.Moves).Returns(new MoveMoney[]
            {
                new MoveMoney{Date = new DateTime(2019,1,1), Purse = purse1, Total = 100000, InMove = DirectMove.incoming, Comment = "Приход на первый кошелек"},
                new MoveMoney{Date = new DateTime(2019,1,2), Purse = purse1, Total = 40000, InMove = DirectMove.expense, Comment = "Расход из первого кошелька"},
                new MoveMoney{Date = new DateTime(2019,1,2), Purse = purse2, Total = 40000, InMove = DirectMove.incoming, Comment = "Приход на второй кошелек"},
                new MoveMoney{Date = new DateTime(2019,1,3), Purse = purse2, Total = 20000, InMove = DirectMove.expense, Comment = "Расход из второго кошелька"},
                new MoveMoney{Date = new DateTime(2019,1,3), Purse = purse3, Total = 20000, InMove = DirectMove.incoming, Comment = "Приход на третий кошелек"},
                new MoveMoney{Date = new DateTime(2019,1,4), Purse = purse3, Total = 10000, InMove = DirectMove.expense, Comment = "Расход из второго кошелька"}
            });

            BudgetController controller = new BudgetController(mock.Object);

            IDictionary<Purse, decimal> result = controller.ListTotal().ViewData.Model as IDictionary<Purse,decimal>;

            decimal balancePurse1 = 0;
            decimal balancePurse2 = 0;
            decimal balancePurse3 = 0;
            
            foreach (var KeyValue in result)
            {
                if (KeyValue.Key == purse1)
                    balancePurse1 = KeyValue.Value;
                if (KeyValue.Key == purse2)
                    balancePurse2 = KeyValue.Value;
                if (KeyValue.Key == purse3)
                    balancePurse3 = KeyValue.Value;
            }

            Assert.True(balancePurse1 == 60000);
            Assert.True(balancePurse2 == 20000);
            Assert.True(balancePurse3 == 10000);

        }
        [Fact]
        public void ListBudgetController()
        {
            Purse purse1 = new Purse { PurseId = 1, Description = "Purse1" };
            Purse purse2 = new Purse { PurseId = 2, Description = "Purse2" };
            Purse purse3 = new Purse { PurseId = 3, Description = "Purse3" };

            Mock<IBudget> mock = new Mock<IBudget>();
            mock.Setup(m => m.Purses).Returns(new Purse[]{

                purse1,
                purse2,
                purse3

            });
            mock.Setup(m => m.Moves).Returns(new MoveMoney[]
            {
                new MoveMoney{Date = new DateTime(2019,1,1), Purse = purse1, Total = 100000, InMove = DirectMove.incoming, Comment = "Приход на первый кошелек"},
                new MoveMoney{Date = new DateTime(2019,1,2), Purse = purse1, Total = 40000, InMove = DirectMove.expense, Comment = "Расход из первого кошелька"},
                new MoveMoney{Date = new DateTime(2019,1,2), Purse = purse2, Total = 40000, InMove = DirectMove.incoming, Comment = "Приход на второй кошелек"},
                new MoveMoney{Date = new DateTime(2019,1,3), Purse = purse2, Total = 20000, InMove = DirectMove.expense, Comment = "Расход из второго кошелька"},
                new MoveMoney{Date = new DateTime(2019,1,3), Purse = purse3, Total = 20000, InMove = DirectMove.incoming, Comment = "Приход на третий кошелек"},
                new MoveMoney{Date = new DateTime(2019,1,4), Purse = purse3, Total = 10000, InMove = DirectMove.expense, Comment = "Расход из второго кошелька"}
            });

            BudgetController controller = new BudgetController(mock.Object);

            IEnumerable<PurseBalance> result = controller.List();

            decimal balancePurse1 = 0;
            decimal balancePurse2 = 0;
            decimal balancePurse3 = 0;

            foreach (var KeyValue in result)
            {
                if (KeyValue.PurseId == purse1.PurseId)
                    balancePurse1 = KeyValue.Balance;
                if (KeyValue.PurseId == purse2.PurseId)
                    balancePurse2 = KeyValue.Balance;
                if (KeyValue.PurseId == purse3.PurseId)
                    balancePurse3 = KeyValue.Balance;
            }

            Assert.True(balancePurse1 == 60000);
            Assert.True(balancePurse2 == 20000);
            Assert.True(balancePurse3 == 10000);

        }

    }
}
