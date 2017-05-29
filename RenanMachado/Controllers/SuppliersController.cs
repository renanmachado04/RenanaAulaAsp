using RenanMachado.Contexts;
using RenanMachado.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RenanMachado.Controllers
{
    public class SuppliersController : Controller
    {
        private EFContext context = new EFContext();
        //	GET:	Suppliers
        public ActionResult Index()
        {
            return View(context.Suppliers.OrderBy(
                            c => c.Name));
        }

        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier suppliers)
        {
            context.Suppliers.Add(suppliers);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //	GET:	Supplier/Edit
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new  HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = context.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        //	POST:	Supplier/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                context.Entry(supplier).State =  EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        //	GET:	Supplier/Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = context.Suppliers.
                            Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        //	GET:	Supplier/Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Supplier supplier = context.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        //	POST:	Fabricantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Supplier supplier = context.Suppliers.
                            Find(id);
            context.Suppliers.Remove(supplier);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}