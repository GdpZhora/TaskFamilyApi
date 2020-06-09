using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFamilyWeb.Models
{
    public interface ITodoRepository
    {
        IEnumerable<ToDo> ToDos { get; }
    }
}
