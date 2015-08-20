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
    public class ReferralContactsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/ReferralContacts
        public IQueryable<ReferralContact> GetReferralContacts()
        {
            return db.ReferralContacts;
        }

        // GET: api/ReferralContacts/5
        [ResponseType(typeof(ReferralContact))]
        public IHttpActionResult GetReferralContact(int id)
        {
            ReferralContact referralContact = db.ReferralContacts.Find(id);
            if (referralContact == null)
            {
                return NotFound();
            }

            return Ok(referralContact);
        }

        // PUT: api/ReferralContacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReferralContact(int id, ReferralContact referralContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != referralContact.ReferralContactId)
            {
                return BadRequest();
            }

            db.Entry(referralContact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferralContactExists(id))
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

        // POST: api/ReferralContacts
        [ResponseType(typeof(ReferralContact))]
        public IHttpActionResult PostReferralContact(ReferralContact referralContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReferralContacts.Add(referralContact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = referralContact.ReferralContactId }, referralContact);
        }

        // DELETE: api/ReferralContacts/5
        [ResponseType(typeof(ReferralContact))]
        public IHttpActionResult DeleteReferralContact(int id)
        {
            ReferralContact referralContact = db.ReferralContacts.Find(id);
            if (referralContact == null)
            {
                return NotFound();
            }

            db.ReferralContacts.Remove(referralContact);
            db.SaveChanges();

            return Ok(referralContact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReferralContactExists(int id)
        {
            return db.ReferralContacts.Count(e => e.ReferralContactId == id) > 0;
        }
    }
}