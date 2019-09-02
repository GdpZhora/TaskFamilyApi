using System;

namespace TaskFamilyWeb.Models
{
    public class Purse
    {
        public int PurseId { get; set; }
        public string Description { get; set; }
        public bool MarkRemoval { get; set; }
        public bool Draft { get; set; }
        public DateTime Date { get; set; }

    }
}
