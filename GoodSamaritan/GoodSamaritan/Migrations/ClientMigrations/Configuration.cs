namespace GoodSamaritan.Migrations.ClientMigrations
{
    using GoodSamaritan.Models.Client;
    using GoodSamaritan.Models.Smart;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GoodSamaritan.Models.Client.ClientContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\ClientMigrations";
        }

        protected override void Seed(GoodSamaritan.Models.Client.ClientContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            /*
            List<Client> Clients = new List<Client>() {
              new Client { 
                ClientId= 1, 
                Month=9,
                Day=17,
                Surname="Doe",
                FirstName="John",
                },            
              };

            context.Clients.AddOrUpdate(
                c => c.ClientId,
                Clients.ToArray()
            );
             * */
            //10-11; 11-12; 12-13; 13-14; 14-15; 15-16; 16-17
            List<FiscalYear> FiscalYears = new List<FiscalYear>() {
                new FiscalYear { FiscalYearName="10-11" },
                new FiscalYear { FiscalYearName="11-12" },
                new FiscalYear { FiscalYearName="12-13" },
                new FiscalYear { FiscalYearName="13-14" },
                new FiscalYear { FiscalYearName="14-15" },
                new FiscalYear { FiscalYearName="15-16" },
                new FiscalYear { FiscalYearName="16-17" },
              };

            context.FiscalYears.AddOrUpdate(
                f => f.FiscalYearId,
                FiscalYears.ToArray()
            );
            context.SaveChanges();

            context.RiskLevels.AddOrUpdate(
                  risk => risk.RiskLevelValue,
                  new RiskLevel { RiskLevelValue = "" },
                  new RiskLevel { RiskLevelValue = "High" },
                  new RiskLevel { RiskLevelValue = "DVU" }
            );
            context.SaveChanges();
            context.Crises.AddOrUpdate(
                  cri => cri.CrisisName,
                  new Crisis { CrisisName = "Call" },
                  new Crisis { CrisisName = "Accompaniment" },
                  new Crisis { CrisisName = "Drop-in" }
            );
            context.SaveChanges();

            context.Services.AddOrUpdate(
                  ser => ser.ServiceName,
                  new Service { ServiceName = "N/A" },
                  new Service { ServiceName = "File" }
            );
            context.SaveChanges();

            //Crisis; Court; SMART; DVU; MCFD
            context.Programs.AddOrUpdate(
                  pro => pro.ProgramName,
                  new Program { ProgramName = "Crisis" },
                  new Program { ProgramName = "Court" },
                  new Program { ProgramName = "SMART" },
                  new Program { ProgramName = "DVU" },
                  new Program { ProgramName = "MCFD" }
            );
            context.SaveChanges();

            context.RiskStatus.AddOrUpdate(
                  risks => risks.RiskStatusValue,
                  new RiskStatus { RiskStatusValue = "" },
                  new RiskStatus { RiskStatusValue = "Pending" },
                  new RiskStatus { RiskStatusValue = "Complete" }
            );
            context.SaveChanges();

            //Michelle; Tyra; Louise; Angela; Dave; Troy; Michael; Manpreet; Patrick; None
            context.AssignedWorkers.AddOrUpdate(
                  aw => aw.AssignedWorkerName,
                  new AssignedWorker { AssignedWorkerName = "None" },
                  new AssignedWorker { AssignedWorkerName = "Michelle" },
                  new AssignedWorker { AssignedWorkerName = "Tyra" },
                  new AssignedWorker { AssignedWorkerName = "Louise" },
                  new AssignedWorker { AssignedWorkerName = "Angela" },
                  new AssignedWorker { AssignedWorkerName = "Dave" },
                  new AssignedWorker { AssignedWorkerName = "Troy" },
                  new AssignedWorker { AssignedWorkerName = "Michael" },
                  new AssignedWorker { AssignedWorkerName = "Manpreet" },
                  new AssignedWorker { AssignedWorkerName = "Patrick" }
                  
            );
            context.SaveChanges();

            //Community Agency; Family/Friend; Government; CVAP; CBVS
            context.ReferralSources.AddOrUpdate(
                  refs => refs.Source,
                  new ReferralSource { Source = "Community Agency" },
                  new ReferralSource { Source = "Family/Friend" },
                  new ReferralSource { Source = "Government" },
                  new ReferralSource { Source = "CVAP" },
                  new ReferralSource { Source = "CBVS" }
            );
            context.SaveChanges();

            context.ReferralContacts.AddOrUpdate(
                  refc => refc.ReferralContactName,
                  new ReferralContact { ReferralContactName = "PBVS" },
                  new ReferralContact { ReferralContactName = "MCFD" },
                  new ReferralContact { ReferralContactName = "VictimLINK" },
                  new ReferralContact { ReferralContactName = "TH" },
                  new ReferralContact { ReferralContactName = "Self" },
                  new ReferralContact { ReferralContactName = "FNS" },
                  new ReferralContact { ReferralContactName = "Other" },
                  new ReferralContact { ReferralContactName = "Medical" }
            );
            context.SaveChanges();
            
            //Abduction; Adult Historical Sexual Assault; Adult Sexual Assault;
            //Partner Assault; Attempted Murder; Child Physical Assault;\
            //Child Sexual Abuse/Exploitation; Criminal Harassment/Stalking;
            //Elder Abuse; Human Trafficking; Murder; N/A; Other; Other Assault;
            //Other Crime – DV; Other Familial Assault; Threatening;
            //Youth Sexual Assault/Exploitation
            context.Incidents.AddOrUpdate(
                  inci => inci.IncidentType,
                  new Incident { IncidentType = "Abduction" },
                  new Incident { IncidentType = "Adult Historical Sexual Assault" },
                  new Incident { IncidentType = "Adult Sexual Assault" },
                  new Incident { IncidentType = "Partner Assault" },
                  new Incident { IncidentType = "Attempted Murder" },
                  new Incident { IncidentType = "Child Physical Assault" },
                  new Incident { IncidentType = "Child Sexual Abuse/Exploitation" },
                  new Incident { IncidentType = "Murder" },
                  new Incident { IncidentType = "N/A" },
                  new Incident { IncidentType = "Other" },
                  new Incident { IncidentType = "Other Assault" },
                  new Incident { IncidentType = "Other Crime – DV" },
                  new Incident { IncidentType = "Other Familial Assault" },
                  new Incident { IncidentType = "Threatening" },
                  new Incident { IncidentType = "Youth Sexual Assault/Exploitation" }
            );
            context.SaveChanges();

            //Acquaintance; Bad Date; DNA; Ex-Partner; Friend;
            //Multiple Perps; N/A; Other; Other Familial; Parent;
            //Partner; Sibling; Stranger
            context.AbuserRelationships.AddOrUpdate(
                  abuser => abuser.Type,
                  new AbuserRelationship { Type = "Acquaintance" },
                  new AbuserRelationship { Type = "Bad Date" },
                  new AbuserRelationship { Type = "DNA" },
                  new AbuserRelationship { Type = "Ex-Partner" },
                  new AbuserRelationship { Type = "Friend" },
                  new AbuserRelationship { Type = "Multiple Perps" },
                  new AbuserRelationship { Type = "N/A" },
                  new AbuserRelationship { Type = "Other" },
                  new AbuserRelationship { Type = "Other Familial" },
                  new AbuserRelationship { Type = "Parent" },
                  new AbuserRelationship { Type = "Partner" },
                  new AbuserRelationship { Type = "Sibling" },
                  new AbuserRelationship { Type = "Stranger" }
            );
            context.SaveChanges();

            context.Victims.AddOrUpdate(
                 vic => vic.VictimType,
                 new Victim { VictimType = "Primary" },
                 new Victim { VictimType = "Secondary" }
           );
            context.SaveChanges();

            context.FamilyViolenceFiles.AddOrUpdate(
                 fvf => fvf.Status,
                 new FamilyViolenceFile { Status = "N/A" },
                 new FamilyViolenceFile { Status = "Yes" },
                 new FamilyViolenceFile { Status = "No" }
            );
            context.SaveChanges();

            //Indigenous; Asian; Black; Caucasian; Declined;
            //Latin; Middle Eastern; Other; South Asian; South East Asian
            context.Ethnicities.AddOrUpdate(
                 eth => eth.Ethnictiy,
                 new Ethnicity { Ethnictiy = "Indigenous" },
                 new Ethnicity { Ethnictiy = "Asian" },
                 new Ethnicity { Ethnictiy = "Black" },
                 new Ethnicity { Ethnictiy = "Caucasian" },
                 new Ethnicity { Ethnictiy = "Declined" },
                 new Ethnicity { Ethnictiy = "Latin" },
                 new Ethnicity { Ethnictiy = "Middle Eastern" },
                 new Ethnicity { Ethnictiy = "Other" },
                 new Ethnicity { Ethnictiy = "South Asian" },
                 new Ethnicity { Ethnictiy = "South East Asian" }
            );
            context.SaveChanges();

            //Adult >24 <65; Youth >12 <19; Youth >18 <25; Child<13; Senior >64
            context.Ages.AddOrUpdate(
                 ag => ag.AgeRange,
                 new Age { AgeRange = "Adult  >24 <65" },
                 new Age { AgeRange = "Youth  >18 <25" },
                 new Age { AgeRange = "Youth  >12 <19" },
                 new Age { AgeRange = "Child  <13" },
                 new Age { AgeRange = "Senior >64" }
            );
            context.SaveChanges();

            context.RepeatClients.AddOrUpdate(
                 rc => rc.Repeat,
                 new RepeatClient { Repeat = "Yes" },
                 new RepeatClient { Repeat = "" }
            );
            context.SaveChanges();

            context.DuplicateFiles.AddOrUpdate(
                 df => df.IsDuplicate,
                 new DuplicateFile { IsDuplicate = "Yes" },
                 new DuplicateFile { IsDuplicate = "" }
            );
            context.SaveChanges();

            context.FileStatus.AddOrUpdate(
                 files => files.FileStatusString,
                 new FileStatus { FileStatusString = "Reopened" },
                 new FileStatus { FileStatusString = "Closed" },
                 new FileStatus { FileStatusString = "Open" }
            );
            context.SaveChanges();

            ////////
            //SMART
            ////////
            context.SexWorkExploitations.AddOrUpdate(
                  swe => swe.SexWorkExploitationValue,
                  new SexWorkExploitation { SexWorkExploitationValue = "Yes" },
                  new SexWorkExploitation { SexWorkExploitationValue = "No" },
                  new SexWorkExploitation { SexWorkExploitationValue = "N/A" }
            );
            context.SaveChanges();

            context.MultiplePerpetrators.AddOrUpdate(
                  mp => mp.MultiplePerpetratorValue,
                  new MultiplePerpetrator { MultiplePerpetratorValue = "Yes" },
                  new MultiplePerpetrator { MultiplePerpetratorValue = "No" },
                  new MultiplePerpetrator { MultiplePerpetratorValue = "N/A" }
            );
            context.SaveChanges();

            context.DrugFacilitatedAssaults.AddOrUpdate(
                  dfa => dfa.DrugFacilitatedAssaultValue,
                  new DrugFacilitatedAssault { DrugFacilitatedAssaultValue = "Yes" },
                  new DrugFacilitatedAssault { DrugFacilitatedAssaultValue = "No" },
                  new DrugFacilitatedAssault { DrugFacilitatedAssaultValue = "N/A" }
            );
            context.SaveChanges();

            //Surrey; Abbotsford; Agassiz; Boston Bar; Burnaby;
            //Chilliwack; Coquitlam; Delta; Harrison Hot Springs;
            //Hope; Langley; Maple Ridge; Mission; New Westminster;
            //Pitt Meadows; Port Coquitlam; Port Moody; Vancouver;
            //White Rock; Yale; Other – BC; Out-of-Province; International
            context.Cities.AddOrUpdate(
                  cit => cit.CityName,
                  new City { CityName = "Surrey" },
                  new City { CityName = "Abbotsford" },
                  new City { CityName = "Agassiz" },
                  new City { CityName = "Boston Bar" },
                  new City { CityName = "Burnaby" },
                  new City { CityName = "Chilliwack" },
                  new City { CityName = "Coquitlam" },
                  new City { CityName = "Delta" },
                  new City { CityName = "Harrison Hot Springs" },
                  new City { CityName = "Hope" },
                  new City { CityName = "Langley" },
                  new City { CityName = "Maple Ridge" },
                  new City { CityName = "Mission" },
                  new City { CityName = "New Westminster" },
                  new City { CityName = "Pitt Meadows" },
                  new City { CityName = "Port Coquitlam" },
                  new City { CityName = "Port Moody" },
                  new City { CityName = "Vancouver" },
                  new City { CityName = "White Rock" },
                  new City { CityName = "Yale" },
                  new City { CityName = "Other – BC" },
                  new City { CityName = "Out-of-Province" },
                  new City { CityName = "International" }
            );
            context.SaveChanges();
            
            context.CityRes.AddOrUpdate(
                  ctr => ctr.CityResName,
                  new CityRes { CityResName = "Surrey" },
                  new CityRes { CityResName = "Abbotsford" },
                  new CityRes { CityResName = "Agassiz" },
                  new CityRes { CityResName = "Boston Bar" },
                  new CityRes { CityResName = "Burnaby" },
                  new CityRes { CityResName = "Chilliwack" },
                  new CityRes { CityResName = "Coquitlam" },
                  new CityRes { CityResName = "Delta" },
                  new CityRes { CityResName = "Harrison Hot Springs" },
                  new CityRes { CityResName = "Hope" },
                  new CityRes { CityResName = "Langley" },
                  new CityRes { CityResName = "Maple Ridge" },
                  new CityRes { CityResName = "Mission" },
                  new CityRes { CityResName = "New Westminster" },
                  new CityRes { CityResName = "Pitt Meadows" },
                  new CityRes { CityResName = "Port Coquitlam" },
                  new CityRes { CityResName = "Port Moody" },
                  new CityRes { CityResName = "Vancouver" },
                  new CityRes { CityResName = "White Rock" },
                  new CityRes { CityResName = "Yale" },
                  new CityRes { CityResName = "Other – BC" },
                  new CityRes { CityResName = "Out-of-Province" },
                  new CityRes { CityResName = "International" }
            );
            context.SaveChanges();

            //Abbotsford Regional Hospital; Surrey Memorial Hospital; 
            //Burnaby Hospital; Chilliwack General Hospital; Delta Hospital;
            //Eagle Ridge Hospital; Fraser Canyon Hospital; Langley Hospital;
            //Mission Hospital; Peace Arch Hospital; Ridge Meadows Hospital;
            //Royal Columbia Hospital
            context.Hospitals.AddOrUpdate(
                  hos => hos.HospitalName,
                  new Hospital { HospitalName = "Abbotsford Regional Hospital" },
                  new Hospital { HospitalName = "Surrey Memorial Hospital" },
                  new Hospital { HospitalName = "Burnaby Hospital" },
                  new Hospital { HospitalName = "Chilliwack General Hospital" },
                  new Hospital { HospitalName = "Delta Hospital" },
                  new Hospital { HospitalName = "Eagle Ridge Hospital" },
                  new Hospital { HospitalName = "Fraser Canyon Hospital" },
                  new Hospital { HospitalName = "Langley Hospital" },
                  new Hospital { HospitalName = "Mission Hospital" },
                  new Hospital { HospitalName = "Peace Arch Hospital" },
                  new Hospital { HospitalName = "Ridge Meadows Hospital" },
                  new Hospital { HospitalName = "Royal Columbia Hospital" }
            );
            context.SaveChanges();

            context.HospitalAtts.AddOrUpdate(
                  hoa=> hoa.HospitalAttName,
                  new HospitalAtt { HospitalAttName = "Abbotsford Regional Hospital" },
                  new HospitalAtt { HospitalAttName = "Surrey Memorial Hospital" },
                  new HospitalAtt { HospitalAttName = "Burnaby Hospital" },
                  new HospitalAtt { HospitalAttName = "Chilliwack General Hospital" },
                  new HospitalAtt { HospitalAttName = "Delta Hospital" },
                  new HospitalAtt { HospitalAttName = "Eagle Ridge Hospital" },
                  new HospitalAtt { HospitalAttName = "Fraser Canyon Hospital" },
                  new HospitalAtt { HospitalAttName = "Langley Hospital" },
                  new HospitalAtt { HospitalAttName = "Mission Hospital" },
                  new HospitalAtt { HospitalAttName = "Peace Arch Hospital" },
                  new HospitalAtt { HospitalAttName = "Ridge Meadows Hospital" },
                  new HospitalAtt { HospitalAttName = "Royal Columbia Hospital" }
            );
            context.SaveChanges();

            context.SocialWorkAttendances.AddOrUpdate(
                  swa => swa.SocialWorkAttendanceValue,
                  new SocialWorkAttendance { SocialWorkAttendanceValue = "Yes" },
                  new SocialWorkAttendance { SocialWorkAttendanceValue = "No" },
                  new SocialWorkAttendance { SocialWorkAttendanceValue = "N/A" }
            );
            context.SaveChanges();

            context.PoliceAttendances.AddOrUpdate(
                  copa => copa.PoliceAttendanceValue,
                  new PoliceAttendance { PoliceAttendanceValue = "Yes" },
                  new PoliceAttendance { PoliceAttendanceValue = "No" },
                  new PoliceAttendance { PoliceAttendanceValue = "N/A" }
            );
            context.SaveChanges();

            context.VictimServicesAttendances.AddOrUpdate(
                  vsa => vsa.VictimServicesAttendanceValue,
                  new VictimServicesAttendance { VictimServicesAttendanceValue = "Yes" },
                  new VictimServicesAttendance { VictimServicesAttendanceValue = "No" },
                  new VictimServicesAttendance { VictimServicesAttendanceValue = "N/A" }
            );
            context.SaveChanges();

            context.MedicalOnlies.AddOrUpdate(
                  mo => mo.MedicalOnlyValue,
                  new MedicalOnly { MedicalOnlyValue = "Yes" },
                  new MedicalOnly { MedicalOnlyValue = "No" },
                  new MedicalOnly { MedicalOnlyValue = "N/A" }
            );
            context.SaveChanges();

            context.EvidenceStoreds.AddOrUpdate(
                  es => es.EvidenceStoredValue,
                  new EvidenceStored { EvidenceStoredValue = "Yes" },
                  new EvidenceStored { EvidenceStoredValue = "No" },
                  new EvidenceStored { EvidenceStoredValue = "N/A" }
            );
            context.SaveChanges();

            context.HIVMeds.AddOrUpdate(
                  hiv => hiv.HIVMedsValue,
                  new HIVMeds { HIVMedsValue = "Yes" },
                  new HIVMeds { HIVMedsValue = "No" },
                  new HIVMeds { HIVMedsValue = "N/A" }
            );
            context.SaveChanges();

            context.ReferCBVS.AddOrUpdate(
                  cbvs => cbvs.ReferCBVSValue,
                  new ReferCBVS { ReferCBVSValue = "Yes" },
                  new ReferCBVS { ReferCBVSValue = "No" },
                  new ReferCBVS { ReferCBVSValue = "PVBS only" },
                  new ReferCBVS { ReferCBVSValue = "N/A" }
            );
            context.SaveChanges();

            context.PoliceReporteds.AddOrUpdate(
                  copr => copr.PoliceReportedValue,
                  new PoliceReported { PoliceReportedValue = "Yes" },
                  new PoliceReported { PoliceReportedValue = "No" },
                  new PoliceReported { PoliceReportedValue = "N/A" }
            );
            context.SaveChanges();

            context.ThirdPartyReports.AddOrUpdate(
                  tpr => tpr.ThirdPartyReportValue,
                  new ThirdPartyReport { ThirdPartyReportValue = "Yes" },
                  new ThirdPartyReport { ThirdPartyReportValue = "No" },
                  new ThirdPartyReport { ThirdPartyReportValue = "N/A" }
            );
            context.SaveChanges();

            context.BadDateReports.AddOrUpdate(
                  bd => bd.BadDateReportValue,
                  new BadDateReport { BadDateReportValue = "Yes" },
                  new BadDateReport { BadDateReportValue = "No" },
                  new BadDateReport { BadDateReportValue = "N/A" }
            );
            context.SaveChanges();

        }
    }
}
