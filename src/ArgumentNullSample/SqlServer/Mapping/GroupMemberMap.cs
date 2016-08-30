using ArgumentNullSample.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArgumentNullSample.SqlServer.Mapping
{
    public class GroupMemberMap
    {
        public GroupMemberMap(EntityTypeBuilder<GroupMember> entityBuilder)
        {
            entityBuilder
                .HasKey(t => t.Id)
                .ForSqlServerIsClustered(clustered: false);

            entityBuilder.HasAlternateKey(t => new { t.UserBusinessId, t.GroupId });

            entityBuilder
                .HasIndex(t => t.CreatedOn)
                .ForSqlServerIsClustered(clustered: true);

            entityBuilder.HasOne(t => t.UserBusiness)
                .WithMany(userbusines => userbusines.GroupMemberships)
                .HasForeignKey(t => t.UserBusinessId)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.HasOne(t => t.Group)
                .WithMany(group => group.Members)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            entityBuilder.Property(t => t.UserBusinessId);

            entityBuilder.Property(t => t.GroupId);

            entityBuilder.Property(t => t.CreatedOn)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
