using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PX.Models;

namespace PX.Controllers
{
    public class ConductorapiController : ApiController
    {
        private ParqueoDBEntities1 db = new ParqueoDBEntities1();

        // GET: api/Conductorapi
        public IQueryable<Conductor> GetConductor()
        {
            return db.Conductor;
        }

        // GET: api/Conductorapi/5
        [ResponseType(typeof(Conductor))]
        public IHttpActionResult GetConductor(int id)
        {
            Conductor conductor = db.Conductor.Find(id);
            if (conductor == null)
            {
                return NotFound();
            }

            return Ok(conductor);
        }

        // PUT: api/Conductorapi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConductor(int id, Conductor conductor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conductor.Id)
            {
                return BadRequest();
            }

            db.Entry(conductor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConductorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Conductorapi
        [ResponseType(typeof(Conductor))]
        public IHttpActionResult PostConductor(Conductor conductor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Conductor.Add(conductor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = conductor.Id }, conductor);
        }

        // DELETE: api/Conductorapi/5
        [ResponseType(typeof(Conductor))]
        public IHttpActionResult DeleteConductor(int id)
        {
            Conductor conductor = db.Conductor.Find(id);
            if (conductor == null)
            {
                return NotFound();
            }

            db.Conductor.Remove(conductor);
            db.SaveChanges();

            return Ok(conductor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConductorExists(int id)
        {
            return db.Conductor.Count(e => e.Id == id) > 0;
        }
    }
}