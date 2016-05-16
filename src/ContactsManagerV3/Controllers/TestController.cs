using System.Linq;
using Microsoft.AspNet.Mvc;
using ContactsManagerV3.Models;

namespace ContactsManagerV3.Controllers
{
    public class TestController : Controller
    {
        private ManagerContext _context;

        public TestController(ManagerContext context)
        {
            _context = context;    
        }

        // GET: Test
        public IActionResult Index()
        {
            return View(_context.Contacts.ToList());
        }

        // GET: Test/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Contact contact = _context.Contacts.Single(m => m.Id == id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        // GET: Test/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Test/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Contact contact = _context.Contacts.Single(m => m.Id == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Test/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Update(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Test/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Contact contact = _context.Contacts.Single(m => m.Id == id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Contact contact = _context.Contacts.Single(m => m.Id == id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
