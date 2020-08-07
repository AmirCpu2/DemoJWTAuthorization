using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoJWTAuthorization.Migrations
{
    public partial class ChengeSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SSO.Account_Profile.Person_PersonID",
                table: "SSO.Account");

            migrationBuilder.DropForeignKey(
                name: "FK_SSO.Roles_SSO.Roles_ParentRoleID",
                table: "SSO.Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SSO.Roles",
                table: "SSO.Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SSO.Account",
                table: "SSO.Account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile.Person",
                table: "Profile.Person");

            migrationBuilder.EnsureSchema(
                name: "SSO");

            migrationBuilder.RenameTable(
                name: "SSO.Roles",
                newName: "Roles",
                newSchema: "SSO");

            migrationBuilder.RenameTable(
                name: "SSO.Account",
                newName: "Account",
                newSchema: "SSO");

            migrationBuilder.RenameTable(
                name: "Profile.Person",
                newName: "Role",
                newSchema: "SSO");

            migrationBuilder.RenameIndex(
                name: "IX_SSO.Roles_ParentRoleID",
                schema: "SSO",
                table: "Roles",
                newName: "IX_Roles_ParentRoleID");

            migrationBuilder.RenameIndex(
                name: "IX_SSO.Account_PersonID",
                schema: "SSO",
                table: "Account",
                newName: "IX_Account_PersonID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                schema: "SSO",
                table: "Roles",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Account",
                schema: "SSO",
                table: "Account",
                column: "ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Roles_ParentRoleID",
                schema: "SSO",
                table: "Roles",
                column: "ParentRoleID",
                principalSchema: "SSO",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Role_PersonID",
                schema: "SSO",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Roles_ParentRoleID",
                schema: "SSO",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                schema: "SSO",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                schema: "SSO",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Account",
                schema: "SSO",
                table: "Account");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "SSO",
                newName: "SSO.Roles");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "SSO",
                newName: "Profile.Person");

            migrationBuilder.RenameTable(
                name: "Account",
                schema: "SSO",
                newName: "SSO.Account");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_ParentRoleID",
                table: "SSO.Roles",
                newName: "IX_SSO.Roles_ParentRoleID");

            migrationBuilder.RenameIndex(
                name: "IX_Account_PersonID",
                table: "SSO.Account",
                newName: "IX_SSO.Account_PersonID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SSO.Roles",
                table: "SSO.Roles",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile.Person",
                table: "Profile.Person",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SSO.Account",
                table: "SSO.Account",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SSO.Account_Profile.Person_PersonID",
                table: "SSO.Account",
                column: "PersonID",
                principalTable: "Profile.Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SSO.Roles_SSO.Roles_ParentRoleID",
                table: "SSO.Roles",
                column: "ParentRoleID",
                principalTable: "SSO.Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
