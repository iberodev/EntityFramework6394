using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ArgumentNullSample.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.CreateSequence<int>(
                name: "InvoiceNumbers",
                schema: "Auth",
                startValue: 1000000L);

            migrationBuilder.CreateTable(
                name: "App",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 100, nullable: false),
                    AppName = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    AddressLine1 = table.Column<string>(maxLength: 35, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 35, nullable: true),
                    BillingCurrencyCode = table.Column<string>(maxLength: 3, nullable: false),
                    BusinessName = table.Column<string>(maxLength: 70, nullable: false),
                    City = table.Column<string>(maxLength: 35, nullable: false),
                    ContactName = table.Column<string>(maxLength: 70, nullable: false),
                    CountryCode = table.Column<string>(maxLength: 2, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsTestBusiness = table.Column<bool>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 35, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 10, nullable: true),
                    Region = table.Column<string>(maxLength: 35, nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    TimeZoneId = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    BusinessId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    GroupName = table.Column<string>(maxLength: 100, nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Group_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalSchema: "Auth",
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Email = table.Column<string>(nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastLoggedInOn = table.Column<DateTime>(nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    PrimaryBusinessId = table.Column<Guid>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.UniqueConstraint("AK_User_Email", x => x.Email);
                    table.ForeignKey(
                        name: "FK_User_Business_PrimaryBusinessId",
                        column: x => x.PrimaryBusinessId,
                        principalSchema: "Auth",
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessApp",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    AppId = table.Column<string>(maxLength: 100, nullable: false),
                    ApprovedByUserId = table.Column<string>(maxLength: 450, nullable: true),
                    ApprovedOn = table.Column<DateTime>(nullable: true),
                    BusinessId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DeactivatedOn = table.Column<DateTime>(nullable: true),
                    DeactivationReason = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessApp", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_BusinessApp_BusinessId_AppId", x => new { x.BusinessId, x.AppId });
                    table.ForeignKey(
                        name: "FK_BusinessApp_App_AppId",
                        column: x => x.AppId,
                        principalSchema: "Auth",
                        principalTable: "App",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessApp_User_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessApp_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalSchema: "Auth",
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBusiness",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    BusinessId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    DeclarantCode = table.Column<string>(maxLength: 35, nullable: true),
                    DeclarantPin = table.Column<byte[]>(type: "varbinary(256)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    UserId = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBusiness", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_UserBusiness_UserId_BusinessId", x => new { x.UserId, x.BusinessId });
                    table.ForeignKey(
                        name: "FK_UserBusiness_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalSchema: "Auth",
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBusiness_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppAccess",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    BusinessAppId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UserBusinessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAccess", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_AppAccess_UserBusinessId_BusinessAppId", x => new { x.UserBusinessId, x.BusinessAppId });
                    table.ForeignKey(
                        name: "FK_AppAccess_BusinessApp_BusinessAppId",
                        column: x => x.BusinessAppId,
                        principalSchema: "Auth",
                        principalTable: "BusinessApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppAccess_UserBusiness_UserBusinessId",
                        column: x => x.UserBusinessId,
                        principalSchema: "Auth",
                        principalTable: "UserBusiness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupMember",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    GroupId = table.Column<Guid>(nullable: false),
                    UserBusinessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMember", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_GroupMember_UserBusinessId_GroupId", x => new { x.UserBusinessId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_GroupMember_Group_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Auth",
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMember_UserBusiness_UserBusinessId",
                        column: x => x.UserBusinessId,
                        principalSchema: "Auth",
                        principalTable: "UserBusiness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAccess_BusinessAppId",
                schema: "Auth",
                table: "AppAccess",
                column: "BusinessAppId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAccess_CreatedOn",
                schema: "Auth",
                table: "AppAccess",
                column: "CreatedOn")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_AppAccess_UserBusinessId",
                schema: "Auth",
                table: "AppAccess",
                column: "UserBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_CountryCode",
                schema: "Auth",
                table: "Business",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Business_CreatedOn",
                schema: "Auth",
                table: "Business",
                column: "CreatedOn")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessApp_AppId",
                schema: "Auth",
                table: "BusinessApp",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessApp_ApprovedByUserId",
                schema: "Auth",
                table: "BusinessApp",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessApp_BusinessId",
                schema: "Auth",
                table: "BusinessApp",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessApp_CreatedOn",
                schema: "Auth",
                table: "BusinessApp",
                column: "CreatedOn")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Group_BusinessId",
                schema: "Auth",
                table: "Group",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_CreatedOn",
                schema: "Auth",
                table: "Group",
                column: "CreatedOn")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_CreatedOn",
                schema: "Auth",
                table: "GroupMember",
                column: "CreatedOn")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_GroupId",
                schema: "Auth",
                table: "GroupMember",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_UserBusinessId",
                schema: "Auth",
                table: "GroupMember",
                column: "UserBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PrimaryBusinessId",
                schema: "Auth",
                table: "User",
                column: "PrimaryBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBusiness_BusinessId",
                schema: "Auth",
                table: "UserBusiness",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBusiness_CreatedOn",
                schema: "Auth",
                table: "UserBusiness",
                column: "CreatedOn")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBusiness_UserId",
                schema: "Auth",
                table: "UserBusiness",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                schema: "Auth",
                table: "UserClaim",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "InvoiceNumbers",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "AppAccess",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "GroupMember",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserClaim",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "BusinessApp",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserBusiness",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "App",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "Business",
                schema: "Auth");
        }
    }
}
