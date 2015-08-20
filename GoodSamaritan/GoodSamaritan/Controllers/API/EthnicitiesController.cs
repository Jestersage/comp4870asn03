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

namespace GoodSamaritan.Controllers.API
{
    public class EthnicitiesController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/Ethnicities
        public IQueryable<Ethnicity> GetEthnicities()
        {
            return db.Ethnicities;
        }

        // GET: api/Ethnicities/5
        [ResponseType(typeof(Ethnicity))]
        public IHttpActionResult GetEthnicity(int id)
        {
            Ethnicity ethnicity = db.Ethnicities.Find(id);
            if (ethnicity == null)
            {
                return NotFound();
            }

            return Ok(ethnicity);
        }

        // PUT: api/Ethnicities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEthnicity(int id, Ethnicity ethnicity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ethnicity.EthnicityId)
            {
                return BadRequest();
            }

            db.Entry(ethnicity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EthnicityExists(id))
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

        // POST: api/Ethnicities
        [ResponseType(typeof(Ethnicity))]
        public IHttpActionResult PostEthnicity(Ethnicity ethnicity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ethnicities.Add(ethnicity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ethnicity.EthnicityId }, ethnicity);
        }

        // DELETE: api/Ethnicities/5
        [ResponseType(typeof(Ethnicity))]
        public IHttpActionResult DeleteEthnicity(int id)
        {
            Ethnicity ethnicity = db.Ethnicities.Find(id);
            if (ethnicity == null)
            {
                return NotFound();
            }

            db.Ethnicities.Remove(ethnicity);
            db.SaveChanges();

            return Ok(ethnicity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EthnicityExists(int id)
        {
            return db.Ethnicities.Count(e => e.EthnicityId == id) > 0;
        }
    }
}