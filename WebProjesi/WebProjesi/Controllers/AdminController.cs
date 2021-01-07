using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProjesi.Models.DataContext;
using WebProjesi.Models.Model;

namespace WebProjesi.Controllers
{
    public class AdminController : Controller
    {
        KisiselDBContext db = new KisiselDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            var sorgu = db.Kategori.ToList();
            return View(sorgu);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var login = db.Admin.Where(x => x.EPosta == admin.EPosta).SingleOrDefault();
            if (login != null)
            {
                if (login.EPosta == admin.EPosta && login.Sifre == admin.Sifre)
                {
                    Session["adminid"] = login.AdminId;
                    Session["eposta"] = login.EPosta;
                    return RedirectToAction("Index", "Admin");
                }
            }
            else
            {
                ViewBag.Uyari = "Kullanıcı Adı yada şifrenizi yanlış girdiniz.";
            }
            return View(admin);
        }
        public ActionResult Logout()
        {
            Session["adminid"] = null;
            Session["eposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }
    }
}