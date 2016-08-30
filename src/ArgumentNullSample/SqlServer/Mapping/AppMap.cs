using ArgumentNullSample.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArgumentNullSample.SqlServer.Mapping
{
    public class AppMap
    {
        public AppMap(EntityTypeBuilder<App> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);

            entityBuilder.HasMany(t => t.BusinessApps);

            entityBuilder.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(t => t.AppName)
                .IsRequired()
                .HasMaxLength(200);

            entityBuilder.Property(t => t.Description)
                .HasMaxLength(500);
        }
    }
}
