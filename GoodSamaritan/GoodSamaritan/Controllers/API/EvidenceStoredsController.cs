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
    public class EvidenceStoredsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/EvidenceStoreds
        public IQueryable<EvidenceStored> GetEvidenceStoreds()
        {
            return db.EvidenceStoreds;
        }

        // GET: api/EvidenceStoreds/5
        [ResponseType(typeof(EvidenceStored))]
        public IHttpActionResult GetEvidenceStored(int id)
        {
            EvidenceStored evidenceStored = db.EvidenceStoreds.Find(id);
            if (evidenceStored == null)
            {
                return NotFound();
            }

            return Ok(evidenceStored);
        }

        // PUT: api/EvidenceStoreds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvidenceStored(int id, EvidenceStored evidenceStored)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evidenceStored.EvidenceStoredId)
            {
                return BadRequest();
            }

            db.Entry(evidenceStored).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvidenceStoredExists(id))
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

        // POST: api/EvidenceStoreds
        [ResponseType(typeof(EvidenceStored))]
        public IHttpActionResult PostEvidenceStored(EvidenceStored evidenceStored)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EvidenceStoreds.Add(evidenceStored);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = evidenceStored.EvidenceStoredId }, evidenceStored);
        }

        // DELETE: api/EvidenceStoreds/5
        [ResponseType(typeof(EvidenceStored))]
        public IHttpActionResult DeleteEvidenceStored(int id)
        {
            EvidenceStored evidenceStored = db.EvidenceStoreds.Find(id);
            if (evidenceStored == null)
            {
                return NotFound();
            }

            db.EvidenceStoreds.Remove(evidenceStored);
            db.SaveChanges();

            return Ok(evidenceStored);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EvidenceStoredExists(int id)
        {
            return db.EvidenceStoreds.Count(e => e.EvidenceStoredId == id) > 0;
        }
    }
}