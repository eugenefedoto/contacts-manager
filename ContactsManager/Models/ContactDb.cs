using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactsManager.Models
{
    public class ContactDb : System.Data.Entity.DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

    }
}