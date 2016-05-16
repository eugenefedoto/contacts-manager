namespace ContactsManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactsManager.Models.ContactDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ContactsManager.Models.ContactDb";
        }

        protected override void Seed(ContactsManager.Models.ContactDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Contacts.AddOrUpdate(r => r.LastName,
                new Models.Contact { FirstName = "Donald", LastName = "Knuth", EmailAddress = "dknuth@gmail.com", PhoneNumber = "0123456789", BirthDate = "2016-01-90", Comments = "some comments" },
                new Models.Contact { FirstName = "Linus", LastName = "Torvalds", EmailAddress = "ltorvalds@gmail.com", PhoneNumber = "0123456789", BirthDate = "2016-01-90", Comments = "some comments" },
                new Models.Contact { FirstName = "James", LastName = "Gosling", EmailAddress = "jgosling@gmail.com", PhoneNumber = "0123456789", BirthDate = "2016-01-90", Comments = "some comments" },
                new Models.Contact { FirstName = "Brian", LastName = "Kerninghan", EmailAddress = "bkerninghan@gmail.com", PhoneNumber = "0123456789", BirthDate = "2016-01-90", Comments = "some comments" },
                new Models.Contact { FirstName = "Ada", LastName = "Lovelace", EmailAddress = "alovelace@gmail.com", PhoneNumber = "0123456789", BirthDate = "2016-01-90", Comments = "some comments" },
                new Models.Contact { FirstName = "John", LastName = "Carmack", EmailAddress = "jcarmack@gmail.com", PhoneNumber = "0123456789", BirthDate = "2016-01-90", Comments = "some comments" },
                new Models.Contact { FirstName = "Richard", LastName = "Stallman", EmailAddress = "rstallman@gmail.com", PhoneNumber = "0123456789", BirthDate = "2016-01-90", Comments = "some comments" },
                new Models.Contact { FirstName = "Grace", LastName = "Hopper", EmailAddress = "ghopper@gmail.com", PhoneNumber = "0123456789", BirthDate = "2016-01-90", Comments = "some comments" },
                new Models.Contact { FirstName = "Ken", LastName = "Thompson", EmailAddress = "kthompson@gmail.com", PhoneNumber = "0123456789", BirthDate = "2016-01-90", Comments = "some comments" },
                new Models.Contact { FirstName = "Mark", LastName = "Zuckerberg", EmailAddress = "mzuckerberg@gmail.com", PhoneNumber = "0123456789", BirthDate = "2016-01-90", Comments = "some comments" },
                new Models.Contact { FirstName = "Steve", LastName = "Wozniak", EmailAddress = "swozniak@gmail.com", PhoneNumber = "0123456789", BirthDate = "2016-01-90", Comments = "some comments" }
                );
        }
    }
}
