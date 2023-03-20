using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EjemploRazorConEntityFrameworkk.Models;

namespace EjemploRazorConEntityFrameworkk.Controllers
{
    public class TotalesController : Controller
    {
        private Tienda_ElectronicaEntities db = new Tienda_ElectronicaEntities();

        // GET: Totales
        public ActionResult Index()
        {
            var totales = db.Totales.Include(t => t.Almacen);
            return View(totales.ToList());
        }

        // GET: Totales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Totales totales = db.Totales.Find(id);
            if (totales == null)
            {
                return HttpNotFound();
            }
            return View(totales);
        }

        // GET: Totales/Create
        public ActionResult Create()
        {
            ViewBag.Codigo = new SelectList(db.Almacen, "Codigo", "Nombre");
            return View();
        }

        // POST: Totales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_insercion,Codigo,Cantidad")] Totales totales)
        {
            if (ModelState.IsValid)
            {
                db.Totales.Add(totales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Codigo = new SelectList(db.Almacen, "Codigo", "Nombre", totales.Codigo);
            return View(totales);
        }

        // GET: Totales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Totales totales = db.Totales.Find(id);
            if (totales == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo = new SelectList(db.Almacen, "Codigo", "Nombre", totales.Codigo);
            return View(totales);
        }

        // POST: Totales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_insercion,Codigo,Cantidad")] Totales totales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(totales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo = new SelectList(db.Almacen, "Codigo", "Nombre", totales.Codigo);
            return View(totales);
        }

        // GET: Totales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Totales totales = db.Totales.Find(id);
            if (totales == null)
            {
                return HttpNotFound();
            }
            return View(totales);
        }

        // POST: Totales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Totales totales = db.Totales.Find(id);
            db.Totales.Remove(totales);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
