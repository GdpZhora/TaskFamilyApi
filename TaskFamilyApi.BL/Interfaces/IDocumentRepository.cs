using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFamilyApi.BL.Interfaces
{
    interface IDocumentRepository<T> where T : class
    {

        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        void Post(int id);
        void UnPost(int id);

    }
}
