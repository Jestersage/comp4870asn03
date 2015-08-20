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
    public class FileStatusController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/FileStatus
        public IQueryable<FileStatus> GetFileStatus()
        {
            return db.FileStatus;
        }

        // GET: api/FileStatus/5
        [ResponseType(typeof(FileStatus))]
        public IHttpActionResult GetFileStatus(int id)
        {
            FileStatus fileStatus = db.FileStatus.Find(id);
            if (fileStatus == null)
            {
                return NotFound();
            }

            return Ok(fileStatus);
        }

        // PUT: api/FileStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFileStatus(int id, FileStatus fileStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fileStatus.FileStatusId)
            {
                return BadRequest();
            }

            db.Entry(fileStatus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileStatusExists(id))
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

        // POST: api/FileStatus
        [ResponseType(typeof(FileStatus))]
        public IHttpActionResult PostFileStatus(FileStatus fileStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FileStatus.Add(fileStatus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fileStatus.FileStatusId }, fileStatus);
        }

        // DELETE: api/FileStatus/5
        [ResponseType(typeof(FileStatus))]
        public IHttpActionResult DeleteFileStatus(int id)
        {
            FileStatus fileStatus = db.FileStatus.Find(id);
            if (fileStatus == null)
            {
                return NotFound();
            }

            db.FileStatus.Remove(fileStatus);
            db.SaveChanges();

            return Ok(fileStatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FileStatusExists(int id)
        {
            return db.FileStatus.Count(e => e.FileStatusId == id) > 0;
        }
    }
}