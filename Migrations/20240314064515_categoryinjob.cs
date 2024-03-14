using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swarojgaar.Migrations
{
    public partial class categoryinjob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "9f7f2665-eba0-4470-94b9-6b60fa3737cd" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f7f2665-eba0-4470-94b9-6b60fa3737cd");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                table: "Jobs",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categories_CategoryId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_CategoryId",
                table: "Jobs");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "8a20a084-b681-4d27-bf5f-d19025709c3a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a20a084-b681-4d27-bf5f-d19025709c3a");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Jobs");

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
    }
}
