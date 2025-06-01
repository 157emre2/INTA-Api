using INTA_Api.AppModules.Authentication;
using INTA_Api.AppModules.Modules;
using INTA_Api.Core;
using Microsoft.EntityFrameworkCore;

namespace INTA_Api.EntitySettings;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<INTA_Modules> INTA_Modules { get; set; }
    public DbSet<INTA_Users> INTA_Users { get; set; }

    public LanguageEnum CurrentLanguage { get; set; } = LanguageEnum.tr_TR;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<INTA_Modules>()
            .HasQueryFilter(x => !x.IsDeleted && x.Language.Equals(CurrentLanguage))
            .HasIndex(e => e.ModuleName)
            .IsUnique();

        modelBuilder.Entity<INTA_Users>()
            .Ignore(e => e.Language);
    }
}
