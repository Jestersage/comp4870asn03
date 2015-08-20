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
    public class ReferralSourcesController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/ReferralSources
        public IQueryable<ReferralSource> GetReferralSources()
        {
            return db.ReferralSources;
        }

        // GET: api/ReferralSources/5
        [ResponseType(typeof(ReferralSource))]
        public IHttpActionResult GetReferralSource(int id)
        {
            ReferralSource referralSource = db.ReferralSources.Find(id);
            if (referralSource == null)
            {
                return NotFound();
            }

            return Ok(referralSource);
        }

        // PUT: api/ReferralSources/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReferralSource(int id, ReferralSource referralSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != referralSource.ReferralSourceId)
            {
                return BadRequest();
            }

            db.Entry(referralSource).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferralSourceExists(id))
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

        // POST: api/ReferralSources
        [ResponseType(typeof(ReferralSource))]
        public IHttpActionResult PostReferralSource(ReferralSource referralSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReferralSources.Add(referralSource);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = referralSource.ReferralSourceId }, referralSource);
        }

        // DELETE: api/ReferralSources/5
        [ResponseType(typeof(ReferralSource))]
        public IHttpActionResult DeleteReferralSource(int id)
        {
            ReferralSource referralSource = db.ReferralSources.Find(id);
            if (referralSource == null)
            {
                return NotFound();
            }

            db.ReferralSources.Remove(referralSource);
            db.SaveChanges();

            return Ok(referralSource);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReferralSourceExists(int id)
        {
            return db.ReferralSources.Count(e => e.ReferralSourceId == id) > 0;
        }
    }
}