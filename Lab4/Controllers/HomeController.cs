using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4.Models;
namespace Lab4.Controllers
{
    public class HomeController : Controller
    {

        Librarycontext db = new Librarycontext();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["userid"] != null)
            {
                return RedirectToAction("welcome", "user");
            }
            else
            {
                return View();
            }
        }

        public ActionResult CreateBook()//
        {
            int userid = int.Parse(Session["userid"].ToString());
            return View(db.Books.Where(n => n.user_id == userid).ToList());

        }

        public ActionResult Add()
        {

            List<catalog> catalog = db.Catalogs.ToList();
            SelectList cat = new SelectList(catalog, "id", "name");
            List<Author> athur = db.Authors.ToList();
            SelectList ath = new SelectList(athur, "id", "name");
            ViewBag.catalogs = cat;
            ViewBag.authors = ath;
            return View();
        }
        [HttpPost]
        public ActionResult Add(books b , HttpPostedFileBase pdf)
        {


            // upload file to server
            pdf.SaveAs(Server.MapPath($"~/attach/{pdf.FileName}"));
            // save path with obj saved in DB
            b.Pdf = pdf.FileName;
            b.user_id = int.Parse(Session["userid"].ToString());
            db.Books.Add(b);
            db.SaveChanges();
            return RedirectToAction("CreateBook");
           
        }

        public ActionResult download(int id)
        {
            string pdf = db.Books.Where(n => n.id == id).FirstOrDefault().Pdf;

            return File($"~/attach/{pdf}" , "application/pdf");
        }

        public ActionResult delete(int id)
        {
            books b = db.Books.Where(n => n.id == id).SingleOrDefault();
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("CreateBook");
        }

        public ActionResult edite(int id)
        {
            books b = db.Books.Where(n => n.id == id).SingleOrDefault();
            ViewBag.catalogs = new SelectList(db.Catalogs.ToList(),"id" , "name",b.catalog_id);
            ViewBag.authors = new SelectList(db.Catalogs.ToList(), "id", "name", b.author_id); ;
            return View(b);
        }
        [HttpPost]
        public ActionResult edite(books b, HttpPostedFileBase pdf)
        {
            books boo = db.Books.Where(n => n.id == b.id).SingleOrDefault();

            // upload file to server
            pdf.SaveAs(Server.MapPath($"~/attach/{pdf.FileName}"));
            // save path with obj saved in DB
            boo.Pdf = pdf.FileName;
            boo.name = b.name;
            boo.Desc = b.Desc;
            boo.brief = b.brief;

            boo.user_id = int.Parse(Session["userid"].ToString());

            db.SaveChanges();
            return RedirectToAction("CreateBook");
        }
    }
}