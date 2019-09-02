using System;
using Xunit;
using Moq;
using System.Linq;
using TaskFamilyWeb.Controllers;
using TaskFamilyWeb.Models;
using System.Collections.Generic;

namespace TaskFamilyWeb.Tests
{
    public class TotodControllerTests
    {
        [Fact]
        public void IndexTodoTest()
        {

            Mock<ITodoRepository> mock = new Mock<ITodoRepository>();
            mock.Setup(m => m.ToDos).Returns(new ToDo[]
            {
                new ToDo {ToDoId = 1, Description = "Тестовая задача 1"},
                new ToDo {ToDoId = 2, Description = "Тестовая задача 2"},
                new ToDo {ToDoId = 3, Description = "Тестовая задача 3"},
                new ToDo {ToDoId = 4, Description = "Тестовая задача 4"}
            });

            TodoController controller = new TodoController(mock.Object);

            //IEnumerable<ToDo> result = controller.List().ViewData.Model as IEnumerable<ToDo>;

            //ToDo[] toDos = result.ToArray();
            //Assert.True(toDos.Length == 4);
        }

    }
}
