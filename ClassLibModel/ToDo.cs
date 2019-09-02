using System;

namespace TaskFamilyWeb.Models
{
    public class ToDo
    {
        public int ToDoId { get; set; }
        public bool Draft { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public bool Complete { get; set; }
        public DateTime FactDate { get; set; }
        public string Detail { get; set; }
        public string Comment { get; set; }
        public decimal PriceResult { get; set; }
    }
}
