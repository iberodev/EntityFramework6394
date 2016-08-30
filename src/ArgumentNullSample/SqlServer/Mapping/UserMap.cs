using ArgumentNullSample.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArgumentNullSample.SqlServer.Mapping
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasAlternateKey(t => t.Email);

            entityBuilder.HasMany(t => t.UserBusinesses);

            entityBuilder.HasOne(t => t.PrimaryBusiness);

            entityBuilder.Property(t => t.CreatedOn)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired(true);

            entityBuilder.Property(t => t.ModifiedOn); // Set in code prior to call to SaveChanges

            entityBuilder.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            entityBuilder.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            entityBuilder.Property(t => t.LastLoggedInOn);

            entityBuilder.Ignore(t => t.FullName);

            entityBuilder.ToTable("User");
        }
    }
}
