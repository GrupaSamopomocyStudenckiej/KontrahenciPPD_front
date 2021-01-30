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
using API.Models;

namespace API.Controllers
{
    public class FirmyController : ApiController
    {
        private readonly KontrahenciEntities db = new KontrahenciEntities();

        // GET: api/Firmy
        public IQueryable<Firmy> GetFirmy()
        {
            return db.Firmy;
        }

        // GET: api/Firmy/5
        [ResponseType(typeof(Firmy))]
        public IHttpActionResult GetFirmy(int id)
        {
            Firmy firmy = db.Firmy.Find(id);
            if (firmy == null)
            {
                return NotFound();
            }

            return Ok(firmy);
        }

        // PUT: api/Firmy/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFirmy(int id, Firmy firmy)
        {
            if (id != firmy.IdFirmy)
            {
                return BadRequest();
            }

            db.Entry(firmy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirmyExists(id))
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

        // POST: api/Firmy
        [ResponseType(typeof(Firmy))]
        public IHttpActionResult PostFirmy(Firmy firmy)
        {
            db.Firmy.Add(firmy);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = firmy.IdFirmy }, firmy);
        }

        // DELETE: api/Firmy/5
        [ResponseType(typeof(Firmy))]
        public IHttpActionResult DeleteFirmy(int id)
        {
            Firmy firmy = db.Firmy.Find(id);
            if (firmy == null)
            {
                return NotFound();
            }

            db.Firmy.Remove(firmy);
            db.SaveChanges();

            return Ok(firmy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FirmyExists(int id)
        {
            return db.Firmy.Count(e => e.IdFirmy == id) > 0;
        }
    }
}