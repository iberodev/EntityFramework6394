using ArgumentNullSample.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArgumentNullSample.SqlServer.Mapping
{
    public class UserBusinessMap
    {
        public UserBusinessMap(EntityTypeBuilder<UserBusiness> entityBuilder)
        {
            entityBuilder
                .HasKey(t => t.Id)
                .ForSqlServerIsClustered(clustered: false);

            entityBuilder.HasAlternateKey(t => new { t.UserId, t.BusinessId });

            entityBuilder
                .HasIndex(t => t.CreatedOn)
                .ForSqlServerIsClustered(clustered: true);

            entityBuilder.HasMany(t => t.AppAccesses)
                .WithOne(aa => aa.UserBusiness);

            entityBuilder.HasMany(t => t.GroupMemberships)
                .WithOne(aa => aa.UserBusiness);

            entityBuilder
                .HasOne(ub => ub.User)
                .WithMany(u => u.UserBusinesses)
                .HasForeignKey(ub => ub.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder
                .HasOne(ub => ub.Business)
                .WithMany(b => b.UserBusinesses)
                .HasForeignKey(ub => ub.BusinessId)
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            entityBuilder.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(450);

            entityBuilder.Property(t => t.CreatedOn)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()");

            entityBuilder.Property(t => t.ModifiedOn); // Set in code prior to call to SaveChanges

            entityBuilder.Property(t => t.RowVersion)
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            entityBuilder.Property(t => t.DeclarantCode)
                .HasMaxLength(35);

            entityBuilder.Property(t => t.DeclarantPin)
                .HasColumnType("varbinary(256)");
        }
    }
}
