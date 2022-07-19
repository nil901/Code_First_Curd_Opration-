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

        public async Task<ActionResult> Index(int? page, bool a=true)
        {

             var AllProducts = await db.Product.Include(c => c.Category_model).Where(x => x.Category_model.ActiveOrNot.Equals(a)).ToListAsync();


 
           // var result = await db.Product.SqlQuery("ProductCatShow").ToListAsync(); 

            return View(AllProducts);
        } 
        [HttpGet]
        public async Task<ActionResult>Index(string proSearch)
        {
            ViewData["GetProductDetails"] = proSearch;

            var Product = from x in db.Product select x; 
            if(!string.IsNullOrEmpty(proSearch))  {
                Product = Product.Where(x=> x.ProductName.Contains(proSearch));
              
            }
            return View(await Product.AsNoTracking().ToListAsync());


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