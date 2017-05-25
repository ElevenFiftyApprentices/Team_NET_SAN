using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shopping_List.Models;
using Shopping_List.Data;

namespace Shopping_List.Controllers
{
    public class ShoppingListController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShoppingList
        public ActionResult Index()
        {
            return View(db.ShoppingLists.ToList());
        }

        // GET: ShoppingList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingList shoppingList = db.ShoppingLists.Find(id);
            if (shoppingList == null)
            {
                return HttpNotFound();
            }
            return View(shoppingList);
        }

        //GET: ViewItem/View
        public ActionResult ViewItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Id = id;
            ViewBag.ListTitle = db.ShoppingLists.Find(id).Name;
            ViewBag.ShoppingListColor = db.ShoppingLists.Find(id).Color;
            return View(db.ShoppingListItems.Where(s => s.Id == id));

        }

        //POST: UpdateCheckBox
        [HttpPost]
        //[ValidateAntiForgeryToken]  //referencing id in order to update IsChecked,creating a new instance of class and calling it "shoppingListItem"
        public ActionResult UpdateCheckbox([Bind(Include = "Id, IsChecked")] ShoppingListItem shoppingListItem)
        {   //pulling data from db and holding it in memory
            var item = db.ShoppingListItems.Find(shoppingListItem.Id);
            //referencing IsChecked on item and converting it to IsChecked on shoppingListItem
            item.IsChecked = shoppingListItem.IsChecked;
            //Save changes
            db.SaveChanges();
            return Json("success");
        }

        //GET: ShoppingListItem/Create
        public ActionResult CreateItem(int id)
        {
            ViewBag.Id = id;
            ViewBag.ListTitle = db.ShoppingLists.Find(id).Name;
            return View();
        }

        //POST: ShoppingListItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateItem(
            [Bind(Include = "Id,ShoppingListId,Contents,Priority,Note")] ShoppingListItem shoppingListItem, int id)
        {
            if (ModelState.IsValid)
            {
                shoppingListItem.Id = id;
                db.ShoppingListItems.Add(shoppingListItem);
                db.SaveChanges();
                return RedirectToAction("ViewItem", new {id});
            }

            return View();
        }

        // GET: ShoppingList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Name,Color,CreatedUtc,ModifiedUtc")] ShoppingList shoppingList)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingLists.Add(shoppingList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingList);
        }

        // GET: ShoppingList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingList shoppingList = db.ShoppingLists.Find(id);
            if (shoppingList == null)
            {
                return HttpNotFound();
            }
            return View(shoppingList);
        }

        // POST: ShoppingList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Name,Color,CreatedUtc,ModifiedUtc")] ShoppingList shoppingList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingList);
        }

        // GET: ShoppingList/Delete/5
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
            ShoppingList shoppingList = db.ShoppingLists.Find(id);
            if (shoppingList == null)
            {
                return HttpNotFound();
            }
            return View(shoppingList);
        }

        // POST: ShoppingList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingList shoppingList = db.ShoppingLists.Find(id);
            db.ShoppingLists.Remove(shoppingList);
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
