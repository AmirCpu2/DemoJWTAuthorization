using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoJWTAuthorization.Migrations
{
    public partial class ChengeSchema3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Role_PersonID",
                schema: "SSO",
                table: "Account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                schema: "SSO",
                table: "Role");

            migrationBuilder.EnsureSchema(
                name: "Profile");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "SSO",
                newName: "Person",
                newSchema: "Profile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                schema: "Profile",
                table: "Person",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Person_PersonID",
                schema: "SSO",
                table: "Account",
                column: "PersonID",
                principalSchema: "Profile",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Person_PersonID",
                schema: "SSO",
                table: "Account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                schema: "Profile",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                schema: "Profile",
                newName: "Role",
                newSchema: "SSO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                schema: "SSO",
                table: "Role",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Role_PersonID",
                schema: "SSO",
                table: "Account",
                column: "PersonID",
                principalSchema: "SSO",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
