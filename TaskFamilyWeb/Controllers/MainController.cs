using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TaskFamilyWeb.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ListView()
        {
            Dictionary<string, string> valuePairs = new Dictionary<string, string>();

            valuePairs.Add("Задачи", "todo");
            valuePairs.Add("Бюджет", "budget");

            return Json(valuePairs);
        }
    }
}