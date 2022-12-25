using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OpdrachtFrameworks.Areas.Identity.Data;

namespace OpdrachtFrameworks.Data
{
    public class SeedDatacontext
    {
            
        public static void Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            using (var context = new ApplicationContext(serviceProvider.GetRequiredService

            <DbContextOptions<ApplicationContext>>()))
            {
                ApplicationUser user = null;
                context.Database.EnsureCreated();    // Zorg dat de databank bestaat

                if(!context.Users.Any())
                {
                    user = new ApplicationUser
                    {
                        Firstname = "System",
                        Lastname = "Administrator",
                        UserName = "Sysadmin",
                        Email = "System.Administrator@Test.be",
                        EmailConfirmed = true
                    };
                    userManager.CreateAsync(user, "Abc!12345");

                    context.Roles.AddRange(
                         new IdentityRole
                        {
                            Id = "User",
                            Name = "User",
                            NormalizedName="USER"
                        },
                          new IdentityRole
                          {
                              Id = "SystemAdministrator",
                              Name = "SystemAdministrator",
                              NormalizedName = "systemadministrator"
                          }

                    );
                }
                /*
                if (!context.Immo.Any())
                {
                    context.Immo.AddRange(

                        new Models.Immo
                        {
                            
                            naam = "x",
                            straat = "dd",
                            description = "fdsfsd",
                            huisnummer = 8,
                            gemeente = 12458,
                            prijs = 1,
                            bouwjaar = 1909,
                            kamers = 4,
                            grootte = 90,
                            tuin = "zz",
                            type = "kdjf"
                        }
                    );
                    context.SaveChanges();
                }

                if (!context.Klant.Any())
                {
                    context.Klant.AddRange(

                        new Models.Klant
                        {
                           
                            naam = "x",
                            straat = "dd",
                            huisnummer = 8,
                            email = "souf"

                        }
                    );
                    context.SaveChanges();
                }

                if (!context.Facture.Any())
                {
                    context.Facture.AddRange(

                        new Models.Facture
                        {
                            
                            naam = "x",
                            prijs = 50

                        }
                    );
                    context.SaveChanges();
                }
                */
                if(user != null)
                {
                    context.UserRoles.AddRange(
                        new IdentityUserRole<string> { UserId = user.Id, RoleId = "UserAdministrator" },
                        new IdentityUserRole<string> { UserId = user.Id, RoleId = "SystemAdministrator" },
                        new IdentityUserRole<string> { UserId = user.Id, RoleId = "User" });
                    context.SaveChanges();
                }




            }
        }
    }
}
