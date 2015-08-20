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
using GoodSamaritan.Models.Client;
using GoodSamaritan.Models.Smart;

namespace GoodSamaritan.Controllers.API
{
    public class MedicalOnliesController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/MedicalOnlies
        public IQueryable<MedicalOnly> GetMedicalOnlies()
        {
            return db.MedicalOnlies;
        }

        // GET: api/MedicalOnlies/5
        [ResponseType(typeof(MedicalOnly))]
        public IHttpActionResult GetMedicalOnly(int id)
        {
            MedicalOnly medicalOnly = db.MedicalOnlies.Find(id);
            if (medicalOnly == null)
            {
                return NotFound();
            }

            return Ok(medicalOnly);
        }

        // PUT: api/MedicalOnlies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedicalOnly(int id, MedicalOnly medicalOnly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicalOnly.MedicalOnlyId)
            {
                return BadRequest();
            }

            db.Entry(medicalOnly).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalOnlyExists(id))
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

        // POST: api/MedicalOnlies
        [ResponseType(typeof(MedicalOnly))]
        public IHttpActionResult PostMedicalOnly(MedicalOnly medicalOnly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MedicalOnlies.Add(medicalOnly);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medicalOnly.MedicalOnlyId }, medicalOnly);
        }

        // DELETE: api/MedicalOnlies/5
        [ResponseType(typeof(MedicalOnly))]
        public IHttpActionResult DeleteMedicalOnly(int id)
        {
            MedicalOnly medicalOnly = db.MedicalOnlies.Find(id);
            if (medicalOnly == null)
            {
                return NotFound();
            }

            db.MedicalOnlies.Remove(medicalOnly);
            db.SaveChanges();

            return Ok(medicalOnly);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicalOnlyExists(int id)
        {
            return db.MedicalOnlies.Count(e => e.MedicalOnlyId == id) > 0;
        }
    }
}