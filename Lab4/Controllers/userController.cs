using Lab4.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class userController : Controller
    {
        // GET: user
        Librarycontext db = new Librarycontext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(users s)
        {
           
            db.Users.Add(s);
            db.SaveChanges();
            Session.Add("userid", s.id);
            return RedirectToAction("welcome");
        }

        public ActionResult welcome()
        {
            int id = int.Parse(Session["userid"].ToString());
            users s = db.Users.Where(n => n.id == id).FirstOrDefault();
            return View(s);
        }

        public ActionResult login()
        {
            if(Request.Cookies["fullstack"] != null)
            {
                Session["userid"] = Request.Cookies["fullstack"].Values["id"].ToString();
                return RedirectToAction("welcome");
            }
            else
            {
                return View();
            }

           
        }
        [HttpPost]
        public ActionResult login(users s , string remeberme)
        {
            users us = db.Users.Where(n => n.email == s.email &&  n.password == s.password).SingleOrDefault();

            //login
            if(us != null)
            {
                Session.Add("userid", us.id);
                if(remeberme == "true") {

                    HttpCookie co = new HttpCookie("fullstack");
                    co.Values.Add("id",us.id.ToString());
                    co.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(co);
                }
            
                return RedirectToAction("welcome");
            }
            else //  Not login
            {
                ViewBag.status = "invalid username or password";
                return View();
            }

        }
        public ActionResult logout()
        {
           
            Session["userid"] = null;
            Response.Cookies["fullstack"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Index", "Home");
        }
    }
}