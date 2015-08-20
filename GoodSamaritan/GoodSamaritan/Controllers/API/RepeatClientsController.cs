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
    public class RepeatClientsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/RepeatClients
        public IQueryable<RepeatClient> GetRepeatClients()
        {
            return db.RepeatClients;
        }

        // GET: api/RepeatClients/5
        [ResponseType(typeof(RepeatClient))]
        public IHttpActionResult GetRepeatClient(int id)
        {
            RepeatClient repeatClient = db.RepeatClients.Find(id);
            if (repeatClient == null)
            {
                return NotFound();
            }

            return Ok(repeatClient);
        }

        // PUT: api/RepeatClients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRepeatClient(int id, RepeatClient repeatClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != repeatClient.RepeatClientId)
            {
                return BadRequest();
            }

            db.Entry(repeatClient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepeatClientExists(id))
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

        // POST: api/RepeatClients
        [ResponseType(typeof(RepeatClient))]
        public IHttpActionResult PostRepeatClient(RepeatClient repeatClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RepeatClients.Add(repeatClient);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = repeatClient.RepeatClientId }, repeatClient);
        }

        // DELETE: api/RepeatClients/5
        [ResponseType(typeof(RepeatClient))]
        public IHttpActionResult DeleteRepeatClient(int id)
        {
            RepeatClient repeatClient = db.RepeatClients.Find(id);
            if (repeatClient == null)
            {
                return NotFound();
            }

            db.RepeatClients.Remove(repeatClient);
            db.SaveChanges();

            return Ok(repeatClient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RepeatClientExists(int id)
        {
            return db.RepeatClients.Count(e => e.RepeatClientId == id) > 0;
        }
    }
}