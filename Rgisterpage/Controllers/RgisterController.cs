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
    public class RgisterController : Controller
    {
        private Contex db = new Contex();
        // GET: Rgister
        public async Task<ActionResult> Index()
        {
            return View(await db.Rgister.ToListAsync());
        } 

        public ActionResult UserProfile ()
        {
            return View();
        }

        // GET: Category_model/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rgister rgister = await db.Rgister.FindAsync(id);
            if (rgister == null)
            {
                return HttpNotFound();
            }
            return View(rgister);
        }

        // POST: Category_model/Edit/5

        [HttpPost]

        public async Task<ActionResult> Edit([Bind(Include = "UserId,UserName,Email,Password,Gender")] Rgister category_model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_model).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category_model);
        }
    }
}