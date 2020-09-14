using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoJWTAuthorization.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Profile",
                table: "Person",
                columns: new[] { "Id", "Address", "Birthday", "CityID", "EconomicCode", "Education", "Email", "FatherName", "FieldActivity", "Fname", "Gilder", "GovernmentSharePercentage", "GroupType", "Image", "IsDeleted", "Job", "LegalDocumentation", "LegalTypeID", "Lname", "MaritalStatus", "Mobile", "NationalCode", "Nationality", "OrganizationEmployee", "Phone", "RelationshipTypeId", "Religion", "SabtCode", "SabtDate", "Sex", "Site", "Study", "TransferList", "TypeGovernmentCompanyID", "TypeID", "ZipCode", "fax", "provinceID" },
                values: new object[] { 1L, null, null, null, null, null, "demo@email.com", null, null, "demo", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, (short)0, null, null, null });

            migrationBuilder.InsertData(
                schema: "SSO",
                table: "Account",
                columns: new[] { "Id", "Active", "LastPasswordChanges", "Password", "PersonID", "RegisterDate", "UserName" },
                values: new object[] { 1, true, null, "61p5CzTgbizjNG+iyl1quw==", 1L, null, "demo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "SSO",
                table: "Account",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Profile",
                table: "Person",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
