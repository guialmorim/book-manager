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
using book_manager.Infra;
using book_manager.Models;
using book_manager.ViewModels;

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
        public JsonResult List(PaginationParameters paginationParameters)
        {
            var books = db.Books.AsQueryable();
            var total = books.Count();

            if (!string.IsNullOrWhiteSpace(paginationParameters.SearchPhrase))
            {
                int year = 0;
                int.TryParse(paginationParameters.SearchPhrase, out year);

                decimal value = 0;
                decimal.TryParse(paginationParameters.SearchPhrase, out value);

                books = books.Where("Title.Contains(@0) OR Author.Contains(@0) OR YearEdition == @1 OR Value == @2", paginationParameters.SearchPhrase, year, value);
            }

            var paginatedBooks = books.OrderBy(paginationParameters.OrderedField).Skip((paginationParameters.Current - 1) * paginationParameters.RowCount).Take(paginationParameters.RowCount);

            return Json(new FilteredData()
            {
                current = paginationParameters.Current,
                rowCount = paginationParameters.RowCount,
                rows = paginatedBooks,
                total = total

            }, JsonRequestBehavior.AllowGet);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Book book = db.Books.Find(id);

            if (book == null)
                return HttpNotFound();
            
            return PartialView(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name");
            return PartialView();
        }

        // POST: Books/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Id,Title,Author,YearEdition,Value,GenderId")] Book book)
        {
            object response = null;

            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                response = new { result = true, message = "Book registered successfully!" };
            }
            else
            {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(item => item.Errors);
                response = new { result = false, message = errors };
            }

            return Json(response);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Book book = db.Books.Find(id);

            if (book == null)
                return HttpNotFound();
            
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Name", book.GenderId);
            return PartialView(book);
        }

        // POST: Books/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit([Bind(Include = "Id,Title,Author,YearEdition,Value,GenderId")] Book book)
        {
            object response = null;

            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                response = new { result = true, message = "Book edited successfully!" };
            }
            else
            {
                IEnumerable<ModelError> errors = ModelState.Values.SelectMany(item => item.Errors);
                response = new { result = false, message = errors };
            }

            return Json(response);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            Book book = db.Books.Find(id);

            if (book == null)
                return HttpNotFound();
            
            return PartialView(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            object response = null;

            try
            {
                Book book = db.Books.Find(id);
                db.Books.Remove(book);
                db.SaveChanges();
                response = new { result = true, message = "Book removed successfully!" };
            }
            catch(Exception ex)
            {
                response = new { result = false, message = ex.Message };
            }

            return Json(response);
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
