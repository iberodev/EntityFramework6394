using ArgumentNullSample.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArgumentNullSample.SqlServer.Mapping
{
    public class GroupMap
    {
        public GroupMap(EntityTypeBuilder<Group> entityBuilder)
        {
            entityBuilder
                .HasKey(t => t.Id)
                .ForSqlServerIsClustered(clustered: false);

            entityBuilder
                .HasIndex(t => t.CreatedOn)
                .ForSqlServerIsClustered(clustered: true);

            entityBuilder.HasOne(t => t.Business)
                .WithMany(business => business.Groups)
                .HasForeignKey(t => t.BusinessId)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.HasMany(t => t.Members);

            entityBuilder.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            entityBuilder.Property(t => t.CreatedOn)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()");

            entityBuilder.Property(t => t.ModifiedOn); // Set in code prior to call to SaveChanges

            entityBuilder.Property(t => t.RowVersion)
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            entityBuilder.Property(t => t.GroupName)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(t => t.Description)
                .HasMaxLength(200);
        }
    }
}
