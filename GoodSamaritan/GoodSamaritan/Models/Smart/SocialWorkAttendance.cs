using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodSamaritan.Models.Smart
{
   [Authorize(Roles = "Administrator")]
    public class SocialWorkAttendance
    {
        public int SocialWorkAttendanceId { get; set; }
        public string SocialWorkAttendanceValue { get; set; }
       [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Smart> Smarts { get; set; }
    }
}