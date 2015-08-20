using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodSamaritan.Models.Client
{
    [Authorize(Roles = "Administrator")]
    public class RepeatClient
    {
        public int RepeatClientId { get; set; }
        public string Repeat { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Client> Clients { get; set; }
    }
}