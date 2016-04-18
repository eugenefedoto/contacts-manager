using ContactsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity;
using System.IO;

namespace ContactsManager.Controllers
{
    public class ContactsController : Controller
    {
        ContactDb _db = new ContactDb();

        // GET: Contacts
        // Contacts are displayed by alphabetical order of their last names.
        public ActionResult Index(int page = 1)
        {
            var model =
                _db.Contacts
                .OrderBy(r => r.LastName)
                .Select(r => r)
                .ToPagedList(page, 10);
            
            return View(model);
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contacts/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public ActionResult Create(Contact contact, HttpPostedFileBase file)
        {
            if(ModelState.IsValid)
            {
                //_db.Contacts.Add(contact);

                var contact2 = new Contact
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    EmailAddress = contact.EmailAddress,
                    PhoneNumber = contact.PhoneNumber,
                    BirthDate = contact.BirthDate,
                    Comments = contact.Comments,
                    Id = contact.Id
                };

                // Save picture to a file on the server.
                if (file != null)
                {
                    

                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(
                                           Server.MapPath("~/Content/images"), pic);

                    
                    // Upload file to server.
                    file.SaveAs(path);

                    contact2.PicturePath = path;
                }

                _db.Contacts.Add(contact2);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(contact);
        }

        // GET: Contacts/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.Contacts.Find(id);
            return View(model);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(contact).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = _db.Contacts.Find(id);
            _db.Contacts.Remove(contact);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
