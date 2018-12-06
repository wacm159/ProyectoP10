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
    public class ConductormvcController : Controller
    {
        private ParqueoDBEntities1 db = new ParqueoDBEntities1();

        // GET: Conductormvc
        public ActionResult Index()
        {
            return View(db.Conductor.ToList());

        }

        // GET: Conductormvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductor conductor = db.Conductor.Find(id);
            if (conductor == null)
            {
                return HttpNotFound();
            }
            return View(conductor);
        }

        // GET: Conductormvc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conductormvc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo_Licencia,Dpi,Nombre,Telefono,Edad")] Conductor conductor)
        {
            if (ModelState.IsValid)
            {
                db.Conductor.Add(conductor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conductor);
        }

        // GET: Conductormvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductor conductor = db.Conductor.Find(id);
            if (conductor == null)
            {
                return HttpNotFound();
            }
            return View(conductor);
        }

        // POST: Conductormvc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo_Licencia,Dpi,Nombre,Telefono,Edad")] Conductor conductor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conductor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conductor);
        }

        // GET: Conductormvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductor conductor = db.Conductor.Find(id);
            if (conductor == null)
            {
                return HttpNotFound();
            }
            return View(conductor);
        }

        // POST: Conductormvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Conductor conductor = db.Conductor.Find(id);
            db.Conductor.Remove(conductor);
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
