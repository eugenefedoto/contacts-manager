using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManagerV3.Models
{
    public class ManagerContextSeedData
    {
        private ManagerContext _context;

        public ManagerContextSeedData(ManagerContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            if (!_context.Contacts.Any())
            {
                var contact = new Contact()
                {
                    FirstName = "Eugene",
                    LastName = "Fedotov",
                    EmailAddress = "eugenefedoto@gmail.com",
                    //Groups = new List<Group>()
                    //{
                    //    new Group() { Name = "Associate" },
                    //    new Group() { Name = "Family" },

                    //}
                };

                _context.Contacts.Add(contact);
                //_context.Groups.AddRange(contact.Groups);
                _context.SaveChanges();
            }
        }
    }
}
