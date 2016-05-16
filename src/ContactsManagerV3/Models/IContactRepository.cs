using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManagerV3.Models
{
    public interface IContactRepository
    {
        void Add(Contact item);
        Contact Remove(string key);
        void Update(Contact item);
        IEnumerable<Contact> GetAll();
        Contact Find(string key);
    }
}
