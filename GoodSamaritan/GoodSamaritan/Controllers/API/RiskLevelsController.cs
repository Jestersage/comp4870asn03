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
    public class RiskLevelsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/RiskLevels
        public IQueryable<RiskLevel> GetRiskLevels()
        {
            return db.RiskLevels;
        }

        // GET: api/RiskLevels/5
        [ResponseType(typeof(RiskLevel))]
        public IHttpActionResult GetRiskLevel(int id)
        {
            RiskLevel riskLevel = db.RiskLevels.Find(id);
            if (riskLevel == null)
            {
                return NotFound();
            }

            return Ok(riskLevel);
        }

        // PUT: api/RiskLevels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRiskLevel(int id, RiskLevel riskLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != riskLevel.RiskLevelId)
            {
                return BadRequest();
            }

            db.Entry(riskLevel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiskLevelExists(id))
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

        // POST: api/RiskLevels
        [ResponseType(typeof(RiskLevel))]
        public IHttpActionResult PostRiskLevel(RiskLevel riskLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RiskLevels.Add(riskLevel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = riskLevel.RiskLevelId }, riskLevel);
        }

        // DELETE: api/RiskLevels/5
        [ResponseType(typeof(RiskLevel))]
        public IHttpActionResult DeleteRiskLevel(int id)
        {
            RiskLevel riskLevel = db.RiskLevels.Find(id);
            if (riskLevel == null)
            {
                return NotFound();
            }

            db.RiskLevels.Remove(riskLevel);
            db.SaveChanges();

            return Ok(riskLevel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RiskLevelExists(int id)
        {
            return db.RiskLevels.Count(e => e.RiskLevelId == id) > 0;
        }
    }
}