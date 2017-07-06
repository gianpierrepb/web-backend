namespace Moments.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Moments.Models;
    using Moments.Models.DataModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Moments.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            // New timeout in seconds
            this.CommandTimeout = 60 * 5;
        }

        protected override void Seed(Moments.Models.ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(
              p => p.Name,
              new IdentityRole { Name = "USER" },
              new IdentityRole { Name = "ADMIN" }
            );


            if (!(context.Users.Any(u => u.UserName == "vmanuelad@gmail.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "vmanuelad@gmail.com", Email = "vmanuelad@gmail.com", NombreCompleto = "Manuel Ivan Alzamora Flores" };
                userManager.Create(userToInsert, "moments12324");

                userManager.AddToRole(userToInsert.Id, "ADMIN");
            }
            if (!(context.Users.Any(u => u.UserName == "vmanuelad1@gmail.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "vmanuelad1@gmail.com", Email = "vmanuelad1@gmail.com", NombreCompleto = "Manuel Ivan Alzamora Flores(ADMIN)" };
                userManager.Create(userToInsert, "moments12324");

                userManager.AddToRole(userToInsert.Id, "USER");
            }

            context.Plan.AddOrUpdate(
             p => p.description,
             new Plan { description = "PREMIUM" },
             new Plan { description = "NORMAL" }
           );
        }
    }
}
