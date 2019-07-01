using System;

namespace TaskFamilyWeb.Models
{
    public class BaseDoc
    {
        public int Id { get; set; }
        public bool Draft { get; set; }
        public DateTime Date { get; set; }
    }
}
