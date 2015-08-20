using GoodSamaritan.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GoodSamaritan.Controllers.Role
{
    public class RoleController : Controller
    {
        [Authorize(Roles = "Administrator")]
        public ActionResult DisableUser()
        {
            List<string> users;
            List<string> enabledUsers;
            List<string> disabledUsers;
            using (var ctx = new ApplicationDbContext())
            {
                var userStore = new UserStore<ApplicationUser>(ctx);
                var userManager = new UserManager<ApplicationUser>(userStore);
                users = (from u in userManager.Users select u.UserName).ToList();
                disabledUsers = new List<string>(users);
                enabledUsers = new List<string>(users);
                foreach (var user in users)
                {
                    if (!userManager.FindByName(user).LockoutEnabled)
                    {
                        disabledUsers.Remove(user);
                    }
                    else
                    {
                        enabledUsers.Remove(user);
                    }
                }
                ViewBag.EnabledUsers = new SelectList(enabledUsers);
                ViewBag.DisabledUsers = new SelectList(disabledUsers);
            }
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult> DisableUser(string userName)
        {

   
            List<string> users;
            List<string> enabledUsers;
            List<string> disabledUsers;
            using (var context = new ApplicationDbContext())
            {

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var selectedUser = userManager.FindByName(userName);

                if (selectedUser == null)
                    throw new Exception("User not found!");

                if (!selectedUser.UserName.Equals("adam@gs.ca"))
                {


                    if (!selectedUser.LockoutEnabled)
                    {
                        userManager.SetLockoutEnabled(selectedUser.Id, true);
                        DateTime lockoutDate = DateTime.Now.AddYears(50);
                        await userManager.SetLockoutEndDateAsync(selectedUser.Id, lockoutDate);
                        context.SaveChanges();
                        userManager.Update(selectedUser);
                        ViewBag.ResultMessage = "Disabled successfully !";

                    }
                }
                else
                {
                    ViewBag.ResultMessage = "Cannot disable Admin";
                }

                users = (from u in userManager.Users select u.UserName).ToList();
                disabledUsers = new List<string>(users);
                enabledUsers = new List<string>(users);
                foreach (var user in users)
                {
                    if (!userManager.FindByName(user).LockoutEnabled)
                    {
                        disabledUsers.Remove(user);
                    }
                    else
                    {
                        enabledUsers.Remove(user);
                    }
                }
            }

            ViewBag.EnabledUsers = new SelectList(enabledUsers);
            ViewBag.DisabledUsers = new SelectList(disabledUsers);
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult EnableUser(string userName)
        {

            List<string> users;
            List<string> enabledUsers;
            List<string> disabledUsers;
            using (var context = new ApplicationDbContext())
            {

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var selectedUser = userManager.FindByName(userName);
                if (selectedUser == null)
                    throw new Exception("User not found!");
                if (selectedUser.LockoutEnabled)
                {
                    userManager.SetLockoutEnabled(selectedUser.Id, false);
                    context.SaveChanges();
                    userManager.Update(selectedUser);


                }


                users = (from u in userManager.Users select u.UserName).ToList();
                disabledUsers = new List<string>(users);
                enabledUsers = new List<string>(users);
                foreach (var user in users)
                {
                    if (!userManager.FindByName(user).LockoutEnabled)
                    {
                        disabledUsers.Remove(user);
                    }
                    else
                    {
                        enabledUsers.Remove(user);
                    }
                }
            }
            ViewBag.ResultMessage = "Enabled successfully !";
            ViewBag.EnabledUsers = new SelectList(enabledUsers);
            ViewBag.DisabledUsers = new SelectList(disabledUsers);
            return View("DisableUser");
        }


        [Authorize(Roles = "Administrator")]
        public ActionResult RoleCreate()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleCreate(string roleName)
        {
            if (roleName != "")
            {
                using (var context = new ApplicationDbContext())
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);

                    roleManager.Create(new IdentityRole(roleName));
                    context.SaveChanges();
                }

                ViewBag.ResultMessage = "Role created successfully !";
                return RedirectToAction("RoleIndex", "Role");

            }

            ViewBag.ResultMessage = "Cannot create empty role name";
            return View("RoleCreate");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult RoleIndex()
        {
            List<string> roles;
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                roles = (from r in roleManager.Roles select r.Name).ToList();
            }

            return View(roles.ToList());
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult RoleDelete(string roleName)
        {
            if (roleName != "Administrator")
            {
                using (var context = new ApplicationDbContext())
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);
                    var role = roleManager.FindByName(roleName);

                    roleManager.Delete(role);
                    context.SaveChanges();
                }

                ViewBag.ResultMessage = "Role deleted succesfully !";
                return RedirectToAction("RoleIndex", "Role");
            }


             ViewBag.ResultMessage = "Can't delete Admin!";
             return RedirectToAction("RoleIndex", "Role");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult RoleAddToUser()
        {
            List<string> roles;
            List<string> users;
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                users = (from u in userManager.Users select u.UserName).ToList();
                roles = (from r in roleManager.Roles select r.Name).ToList();
            }

            ViewBag.Roles = new SelectList(roles);
            ViewBag.Users = new SelectList(users);
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string roleName, string userName)
        {
            List<string> roles;
            List<string> users;
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                users = (from u in userManager.Users select u.UserName).ToList();

                var user = userManager.FindByName(userName);
                if (user == null)
                    throw new Exception("User not found!");

                var role = roleManager.FindByName(roleName);
                if (role == null)
                    throw new Exception("Role not found!");

                if (userManager.IsInRole(user.Id, role.Name))
                {
                    ViewBag.ResultMessage = "This user already has the role specified !";
                }
                else
                {
                    userManager.AddToRole(user.Id, role.Name);
                    context.SaveChanges();

                    ViewBag.ResultMessage = "Username added to the role succesfully !";
                }

                roles = (from r in roleManager.Roles select r.Name).ToList();
            }

            ViewBag.Roles = new SelectList(roles);
            ViewBag.Users = new SelectList(users);
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                List<string> userRoles;
                List<string> roles;
                List<string> users;
                using (var context = new ApplicationDbContext())
                {
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);

                    roles = (from r in roleManager.Roles select r.Name).ToList();

                    var userStore = new UserStore<ApplicationUser>(context);
                    var userManager = new UserManager<ApplicationUser>(userStore);

                    users = (from u in userManager.Users select u.UserName).ToList();

                    var user = userManager.FindByName(userName);
                    if (user == null)
                        throw new Exception("User not found!");

                    var userRoleIds = (from r in user.Roles select r.RoleId);
                    userRoles = (from id in userRoleIds
                                 let r = roleManager.FindById(id)
                                 select r.Name).ToList();
                }

                ViewBag.Roles = new SelectList(roles);
                ViewBag.Users = new SelectList(users);
                ViewBag.RolesForThisUser = userRoles;
            }

            return View("RoleAddToUser");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string userName, string roleName)
        {
            List<string> userRoles;
            List<string> roles;
            List<string> users;
            using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                roles = (from r in roleManager.Roles select r.Name).ToList();

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                users = (from u in userManager.Users select u.UserName).ToList();

                var user = userManager.FindByName(userName);
                if (user == null)
                    throw new Exception("User not found!");

                if (userManager.IsInRole(user.Id, roleName))
                {
                    userManager.RemoveFromRole(user.Id, roleName);
                    context.SaveChanges();

                    ViewBag.ResultMessage = "Role removed from this user successfully !";
                }
                else
                {
                    ViewBag.ResultMessage = "This user doesn't belong to selected role.";
                }

                var userRoleIds = (from r in user.Roles select r.RoleId);
                userRoles = (from id in userRoleIds
                             let r = roleManager.FindById(id)
                             select r.Name).ToList();
            }

            ViewBag.RolesForThisUser = userRoles;
            ViewBag.Roles = new SelectList(roles);
            ViewBag.Users = new SelectList(users);
            return View("RoleAddToUser");
        }
    }
}