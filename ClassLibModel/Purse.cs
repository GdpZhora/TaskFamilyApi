using System;
using System.Collections.Generic;

namespace TaskFamilyWeb.Models
{
    public class Purse
    {
        public int PurseId { get; set; }
        public string Description { get; set; }
        public bool MarkRemoval { get; set; }
        public int FamilyId { get; set; }
        public virtual Family Family { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public bool Draft { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<MoveMoney> MovesMoney { get; set; }
        public Purse()
        {
            this.MovesMoney = new List<MoveMoney>();
        }


    }
}
