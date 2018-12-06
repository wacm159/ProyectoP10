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
    public class Vehiculo_parqueomvcController : Controller
    {
        private ParqueoDBEntities1 db = new ParqueoDBEntities1();

        // GET: Vehiculo_parqueomvc
        public ActionResult Index()
        {
            var vehiculo_parqueo = db.Vehiculo_parqueo.Include(v => v.Vehiculo1);
            return View(vehiculo_parqueo.ToList());
        }

        // GET: Vehiculo_parqueomvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo_parqueo vehiculo_parqueo = db.Vehiculo_parqueo.Find(id);
            if (vehiculo_parqueo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo_parqueo);
        }

        // GET: Vehiculo_parqueomvc/Create
        public ActionResult Create()
        {
            ViewBag.Vehiculo = new SelectList(db.Vehiculo, "Id", "Matricula");
            return View();
        }

        // POST: Vehiculo_parqueomvc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Vehiculo")] Vehiculo_parqueo vehiculo_parqueo)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculo_parqueo.Add(vehiculo_parqueo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Vehiculo = new SelectList(db.Vehiculo, "Id", "Matricula", vehiculo_parqueo.Vehiculo);
            return View(vehiculo_parqueo);
        }

        // GET: Vehiculo_parqueomvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo_parqueo vehiculo_parqueo = db.Vehiculo_parqueo.Find(id);
            if (vehiculo_parqueo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vehiculo = new SelectList(db.Vehiculo, "Id", "Matricula", vehiculo_parqueo.Vehiculo);
            return View(vehiculo_parqueo);
        }

        // POST: Vehiculo_parqueomvc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Vehiculo")] Vehiculo_parqueo vehiculo_parqueo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo_parqueo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vehiculo = new SelectList(db.Vehiculo, "Id", "Matricula", vehiculo_parqueo.Vehiculo);
            return View(vehiculo_parqueo);
        }

        // GET: Vehiculo_parqueomvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo_parqueo vehiculo_parqueo = db.Vehiculo_parqueo.Find(id);
            if (vehiculo_parqueo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo_parqueo);
        }

        // POST: Vehiculo_parqueomvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehiculo_parqueo vehiculo_parqueo = db.Vehiculo_parqueo.Find(id);
            db.Vehiculo_parqueo.Remove(vehiculo_parqueo);
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
