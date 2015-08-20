using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodSamaritan.Models.Client
{
    [Authorize(Roles = "Administrator")]
    public class Incident
    {
        public int IncidentId { get; set; }
        //Abduction; Adult Historical Sexual Assault; Adult Sexual Assault; Partner Assault; Attempted Murder; Child Physical Assault; Child Sexual Abuse/Exploitation; Criminal Harassment/Stalking; Elder Abuse; Human Trafficking; Murder; N/A; Other; Other Assault; Other Crime – DV; Other Familial Assault; Threatening; Youth Sexual Assault/Exploitation
        public string IncidentType { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Client> Clients { get; set; }
    }
}