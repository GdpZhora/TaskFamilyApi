using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskFamilyWeb.Models;

namespace TaskFamilyWeb.Controllers
{
    public class TodoController : Controller
    {
        private ITodoRepository todo;

        public TodoController(ITodoRepository repository)
        {
            todo = repository;
        }

        public ViewResult List()
        {
            return View(todo.ToDos);
        }
    }
}