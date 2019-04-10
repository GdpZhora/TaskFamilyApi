using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFamilyWeb.Models
{
    public class BaseDoc
    {
        public int Id { get; set; }
        public bool Draft { get; set; }
        public DateTime Date { get; set; }
    }
}
