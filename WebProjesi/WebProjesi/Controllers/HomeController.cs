using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProjesi.Models.DataContext;

namespace WebProjesi.Controllers
{
    public class HomeController : Controller
    {
        private KisiselDBContext db = new KisiselDBContext();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Hakkimda = db.Hakkimda.ToList();
        
            return View();
        }
        public ActionResult SliderPartial()
        {
            return View(db.Slider.ToList().OrderByDescending(x=>x.SliderId));
        }
        public ActionResult HizmetPartial()
        {
            return View(db.Hizmet.ToList().OrderByDescending(x=>x.HizmetId));
        }
    }
}