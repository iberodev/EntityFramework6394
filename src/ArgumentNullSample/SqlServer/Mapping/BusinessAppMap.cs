using ArgumentNullSample.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArgumentNullSample.SqlServer.Mapping
{
    public class BusinessAppMap
    {
        public BusinessAppMap(EntityTypeBuilder<BusinessApp> entityBuilder)
        {
            entityBuilder
                .HasKey(t => t.Id)
                .ForSqlServerIsClustered(clustered: false);

            entityBuilder.HasAlternateKey(t => new { t.BusinessId, t.AppId });

            entityBuilder
                .HasIndex(t => t.CreatedOn)
                .ForSqlServerIsClustered(clustered: true);

            entityBuilder.HasMany(t => t.AppAccess);

            entityBuilder.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            entityBuilder.Property(t => t.BusinessId);

            entityBuilder.Property(t => t.AppId)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(t => t.CreatedOn)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()");

            entityBuilder.Property(t => t.DeactivatedOn);

            entityBuilder.Property(t => t.DeactivationReason)
                .HasMaxLength(200);

            entityBuilder.Property(t => t.ApprovedOn);

            entityBuilder.Property(t => t.ApprovedByUserId)
                .HasMaxLength(450);

            entityBuilder.HasOne(t => t.ApprovedByUser);
        }
    }
}
