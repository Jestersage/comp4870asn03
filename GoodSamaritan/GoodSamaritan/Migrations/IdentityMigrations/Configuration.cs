namespace GoodSamaritan.Migrations.IdentityMigrations
{
    using GoodSamaritan.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GoodSamaritan.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\IdentityMigrations";
        }

        protected override void Seed(GoodSamaritan.Models.ApplicationDbContext context)
        {
             
            if (!context.Users.Any(u => u.Email == "adam@gs.ca"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                  
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = "adam@gs.ca" };
                user.Email = "adam@gs.ca";
               userManager.Create(user, "P@$$w0rd");
              
               roleManager.Create(new IdentityRole("Administrator"));
               userManager.AddToRole(user.Id, "Administrator");

            }

            if (!context.Users.Any(u => u.Email == "wendy@gs.ca"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = "wendy@gs.ca" };
                user.Email = "wendy@gs.ca";
                userManager.Create(user, "P@$$w0rd");

                roleManager.Create(new IdentityRole("Worker"));
                userManager.AddToRole(user.Id, "Worker");

            }


            if (!context.Users.Any(u => u.Email == "rob@gs.ca"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = "rob@gs.ca" };
                user.Email = "rob@gs.ca";
                userManager.Create(user, "P@$$w0rd");

                roleManager.Create(new IdentityRole("Report"));
                userManager.AddToRole(user.Id, "Report");

            }
        }
        
        }
    
}
