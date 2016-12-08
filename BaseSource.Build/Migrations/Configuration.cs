namespace BaseSource.Build.Migrations
{
    using Identity;
    using Identity.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BaseSource.Build.BuildDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BaseSource.Build.BuildDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "nphihung",
                Email = "nphihung@tma.com.vn",
                EmailConfirmed = true,
                Birthday = DateTime.Now,
                FullName = "Nguyen Phi Hung"
            };

            manager.Create(user, "12345678x@X");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("nphihung@tma.com.vn");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}