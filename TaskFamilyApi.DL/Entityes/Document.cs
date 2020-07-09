using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace TaskFamilyApi.DL.Entityes
{
    public class Document
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Post { get; set; }
        public bool MarkDelete { get; set; }


    }
}
