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
    public class AssignedWorkersController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/AssignedWorkers
        public IQueryable<AssignedWorker> GetAssignedWorkers()
        {
            return db.AssignedWorkers;
        }

        // GET: api/AssignedWorkers/5
        [ResponseType(typeof(AssignedWorker))]
        public IHttpActionResult GetAssignedWorker(int id)
        {
            AssignedWorker assignedWorker = db.AssignedWorkers.Find(id);
            if (assignedWorker == null)
            {
                return NotFound();
            }

            return Ok(assignedWorker);
        }

        // PUT: api/AssignedWorkers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssignedWorker(int id, AssignedWorker assignedWorker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignedWorker.AssignedWorkerId)
            {
                return BadRequest();
            }

            db.Entry(assignedWorker).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignedWorkerExists(id))
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

        // POST: api/AssignedWorkers
        [ResponseType(typeof(AssignedWorker))]
        public IHttpActionResult PostAssignedWorker(AssignedWorker assignedWorker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssignedWorkers.Add(assignedWorker);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assignedWorker.AssignedWorkerId }, assignedWorker);
        }

        // DELETE: api/AssignedWorkers/5
        [ResponseType(typeof(AssignedWorker))]
        public IHttpActionResult DeleteAssignedWorker(int id)
        {
            AssignedWorker assignedWorker = db.AssignedWorkers.Find(id);
            if (assignedWorker == null)
            {
                return NotFound();
            }

            db.AssignedWorkers.Remove(assignedWorker);
            db.SaveChanges();

            return Ok(assignedWorker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssignedWorkerExists(int id)
        {
            return db.AssignedWorkers.Count(e => e.AssignedWorkerId == id) > 0;
        }
    }
}