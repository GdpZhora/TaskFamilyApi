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

        public BudgetController(IBudget budgetOut)
        {
            budget = budgetOut;
        }

        public IActionResult Index()
        {
            return View(budget.Purses);
        }
    }
}