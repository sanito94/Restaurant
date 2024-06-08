using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Infrastructure.Migrations
{
    public partial class AdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa900f18-0e4d-4041-b839-75331658416e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e43ce836-997d-4927-ac59-74e8c41bbfd3", 0, "", "12d5948d-2d12-4776-83f9-4a839104349f", "ApplicationUser", "admin@gmail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEMlv2nHU0JZdoeXzlBSPyOC0SKpsKNDfARL7endvegicFTg2JClxrMwnGb0/J997Uw==", null, false, "", "1f59c159-8f5e-4798-9ddf-112705db49d8", false, "admin@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fa900f18-0e4d-4041-b839-75331658416e", 0, "ul. Pliska 4, bl. Preslav, grad Ruse", "f2e95d57-dade-4424-b1f2-d670545fdf11", "ApplicationUser", "admin@gmail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEFNdk2b7Fq+vm2o8MakFxIeYfyYMXePiXG2KRhdVLyThtne1SgFvyiy1TsylRt7N4Q==", "+491787181664", false, "7000", "8fffbd6e-0871-47cc-b122-09f438f161d9", false, "admin@gmail.com" });
        }
    }
}
