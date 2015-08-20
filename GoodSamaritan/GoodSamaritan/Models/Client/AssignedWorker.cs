using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodSamaritan.Models.Client
{
    [Authorize(Roles = "Administrator")]
    public class AssignedWorker
    {
        public int AssignedWorkerId { get; set; }

        //Michelle; Tyra; Louise; Angela; Dave; Troy; Michael; Manpreet; Patrick; None
        public string AssignedWorkerName { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Client> Clients { get; set; }
    }
}