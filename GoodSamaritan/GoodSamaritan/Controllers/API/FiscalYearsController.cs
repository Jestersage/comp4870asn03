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
    public class FiscalYearsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/FiscalYears
        public IQueryable<FiscalYear> GetFiscalYears()
        {
            return db.FiscalYears;
        }

        // GET: api/FiscalYears/5
        [ResponseType(typeof(FiscalYear))]
        public IHttpActionResult GetFiscalYear(int id)
        {
            FiscalYear fiscalYear = db.FiscalYears.Find(id);
            if (fiscalYear == null)
            {
                return NotFound();
            }

            return Ok(fiscalYear);
        }

        // PUT: api/FiscalYears/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFiscalYear(int id, FiscalYear fiscalYear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fiscalYear.FiscalYearId)
            {
                return BadRequest();
            }

            db.Entry(fiscalYear).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiscalYearExists(id))
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

        // POST: api/FiscalYears
        [ResponseType(typeof(FiscalYear))]
        public IHttpActionResult PostFiscalYear(FiscalYear fiscalYear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FiscalYears.Add(fiscalYear);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fiscalYear.FiscalYearId }, fiscalYear);
        }

        // DELETE: api/FiscalYears/5
        [ResponseType(typeof(FiscalYear))]
        public IHttpActionResult DeleteFiscalYear(int id)
        {
            FiscalYear fiscalYear = db.FiscalYears.Find(id);
            if (fiscalYear == null)
            {
                return NotFound();
            }

            db.FiscalYears.Remove(fiscalYear);
            db.SaveChanges();

            return Ok(fiscalYear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FiscalYearExists(int id)
        {
            return db.FiscalYears.Count(e => e.FiscalYearId == id) > 0;
        }
    }
}