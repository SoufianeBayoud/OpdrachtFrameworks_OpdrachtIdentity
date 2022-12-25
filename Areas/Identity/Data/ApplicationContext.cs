using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpdrachtFrameworks.Areas.Identity.Data;

namespace OpdrachtFrameworks.Data;

public class ApplicationContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
    public DbSet<OpdrachtFrameworks.Models.Immo> Immo { get; set; }
    public DbSet<OpdrachtFrameworks.Models.Klant> Klant { get; set; }
    public DbSet<OpdrachtFrameworks.Models.Facture> Facture { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
