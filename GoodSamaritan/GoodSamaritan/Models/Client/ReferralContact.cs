using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodSamaritan.Models.Client
{
    [Authorize(Roles = "Administrator")]
    public class ReferralContact
    {
        public int ReferralContactId {get; set;}

        //PBVS; MCFD; PBVS; VictimLINK; TH; Self; FNS; Other; Medical
        public string ReferralContactName {get;set;}
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Client> Clients { get; set; }
    }
}