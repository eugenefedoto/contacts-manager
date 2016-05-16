using Microsoft.AspNet.Mvc;
using ContactsManagerV3.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using System.IO;
using Microsoft.AspNet.Hosting;
using Microsoft.Net.Http.Headers;
using Sakura.AspNet;
using Sakura.AspNet.Mvc.PagedList;

namespace ContactsManagerV3.Controllers
{
    public class ContactsController : Controller
    {
        private ManagerContext _context;
        private IHostingEnvironment _environment;

        public IContactRepository Contacts { get; set; }

        public ContactsController(ManagerContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;


        }

        // GET: Contacts
        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var model =
                _context.Contacts
                .OrderBy(r => r.LastName)
                .Select(r => r);

            var pageSize = 3;

            // data is assumed as coming from an EntityFramework DbSet here. All data source with IEnumerable<T> and IQueryable<T> are both supported with different implementations.
            var data = from i in _context.Contacts select i;

            // The IPagedList type, which contains a partial view for the current page, and the paging information.
            var pagedData = data.ToPagedList(pageSize, page);

            //return View(model);
            return View(pagedData);
        }



        // GET: Contacts/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactViewModel vm, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new Contact();
                contact.BirthDate = vm.BirthDate;
                contact.Comments = vm.Comments;
                contact.EmailAddress = vm.EmailAddress;
                contact.FirstName = vm.FirstName;
                contact.LastName = vm.LastName;
                contact.PhoneNumber = vm.PhoneNumber;

                // File upload logic
                var uploads = Path.Combine(_environment.WebRootPath, "images/UploadedProfileImages");
                if (file != null && file.Length > 0)
                {
                    contact.ProfileImagePath = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    await file.SaveAsAsync(Path.Combine(uploads, contact.ProfileImagePath));
                }
                //
                
                if (vm.SelectedGroups != null)
                {
                    foreach (string group in vm.SelectedGroups)
                    {
                        switch (group)
                        {
                            case "Associate":
                                contact.isAssociate = true;
                                break;
                            case "Colleague":
                                contact.isColleague = true;
                                break;
                            case "Family":
                                contact.isFamily = true;
                                break;
                            case "Friend":
                                contact.isFriend = true;
                                break;
                            default:
                                contact.isAssociate = false;
                                contact.isColleague = false;
                                contact.isFamily = false;
                                contact.isFriend = false;
                                break;
                        }
                    }
                }
                else
                {
                    contact.isAssociate = false;
                    contact.isColleague = false;
                    contact.isFamily = false;
                    contact.isFriend = false;
                }

                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);

        }

        // GET: Contact/Edit/5
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

            List<string> list = new List<string>();

            if (contact.isAssociate)
            {
                list.Add("Associate");
            }
            if (contact.isColleague)
            {
                list.Add("Colleague");
            }
            if (contact.isFamily)
            {
                list.Add("Family");
            }
            if (contact.isFriend)
            {
                list.Add("Friend");
            }

            CreateContactViewModel vm = new CreateContactViewModel()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                BirthDate = contact.BirthDate,
                EmailAddress = contact.EmailAddress,
                PhoneNumber = contact.PhoneNumber,
                SelectedGroups = list
            };

            return View(vm);
        }

        // POST: Test/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateContactViewModel vm, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                Contact contact = new Contact();
                contact.Id = vm.Id;
                contact.BirthDate = vm.BirthDate;
                contact.Comments = vm.Comments;
                contact.EmailAddress = vm.EmailAddress;
                contact.FirstName = vm.FirstName;
                contact.LastName = vm.LastName;
                contact.PhoneNumber = vm.PhoneNumber;

                // File upload logic
                var uploads = Path.Combine(_environment.WebRootPath, "images/UploadedProfileImages");
                if (file != null && file.Length > 0)
                {
                    contact.ProfileImagePath = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    await file.SaveAsAsync(Path.Combine(uploads, contact.ProfileImagePath));
                }
                else
                {
                    contact.ProfileImagePath = vm.ProfileImagePath;
                }
                //

                if (vm.SelectedGroups != null)
                {
                    foreach (string group in vm.SelectedGroups)
                    {
                        switch (group)
                        {
                            case "Associate":
                                contact.isAssociate = true;
                                break;
                            case "Colleague":
                                contact.isColleague = true;
                                break;
                            case "Family":
                                contact.isFamily = true;
                                break;
                            case "Friend":
                                contact.isFriend = true;
                                break;
                            default:
                                contact.isAssociate = false;
                                contact.isColleague = false;
                                contact.isFamily = false;
                                contact.isFriend = false;
                                break;
                        }
                    }
                }
                else
                {
                    contact.isAssociate = false;
                    contact.isColleague = false;
                    contact.isFamily = false;
                    contact.isFriend = false;
                }

                _context.Contacts.Update(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CreateContactViewModel vm)
        {
            Contact contact = _context.Contacts.Single(m => m.Id == vm.Id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            return Contacts.GetAll();
        }

        [HttpGet("{id}", Name = "GetContact")]
        public IActionResult GetById(string id)
        {
            var item = Contacts.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }

    }
}
