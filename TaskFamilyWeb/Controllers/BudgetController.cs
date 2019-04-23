using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskFamilyWeb.Models;

namespace TaskFamilyWeb.Controllers
{
    public class BudgetController : Controller
    {
        private IBudget budget;
        private CalcBudget calcBudget;


        public BudgetController(IBudget budgetOut)
        {
            budget = budgetOut;
            calcBudget = new CalcBudget(budget);
        }

        public ViewResult List()
        {
            Dictionary<Purse, decimal> keyValues = new Dictionary<Purse, decimal>();

             

            foreach (Purse purse in budget.Purses)
            {
                decimal Total = calcBudget.BalancePurse(purse, DateTime.Now);
                keyValues.Add(purse, Total);
            }

            return View(keyValues);
        }

        public JsonResult JSTotal()
        {
            return Json(calcBudget.TotalBalance(DateTime.Now));
        }
    }
}