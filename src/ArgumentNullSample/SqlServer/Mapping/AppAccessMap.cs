using ArgumentNullSample.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArgumentNullSample.SqlServer.Mapping
{
    public class AppAccessMap
    {
        public AppAccessMap(EntityTypeBuilder<AppAccess> entityBuilder)
        {
            entityBuilder
                .HasKey(t => t.Id)
                .ForSqlServerIsClustered(clustered: false);

            entityBuilder.HasAlternateKey(t => new { t.UserBusinessId, t.BusinessAppId });

            entityBuilder
                .HasIndex(t => t.CreatedOn)
                .ForSqlServerIsClustered(clustered: true);

            entityBuilder.HasOne(aa => aa.UserBusiness)
                .WithMany(ub => ub.AppAccesses)
                .HasForeignKey(aa => aa.UserBusinessId)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.HasOne(aa => aa.BusinessApp)
                .WithMany(businessapp => businessapp.AppAccess)
                .HasForeignKey(aa => aa.BusinessAppId)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            entityBuilder.Property(t => t.UserBusinessId);

            entityBuilder.Property(t => t.BusinessAppId);

            entityBuilder.Property(t => t.CreatedOn)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired(true);
        }
    }
}
