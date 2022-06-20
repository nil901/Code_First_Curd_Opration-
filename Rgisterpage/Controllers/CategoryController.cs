using Rgisterpage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Rgisterpage.Controllers
{
    public class CategoryController : Controller
    {
        private Contex db = new Contex();
      
        public async Task<ActionResult> Index()
        {
            return View(await db.Category.ToListAsync());
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Create([Bind(Include = "CategoryId,CategoryName,status")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Category.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(category);
        }


        // GET: Category_model/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category_model = await db.Category.FindAsync(id);
            if (category_model == null)
            {
                return HttpNotFound();
            }
            return View(category_model);
        }

        // POST: Category_model/Edit/5

        [HttpPost]

        public async Task<ActionResult> Edit([Bind(Include = "CategoryId,CategoryName,status")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category);
        }


        // GET: Category_model/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category_model = await db.Category.FindAsync(id);
            if (category_model == null)
            {
                return HttpNotFound();
            }
            return View(category_model);
        }

        // POST: Category_model/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Category category_model = await db.Category.FindAsync(id);
            db.Category.Remove(category_model);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category_model = await db.Category.FindAsync(id);
            if (category_model == null)
            {
                return HttpNotFound();
            }
            return View(category_model);
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