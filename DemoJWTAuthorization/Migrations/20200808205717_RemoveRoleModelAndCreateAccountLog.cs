using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoJWTAuthorization.Migrations
{
    public partial class RemoveRoleModelAndCreateAccountLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role",
                schema: "SSO");

            migrationBuilder.DropColumn(
                name: "FialedRepeat",
                schema: "SSO",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "InheritTypeID",
                schema: "SSO",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "LastFialed",
                schema: "SSO",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                schema: "SSO",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "LoginCount",
                schema: "SSO",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "SSO",
                table: "Account",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "Profile",
                table: "Person",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "SSO",
                schema: "SSO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Logined = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SSO_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "SSO",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SSO_AccountId",
                schema: "SSO",
                table: "SSO",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SSO",
                schema: "SSO");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "SSO",
                table: "Account",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Profile",
                table: "Person",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "FialedRepeat",
                schema: "SSO",
                table: "Account",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "InheritTypeID",
                schema: "SSO",
                table: "Account",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastFialed",
                schema: "SSO",
                table: "Account",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                schema: "SSO",
                table: "Account",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                schema: "SSO",
                table: "Account",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "SSO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    ParentRoleID = table.Column<int>(type: "int", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TitleFa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Role_Role_ParentRoleID",
                        column: x => x.ParentRoleID,
                        principalSchema: "SSO",
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Role_ParentRoleID",
                schema: "SSO",
                table: "Role",
                column: "ParentRoleID");
        }
    }
}
