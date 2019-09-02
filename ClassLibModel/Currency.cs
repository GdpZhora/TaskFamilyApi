using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFamilyWeb.Models
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string Description { get; set; }
        public string DigitalCode { get; set; }
        public string CharacterCode { get; set; }
        public bool MarkRemoval { get; set; }

    }
}
