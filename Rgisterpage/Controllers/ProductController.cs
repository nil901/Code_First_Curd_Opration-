using Rgisterpage.Models;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Rgisterpage.Controllers
{
    public class ProductController : Controller
    {
        private Contex db = new Contex();

        public async Task<ActionResult> Index(int pg = 1)
        {

            var AllProducts = await db.Product.ToListAsync();

            const int pageSize = 2;
            var param1 = new SqlParameter();
            param1.ParameterName = "@PageNumber";
            param1.SqlDbType = SqlDbType.Int;
            param1.SqlValue = pg;

            var param2 = new SqlParameter();  
            param2.ParameterName = "@PageSize";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.SqlValue = pageSize;

            var result = await db.Product.SqlQuery("ProductCatShow").ToListAsync();



            if (pg < 1)
            {
                pg = 1;
            }

            int rescount = AllProducts.Count();
            //int rescount = result.Count();

            var pager = new Pager(rescount, pg, pageSize);
            //int recSkip = (pg - 1) * pageSize;
            //var data = AllProducts.Skip(recSkip).Take(pager.PageSize).ToList();
            var data = result;
            this.ViewBag.pager = pager;
            return View(data);
        }

        public ActionResult Create()
        {
            var Categorylist = db.Category.ToList();
            ViewBag.CategoryId = new SelectList(Categorylist, "CategoryId"," CategoryName");  
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Create([Bind(Include = "ProductId,ProductName,CategoryId")] Product product)
            
        {
            var Categorylist  = db.Category.ToList();
            ViewBag.CategoryId = new SelectList(Categorylist, "CategoryId" , " CategoryName"); 
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(product); 


        }


        public ActionResult Edit(int id)
        {
            var Edit_row = db.Product.Where(Model => Model.ProductId == id).FirstOrDefault();
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName");

            return View(Edit_row);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Product p)
        {
            db.Entry(p).State = EntityState.Modified;
            int a = await db.SaveChangesAsync();
            if (a > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var Delete_row = db.Product.Where(Model => Model.ProductId == id).FirstOrDefault();
            return View(Delete_row);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Product p, int id)
        {
            var Delete_row = db.Product.Where(Model => Model.ProductId == id).FirstOrDefault();
            db.Product.Remove(Delete_row);
            int a = await db.SaveChangesAsync();
            if (a > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}