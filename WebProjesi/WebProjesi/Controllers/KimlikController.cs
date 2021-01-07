using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebProjesi.Models.DataContext;
using WebProjesi.Models.Model;

namespace WebProjesi.Controllers
{
    public class KimlikController : Controller
    {
        KisiselDBContext db = new KisiselDBContext(); // database'in örneği alındı.

        //get
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Kimlik kimlik)
        {
            if (ModelState.IsValid)
            {
                db.Kimlik.Add(kimlik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kimlik);

        }


        // GET: Kimlik
        public ActionResult Index()
        {
            return View(db.Kimlik.ToList()); //kimliğin listesini index viewına gönderelim.
        }
        // GET: Kimlik/Edit/5
        public ActionResult Edit(int id)
        {
            var kimlik = db.Kimlik.Where(x => x.KimlikId == id).SingleOrDefault(); // bizdeki kimlik id ile dışarıdan gelen kimlikıd eşit mi? bize geliyor mu geliyorsa nereden geliyor.
            return View(kimlik);
        }

        // POST: Kimlik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id,Kimlik kimlik,HttpPostedFileBase LogoURL)
        {
            if (ModelState.IsValid)
            {
                var k = db.Kimlik.Where(x => x.KimlikId == id).SingleOrDefault();
                if (LogoURL!=null)
                {
                    if (System.IO.File.Exists(Server.MapPath(k.LogoURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(k.LogoURL));
                    }
                    WebImage img = new WebImage(LogoURL.InputStream);
                    FileInfo imginfo = new FileInfo(LogoURL.FileName);
                    string logoname = LogoURL.FileName+ imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Kimlik/" + logoname);
                    k.LogoURL = "/Uploads/Kimlik/" + logoname;
                }
                k.Title = kimlik.Title;
                k.KeyWords = kimlik.KeyWords;
                k.Description = kimlik.Description;
                k.Unvan = kimlik.Unvan;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kimlik);
        }
    }
}
