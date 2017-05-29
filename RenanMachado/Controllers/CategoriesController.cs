using RenanMachado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RenanMachado.Controllers
{
    public class CategoriesController : Controller
    {
        private static IList<Category> categories = new List<Category>()
        {
            new Category(){ CategoryID = 1, Name = "Notebooks" },
            new Category(){ CategoryID = 2, Name = "Monitores" },
            new Category(){ CategoryID = 3, Name = "Impressoras" },
            new Category(){ CategoryID = 4, Name = "Mouses" },
            new Category(){ CategoryID = 5, Name = "Desktops" }
        };
        //	GET: Categories
        public ActionResult Index()
        {
            return View(categories);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            categories.Add(category);
            category.CategoryID =
                            categories.Select(m => m.CategoryID).Max() + 1;
            return RedirectToAction("Index");
        }

        // GET: Categories/Edit
        public ActionResult Edit(long id)
        {
            return View(categories.Where(
                            m => m.CategoryID == id).First());
        }

        // POST: Categories/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            categories.Remove(categories.Where(
                            c => c.CategoryID == category.CategoryID)
                            .First());
            categories.Add(category);
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            return View(categories.Where(
                            m => m.CategoryID == id).First());
        }

        // GET: Categories/Delete
        public ActionResult Delete(long id)
        {
            return View(categories.Where(
                            c => c.CategoryID == id).First());
        }

        //  Categories/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Category category)
        {
            categories.Remove(categories.Where(
                            m => m.CategoryID == category.CategoryID)
                            .First());
            return RedirectToAction("Index");
        }



    }
}
