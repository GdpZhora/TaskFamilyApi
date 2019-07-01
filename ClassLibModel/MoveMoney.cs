using System;

namespace TaskFamilyWeb.Models
{
    public class MoveMoney
    {
        public Purse PurseMoney { get; set; }
        public DateTime Date { get; set; }
        public DirectMove InMove { get; set; }
        public string Comment { get; set; }

        private decimal total;
        public decimal Total {
            get
            {
                if (InMove == DirectMove.expense)
                    return (-1) * total;
                else return total;
            }
            set
            {
                total = value;
            }
        }
    }

    public enum DirectMove
    {
        incoming,
        expense
    }

}
