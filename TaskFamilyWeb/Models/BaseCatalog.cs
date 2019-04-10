using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFamilyWeb.Models
{
    public class BaseCatalog
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool MarkRemoval { get; set; }

    }
}
