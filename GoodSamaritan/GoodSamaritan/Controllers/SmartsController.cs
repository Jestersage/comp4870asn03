using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GoodSamaritan.Models.Client;
using GoodSamaritan.Models.Smart;

namespace GoodSamaritan.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SmartsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Smarts
        public ActionResult Index()
        {
            var smarts = db.Smarts.Include(s => s.BadDate).Include(s => s.CityAssault).Include(s => s.CityResidence).Include(s => s.DrugAssault).Include(s => s.Evidence).Include(s => s.Exploitation).Include(s => s.HIVMeds).Include(s => s.HospitalAttended).Include(s => s.MedicalOnly).Include(s => s.MultiPerp).Include(s => s.PoliceAttendence).Include(s => s.PoliceReported).Include(s => s.ReferCBVS).Include(s => s.ReferringHospital).Include(s => s.SocialWorkAttendence).Include(s => s.ThirdParty).Include(s => s.VictimServices);
            return View(smarts.ToList());
        }

        // GET: Smarts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smart smart = db.Smarts.Find(id);
            if (smart == null)
            {
                return HttpNotFound();
            }
            return View(smart);
        }

        // GET: Smarts/Create
        public ActionResult Create()
        {
            ViewBag.BadDateReportId = new SelectList(db.BadDateReports, "BadDateReportId", "BadDateReportValue");
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
            ViewBag.CityResId = new SelectList(db.CityRes, "CityResId", "CityResName");
            ViewBag.DrugFacilitatedAssaultId = new SelectList(db.DrugFacilitatedAssaults, "DrugFacilitatedAssaultId", "DrugFacilitatedAssaultValue");
            ViewBag.EvidenceStoredId = new SelectList(db.EvidenceStoreds, "EvidenceStoredId", "EvidenceStoredValue");
            ViewBag.SexWorkExploitationId = new SelectList(db.SexWorkExploitations, "SexWorkExploitationId", "SexWorkExploitationValue");
            ViewBag.HIVMedsId = new SelectList(db.HIVMeds, "HIVMedsId", "HIVMedsValue");
            ViewBag.HospitalAttId = new SelectList(db.HospitalAtts, "HospitalAttId", "HospitalAttName");
            ViewBag.MedicalOnlyId = new SelectList(db.MedicalOnlies, "MedicalOnlyId", "MedicalOnlyValue");
            ViewBag.MultiplePerpetratorId = new SelectList(db.MultiplePerpetrators, "MultiplePerpetratorId", "MultiplePerpetratorValue");
            ViewBag.PoliceAttendanceId = new SelectList(db.PoliceAttendances, "PoliceAttendanceId", "PoliceAttendanceValue");
            ViewBag.PoliceReportedId = new SelectList(db.PoliceReporteds, "PoliceReportedId", "PoliceReportedValue");
            ViewBag.ReferCBVSId = new SelectList(db.ReferCBVS, "ReferCBVSId", "ReferCBVSValue");
            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalId", "HospitalName");
            ViewBag.SocialWorkAttendanceId = new SelectList(db.SocialWorkAttendances, "SocialWorkAttendanceId", "SocialWorkAttendanceValue");
            ViewBag.ThirdPartyReportId = new SelectList(db.ThirdPartyReports, "ThirdPartyReportId", "ThirdPartyReportValue");
            ViewBag.VictimServicesAttendanceId = new SelectList(db.VictimServicesAttendances, "VictimServicesAttendanceId", "VictimServicesAttendanceValue");
            return View();
        }

        // POST: Smarts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SmartId,ClientId,SexWorkExploitationId,MultiplePerpetratorId,DrugFacilitatedAssaultId,CityId,CityResId,AccompanimentMinutes,HospitalId,HospitalAttId,SocialWorkAttendanceId,PoliceAttendanceId,VictimServicesAttendanceId,MedicalOnlyId,EvidenceStoredId,HIVMedsId,ReferCBVSId,PoliceReportedId,ThirdPartyReportId,BadDateReportId,NumTransportProvided,ReferToNurse")] Smart smart)
        {
            if (ModelState.IsValid)
            {
                db.Smarts.Add(smart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BadDateReportId = new SelectList(db.BadDateReports, "BadDateReportId", "BadDateReportValue", smart.BadDateReportId);
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", smart.CityId);
            ViewBag.CityResId = new SelectList(db.CityRes, "CityResId", "CityResName", smart.CityResId);
            ViewBag.DrugFacilitatedAssaultId = new SelectList(db.DrugFacilitatedAssaults, "DrugFacilitatedAssaultId", "DrugFacilitatedAssaultValue", smart.DrugFacilitatedAssaultId);
            ViewBag.EvidenceStoredId = new SelectList(db.EvidenceStoreds, "EvidenceStoredId", "EvidenceStoredValue", smart.EvidenceStoredId);
            ViewBag.SexWorkExploitationId = new SelectList(db.SexWorkExploitations, "SexWorkExploitationId", "SexWorkExploitationValue", smart.SexWorkExploitationId);
            ViewBag.HIVMedsId = new SelectList(db.HIVMeds, "HIVMedsId", "HIVMedsValue", smart.HIVMedsId);
            ViewBag.HospitalAttId = new SelectList(db.HospitalAtts, "HospitalAttId", "HospitalAttName", smart.HospitalAttId);
            ViewBag.MedicalOnlyId = new SelectList(db.MedicalOnlies, "MedicalOnlyId", "MedicalOnlyValue", smart.MedicalOnlyId);
            ViewBag.MultiplePerpetratorId = new SelectList(db.MultiplePerpetrators, "MultiplePerpetratorId", "MultiplePerpetratorValue", smart.MultiplePerpetratorId);
            ViewBag.PoliceAttendanceId = new SelectList(db.PoliceAttendances, "PoliceAttendanceId", "PoliceAttendanceValue", smart.PoliceAttendanceId);
            ViewBag.PoliceReportedId = new SelectList(db.PoliceReporteds, "PoliceReportedId", "PoliceReportedValue", smart.PoliceReportedId);
            ViewBag.ReferCBVSId = new SelectList(db.ReferCBVS, "ReferCBVSId", "ReferCBVSValue", smart.ReferCBVSId);
            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalId", "HospitalName", smart.HospitalId);
            ViewBag.SocialWorkAttendanceId = new SelectList(db.SocialWorkAttendances, "SocialWorkAttendanceId", "SocialWorkAttendanceValue", smart.SocialWorkAttendanceId);
            ViewBag.ThirdPartyReportId = new SelectList(db.ThirdPartyReports, "ThirdPartyReportId", "ThirdPartyReportValue", smart.ThirdPartyReportId);
            ViewBag.VictimServicesAttendanceId = new SelectList(db.VictimServicesAttendances, "VictimServicesAttendanceId", "VictimServicesAttendanceValue", smart.VictimServicesAttendanceId);
            return View(smart);
        }

        // GET: Smarts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smart smart = db.Smarts.Find(id);
            if (smart == null)
            {
                return HttpNotFound();
            }
            ViewBag.BadDateReportId = new SelectList(db.BadDateReports, "BadDateReportId", "BadDateReportValue", smart.BadDateReportId);
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", smart.CityId);
            ViewBag.CityResId = new SelectList(db.CityRes, "CityResId", "CityResName", smart.CityResId);
            ViewBag.DrugFacilitatedAssaultId = new SelectList(db.DrugFacilitatedAssaults, "DrugFacilitatedAssaultId", "DrugFacilitatedAssaultValue", smart.DrugFacilitatedAssaultId);
            ViewBag.EvidenceStoredId = new SelectList(db.EvidenceStoreds, "EvidenceStoredId", "EvidenceStoredValue", smart.EvidenceStoredId);
            ViewBag.SexWorkExploitationId = new SelectList(db.SexWorkExploitations, "SexWorkExploitationId", "SexWorkExploitationValue", smart.SexWorkExploitationId);
            ViewBag.HIVMedsId = new SelectList(db.HIVMeds, "HIVMedsId", "HIVMedsValue", smart.HIVMedsId);
            ViewBag.HospitalAttId = new SelectList(db.HospitalAtts, "HospitalAttId", "HospitalAttName", smart.HospitalAttId);
            ViewBag.MedicalOnlyId = new SelectList(db.MedicalOnlies, "MedicalOnlyId", "MedicalOnlyValue", smart.MedicalOnlyId);
            ViewBag.MultiplePerpetratorId = new SelectList(db.MultiplePerpetrators, "MultiplePerpetratorId", "MultiplePerpetratorValue", smart.MultiplePerpetratorId);
            ViewBag.PoliceAttendanceId = new SelectList(db.PoliceAttendances, "PoliceAttendanceId", "PoliceAttendanceValue", smart.PoliceAttendanceId);
            ViewBag.PoliceReportedId = new SelectList(db.PoliceReporteds, "PoliceReportedId", "PoliceReportedValue", smart.PoliceReportedId);
            ViewBag.ReferCBVSId = new SelectList(db.ReferCBVS, "ReferCBVSId", "ReferCBVSValue", smart.ReferCBVSId);
            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalId", "HospitalName", smart.HospitalId);
            ViewBag.SocialWorkAttendanceId = new SelectList(db.SocialWorkAttendances, "SocialWorkAttendanceId", "SocialWorkAttendanceValue", smart.SocialWorkAttendanceId);
            ViewBag.ThirdPartyReportId = new SelectList(db.ThirdPartyReports, "ThirdPartyReportId", "ThirdPartyReportValue", smart.ThirdPartyReportId);
            ViewBag.VictimServicesAttendanceId = new SelectList(db.VictimServicesAttendances, "VictimServicesAttendanceId", "VictimServicesAttendanceValue", smart.VictimServicesAttendanceId);
            return View(smart);
        }

        // POST: Smarts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SmartId,ClientId,SexWorkExploitationId,MultiplePerpetratorId,DrugFacilitatedAssaultId,CityId,CityResId,AccompanimentMinutes,HospitalId,HospitalAttId,SocialWorkAttendanceId,PoliceAttendanceId,VictimServicesAttendanceId,MedicalOnlyId,EvidenceStoredId,HIVMedsId,ReferCBVSId,PoliceReportedId,ThirdPartyReportId,BadDateReportId,NumTransportProvided,ReferToNurse")] Smart smart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BadDateReportId = new SelectList(db.BadDateReports, "BadDateReportId", "BadDateReportValue", smart.BadDateReportId);
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", smart.CityId);
            ViewBag.CityResId = new SelectList(db.CityRes, "CityResId", "CityResName", smart.CityResId);
            ViewBag.DrugFacilitatedAssaultId = new SelectList(db.DrugFacilitatedAssaults, "DrugFacilitatedAssaultId", "DrugFacilitatedAssaultValue", smart.DrugFacilitatedAssaultId);
            ViewBag.EvidenceStoredId = new SelectList(db.EvidenceStoreds, "EvidenceStoredId", "EvidenceStoredValue", smart.EvidenceStoredId);
            ViewBag.SexWorkExploitationId = new SelectList(db.SexWorkExploitations, "SexWorkExploitationId", "SexWorkExploitationValue", smart.SexWorkExploitationId);
            ViewBag.HIVMedsId = new SelectList(db.HIVMeds, "HIVMedsId", "HIVMedsValue", smart.HIVMedsId);
            ViewBag.HospitalAttId = new SelectList(db.HospitalAtts, "HospitalAttId", "HospitalAttName", smart.HospitalAttId);
            ViewBag.MedicalOnlyId = new SelectList(db.MedicalOnlies, "MedicalOnlyId", "MedicalOnlyValue", smart.MedicalOnlyId);
            ViewBag.MultiplePerpetratorId = new SelectList(db.MultiplePerpetrators, "MultiplePerpetratorId", "MultiplePerpetratorValue", smart.MultiplePerpetratorId);
            ViewBag.PoliceAttendanceId = new SelectList(db.PoliceAttendances, "PoliceAttendanceId", "PoliceAttendanceValue", smart.PoliceAttendanceId);
            ViewBag.PoliceReportedId = new SelectList(db.PoliceReporteds, "PoliceReportedId", "PoliceReportedValue", smart.PoliceReportedId);
            ViewBag.ReferCBVSId = new SelectList(db.ReferCBVS, "ReferCBVSId", "ReferCBVSValue", smart.ReferCBVSId);
            ViewBag.HospitalId = new SelectList(db.Hospitals, "HospitalId", "HospitalName", smart.HospitalId);
            ViewBag.SocialWorkAttendanceId = new SelectList(db.SocialWorkAttendances, "SocialWorkAttendanceId", "SocialWorkAttendanceValue", smart.SocialWorkAttendanceId);
            ViewBag.ThirdPartyReportId = new SelectList(db.ThirdPartyReports, "ThirdPartyReportId", "ThirdPartyReportValue", smart.ThirdPartyReportId);
            ViewBag.VictimServicesAttendanceId = new SelectList(db.VictimServicesAttendances, "VictimServicesAttendanceId", "VictimServicesAttendanceValue", smart.VictimServicesAttendanceId);
            return View(smart);
        }

        // GET: Smarts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smart smart = db.Smarts.Find(id);
            if (smart == null)
            {
                return HttpNotFound();
            }
            return View(smart);
        }

        // POST: Smarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Smart smart = db.Smarts.Find(id);
            db.Smarts.Remove(smart);
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
