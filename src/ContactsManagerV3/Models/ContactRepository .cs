using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManagerV3.Models
{
    public class ContactRepository : IContactRepository
    {
        static ConcurrentDictionary<string, Contact> _contacts = new ConcurrentDictionary<string, Contact>();

        public ContactRepository()
        {
            
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contacts.Values;
        }

        public Contact Find(string key)
        {
            Contact item;
            _contacts.TryGetValue(key, out item);
            return item;
        }

        public void Add(Contact item)
        {
            item.Key = Guid.NewGuid().ToString();
            _contacts[item.Key] = item;
        }

        public Contact Remove(string key)
        {
            Contact item;
            _contacts.TryGetValue(key, out item);
            _contacts.TryRemove(key, out item);
            return item;
        }

        public void Update(Contact item)
        {
            _contacts[item.Key] = item;
        }
    }
}
