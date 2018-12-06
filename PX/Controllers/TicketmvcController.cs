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
    public class TicketmvcController : Controller
    {
        private ParqueoDBEntities1 db = new ParqueoDBEntities1();

        // GET: Ticketmvc
        public ActionResult Index()
        {
            var ticket = db.Ticket.Include(t => t.parqueo1);
            return View(ticket.ToList());

        }

        // GET: Ticketmvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Ticketmvc/Create
        public ActionResult Create()
        {
            ViewBag.Parqueo = new SelectList(db.parqueo, "Id", "Nombre");
            return View();
        }

        // POST: Ticketmvc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Parqueo,Fecha,Total")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Ticket.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Parqueo = new SelectList(db.parqueo, "Id", "Nombre", ticket.Parqueo);
            return View(ticket);
        }

        // GET: Ticketmvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.Parqueo = new SelectList(db.parqueo, "Id", "Nombre", ticket.Parqueo);
            return View(ticket);
        }

        // POST: Ticketmvc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Parqueo,Fecha,Total")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Parqueo = new SelectList(db.parqueo, "Id", "Nombre", ticket.Parqueo);
            return View(ticket);
        }

        // GET: Ticketmvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Ticketmvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Ticket.Find(id);
            db.Ticket.Remove(ticket);
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
