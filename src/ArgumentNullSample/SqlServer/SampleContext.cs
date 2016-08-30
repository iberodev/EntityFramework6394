using ArgumentNullSample.Model;
using ArgumentNullSample.SqlServer.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ArgumentNullSample.SqlServer
{
    public class SampleContext : IdentityDbContext<User>
    {
        public SampleContext(DbContextOptions<SampleContext> options) : base(options)
        {

        }

        public DbSet<App> Apps { get; set; }
        public DbSet<AppAccess> AppAccess { get; set; }
        public DbSet<BusinessApp> BusinessApps { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<UserBusiness> UserBusinesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Auth");

            // Sequence for generating unique invoice numbers
            modelBuilder.HasSequence<int>("InvoiceNumbers", "Auth")
                .StartsAt(1000000)
                .IncrementsBy(1);

            // Mappings
            new AppMap(modelBuilder.Entity<App>());
            new AppAccessMap(modelBuilder.Entity<AppAccess>());
            new BusinessAppMap(modelBuilder.Entity<BusinessApp>());
            new BusinessMap(modelBuilder.Entity<Business>());
            new GroupMap(modelBuilder.Entity<Group>());
            new GroupMemberMap(modelBuilder.Entity<GroupMember>());
            new UserMap(modelBuilder.Entity<User>());
            new UserBusinessMap(modelBuilder.Entity<UserBusiness>());

            // Ignore Asp Identity models that are not required
            modelBuilder.Ignore<IdentityRole>();
            modelBuilder.Ignore<IdentityRoleClaim<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                string tableName = entity.DisplayName();

                if (tableName == "IdentityUserClaim<string>")
                {
                    tableName = "UserClaim";
                }

                entity.Relational().TableName = tableName;
            }
        }
    }
}
