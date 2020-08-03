using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using book_manager.DataAccess;
using book_manager.Models;

namespace book_manager.Controllers
{
    public class BooksController : Controller
    {
        private BookContext db = new BookContext();

        // GET: Books/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Books/List -> JSON with all books
        public JsonResult List(Book book, int current = 1, int rowCount = 5)
        {
            string sortKey = Request.Form.AllKeys.Where(k => k.StartsWith("sort")).First();
            string ordination = Request[sortKey];
            string selectedField = sortKey.Replace("sort[", string.Empty).Replace("]", string.Empty);

            var books = db.Books.Include(b => b.Gender);
            var total = books.Count();

            if (!string.IsNullOrWhiteSpace(book.Title))
                books = books.Where(b => b.Title.Contains(book.Title));

            if (!string.IsNullOrWhiteSpace(book.Author))
                books = books.Where(b => b.Author.Contains(book.Author));

            if (book.YearEdition != 0)
                books = books.Where(b => b.YearEdition == book.YearEdition);

            if (book.Value != decimal.Zero)
                books = books.Where(b => b.Value == book.Value);

            string fieldAndOrdination = String.Format("{0} {1}", selectedField, ordination);

            var paginatedBooks = books.OrderBy(fieldAndOrdination).Skip((current - 1) * rowCount).Take(rowCount);

            return Json( new { rows = paginatedBooks.ToList(),
                current, rowCount, total }, 
                JsonRequestBehavior.AllowGet);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Author,YearEdition,Value,GenderId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", book.GenderId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", book.GenderId);
            return View(book);
        }

        // POST: Books/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Author,YearEdition,Value,GenderId")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", book.GenderId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
