using GoodSamaritan.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;
using System.Net;

namespace GoodSamaritan.Controllers.Report
{
    public class ReportController : Controller
    {
        List<string> assignedWorkers;
        List<string> fileStatus;
        private ClientContext db = new ClientContext();
        // GET: Report
        public ActionResult ReportIndex()
        {
            assignedWorkers = (from w in db.AssignedWorkers select w.AssignedWorkerName).ToList();
            ViewBag.AssignedWorkers = new SelectList(assignedWorkers);

            fileStatus = (from f in db.FileStatus select f.FileStatusString).ToList();
            ViewBag.FileStatus = new SelectList(fileStatus);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReportIndex(string assignedWorkerName, string fileStatusString)
        {
            List<string> files;
            int assingnedInSelectedStatus = 0;
            int totalAssign = 0;
            int open = 0;
            int reopened = 0;
            int closed = 0;
            int none = 0;

            files = (from f in db.Clients where f.AssignedWorker.AssignedWorkerName == assignedWorkerName select f.FileStatuse.FileStatusString).ToList();
            foreach (var file in files)
            {
                totalAssign++;
                if (file.Equals(fileStatusString))
                {
                    assingnedInSelectedStatus++;
                }
                if (file.Equals("Open"))
                {
                    open++;
                }
                if (file.Equals("Closed"))
                {
                    closed++;
                }
                if (file.Equals("Reopened"))
                {
                    reopened++;
                }
                if (file.Equals("None"))
                {
                    none++;
                }
            }


            assignedWorkers = (from w in db.AssignedWorkers select w.AssignedWorkerName).ToList();
            ViewBag.AssignedWorkers = new SelectList(assignedWorkers);

            fileStatus = (from f in db.FileStatus select f.FileStatusString).ToList();
            ViewBag.FileStatus = new SelectList(fileStatus);

            ViewBag.AssignedInSelectedStatus = assingnedInSelectedStatus;
            ViewBag.TotalAssinged = totalAssign;
            ViewBag.Open = open;
            ViewBag.Closed = closed;
            ViewBag.Reopened = reopened;
            ViewBag.None = none;
            Details(fileStatusString);
            return View("ReportIndex");
        }

        private void Details(string selectedStatus)
        {
            List<string> fiscalYearName = new List<string>();
            List<string> programName = new List<string>();
            List<string> surname = new List<string>();
            List<string> firstName = new List<string>();
            List<string> policeFileNum = new List<string>();
            List<string> serviceName = new List<string>();
            List<string> victimType = new List<string>();
            List<string> status = new List<string>();
            List<string> gender = new List<string>();
            List<string> ethnictiy = new List<string>();
            List<string> ageRange = new List<string>();
            List<int> clientId = new List<int>();
            List<int> month = new List<int>();
            List<int> day = new List<int>();
            List<int> courtFileNum = new List<int>();

            clientId = (from d in db.Clients where d.FileStatuse.FileStatusString == selectedStatus select d.ClientId).ToList();
            fiscalYearName = (from d in db.Clients where d.FileStatuse.FileStatusString == selectedStatus select d.FiscalYear.FiscalYearName).ToList();
            programName = (from d in db.Clients where d.FileStatuse.FileStatusString == selectedStatus select d.Program.ProgramName).ToList();
            surname = (from d in db.Clients where d.FileStatuse.FileStatusString == selectedStatus select d.Surname).ToList();
            firstName = (from d in db.Clients where d.FileStatuse.FileStatusString == selectedStatus select d.FirstName).ToList();
            policeFileNum = (from d in db.Clients where d.FileStatuse.FileStatusString == selectedStatus select d.PoliceFileNum).ToList();
            serviceName = (from d in db.Clients where d.FileStatuse.FileStatusString == selectedStatus select d.Serivce.ServiceName).ToList();
            victimType = (from d in db.Clients where d.FileStatuse.FileStatusString == selectedStatus select d.VictimOfIncident.VictimType).ToList();
            status = (from d in db.Clients where d.FileStatuse.FileStatusString == selectedStatus select d.FileStatuse.FileStatusString).ToList();
            gender = (from d in db.Clients where d.FileStatuse.FileStatusString == selectedStatus select d.Gender).ToList();
            ethnictiy = (from d in db.Clients where d.FileStatuse.FileStatusString == selectedStatus select d.Race.Ethnictiy).ToList();
            ageRange = (from d in db.Clients where d.FileStatuse.FileStatusString == selectedStatus select d.age.AgeRange).ToList();
            month = (from d in db.Clients where d.FileStatuse.FileStatusString == selectedStatus select d.Month).ToList();
            day = (from d in db.Clients where d.FileStatuse.FileStatusString == selectedStatus select d.Day).ToList();
            courtFileNum = (from d in db.Clients where d.FileStatuse.FileStatusString == selectedStatus select d.CourtFileNum).ToList();

            ViewBag.FiscalYearName = fiscalYearName;
            ViewBag.ProgramName = programName;
            ViewBag.FirstName = firstName;
            ViewBag.Surname = surname;
            ViewBag.PoliceFileNum = policeFileNum;
            ViewBag.ServiceName = serviceName;
            ViewBag.VictimType = victimType;
            ViewBag.Status = status;
            ViewBag.Gender = gender;
            ViewBag.Ethnictiy = ethnictiy;
            ViewBag.AgeRange = ageRange;
            ViewBag.ClientId = clientId;
            ViewBag.Month = month;
            ViewBag.Day = day;
            ViewBag.CourtFileNum = courtFileNum;


        }
    }
}