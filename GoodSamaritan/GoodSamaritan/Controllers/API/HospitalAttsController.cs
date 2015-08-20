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
    public class HospitalAttsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/HospitalAtts
        public IQueryable<HospitalAtt> GetHospitalAtts()
        {
            return db.HospitalAtts;
        }

        // GET: api/HospitalAtts/5
        [ResponseType(typeof(HospitalAtt))]
        public IHttpActionResult GetHospitalAtt(int id)
        {
            HospitalAtt hospitalAtt = db.HospitalAtts.Find(id);
            if (hospitalAtt == null)
            {
                return NotFound();
            }

            return Ok(hospitalAtt);
        }

        // PUT: api/HospitalAtts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHospitalAtt(int id, HospitalAtt hospitalAtt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hospitalAtt.HospitalAttId)
            {
                return BadRequest();
            }

            db.Entry(hospitalAtt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalAttExists(id))
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

        // POST: api/HospitalAtts
        [ResponseType(typeof(HospitalAtt))]
        public IHttpActionResult PostHospitalAtt(HospitalAtt hospitalAtt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HospitalAtts.Add(hospitalAtt);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hospitalAtt.HospitalAttId }, hospitalAtt);
        }

        // DELETE: api/HospitalAtts/5
        [ResponseType(typeof(HospitalAtt))]
        public IHttpActionResult DeleteHospitalAtt(int id)
        {
            HospitalAtt hospitalAtt = db.HospitalAtts.Find(id);
            if (hospitalAtt == null)
            {
                return NotFound();
            }

            db.HospitalAtts.Remove(hospitalAtt);
            db.SaveChanges();

            return Ok(hospitalAtt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HospitalAttExists(int id)
        {
            return db.HospitalAtts.Count(e => e.HospitalAttId == id) > 0;
        }
    }
}