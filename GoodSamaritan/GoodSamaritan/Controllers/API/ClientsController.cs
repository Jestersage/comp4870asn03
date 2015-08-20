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
    public class ClientsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/Clients
        public IQueryable<Client> GetClients()
        {
            var clients = db.Clients.Include(c => c.age).Include(c => c.AssignedWorker).Include(c => c.Crisis).Include(c => c.DuplicateFile).Include(c => c.File).Include(c => c.FileStatuse).Include(c => c.FiscalYear).Include(c => c.Incident).Include(c => c.Program).Include(c => c.Race).Include(c => c.ReferralContact).Include(c => c.ReferralSource).Include(c => c.Relationship).Include(c => c.RepeatClient).Include(c => c.RiskLevel).Include(c => c.RiskStatus).Include(c => c.Serivce).Include(c => c.VictimOfIncident);
            return clients;
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        
        [ResponseType(typeof(Client))]
        [Route("api/Clients/{worker:string}/{status:string}")]
        public IHttpActionResult GetClient(string worker, string status)
        {
            
            Client client = db.Clients.Find();
            var assignedWorker = worker;
            var fileStatus = status;

            var files = (from f in db.Clients
                         where f.AssignedWorker.AssignedWorkerName == worker
                         select f.FileStatuse.FileStatusString)
                         .ToList();


           
            if (client == null)
            {
                return NotFound();
            }

            return Ok(files);
        }
        

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ClientId)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.ClientId == id) > 0;
        }
    }
}