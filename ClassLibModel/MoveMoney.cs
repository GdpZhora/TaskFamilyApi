using System;

namespace TaskFamilyWeb.Models
{
    public class MoveMoney
    {
        public int MoveMoneyId { get; set; }
        public int PurseId { get; set; }
        public virtual Purse Purse { get; set; }
        public DateTime Date { get; set; }
        public DirectMove InMove { get; set; }
        public string Comment { get; set; }

        public decimal Total {get; set;}
    }

    public enum DirectMove
    {
        incoming,
        expense
    }

}
