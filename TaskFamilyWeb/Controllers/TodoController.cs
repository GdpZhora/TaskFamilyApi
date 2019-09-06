using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskFamilyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskFamilyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository todo;

        public TodoController(ITodoRepository repository)
        {
            todo = repository;
        }


        [HttpGet]
        public IEnumerable<ToDo> List()
        {
            return todo.ToDos;
        }

        [HttpGet("current")]
        public IActionResult Current()
        {
            return Ok(todo.ToDos);
        }

    }
}