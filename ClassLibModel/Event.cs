using System;

namespace TaskFamilyWeb.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Description { get; set; }
        public bool MarkRemoval { get; set; }
        public int FamilyId { get; set; }
        public virtual Family Family { get; set; }
        public PeriodicityEnum Periodicity { get; set; }
        public DateTime DateBegin { get; set; }

    }

    public enum PeriodicityEnum
    {
        once,
        everyday,
        everyweek,
        everymonth,
        everyyear
    }

}
