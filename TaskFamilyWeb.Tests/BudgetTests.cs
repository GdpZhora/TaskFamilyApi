using System;
using Xunit;
using Moq;
using System.Linq;
using TaskFamilyWeb.Controllers;
using TaskFamilyWeb.Models;
using System.Collections.Generic;

namespace TaskFamilyWeb.Tests
{
    public class BudgetTests
    {
        [Fact]
        public void FinancialStat()
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
                new MoveMoney{Date = new DateTime(2019,1,3), Purse = purse3, Total = 20000, InMove = DirectMove.incoming, Comment = "Приход на третий кошелек"}
            });

            CalcBudget calcBudget = new CalcBudget(mock.Object);

            decimal FinState = calcBudget.TotalBalance(DateTime.Now);
            decimal result = 100000;

            Assert.Equal(FinState, result);
        }

        [Fact]
        public void BalanceParseTest()
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

            CalcBudget calcBudget = new CalcBudget(mock.Object);

            decimal balancePurse1 = calcBudget.BalancePurse(purse1, DateTime.Now);
            decimal balancePurse2 = calcBudget.BalancePurse(purse2, DateTime.Now);
            decimal balancePurse3 = calcBudget.BalancePurse(purse3, DateTime.Now);

            Assert.True(balancePurse1 == 60000);
            Assert.True(balancePurse2 == 20000);
            Assert.True(balancePurse3 == 10000);

        }
    }
}
