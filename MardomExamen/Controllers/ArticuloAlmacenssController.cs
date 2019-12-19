using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MardomExamen.Models;

namespace MardomExamen.Controllers
{
    public class ArticuloAlmacenssController : Controller
    {
        private dbMardomExamenEntities db = new dbMardomExamenEntities();

        // GET: ArticuloAlmacens
        public ActionResult Index()
        {
            var articuloAlmacen = db.ArticuloAlmacen.Include(a => a.Almacenes).Include(a => a.Articulos);
            return View(articuloAlmacen.ToList());
        }

        // GET: ArticuloAlmacens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticuloAlmacen articuloAlmacen = db.ArticuloAlmacen.Find(id);
            if (articuloAlmacen == null)
            {
                return HttpNotFound();
            }
            return View(articuloAlmacen);
        }

        // GET: ArticuloAlmacens/Create
        public ActionResult Create()
        {
            ViewBag.Almacen_ID = new SelectList(db.Almacenes, "ID", "Almacen");
            ViewBag.Articulo_ID = new SelectList(db.Articulos, "ID", "Articulo");
            return View();
        }

        // POST: ArticuloAlmacens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Articulo_ID,Almacen_ID")] ArticuloAlmacen articuloAlmacen)
        {
            if (ModelState.IsValid)
            {
                db.ArticuloAlmacen.Add(articuloAlmacen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Almacen_ID = new SelectList(db.Almacenes, "ID", "Almacen", articuloAlmacen.Almacen_ID);
            ViewBag.Articulo_ID = new SelectList(db.Articulos, "ID", "Articulo", articuloAlmacen.Articulo_ID);
            return View(articuloAlmacen);
        }

        // GET: ArticuloAlmacens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticuloAlmacen articuloAlmacen = db.ArticuloAlmacen.Find(id);
            if (articuloAlmacen == null)
            {
                return HttpNotFound();
            }
            ViewBag.Almacen_ID = new SelectList(db.Almacenes, "ID", "Almacen", articuloAlmacen.Almacen_ID);
            ViewBag.Articulo_ID = new SelectList(db.Articulos, "ID", "Articulo", articuloAlmacen.Articulo_ID);
            return View(articuloAlmacen);
        }

        // POST: ArticuloAlmacens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Articulo_ID,Almacen_ID")] ArticuloAlmacen articuloAlmacen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articuloAlmacen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Almacen_ID = new SelectList(db.Almacenes, "ID", "Almacen", articuloAlmacen.Almacen_ID);
            ViewBag.Articulo_ID = new SelectList(db.Articulos, "ID", "Articulo", articuloAlmacen.Articulo_ID);
            return View(articuloAlmacen);
        }

        // GET: ArticuloAlmacens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticuloAlmacen articuloAlmacen = db.ArticuloAlmacen.Find(id);
            if (articuloAlmacen == null)
            {
                return HttpNotFound();
            }
            return View(articuloAlmacen);
        }

        // POST: ArticuloAlmacens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArticuloAlmacen articuloAlmacen = db.ArticuloAlmacen.Find(id);
            db.ArticuloAlmacen.Remove(articuloAlmacen);
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
