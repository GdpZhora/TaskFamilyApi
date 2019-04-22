﻿using System;
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
            Purse purse1 = new Purse { Id = 1, Description = "Purse1" };
            Purse purse2 = new Purse { Id = 2, Description = "Purse2" };
            Purse purse3 = new Purse { Id = 3, Description = "Purse3" };

            Mock<IBudget> mock = new Mock<IBudget>();
            mock.Setup(m => m.Purses).Returns(new Purse[]{

                purse1,
                purse2,
                purse3

            });
            mock.Setup(m => m.Moves).Returns(new MoveMoney[]
            {
                new MoveMoney{Date = new DateTime(2019,1,1), PurseMoney = purse1, Total = 100000, InMove = DirectMove.incoming, Comment = "Приход на первый кошелек"},
                new MoveMoney{Date = new DateTime(2019,1,2), PurseMoney = purse1, Total = 40000, InMove = DirectMove.expense, Comment = "Расход из первого кошелька"},
                new MoveMoney{Date = new DateTime(2019,1,2), PurseMoney = purse2, Total = 40000, InMove = DirectMove.incoming, Comment = "Приход на второй кошелек"},
                new MoveMoney{Date = new DateTime(2019,1,3), PurseMoney = purse2, Total = 20000, InMove = DirectMove.expense, Comment = "Расход из второго кошелька"},
                new MoveMoney{Date = new DateTime(2019,1,3), PurseMoney = purse3, Total = 20000, InMove = DirectMove.incoming, Comment = "Приход на третий кошелек"},
                new MoveMoney{Date = new DateTime(2019,1,4), PurseMoney = purse3, Total = 10000, InMove = DirectMove.expense, Comment = "Расход из второго кошелька"}
            });

            BudgetController controller = new BudgetController(mock.Object);

            IDictionary<Purse, decimal> result = controller.List().ViewData.Model as IDictionary<Purse,decimal>;

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
    }
}