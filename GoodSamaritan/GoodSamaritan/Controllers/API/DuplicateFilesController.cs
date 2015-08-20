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
    public class DuplicateFilesController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/DuplicateFiles
        public IQueryable<DuplicateFile> GetDuplicateFiles()
        {
            return db.DuplicateFiles;
        }

        // GET: api/DuplicateFiles/5
        [ResponseType(typeof(DuplicateFile))]
        public IHttpActionResult GetDuplicateFile(int id)
        {
            DuplicateFile duplicateFile = db.DuplicateFiles.Find(id);
            if (duplicateFile == null)
            {
                return NotFound();
            }

            return Ok(duplicateFile);
        }

        // PUT: api/DuplicateFiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDuplicateFile(int id, DuplicateFile duplicateFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != duplicateFile.DuplicateFileId)
            {
                return BadRequest();
            }

            db.Entry(duplicateFile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuplicateFileExists(id))
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

        // POST: api/DuplicateFiles
        [ResponseType(typeof(DuplicateFile))]
        public IHttpActionResult PostDuplicateFile(DuplicateFile duplicateFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DuplicateFiles.Add(duplicateFile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = duplicateFile.DuplicateFileId }, duplicateFile);
        }

        // DELETE: api/DuplicateFiles/5
        [ResponseType(typeof(DuplicateFile))]
        public IHttpActionResult DeleteDuplicateFile(int id)
        {
            DuplicateFile duplicateFile = db.DuplicateFiles.Find(id);
            if (duplicateFile == null)
            {
                return NotFound();
            }

            db.DuplicateFiles.Remove(duplicateFile);
            db.SaveChanges();

            return Ok(duplicateFile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DuplicateFileExists(int id)
        {
            return db.DuplicateFiles.Count(e => e.DuplicateFileId == id) > 0;
        }
    }
}