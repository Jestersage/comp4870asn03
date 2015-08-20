using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoodSamaritan.Models.Client;

namespace GoodSamaritan.Controllers
{
    [Authorize(Roles = "Administrator, Worker")]
    public class ClientsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Clients
        public ActionResult Index()
        {
            var clients = db.Clients.Include(c => c.age).Include(c => c.AssignedWorker).Include(c => c.Crisis).Include(c => c.DuplicateFile).Include(c => c.File).Include(c => c.FileStatuse).Include(c => c.FiscalYear).Include(c => c.Incident).Include(c => c.Program).Include(c => c.Race).Include(c => c.ReferralContact).Include(c => c.ReferralSource).Include(c => c.Relationship).Include(c => c.RepeatClient).Include(c => c.RiskLevel).Include(c => c.RiskStatus).Include(c => c.Serivce).Include(c => c.VictimOfIncident);
            return View(clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.AgeId = new SelectList(db.Ages, "AgeId", "AgeRange");
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkers, "AssignedWorkerId", "AssignedWorkerName");
            ViewBag.CrisisId = new SelectList(db.Crises, "CrisisId", "CrisisName");
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFiles, "DuplicateFileId", "IsDuplicate");
            ViewBag.FamilyViolenceFileId = new SelectList(db.FamilyViolenceFiles, "FamilyViolenceFileId", "Status");
            ViewBag.FileStatusId = new SelectList(db.FileStatus, "FileStatusId", "FileStatusString");
            ViewBag.FiscalYearId = new SelectList(db.FiscalYears, "FiscalYearId", "FiscalYearName");
            ViewBag.IncidentId = new SelectList(db.Incidents, "IncidentId", "IncidentType");
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramName");
            ViewBag.EthnicityId = new SelectList(db.Ethnicities, "EthnicityId", "Ethnictiy");
            ViewBag.ReferralContactId = new SelectList(db.ReferralContacts, "ReferralContactId", "ReferralContactName");
            ViewBag.ReferralSourceId = new SelectList(db.ReferralSources, "ReferralSourceId", "Source");
            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationships, "AbuserRelationshipId", "Type");
            ViewBag.RepeatClientId = new SelectList(db.RepeatClients, "RepeatClientId", "Repeat");
            ViewBag.RiskLevelId = new SelectList(db.RiskLevels, "RiskLevelId", "RiskLevelValue");
            ViewBag.RiskStatusId = new SelectList(db.RiskStatus, "RiskStatusId", "RiskStatusValue");
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "ServiceName");
            ViewBag.VictimId = new SelectList(db.Victims, "VictimId", "VictimType");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,FiscalYearId,Month,Day,Surname,FirstName,PoliceFileNum,CourtFileNum,SWCFileNum,RiskLevelId,CrisisId,ServiceId,ProgramId,RiskAccessmentAssignedTo,RiskStatusId,AssignedWorkerId,ReferralSourceId,ReferralContactId,IncidentId,AbuserSurname,AbuserFirstName,AbuserRelationshipId,VictimId,FamilyViolenceFileId,Gender,EthnicityId,AgeId,RepeatClientId,DuplicateFileId,NumChildrenAgeZeroSix,NumChildrenAgeSevenTweleve,NumChildrenAgeTeens,FileStatusId,DateLastTransfer,DateClosed,DateReopened")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgeId = new SelectList(db.Ages, "AgeId", "AgeRange", client.AgeId);
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkers, "AssignedWorkerId", "AssignedWorkerName", client.AssignedWorkerId);
            ViewBag.CrisisId = new SelectList(db.Crises, "CrisisId", "CrisisName", client.CrisisId);
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFiles, "DuplicateFileId", "IsDuplicate", client.DuplicateFileId);
            ViewBag.FamilyViolenceFileId = new SelectList(db.FamilyViolenceFiles, "FamilyViolenceFileId", "Status", client.FamilyViolenceFileId);
            ViewBag.FileStatusId = new SelectList(db.FileStatus, "FileStatusId", "FileStatusString", client.FileStatusId);
            ViewBag.FiscalYearId = new SelectList(db.FiscalYears, "FiscalYearId", "FiscalYearName", client.FiscalYearId);
            ViewBag.IncidentId = new SelectList(db.Incidents, "IncidentId", "IncidentType", client.IncidentId);
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramName", client.ProgramId);
            ViewBag.EthnicityId = new SelectList(db.Ethnicities, "EthnicityId", "Ethnictiy", client.EthnicityId);
            ViewBag.ReferralContactId = new SelectList(db.ReferralContacts, "ReferralContactId", "ReferralContactName", client.ReferralContactId);
            ViewBag.ReferralSourceId = new SelectList(db.ReferralSources, "ReferralSourceId", "Source", client.ReferralSourceId);
            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationships, "AbuserRelationshipId", "Type", client.AbuserRelationshipId);
            ViewBag.RepeatClientId = new SelectList(db.RepeatClients, "RepeatClientId", "Repeat", client.RepeatClientId);
            ViewBag.RiskLevelId = new SelectList(db.RiskLevels, "RiskLevelId", "RiskLevelValue", client.RiskLevelId);
            ViewBag.RiskStatusId = new SelectList(db.RiskStatus, "RiskStatusId", "RiskStatusValue", client.RiskStatusId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "ServiceName", client.ServiceId);
            ViewBag.VictimId = new SelectList(db.Victims, "VictimId", "VictimType", client.VictimId);
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgeId = new SelectList(db.Ages, "AgeId", "AgeRange", client.AgeId);
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkers, "AssignedWorkerId", "AssignedWorkerName", client.AssignedWorkerId);
            ViewBag.CrisisId = new SelectList(db.Crises, "CrisisId", "CrisisName", client.CrisisId);
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFiles, "DuplicateFileId", "IsDuplicate", client.DuplicateFileId);
            ViewBag.FamilyViolenceFileId = new SelectList(db.FamilyViolenceFiles, "FamilyViolenceFileId", "Status", client.FamilyViolenceFileId);
            ViewBag.FileStatusId = new SelectList(db.FileStatus, "FileStatusId", "FileStatusString", client.FileStatusId);
            ViewBag.FiscalYearId = new SelectList(db.FiscalYears, "FiscalYearId", "FiscalYearName", client.FiscalYearId);
            ViewBag.IncidentId = new SelectList(db.Incidents, "IncidentId", "IncidentType", client.IncidentId);
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramName", client.ProgramId);
            ViewBag.EthnicityId = new SelectList(db.Ethnicities, "EthnicityId", "Ethnictiy", client.EthnicityId);
            ViewBag.ReferralContactId = new SelectList(db.ReferralContacts, "ReferralContactId", "ReferralContactName", client.ReferralContactId);
            ViewBag.ReferralSourceId = new SelectList(db.ReferralSources, "ReferralSourceId", "Source", client.ReferralSourceId);
            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationships, "AbuserRelationshipId", "Type", client.AbuserRelationshipId);
            ViewBag.RepeatClientId = new SelectList(db.RepeatClients, "RepeatClientId", "Repeat", client.RepeatClientId);
            ViewBag.RiskLevelId = new SelectList(db.RiskLevels, "RiskLevelId", "RiskLevelValue", client.RiskLevelId);
            ViewBag.RiskStatusId = new SelectList(db.RiskStatus, "RiskStatusId", "RiskStatusValue", client.RiskStatusId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "ServiceName", client.ServiceId);
            ViewBag.VictimId = new SelectList(db.Victims, "VictimId", "VictimType", client.VictimId);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,FiscalYearId,Month,Day,Surname,FirstName,PoliceFileNum,CourtFileNum,SWCFileNum,RiskLevelId,CrisisId,ServiceId,ProgramId,RiskAccessmentAssignedTo,RiskStatusId,AssignedWorkerId,ReferralSourceId,ReferralContactId,IncidentId,AbuserSurname,AbuserFirstName,AbuserRelationshipId,VictimId,FamilyViolenceFileId,Gender,EthnicityId,AgeId,RepeatClientId,DuplicateFileId,NumChildrenAgeZeroSix,NumChildrenAgeSevenTweleve,NumChildrenAgeTeens,FileStatusId,DateLastTransfer,DateClosed,DateReopened")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgeId = new SelectList(db.Ages, "AgeId", "AgeRange", client.AgeId);
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkers, "AssignedWorkerId", "AssignedWorkerName", client.AssignedWorkerId);
            ViewBag.CrisisId = new SelectList(db.Crises, "CrisisId", "CrisisName", client.CrisisId);
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFiles, "DuplicateFileId", "IsDuplicate", client.DuplicateFileId);
            ViewBag.FamilyViolenceFileId = new SelectList(db.FamilyViolenceFiles, "FamilyViolenceFileId", "Status", client.FamilyViolenceFileId);
            ViewBag.FileStatusId = new SelectList(db.FileStatus, "FileStatusId", "FileStatusString", client.FileStatusId);
            ViewBag.FiscalYearId = new SelectList(db.FiscalYears, "FiscalYearId", "FiscalYearName", client.FiscalYearId);
            ViewBag.IncidentId = new SelectList(db.Incidents, "IncidentId", "IncidentType", client.IncidentId);
            ViewBag.ProgramId = new SelectList(db.Programs, "ProgramId", "ProgramName", client.ProgramId);
            ViewBag.EthnicityId = new SelectList(db.Ethnicities, "EthnicityId", "Ethnictiy", client.EthnicityId);
            ViewBag.ReferralContactId = new SelectList(db.ReferralContacts, "ReferralContactId", "ReferralContactName", client.ReferralContactId);
            ViewBag.ReferralSourceId = new SelectList(db.ReferralSources, "ReferralSourceId", "Source", client.ReferralSourceId);
            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationships, "AbuserRelationshipId", "Type", client.AbuserRelationshipId);
            ViewBag.RepeatClientId = new SelectList(db.RepeatClients, "RepeatClientId", "Repeat", client.RepeatClientId);
            ViewBag.RiskLevelId = new SelectList(db.RiskLevels, "RiskLevelId", "RiskLevelValue", client.RiskLevelId);
            ViewBag.RiskStatusId = new SelectList(db.RiskStatus, "RiskStatusId", "RiskStatusValue", client.RiskStatusId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "ServiceName", client.ServiceId);
            ViewBag.VictimId = new SelectList(db.Victims, "VictimId", "VictimType", client.VictimId);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
