using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoJWTAuthorization.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profile.Person",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(maxLength: 256, nullable: false),
                    Lname = table.Column<string>(maxLength: 256, nullable: true),
                    NationalCode = table.Column<string>(maxLength: 20, nullable: true),
                    SabtCode = table.Column<string>(maxLength: 64, nullable: true),
                    TypeID = table.Column<short>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    EconomicCode = table.Column<string>(maxLength: 64, nullable: true),
                    provinceID = table.Column<long>(nullable: true),
                    CityID = table.Column<long>(nullable: true),
                    Address = table.Column<string>(maxLength: 2048, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 16, nullable: true),
                    Phone = table.Column<string>(maxLength: 16, nullable: true),
                    Job = table.Column<string>(maxLength: 512, nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    fax = table.Column<string>(maxLength: 16, nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    Education = table.Column<int>(nullable: true),
                    FatherName = table.Column<string>(maxLength: 128, nullable: true),
                    SabtDate = table.Column<DateTime>(nullable: true),
                    Mobile = table.Column<string>(maxLength: 11, nullable: true),
                    Site = table.Column<string>(maxLength: 256, nullable: true),
                    MaritalStatus = table.Column<short>(nullable: true),
                    Sex = table.Column<bool>(nullable: true),
                    Study = table.Column<string>(maxLength: 256, nullable: true),
                    LegalTypeID = table.Column<short>(nullable: true),
                    TypeGovernmentCompanyID = table.Column<short>(nullable: true),
                    GovernmentSharePercentage = table.Column<short>(nullable: true),
                    GroupType = table.Column<string>(maxLength: 512, nullable: true),
                    TransferList = table.Column<bool>(nullable: true),
                    LegalDocumentation = table.Column<string>(maxLength: 512, nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Religion = table.Column<short>(nullable: true),
                    Gilder = table.Column<short>(nullable: true),
                    Nationality = table.Column<short>(nullable: true),
                    OrganizationEmployee = table.Column<bool>(nullable: true),
                    RelationshipTypeId = table.Column<byte>(nullable: true),
                    FieldActivity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile.Person", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SSO.Roles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEn = table.Column<string>(maxLength: 150, nullable: false),
                    TitleFa = table.Column<string>(maxLength: 150, nullable: false),
                    ParentRoleID = table.Column<int>(nullable: true),
                    IsPrivate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSO.Roles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SSO.Roles_SSO.Roles_ParentRoleID",
                        column: x => x.ParentRoleID,
                        principalTable: "SSO.Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SSO.Account",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    FialedRepeat = table.Column<int>(nullable: true),
                    LastFialed = table.Column<DateTime>(nullable: true),
                    LoginCount = table.Column<int>(nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: true),
                    PersonID = table.Column<long>(nullable: false),
                    LastPasswordChanges = table.Column<DateTime>(nullable: true),
                    InheritTypeID = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSO.Account", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SSO.Account_Profile.Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Profile.Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SSO.Account_PersonID",
                table: "SSO.Account",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_SSO.Roles_ParentRoleID",
                table: "SSO.Roles",
                column: "ParentRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SSO.Account");

            migrationBuilder.DropTable(
                name: "SSO.Roles");

            migrationBuilder.DropTable(
                name: "Profile.Person");
        }
    }
}
