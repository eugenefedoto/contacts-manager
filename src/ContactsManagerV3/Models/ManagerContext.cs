using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManagerV3.Models
{
    public class ManagerContext : DbContext
    {
        public ManagerContext()
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Group> Groups { get; set; }
    }
}
