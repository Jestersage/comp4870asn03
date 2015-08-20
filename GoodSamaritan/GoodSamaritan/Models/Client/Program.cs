using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodSamaritan.Models.Client
{
    [Authorize(Roles = "Administrator")]
    public class Program
    {
        public int ProgramId { get; set; }
        
        //Crisis; Court; SMART; DVU; MCFD
        //If Program == SMART, ref Smart
        public string ProgramName { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Client> Clients { get; set; }
    }
}