using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFamilyWeb.Models
{
    public interface IBudget
    {
        IEnumerable<Purse> Purses { get; }

        IEnumerable<MoveMoney> Moves { get; }

        void SavePurse(Purse purse);

        void SaveMoveMoney(Purse purse, DirectMove move, decimal sum, string comment = "");


    }
}
