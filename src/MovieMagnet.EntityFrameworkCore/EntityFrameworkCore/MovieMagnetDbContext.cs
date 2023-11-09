using Microsoft.EntityFrameworkCore;
using MovieMagnet.Genres;
using MovieMagnet.Keywords;
using MovieMagnet.Languages;
using MovieMagnet.MovieCompanies;
using MovieMagnet.MovieCountries;
using MovieMagnet.MovieGenres;
using MovieMagnet.MovieKeywords;
using MovieMagnet.Movies;
using MovieMagnet.ProductionCompanies;
using MovieMagnet.ProductionCountries;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace MovieMagnet.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class MovieMagnetDbContext :
    AbpDbContext<MovieMagnetDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Keyword> Keywords { get; set; }
    public DbSet<ProductionCountry> ProductionCountries { get; set; }
    public DbSet<ProductionCompany> ProductionCompanies { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<MovieCountry> MovieCountries { get; set; }
    public DbSet<MovieCompany> MovieCompanies { get; set; }
    public DbSet<MovieKeyword> MovieKeywords { get; set; }
    
    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public MovieMagnetDbContext(DbContextOptions<MovieMagnetDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(MovieMagnetConsts.DbTablePrefix + "YourEntities", MovieMagnetConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        
        builder.Entity<MovieGenre>(b =>
        {
            b.ToTable("MovieGenres");
            b.HasKey(x => new { x.MovieId, x.GenreId });
            b.HasOne(x => x.Movie).WithMany(x => x.MovieGenres).HasForeignKey(x => x.MovieId);
            b.HasOne(x => x.Genre).WithMany(x => x.MovieGenres).HasForeignKey(x => x.GenreId);
        });
        
        builder.Entity<MovieCountry>(b =>
        {
            b.ToTable("MovieCountries");
            b.HasKey(x => new { x.MovieId, x.CountryId });
            b.HasOne(x => x.Movie).WithMany(x => x.MovieCountries).HasForeignKey(x => x.MovieId);
            b.HasOne(x => x.Country).WithMany(x => x.MovieCountries).HasForeignKey(x => x.CountryId);
        });
        
        builder.Entity<MovieCompany>(b =>
        {
            b.ToTable("MovieCompanies");
            b.HasKey(x => new { x.MovieId, x.CompanyId });
            b.HasOne(x => x.Movie).WithMany(x => x.MovieCompanies).HasForeignKey(x => x.MovieId);
            b.HasOne(x => x.Company).WithMany(x => x.MovieCompanies).HasForeignKey(x => x.CompanyId);
        });
        
        builder.Entity<MovieKeyword>(b =>
        {
            b.ToTable("MovieKeywords");
            b.HasKey(x => new { x.MovieId, x.KeywordId });
            b.HasOne(x => x.Movie).WithMany(x => x.MovieKeywords).HasForeignKey(x => x.MovieId);
            b.HasOne(x => x.Keyword).WithMany(x => x.MovieKeywords).HasForeignKey(x => x.KeywordId);
        });
        
        builder.Entity<Movie>(b =>
        {
            b.ToTable("Movies");
            b.Property(x => x.Title).IsRequired().HasMaxLength(MovieConsts.MaxTitleLength);
            b.Property(x => x.Language).IsRequired().HasMaxLength(MovieConsts.MaxLanguageLength);
            b.Property(x => x.Overview).IsRequired().HasMaxLength(512);
            b.HasIndex(x => x.ImdbId).IsUnique();
            b.HasMany(x => x.MovieGenres).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId);
            b.HasMany(x => x.MovieCountries).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId);
            b.HasMany(x => x.MovieCompanies).WithOne(x => x.Movie).HasForeignKey(x => x.MovieId);
        });
    }
}
