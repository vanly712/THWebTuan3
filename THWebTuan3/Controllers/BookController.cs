using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THWebTuan3.Models;

namespace THWebTuan3.Controllers
{
    public class BookController : Controller
    {
        BookManagerContext context = new BookManagerContext();
        // GET: Book
        [Authorize]
        public ActionResult ListBook()
        {
            List<Book> listBook = context.Books.ToList();
            return View(listBook);
        }

        [Authorize]
        public ActionResult Buy(int id)
        {
            Book book = context.Books.SingleOrDefault(b => b.ID == id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="ID, Title, Description, Author, Image, Price")]Book book) {
            if (ModelState.IsValid)
            {
                context.Books.AddOrUpdate(book);
                context.SaveChanges();
            }
            
            return RedirectToAction("ListBook");
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            Book book = context.Books.Find(id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        [Authorize]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Title, Description,Author, Images, Price")] Book book) {
            context.Books.AddOrUpdate(book);
            context.SaveChanges();
            return RedirectToAction("ListBook");
        }

        public ActionResult Delete(int? id) {
            Book book = context.Books.Find(id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Book book = context.Books.Find(id);
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("ListBook");
        }
    }
}