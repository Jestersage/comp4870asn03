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
    public class DrugFacilitatedAssaultsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/DrugFacilitatedAssaults
        public IQueryable<DrugFacilitatedAssault> GetDrugFacilitatedAssaults()
        {
            return db.DrugFacilitatedAssaults;
        }

        // GET: api/DrugFacilitatedAssaults/5
        [ResponseType(typeof(DrugFacilitatedAssault))]
        public IHttpActionResult GetDrugFacilitatedAssault(int id)
        {
            DrugFacilitatedAssault drugFacilitatedAssault = db.DrugFacilitatedAssaults.Find(id);
            if (drugFacilitatedAssault == null)
            {
                return NotFound();
            }

            return Ok(drugFacilitatedAssault);
        }

        // PUT: api/DrugFacilitatedAssaults/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrugFacilitatedAssault(int id, DrugFacilitatedAssault drugFacilitatedAssault)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drugFacilitatedAssault.DrugFacilitatedAssaultId)
            {
                return BadRequest();
            }

            db.Entry(drugFacilitatedAssault).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugFacilitatedAssaultExists(id))
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

        // POST: api/DrugFacilitatedAssaults
        [ResponseType(typeof(DrugFacilitatedAssault))]
        public IHttpActionResult PostDrugFacilitatedAssault(DrugFacilitatedAssault drugFacilitatedAssault)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DrugFacilitatedAssaults.Add(drugFacilitatedAssault);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drugFacilitatedAssault.DrugFacilitatedAssaultId }, drugFacilitatedAssault);
        }

        // DELETE: api/DrugFacilitatedAssaults/5
        [ResponseType(typeof(DrugFacilitatedAssault))]
        public IHttpActionResult DeleteDrugFacilitatedAssault(int id)
        {
            DrugFacilitatedAssault drugFacilitatedAssault = db.DrugFacilitatedAssaults.Find(id);
            if (drugFacilitatedAssault == null)
            {
                return NotFound();
            }

            db.DrugFacilitatedAssaults.Remove(drugFacilitatedAssault);
            db.SaveChanges();

            return Ok(drugFacilitatedAssault);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrugFacilitatedAssaultExists(int id)
        {
            return db.DrugFacilitatedAssaults.Count(e => e.DrugFacilitatedAssaultId == id) > 0;
        }
    }
}