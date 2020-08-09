using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoJWTAuthorization.Migrations
{
    public partial class ChengeTableNameSSOToAccountLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SSO_Account_AccountId",
                schema: "SSO",
                table: "SSO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SSO",
                schema: "SSO",
                table: "SSO");

            migrationBuilder.RenameTable(
                name: "SSO",
                schema: "SSO",
                newName: "AccountLog",
                newSchema: "SSO");

            migrationBuilder.RenameIndex(
                name: "IX_SSO_AccountId",
                schema: "SSO",
                table: "AccountLog",
                newName: "IX_AccountLog_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountLog",
                schema: "SSO",
                table: "AccountLog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountLog_Account_AccountId",
                schema: "SSO",
                table: "AccountLog",
                column: "AccountId",
                principalSchema: "SSO",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountLog_Account_AccountId",
                schema: "SSO",
                table: "AccountLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountLog",
                schema: "SSO",
                table: "AccountLog");

            migrationBuilder.RenameTable(
                name: "AccountLog",
                schema: "SSO",
                newName: "SSO",
                newSchema: "SSO");

            migrationBuilder.RenameIndex(
                name: "IX_AccountLog_AccountId",
                schema: "SSO",
                table: "SSO",
                newName: "IX_SSO_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SSO",
                schema: "SSO",
                table: "SSO",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SSO_Account_AccountId",
                schema: "SSO",
                table: "SSO",
                column: "AccountId",
                principalSchema: "SSO",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
