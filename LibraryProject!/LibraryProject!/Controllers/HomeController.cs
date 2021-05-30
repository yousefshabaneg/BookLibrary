using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject_.Models;

namespace LibraryProject_.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = ApplicationDbContext.Create();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            var contact = new Contact();
            return View(contact);
        }

        [HttpPost]
        public ActionResult Save(Contact contact)
        {
            if (!ModelState.IsValid)
                return View("Contact", contact);

            _context.Contact.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}