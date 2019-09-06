using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFamilyWeb.Models
{
    public class PurseBalance
    {
        public int PurseId { get; set; }
        public string PurseDescription { get; set; }
        public decimal Balance { get; set; }
    }
}
