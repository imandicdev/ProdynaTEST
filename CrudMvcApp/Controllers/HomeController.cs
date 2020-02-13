using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrudMvcApp.Models;

namespace CrudMvcApp.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext db = new MyDbContext();
        public IActionResult Index()
        {
            var list = db.Vesti.ToList();
            return View(db.Vesti.ToList());
        }

        public ActionResult Create( )
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateVest(Vest vest)
        {
            vest.CratedDate = DateTime.Now;
            db.Vesti.Add(vest);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Vest vest = db.Vesti.Where(s => s.Id == id).First();
                db.Vesti.Remove(vest);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch (System.Exception)
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

        }

        public ActionResult Update(int id)
        {
            return View(db.Vesti.Where(s => s.Id == id).First());
        }

        [HttpPost]
        public ActionResult UpdateVest(Vest vest)
        {
            var d = db.Vesti.Where(s => s.Id == vest.Id).First();
            d.Name = vest.Name;
            d.Description = vest.Description;
            d.Author = vest.Author;
            d.Category = vest.Category;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
