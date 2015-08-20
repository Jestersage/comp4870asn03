using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodSamaritan.Models.Smart
{
   [Authorize(Roles = "Administrator")]
    public class PoliceReported
    {
        public int PoliceReportedId { get; set; }
        public string PoliceReportedValue { get; set; }
       [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Smart> Smarts { get; set; }
    }
}