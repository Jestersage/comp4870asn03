using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoodSamaritan.Models.Client
{
    public class ClientContext:DbContext
    {
        public ClientContext()
            : base("DefaultConnection")
        //{ Database.SetInitializer(new DropCreateDatabaseAlways<ClientContext>()); }
        { }
        public DbSet<Client> Clients{get; set;}

        public DbSet<AbuserRelationship> AbuserRelationships { get; set; }

        public DbSet<Age> Ages { get; set; }

        public DbSet<AssignedWorker> AssignedWorkers { get; set; }

        public DbSet<Crisis> Crises { get; set; }

        public DbSet<DuplicateFile> DuplicateFiles { get; set; }

        public DbSet<Ethnicity> Ethnicities { get; set; }

        public DbSet<FamilyViolenceFile> FamilyViolenceFiles { get; set; }

        public DbSet<Incident> Incidents { get; set; }

        public DbSet<FileStatus> FileStatus { get; set; }

        public DbSet<FiscalYear> FiscalYears { get; set; }

        public DbSet<Program> Programs { get; set; }

        public DbSet<ReferralContact> ReferralContacts { get; set; }

        public DbSet<ReferralSource> ReferralSources { get; set; }

        public DbSet<RepeatClient> RepeatClients { get; set; }

        public DbSet<RiskLevel> RiskLevels { get; set; }

        public DbSet<RiskStatus> RiskStatus { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Victim> Victims { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.BadDateReport> BadDateReports { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.City> Cities { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.DrugFacilitatedAssault> DrugFacilitatedAssaults { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.Smart> Smarts { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.EvidenceStored> EvidenceStoreds { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.HIVMeds> HIVMeds { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.Hospital> Hospitals { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.MedicalOnly> MedicalOnlies { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.MultiplePerpetrator> MultiplePerpetrators { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.PoliceAttendance> PoliceAttendances { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.PoliceReported> PoliceReporteds { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.ReferCBVS> ReferCBVS { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.SexWorkExploitation> SexWorkExploitations { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.SocialWorkAttendance> SocialWorkAttendances { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.ThirdPartyReport> ThirdPartyReports { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.VictimServicesAttendance> VictimServicesAttendances { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.CityRes> CityRes { get; set; }

        public System.Data.Entity.DbSet<GoodSamaritan.Models.Smart.HospitalAtt> HospitalAtts { get; set; }

        


    }
}