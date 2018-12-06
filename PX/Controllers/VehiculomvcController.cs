using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PX.Models;

namespace PX.Controllers
{
    public class VehiculomvcController : Controller
    {
        private ParqueoDBEntities1 db = new ParqueoDBEntities1();

        // GET: Vehiculomvc
        public ActionResult Index()
        {
        //    var vehiculo = db.Vehiculo.Include(v => v.Categoria1).Include(v => v.Conductor1);
        //    return View(vehiculo.ToList());

            IEnumerable<Vehiculo> vehiculos = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:55674/api/");
                //GET GETAlumnos
                //el siguente codigo obtiene la informacion de manera asincrona y espera hata obtener la data
                var reponseTask = client.GetAsync("vehiculoapi");
                reponseTask.Wait();
                var result = reponseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    // leer todo el cotenido y lo parseamos a una lista de alumno
                    var leer = result.Content.ReadAsAsync<IList<Vehiculo>>();
                    leer.Wait();
                    vehiculos = leer.Result;
                }
                else
                {
                    vehiculos = Enumerable.Empty<Vehiculo>();
                    ModelState.AddModelError(string.Empty, "Error...");
                }

            }
            return View(vehiculos.ToList());
        }

        // GET: Vehiculomvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: Vehiculomvc/Create
        public ActionResult Create()
        {
            ViewBag.Categoria = new SelectList(db.Categoria, "Id", "Descripcion");
            ViewBag.Conductor = new SelectList(db.Conductor, "Id", "Tipo_Licencia");
            return View();
        }

        // POST: Vehiculomvc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Matricula,Color,Linea,Categoria,Conductor")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculo.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categoria = new SelectList(db.Categoria, "Id", "Descripcion", vehiculo.Categoria);
            ViewBag.Conductor = new SelectList(db.Conductor, "Id", "Tipo_Licencia", vehiculo.Conductor);
            return View(vehiculo);
        }

        // GET: Vehiculomvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoria = new SelectList(db.Categoria, "Id", "Descripcion", vehiculo.Categoria);
            ViewBag.Conductor = new SelectList(db.Conductor, "Id", "Tipo_Licencia", vehiculo.Conductor);
            return View(vehiculo);
        }

        // POST: Vehiculomvc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Matricula,Color,Linea,Categoria,Conductor")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categoria = new SelectList(db.Categoria, "Id", "Descripcion", vehiculo.Categoria);
            ViewBag.Conductor = new SelectList(db.Conductor, "Id", "Tipo_Licencia", vehiculo.Conductor);
            return View(vehiculo);
        }

        // GET: Vehiculomvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculomvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehiculo vehiculo = db.Vehiculo.Find(id);
            db.Vehiculo.Remove(vehiculo);
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
