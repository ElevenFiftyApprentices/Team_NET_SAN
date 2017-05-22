using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingList.Models;
using ShoppingList.Data;

namespace ShoppingList.Controllers
{
    public class ListItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ListItem
        public ActionResult Index()
        {
            return View(db.ListItems.ToList());
        }

        // GET: ListItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListItem listItem = db.ListItems.Find(id);
            if (listItem == null)
            {
                return HttpNotFound();
            }
            return View(listItem);
        }

        // GET: ListItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShoppingListId,Contents,IsChecked,CreatedUtc,ModifiedUtc")] ListItem listItem)
        {
            if (ModelState.IsValid)
            {
                db.ListItems.Add(listItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listItem);
        }

        // GET: ListItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListItem listItem = db.ListItems.Find(id);
            if (listItem == null)
            {
                return HttpNotFound();
            }
            return View(listItem);
        }

        // POST: ListItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShoppingListId,Contents,IsChecked,CreatedUtc,ModifiedUtc")] ListItem listItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listItem);
        }

        // GET: ListItem/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed.";
            }
            ListItem item = db.ListItems.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: ShoppingListItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListItem item = db.ListItems.Find(id);
            db.ListItems.Remove(item);
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
