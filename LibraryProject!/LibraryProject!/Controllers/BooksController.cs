using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProject_.Models;
using System.Data.Entity;
using System.Web.WebPages;
namespace LibraryProject_.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _conext;

        public BooksController()
        {
            _conext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _conext.Dispose();
        }
        // GET: Books
        public ActionResult Index()
        {
            var books = _conext.Book.Include(c => c.publisher).ToList();
            return View(books);
        }
        [AllowAnonymous]
        public ActionResult Details()
        {
            var books = _conext.Book.Include(c => c.publisher).ToList();
            return View(books);
        }

        [AllowAnonymous]
        public ActionResult BookDetails(int id)
        {
            var book = _conext.Book.Include(c => c.publisher).SingleOrDefault(c => c.Id == id);
            return View(book);
        }
        public ActionResult New()
        {
            var publishers = _conext.publisher.ToList();
            var viewbook = new NewBookViewModel
            {
                publshiers = publishers,
                book = new Book()
            };
            ViewBag.Name = "New Book";
            return View(viewbook);
        }

        [HttpPost]
        public ActionResult Save(Book booK)
        {
            if (!ModelState.IsValid)
            {
                var bookview = new NewBookViewModel
                {
                    book = booK,
                    publshiers = _conext.publisher.ToList()
                };
                return View("New",bookview);
            }
            if(booK.Id == 0)
                _conext.Book.Add(booK);
            else 
            {
                var bookinDb = _conext.Book.SingleOrDefault(c => c.Id == booK.Id);
                bookinDb.Title = booK.Title;
                bookinDb.Author = booK.Author;
                bookinDb.Price = booK.Price;
                bookinDb.Url = booK.Url;
                bookinDb.avaliable = booK.avaliable;
                bookinDb.publisherId = booK.publisherId;
            }
            _conext.SaveChanges();
            return RedirectToAction("Index", "Books");
        }

        public ActionResult Edit(int id)
        {
            var book = _conext.Book.SingleOrDefault(c => c.Id == id);

            if (book == null)
                return HttpNotFound();

            var bookModel = new NewBookViewModel
            {
                book = book,
                publshiers = _conext.publisher.ToList()
            };
            ViewBag.Name = "Edit";
            return View("New", bookModel); 
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var book = _conext.Book.SingleOrDefault(c => c.Id == id);


           _conext.Book.Remove(book);
           _conext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}