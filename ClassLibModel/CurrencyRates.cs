using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFamilyWeb.Models
{
    public class CurrencyRates
    {
        //public int CurrencyRatesId { get; set; }
        public DateTime Period { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public int BaseCurrencyId { get; set; }
        public virtual Currency BaseCurrency { get; set; }
        public decimal Rate { get; set; }
        public int Multiplicity { get; set; }
    }
}
