using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFamilyWeb.Models
{
    public class MoveMoney
    {
        public Purse PurseMoney { get; set; }
        public DirectMove InMove { get; set; }
        public string Comment { get; set;}
        public decimal Total { get; set; }
    }

    public enum DirectMove
    {
        incoming,
        expense
    }

}
