using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodSamaritan.Models.Smart
{
   [Authorize(Roles = "Administrator")]
    public class HospitalAtt
    {

        public int HospitalAttId { get; set; }
        public string HospitalAttName { get; set; }
       [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Smart> Smarts { get; set; }
    }
}