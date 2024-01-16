using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swarojgaar.Migrations
{
    public partial class adminpassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "5f72c52c-84ad-4656-b941-66324a798316" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5f72c52c-84ad-4656-b941-66324a798316");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64a99865-2144-4979-942e-71a8540d5061",
                column: "ConcurrencyStamp",
                value: "1276c771-fe82-4f14-af06-fd115a4bf994");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65c00570-b09f-4c8b-a412-eea238c829b7",
                column: "ConcurrencyStamp",
                value: "d53ddb91-b2b3-46a4-af4a-518ee09c0d7f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d959fac3-736d-437f-b467-00bce9b64a65",
                column: "ConcurrencyStamp",
                value: "28a5fe02-4e74-424f-ad50-ffade336df6f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a9324f38-3fe9-4e2d-9d8d-1ca589542814", 0, "74f1e140-33ce-4be6-8997-fd7335c0143f", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEJvuWiYLKU13sEvJ0B6JRCWSmH9iWyWW+fsnkbKIlvd8G9cgIU04Nx1nv3e8/Wwkcw==", null, false, "UniqueSecurityStamp", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "a9324f38-3fe9-4e2d-9d8d-1ca589542814" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "a9324f38-3fe9-4e2d-9d8d-1ca589542814" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9324f38-3fe9-4e2d-9d8d-1ca589542814");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64a99865-2144-4979-942e-71a8540d5061",
                column: "ConcurrencyStamp",
                value: "8cd07b0f-0881-4e16-be19-ca683a36f293");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65c00570-b09f-4c8b-a412-eea238c829b7",
                column: "ConcurrencyStamp",
                value: "5548cdf1-605b-4bda-8bd7-c2e5a3d57738");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d959fac3-736d-437f-b467-00bce9b64a65",
                column: "ConcurrencyStamp",
                value: "5b45459b-26cf-4ca4-b22f-7946f2e220fe");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5f72c52c-84ad-4656-b941-66324a798316", 0, "7cbc04af-041c-40f1-96f2-d29091379972", "IdentityUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEFWLSgdcOkhjqHn3BLjg/5K4Ix9ySV9BzWPTgw2Q14BicR/Sb2MHoQ/EJfr9q56g8w==", null, false, "UniqueSecurityStamp", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "65c00570-b09f-4c8b-a412-eea238c829b7", "5f72c52c-84ad-4656-b941-66324a798316" });
        }
    }
}
