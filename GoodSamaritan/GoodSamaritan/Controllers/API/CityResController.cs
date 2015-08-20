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
    public class CityResController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/CityRes
        public IQueryable<CityRes> GetCityRes()
        {
            return db.CityRes;
        }

        // GET: api/CityRes/5
        [ResponseType(typeof(CityRes))]
        public IHttpActionResult GetCityRes(int id)
        {
            CityRes cityRes = db.CityRes.Find(id);
            if (cityRes == null)
            {
                return NotFound();
            }

            return Ok(cityRes);
        }

        // PUT: api/CityRes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCityRes(int id, CityRes cityRes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cityRes.CityResId)
            {
                return BadRequest();
            }

            db.Entry(cityRes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityResExists(id))
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

        // POST: api/CityRes
        [ResponseType(typeof(CityRes))]
        public IHttpActionResult PostCityRes(CityRes cityRes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CityRes.Add(cityRes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cityRes.CityResId }, cityRes);
        }

        // DELETE: api/CityRes/5
        [ResponseType(typeof(CityRes))]
        public IHttpActionResult DeleteCityRes(int id)
        {
            CityRes cityRes = db.CityRes.Find(id);
            if (cityRes == null)
            {
                return NotFound();
            }

            db.CityRes.Remove(cityRes);
            db.SaveChanges();

            return Ok(cityRes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CityResExists(int id)
        {
            return db.CityRes.Count(e => e.CityResId == id) > 0;
        }
    }
}