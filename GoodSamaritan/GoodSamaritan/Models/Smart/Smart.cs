using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodSamaritan.Models.Smart
{
   [Authorize(Roles = "Administrator")]
    public class Smart
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SmartId { get; set; }
        //Foreign Key to Client
        public int ClientId { get; set; }
        public virtual ICollection<Client.Client> Clients { get; set; }

        public int SexWorkExploitationId { get; set; }
        public virtual SexWorkExploitation Exploitation { get; set; } //Yes, No, N/A

        public int MultiplePerpetratorId { get; set; }
        public virtual MultiplePerpetrator MultiPerp { get; set; } //Yes. No N/A

        public int DrugFacilitatedAssaultId { get; set; }
        public virtual DrugFacilitatedAssault DrugAssault { get; set; } //Yes No N/A

        public int CityId { get; set; }
        public virtual City CityAssault { get; set; }

        public int CityResId { get; set; }
        public virtual CityRes CityResidence { get; set; }

        public int AccompanimentMinutes { get; set; }

        public int HospitalId { get; set; }
        public virtual Hospital ReferringHospital { get; set; }

        public int HospitalAttId { get; set; }
        public virtual HospitalAtt HospitalAttended { get; set; }


        public int SocialWorkAttendanceId { get; set; }
        public virtual SocialWorkAttendance SocialWorkAttendence { get; set; }//y/n/na

        public int PoliceAttendanceId { get; set; }
        public virtual PoliceAttendance PoliceAttendence { get; set; } //Lookup y/n/na

        public int VictimServicesAttendanceId { get; set; }
        public virtual VictimServicesAttendance VictimServices { get; set; }//Lookup

        public int MedicalOnlyId { get; set; }
        public virtual MedicalOnly MedicalOnly { get; set; }

        public int EvidenceStoredId { get; set; }
        public virtual EvidenceStored Evidence { get; set; }

        public int HIVMedsId { get; set; }
        public virtual HIVMeds HIVMeds { get; set; }

        public int ReferCBVSId { get; set; }
        public virtual ReferCBVS ReferCBVS { get; set; }//y/n/pvbs/na

        public int PoliceReportedId { get; set; }
        public virtual PoliceReported PoliceReported { get; set; }

        public int ThirdPartyReportId { get; set; }
        public virtual ThirdPartyReport ThirdParty { get; set; }

        public int BadDateReportId { get; set; }
        public virtual BadDateReport BadDate { get; set; }
        public int NumTransportProvided { get; set; }
        public bool ReferToNurse { get; set; }
    }
}