using System;
using System.Collections.Generic;
using System.Text;
using TaskFamilyApi.DL.Entityes;

namespace TaskFamilyApi.BL.Interfaces
{
    public interface IPursesRepository
    {
        IEnumerable<Purse> GetAllPurses(bool includeMoves = false);
        Purse GetPurseById(int purseId, bool includeMoves = false);
        void SavePurse(Purse achieve);
        void DeletePurse(Purse achieve);

    }
}
