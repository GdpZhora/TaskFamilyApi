using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFamilyWeb.Models
{
    public class FakeTodoRepository : ITodoRepository
    {
        public IEnumerable<ToDo> ToDos => new List<ToDo>
        {
            new ToDo{Id =1, Description = "Релизовать вывод всех задач"},
            new ToDo{Id =2, Description = "Подключить Bootstrap библиотеки к страничке"},
            new ToDo{Id =3, Description = "Доработать контроллер на изменение задач"}

        };
    }
}
