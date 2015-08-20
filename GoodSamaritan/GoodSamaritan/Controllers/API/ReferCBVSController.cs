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
    public class ReferCBVSController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/ReferCBVS
        public IQueryable<ReferCBVS> GetReferCBVS()
        {
            return db.ReferCBVS;
        }

        // GET: api/ReferCBVS/5
        [ResponseType(typeof(ReferCBVS))]
        public IHttpActionResult GetReferCBVS(int id)
        {
            ReferCBVS referCBVS = db.ReferCBVS.Find(id);
            if (referCBVS == null)
            {
                return NotFound();
            }

            return Ok(referCBVS);
        }

        // PUT: api/ReferCBVS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReferCBVS(int id, ReferCBVS referCBVS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != referCBVS.ReferCBVSId)
            {
                return BadRequest();
            }

            db.Entry(referCBVS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferCBVSExists(id))
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

        // POST: api/ReferCBVS
        [ResponseType(typeof(ReferCBVS))]
        public IHttpActionResult PostReferCBVS(ReferCBVS referCBVS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReferCBVS.Add(referCBVS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = referCBVS.ReferCBVSId }, referCBVS);
        }

        // DELETE: api/ReferCBVS/5
        [ResponseType(typeof(ReferCBVS))]
        public IHttpActionResult DeleteReferCBVS(int id)
        {
            ReferCBVS referCBVS = db.ReferCBVS.Find(id);
            if (referCBVS == null)
            {
                return NotFound();
            }

            db.ReferCBVS.Remove(referCBVS);
            db.SaveChanges();

            return Ok(referCBVS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReferCBVSExists(int id)
        {
            return db.ReferCBVS.Count(e => e.ReferCBVSId == id) > 0;
        }
    }
}