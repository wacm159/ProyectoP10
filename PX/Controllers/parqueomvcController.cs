using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PX.Models;

namespace PX.Controllers
{
    public class parqueomvcController : Controller
    {
        private ParqueoDBEntities1 db = new ParqueoDBEntities1();

        // GET: parqueomvc
        public ActionResult Index()
        {
            var parqueo = db.parqueo.Include(p => p.Vehiculo_parqueo).Include(p => p.Ubicacion1);
            return View(parqueo.ToList());
        }

        // GET: parqueomvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parqueo parqueo = db.parqueo.Find(id);
            if (parqueo == null)
            {
                return HttpNotFound();
            }
            return View(parqueo);
        }

        // GET: parqueomvc/Create
        public ActionResult Create()
        {
            ViewBag.Parqueo_Vehiculo = new SelectList(db.Vehiculo_parqueo, "Id", "Id");
            ViewBag.Ubicacion = new SelectList(db.Ubicacion, "Id", "Nombre");
            return View();
        }

        // POST: parqueomvc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Ubicacion,Precio,Capacidad,Estado,Parqueo_Vehiculo")] parqueo parqueo)
        {
            if (ModelState.IsValid)
            {
                db.parqueo.Add(parqueo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Parqueo_Vehiculo = new SelectList(db.Vehiculo_parqueo, "Id", "Id", parqueo.Parqueo_Vehiculo);
            ViewBag.Ubicacion = new SelectList(db.Ubicacion, "Id", "Nombre", parqueo.Ubicacion);
            return View(parqueo);
        }

        // GET: parqueomvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parqueo parqueo = db.parqueo.Find(id);
            if (parqueo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Parqueo_Vehiculo = new SelectList(db.Vehiculo_parqueo, "Id", "Id", parqueo.Parqueo_Vehiculo);
            ViewBag.Ubicacion = new SelectList(db.Ubicacion, "Id", "Nombre", parqueo.Ubicacion);
            return View(parqueo);
        }

        // POST: parqueomvc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Ubicacion,Precio,Capacidad,Estado,Parqueo_Vehiculo")] parqueo parqueo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parqueo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Parqueo_Vehiculo = new SelectList(db.Vehiculo_parqueo, "Id", "Id", parqueo.Parqueo_Vehiculo);
            ViewBag.Ubicacion = new SelectList(db.Ubicacion, "Id", "Nombre", parqueo.Ubicacion);
            return View(parqueo);
        }

        // GET: parqueomvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parqueo parqueo = db.parqueo.Find(id);
            if (parqueo == null)
            {
                return HttpNotFound();
            }
            return View(parqueo);
        }

        // POST: parqueomvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            parqueo parqueo = db.parqueo.Find(id);
            db.parqueo.Remove(parqueo);
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
