using System;
using Xunit;
using TaskFamilyWeb.Controllers;
using TaskFamilyWeb.Models;
using System.Collections.Generic;

namespace TaskFamilyWeb.Tests
{
    public class ControllerTests
    {
        [Fact]
        public void IndexTodoTest()
        {

            ITodoRepository todoRepository = new TestTodoRepository();

            TodoController todoController = new TodoController(todoRepository);

            //todoController.Index()

        }

        public class TestTodoRepository : ITodoRepository
        {
            public IEnumerable<ToDo> ToDos => new List<ToDo>
            {
                new ToDo {Id = 1, Description = "Тестовая задача 1"},
                new ToDo {Id = 2, Description = "Тестовая задача 2"},
                new ToDo {Id = 3, Description = "Тестовая задача 3"},
                new ToDo {Id = 4, Description = "Тестовая задача 4"}
            }
                ;
        }
    }
}
