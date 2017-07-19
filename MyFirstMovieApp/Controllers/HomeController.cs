using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MyFirstMovieApp.Models;
using System.Data.Entity.Migrations;

namespace MyFirstMovieApp.Controllers
{
    public class HomeController : Controller
    {
        private ilonaMoviesEntities _db = new ilonaMoviesEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(_db.Movies1.ToList());
        }

        // GET: Home/About
        public ActionResult About()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var movieToView = (from m in _db.Movies1
                               where m.Id == id
                               select m).First();
            return View(movieToView);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude ="Id")] Movie movieToCreate)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View();
                }
                _db.Movies1.Add(movieToCreate);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var movieToEdit = (from m in _db.Movies1
                               where m.Id == id
                               select m).First();
            return View(movieToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie movieToEdit)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(movieToEdit);
                }
                _db.Entry(movieToEdit).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
