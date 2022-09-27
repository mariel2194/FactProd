using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FactProd.Models;

namespace FactProd.Controllers
{
    public class ProdSchemasController : Controller
    {
        private FacturacionProdDbContext db = new FacturacionProdDbContext();

        // GET: ProdSchemas
        public ActionResult Index()
        {
            return View(db.Productos.ToList());
        }

        // GET: ProdSchemas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdSchema prodSchema = db.Productos.Find(id);
            if (prodSchema == null)
            {
                return HttpNotFound();
            }
            return View(prodSchema);
        }

        // GET: ProdSchemas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdSchemas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Descripcion,Activo,Cantidad,Precio,fecha")] ProdSchema prodSchema)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(prodSchema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prodSchema);
        }

        // GET: ProdSchemas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdSchema prodSchema = db.Productos.Find(id);
            if (prodSchema == null)
            {
                return HttpNotFound();
            }
            return View(prodSchema);
        }

        // POST: ProdSchemas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Descripcion,Activo,Cantidad,Precio,fecha")] ProdSchema prodSchema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodSchema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prodSchema);
        }

        // GET: ProdSchemas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdSchema prodSchema = db.Productos.Find(id);
            if (prodSchema == null)
            {
                return HttpNotFound();
            }
            return View(prodSchema);
        }

        // POST: ProdSchemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdSchema prodSchema = db.Productos.Find(id);
            db.Productos.Remove(prodSchema);
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
