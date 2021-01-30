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
    public class PracownicyController : ApiController
    {
        private readonly KontrahenciEntities db = new KontrahenciEntities();

        // GET: api/Pracownicy
        public IQueryable<Pracownicy> GetPracownicy()
        {
            return db.Pracownicy;
        }

        // GET: api/Pracownicy/5
        [ResponseType(typeof(Pracownicy))]
        public IHttpActionResult GetPracownicy(int id)
        {
            Pracownicy pracownicy = db.Pracownicy.Find(id);
            if (pracownicy == null)
            {
                return NotFound();
            }

            return Ok(pracownicy);
        }

        // PUT: api/Pracownicy/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPracownicy(int id, Pracownicy pracownicy)
        {
            if (id != pracownicy.IdPracownika)
            {
                return BadRequest();
            }

            db.Entry(pracownicy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PracownicyExists(id))
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

        // POST: api/Pracownicy
        [ResponseType(typeof(Pracownicy))]
        public IHttpActionResult PostPracownicy(Pracownicy pracownicy)
        {
            db.Pracownicy.Add(pracownicy);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pracownicy.IdPracownika }, pracownicy);
        }

        // DELETE: api/Pracownicy/5
        [ResponseType(typeof(Pracownicy))]
        public IHttpActionResult DeletePracownicy(int id)
        {
            Pracownicy pracownicy = db.Pracownicy.Find(id);
            if (pracownicy == null)
            {
                return NotFound();
            }

            db.Pracownicy.Remove(pracownicy);
            db.SaveChanges();

            return Ok(pracownicy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PracownicyExists(int id)
        {
            return db.Pracownicy.Count(e => e.IdPracownika == id) > 0;
        }
    }
}