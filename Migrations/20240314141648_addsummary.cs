using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swarojgaar.Migrations
{
    public partial class addsummary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "fe357059-f578-4e57-8757-24a94dee5d05" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe357059-f578-4e57-8757-24a94dee5d05");

            migrationBuilder.AddColumn<string>(
                name: "JobSummary",
                table: "SavedJobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobSummary",
                table: "Jobs",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobSummary",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64a99865-2144-4979-942e-71a8540d5061",
                column: "ConcurrencyStamp",
                value: "57124134-4ad9-4eec-8670-bf7b52c8db0f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65c00570-b09f-4c8b-a412-eea238c829b7",
                column: "ConcurrencyStamp",
                value: "5279e1bb-436e-4df4-ba78-d70eabae57b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d959fac3-736d-437f-b467-00bce9b64a65",
                column: "ConcurrencyStamp",
                value: "f6046610-43b6-40c3-91c6-a536e138d10b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DocFile", "Email", "EmailConfirmed", "FirstName", "IdentityImage", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "286f3cac-bd15-4c70-8910-94b18729ea07", 0, "8c9d51ee-b902-4fcf-9eb7-b618a915c5e5", "", "admin@gmail.com", true, "Admin", "1516929476300.jpeg", "", "Nepal", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEF8eXDb2KfGTEsTI03vSyWmq3+y7ocrp1R00HsZjvB/OwWqOSB4IrRVkurEYGUQI6Q==", "9840030129", false, "UniqueSecurityStamp", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "286f3cac-bd15-4c70-8910-94b18729ea07" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "286f3cac-bd15-4c70-8910-94b18729ea07" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "286f3cac-bd15-4c70-8910-94b18729ea07");

            migrationBuilder.DropColumn(
                name: "JobSummary",
                table: "SavedJobs");

            migrationBuilder.DropColumn(
                name: "JobSummary",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobSummary",
                table: "JobApplications");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64a99865-2144-4979-942e-71a8540d5061",
                column: "ConcurrencyStamp",
                value: "9ec38a2d-8e8a-43e5-87a6-3ea19492c6a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65c00570-b09f-4c8b-a412-eea238c829b7",
                column: "ConcurrencyStamp",
                value: "64dc85e2-0769-48ad-bda4-83e972a6e04d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d959fac3-736d-437f-b467-00bce9b64a65",
                column: "ConcurrencyStamp",
                value: "dd4d3a00-e68d-4efc-8ec8-2d58661f60d1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DocFile", "Email", "EmailConfirmed", "FirstName", "IdentityImage", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fe357059-f578-4e57-8757-24a94dee5d05", 0, "2fa2d893-cd1a-4470-915a-26270d4ef5ed", "", "admin@gmail.com", true, "Admin", "1516929476300.jpeg", "", "Nepal", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEDcZ00NIVA+0yi1M7O9/pJNSePQqUZDJUA894TZvfAr+BSQCQCw7s4ivyI3C60vI+Q==", "9840030129", false, "UniqueSecurityStamp", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "fe357059-f578-4e57-8757-24a94dee5d05" });
        }
    }
}
