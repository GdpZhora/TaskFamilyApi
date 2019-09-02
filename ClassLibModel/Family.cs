using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFamilyWeb.Models
{
    public class Family
    {
        public int FamilyId { get; set; }
        public string Description { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

    }

    public abstract class FamilyShare
    {
        public int FamilyId { get; set; }
        public virtual Family Family { get; set; }

    }
}
