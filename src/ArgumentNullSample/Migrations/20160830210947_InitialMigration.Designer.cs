using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ArgumentNullSample.SqlServer;

namespace ArgumentNullSample.Migrations
{
    [DbContext(typeof(SampleContext))]
    [Migration("20160830210947_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDefaultSchema("Auth")
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("Relational:Sequence:Auth.InvoiceNumbers", "'InvoiceNumbers', 'Auth', '1000000', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ArgumentNullSample.Model.App", b =>
                {
                    b.Property<string>("Id")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("AppName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.HasKey("Id");

                    b.ToTable("App");
                });

            modelBuilder.Entity("ArgumentNullSample.Model.AppAccess", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("BusinessAppId");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<Guid>("UserBusinessId");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasAlternateKey("UserBusinessId", "BusinessAppId");

                    b.HasIndex("BusinessAppId");

                    b.HasIndex("CreatedOn")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("UserBusinessId");

                    b.ToTable("AppAccess");
                });

            modelBuilder.Entity("ArgumentNullSample.Model.Business", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 35);

                    b.Property<string>("AddressLine2")
                        .HasAnnotation("MaxLength", 35);

                    b.Property<string>("BillingCurrencyCode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 3);

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 70);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 35);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 70);

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 2);

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<bool>("IsTestBusiness");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 35);

                    b.Property<string>("PostalCode")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Region")
                        .HasAnnotation("MaxLength", 35);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("TimeZoneId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("CountryCode");

                    b.HasIndex("CreatedOn")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Business");
                });

            modelBuilder.Entity("ArgumentNullSample.Model.BusinessApp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("AppId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("ApprovedByUserId")
                        .HasAnnotation("MaxLength", 450);

                    b.Property<DateTime?>("ApprovedOn");

                    b.Property<Guid>("BusinessId");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime?>("DeactivatedOn");

                    b.Property<string>("DeactivationReason")
                        .HasAnnotation("MaxLength", 200);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasAlternateKey("BusinessId", "AppId");

                    b.HasIndex("AppId");

                    b.HasIndex("ApprovedByUserId");

                    b.HasIndex("BusinessId");

                    b.HasIndex("CreatedOn")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("BusinessApp");
                });

            modelBuilder.Entity("ArgumentNullSample.Model.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("BusinessId");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("BusinessId");

                    b.HasIndex("CreatedOn")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Group");
                });

            modelBuilder.Entity("ArgumentNullSample.Model.GroupMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<Guid>("GroupId");

                    b.Property<Guid>("UserBusinessId");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasAlternateKey("UserBusinessId", "GroupId");

                    b.HasIndex("CreatedOn")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("GroupId");

                    b.HasIndex("UserBusinessId");

                    b.ToTable("GroupMember");
                });

            modelBuilder.Entity("ArgumentNullSample.Model.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime?>("LastLoggedInOn");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<Guid?>("PrimaryBusinessId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("PrimaryBusinessId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ArgumentNullSample.Model.UserBusiness", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("BusinessId");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("DeclarantCode")
                        .HasAnnotation("MaxLength", 35);

                    b.Property<byte[]>("DeclarantPin")
                        .HasColumnType("varbinary(256)");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 450);

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasAlternateKey("UserId", "BusinessId");

                    b.HasIndex("BusinessId");

                    b.HasIndex("CreatedOn")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("UserId");

                    b.ToTable("UserBusiness");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("ArgumentNullSample.Model.AppAccess", b =>
                {
                    b.HasOne("ArgumentNullSample.Model.BusinessApp", "BusinessApp")
                        .WithMany("AppAccess")
                        .HasForeignKey("BusinessAppId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ArgumentNullSample.Model.UserBusiness", "UserBusiness")
                        .WithMany("AppAccesses")
                        .HasForeignKey("UserBusinessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ArgumentNullSample.Model.BusinessApp", b =>
                {
                    b.HasOne("ArgumentNullSample.Model.App", "App")
                        .WithMany("BusinessApps")
                        .HasForeignKey("AppId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ArgumentNullSample.Model.User", "ApprovedByUser")
                        .WithMany()
                        .HasForeignKey("ApprovedByUserId");

                    b.HasOne("ArgumentNullSample.Model.Business", "Business")
                        .WithMany("BusinessApps")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ArgumentNullSample.Model.Group", b =>
                {
                    b.HasOne("ArgumentNullSample.Model.Business", "Business")
                        .WithMany("Groups")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ArgumentNullSample.Model.GroupMember", b =>
                {
                    b.HasOne("ArgumentNullSample.Model.Group", "Group")
                        .WithMany("Members")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ArgumentNullSample.Model.UserBusiness", "UserBusiness")
                        .WithMany("GroupMemberships")
                        .HasForeignKey("UserBusinessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ArgumentNullSample.Model.User", b =>
                {
                    b.HasOne("ArgumentNullSample.Model.Business", "PrimaryBusiness")
                        .WithMany()
                        .HasForeignKey("PrimaryBusinessId");
                });

            modelBuilder.Entity("ArgumentNullSample.Model.UserBusiness", b =>
                {
                    b.HasOne("ArgumentNullSample.Model.Business", "Business")
                        .WithMany("UserBusinesses")
                        .HasForeignKey("BusinessId");

                    b.HasOne("ArgumentNullSample.Model.User", "User")
                        .WithMany("UserBusinesses")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ArgumentNullSample.Model.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
