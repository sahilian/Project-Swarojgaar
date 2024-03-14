using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swarojgaar.Migrations
{
    public partial class addedcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "ba78b512-b78e-4d26-8705-6309cd643dc7" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba78b512-b78e-4d26-8705-6309cd643dc7");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64a99865-2144-4979-942e-71a8540d5061",
                column: "ConcurrencyStamp",
                value: "c906a00f-6199-409c-9dfc-2dfef2e504cb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65c00570-b09f-4c8b-a412-eea238c829b7",
                column: "ConcurrencyStamp",
                value: "11396976-70a0-4b1c-b51b-72005d83a0f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d959fac3-736d-437f-b467-00bce9b64a65",
                column: "ConcurrencyStamp",
                value: "1f6d0abc-0a50-4acb-bbb6-cd688deff22f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DocFile", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9f7f2665-eba0-4470-94b9-6b60fa3737cd", 0, "2327eea1-567f-4852-9157-2155d62a02bc", "", "admin@gmail.com", true, "Admin", "", "", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEHzP7mkhph/mEXZAlOxAq5ncqhVNOuy4DHtvvIUiQ91EmQuDlnPZzAq6NuqmgLp0ug==", "", false, "UniqueSecurityStamp", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "9f7f2665-eba0-4470-94b9-6b60fa3737cd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "9f7f2665-eba0-4470-94b9-6b60fa3737cd" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f7f2665-eba0-4470-94b9-6b60fa3737cd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64a99865-2144-4979-942e-71a8540d5061",
                column: "ConcurrencyStamp",
                value: "a44acf94-f12e-4316-ba4d-7eac7b7c5402");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65c00570-b09f-4c8b-a412-eea238c829b7",
                column: "ConcurrencyStamp",
                value: "cff4e41c-e370-4e72-b19c-9bae062f208b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d959fac3-736d-437f-b467-00bce9b64a65",
                column: "ConcurrencyStamp",
                value: "cdfedd88-a090-4d79-abc4-73db2d6cf1e7");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DocFile", "Email", "EmailConfirmed", "FirstName", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ba78b512-b78e-4d26-8705-6309cd643dc7", 0, "e2bfd687-0aaa-488f-9017-9654b85214ef", "", "admin@gmail.com", true, "Admin", "", "", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEM2qTXxP+ohnQJAnzAJVSE3NDZrLzWYSYsjFvUeHymzwFW4HN4gnKDI1qc7mQ/RCGQ==", "", false, "UniqueSecurityStamp", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "ba78b512-b78e-4d26-8705-6309cd643dc7" });
        }
    }
}
