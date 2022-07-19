using Rgisterpage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rgisterpage.Controllers
{ 

    public class LoginController : Controller
    {
        Contex db = new Contex(); 
        // GET: Login
        public ActionResult Index()
        {
            return View(db.Login.ToList() );
        } 
         
        public  ActionResult SignUp()
        {  

            return View();
        } 

        [HttpPost]
        public ActionResult SignUp(Login login)
        { 


                if (db.Login.Any(x => x.UserName == login.UserName))
                {

                    ViewBag.Notigication = "This account has been exit";
                    return View();

                }
                else
                {
                    db.Login.Add(login);
                    db.SaveChanges();
                    Session["IdU"] = login.Id.ToString();
                    Session["Username"] = login.UserName.ToString();
                    return RedirectToAction("Login", "Login");

                }

            
           

        }
        public ActionResult LogOut()
        {

            Session["Username"] = null;
            
           // Session.Abandon();
          // Session.RemoveAll(); 
             Session.Clear(); 
          
            return RedirectToAction("Login", "Login");               
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        } 

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            var checkLogin = db.Login.Where(x => x.UserName.Equals(login.UserName)&& x.Passworld.Equals(login.Passworld)).FirstOrDefault();
            if (checkLogin != null)
            {


                Session["Id"] = login.Id.ToString();
                Session["UserName"] = login.UserName.ToString();
                Session["Passworld"] = login.Passworld.ToString();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Notification = "wrong username and passworld";
               
            }
            return View();
        } 
    }
}