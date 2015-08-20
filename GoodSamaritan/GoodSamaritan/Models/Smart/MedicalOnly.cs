using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodSamaritan.Models.Smart
{
    [Authorize(Roles = "Administrator")]
    public class MedicalOnly
    {
        public int MedicalOnlyId { get; set; }
        public string MedicalOnlyValue { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Smart> Smarts { get; set; }
    }
}