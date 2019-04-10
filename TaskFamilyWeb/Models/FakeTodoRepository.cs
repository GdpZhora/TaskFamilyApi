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
            new ToDo{Id =1}
        };
    }
}
