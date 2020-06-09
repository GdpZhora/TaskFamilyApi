using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaskFamilyWeb.Models
{
    public class EFTodo : ITodoRepository
    {
        private ApplicationDbContext context;

        public EFTodo(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<ToDo> ToDos => context.ToDos;

    }
}
