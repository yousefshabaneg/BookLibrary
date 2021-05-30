using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject_.Models;

namespace LibraryProject_.Controllers
{
    public class PublisherController : Controller
    {
        private ApplicationDbContext _context;

        public PublisherController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Publisher
        public ActionResult Index()
        {
            var publishers = _context.publisher.ToList();
            return View(publishers);
        }
        public ActionResult New()
        {
            ViewBag.Name = "New Publisher";
            return View();
        }

        [HttpPost]
        public ActionResult save(publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View("New",publisher);
            }
            if (publisher.Id == 0)
                _context.publisher.Add(publisher);
            else
            {
                var publisherInDb = _context.publisher.SingleOrDefault(c => c.Id == publisher.Id);
                publisherInDb.Name = publisher.Name;
                publisherInDb.Address = publisher.Address;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Publisher");
        }

        public ActionResult Edit(int id)
        {
            var publisher = _context.publisher.SingleOrDefault(c => c.Id == id);

            if (publisher == null)
                return HttpNotFound();
            ViewBag.Name = "Edit";
            return View("New", publisher);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var publisher = _context.publisher.SingleOrDefault(c => c.Id == id);
            _context.publisher.Remove(publisher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}