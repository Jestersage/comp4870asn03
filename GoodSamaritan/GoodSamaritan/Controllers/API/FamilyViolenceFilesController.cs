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
    public class FamilyViolenceFilesController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/FamilyViolenceFiles
        public IQueryable<FamilyViolenceFile> GetFamilyViolenceFiles()
        {
            return db.FamilyViolenceFiles;
        }

        // GET: api/FamilyViolenceFiles/5
        [ResponseType(typeof(FamilyViolenceFile))]
        public IHttpActionResult GetFamilyViolenceFile(int id)
        {
            FamilyViolenceFile familyViolenceFile = db.FamilyViolenceFiles.Find(id);
            if (familyViolenceFile == null)
            {
                return NotFound();
            }

            return Ok(familyViolenceFile);
        }

        // PUT: api/FamilyViolenceFiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFamilyViolenceFile(int id, FamilyViolenceFile familyViolenceFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != familyViolenceFile.FamilyViolenceFileId)
            {
                return BadRequest();
            }

            db.Entry(familyViolenceFile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FamilyViolenceFileExists(id))
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

        // POST: api/FamilyViolenceFiles
        [ResponseType(typeof(FamilyViolenceFile))]
        public IHttpActionResult PostFamilyViolenceFile(FamilyViolenceFile familyViolenceFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FamilyViolenceFiles.Add(familyViolenceFile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = familyViolenceFile.FamilyViolenceFileId }, familyViolenceFile);
        }

        // DELETE: api/FamilyViolenceFiles/5
        [ResponseType(typeof(FamilyViolenceFile))]
        public IHttpActionResult DeleteFamilyViolenceFile(int id)
        {
            FamilyViolenceFile familyViolenceFile = db.FamilyViolenceFiles.Find(id);
            if (familyViolenceFile == null)
            {
                return NotFound();
            }

            db.FamilyViolenceFiles.Remove(familyViolenceFile);
            db.SaveChanges();

            return Ok(familyViolenceFile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FamilyViolenceFileExists(int id)
        {
            return db.FamilyViolenceFiles.Count(e => e.FamilyViolenceFileId == id) > 0;
        }
    }
}