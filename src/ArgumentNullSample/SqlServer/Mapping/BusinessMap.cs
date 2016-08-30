using ArgumentNullSample.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArgumentNullSample.SqlServer.Mapping
{
    public class BusinessMap
    {
        public BusinessMap(EntityTypeBuilder<Business> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id)
                .ForSqlServerIsClustered(clustered: false);

            entityBuilder
                .HasIndex(t => t.CreatedOn)
                .ForSqlServerIsClustered(clustered: true);

            entityBuilder.HasIndex(t => t.CountryCode);

            entityBuilder.HasMany(t => t.UserBusinesses)
                .WithOne(ub => ub.Business);

            entityBuilder.HasMany(t => t.Groups)
                .WithOne(group => group.Business);

            entityBuilder.HasMany(t => t.BusinessApps);

            entityBuilder.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            entityBuilder.Property(t => t.CreatedOn)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired(true);

            entityBuilder.Property(t => t.ModifiedOn); // Set in code prior to call to SaveChanges

            entityBuilder.Property(t => t.RowVersion)
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken();

            entityBuilder.Property(t => t.BusinessName)
                .IsRequired()
                .HasMaxLength(70);

            entityBuilder.Property(t => t.AddressLine1)
                .IsRequired()
                .HasMaxLength(35);

            entityBuilder.Property(t => t.AddressLine2)
                .HasMaxLength(35);

            entityBuilder.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(35);

            entityBuilder.Property(t => t.Region)
                .HasMaxLength(35);

            entityBuilder.Property(t => t.PostalCode)
                .HasMaxLength(10);

            entityBuilder.Property(t => t.CountryCode)
                .IsRequired()
                .HasMaxLength(2);

            entityBuilder.Property(t => t.ContactName)
                .IsRequired()
                .HasMaxLength(70);

            entityBuilder.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasMaxLength(35);

            entityBuilder.Property(t => t.TimeZoneId)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(t => t.BillingCurrencyCode)
                .IsRequired()
                .HasMaxLength(3);
            
            entityBuilder.Property(t => t.IsTestBusiness);
        }
    }
}
