using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFamilyWeb.Models
{
    public class ToDo : BaseDoc
    {
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public bool Complete { get; set; }
        public DateTime FactDate { get; set; }
        public string Detail { get; set; }
        public string Comment { get; set; }
        public decimal PriceResult { get; set; }
    }
}
