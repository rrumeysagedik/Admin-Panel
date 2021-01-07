using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProjesi.Models.DataContext;
using WebProjesi.Models.Model;

namespace WebProjesi.Controllers
{
    public class HakkimdaController : Controller
    {
        KisiselDBContext db = new KisiselDBContext();
        // GET: Hakkimda
        public ActionResult Index()
        {
            var h = db.Hakkimda.ToList();
            return View(h);
        }
        //http post olarak falan belirtilmediği için direk get olarak algılanıyor.
        public ActionResult Edit(int id)
        {
            var h = db.Hakkimda.Where(x => x.HakkımdaId == id).FirstOrDefault();
            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Hakkimda h)
        {
            if (ModelState.IsValid)
            {
                var hakkimda = db.Hakkimda.Where(x => x.HakkımdaId == id).SingleOrDefault();
                hakkimda.Aciklama = h.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(h);
        }
    }
}