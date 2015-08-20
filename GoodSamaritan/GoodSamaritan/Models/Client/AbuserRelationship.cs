using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodSamaritan.Models.Client
{
    [Authorize(Roles="Administrator")]
    public class AbuserRelationship
    {
        public int AbuserRelationshipId { get; set; }
        //Acquaintance; Bad Date; DNA; Ex-Partner; Friend;
        //Multiple Perps; N/A; Other; Other Familial; Parent; Partner; Sibling; Stranger
        public string Type { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Client> Clients { get; set; }
    }
}