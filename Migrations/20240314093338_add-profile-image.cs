using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swarojgaar.Migrations
{
    public partial class addprofileimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "8a20a084-b681-4d27-bf5f-d19025709c3a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a20a084-b681-4d27-bf5f-d19025709c3a");

            migrationBuilder.AddColumn<string>(
                name: "IdentityImage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "fe357059-f578-4e57-8757-24a94dee5d05" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe357059-f578-4e57-8757-24a94dee5d05");

            migrationBuilder.DropColumn(
                name: "IdentityImage",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64a99865-2144-4979-942e-71a8540d5061",
                column: "ConcurrencyStamp",
                value: "4eb7e305-7678-4701-9549-e7742fa10202");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65c00570-b09f-4c8b-a412-eea238c829b7",
                column: "ConcurrencyStamp",
                value: "9291dfcc-d028-4133-9c73-35659a3d1f0f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d959fac3-736d-437f-b467-00bce9b64a65",
                column: "ConcurrencyStamp",
                value: "a4f4d0e7-2533-455c-b43e-fb3da98bfd68");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DocFile", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8a20a084-b681-4d27-bf5f-d19025709c3a", 0, "1d980d54-2df9-4969-9a7f-daa7f6dd30ae", "", "admin@gmail.com", true, "Admin", "", "", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEMiE35fyoCHsVO88QQAKx9BqrK+x3kuqAVAOLvu1YZXxViLlrYK42DEkIzFD7U10ng==", "", false, "UniqueSecurityStamp", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "8a20a084-b681-4d27-bf5f-d19025709c3a" });
        }
    }
}
