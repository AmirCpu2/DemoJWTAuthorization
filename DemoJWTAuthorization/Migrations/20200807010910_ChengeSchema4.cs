using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoJWTAuthorization.Migrations
{
    public partial class ChengeSchema4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Roles_ParentRoleID",
                schema: "SSO",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                schema: "SSO",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "SSO",
                newName: "Role",
                newSchema: "SSO");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_ParentRoleID",
                schema: "SSO",
                table: "Role",
                newName: "IX_Role_ParentRoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                schema: "SSO",
                table: "Role",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Role_ParentRoleID",
                schema: "SSO",
                table: "Role",
                column: "ParentRoleID",
                principalSchema: "SSO",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Role_ParentRoleID",
                schema: "SSO",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                schema: "SSO",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "SSO",
                newName: "Roles",
                newSchema: "SSO");

            migrationBuilder.RenameIndex(
                name: "IX_Role_ParentRoleID",
                schema: "SSO",
                table: "Roles",
                newName: "IX_Roles_ParentRoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                schema: "SSO",
                table: "Roles",
                column: "ID");

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
    }
}
