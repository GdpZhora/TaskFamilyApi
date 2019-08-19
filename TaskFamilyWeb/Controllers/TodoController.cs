using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskFamilyWeb.Models;

namespace TaskFamilyWeb.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private ITodoRepository todo;

        public TodoController(ITodoRepository repository)
        {
            todo = repository;
        }


        [HttpGet]
        public IActionResult List()
        {
            return Ok(todo.ToDos);
        }

        [HttpGet("current")]
        public IActionResult Current()
        {
            return Ok(todo.ToDos);
        }

    }
}