using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Infrastructure.Migrations
{
    public partial class Cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad5e346f-1935-4966-8226-198bdff9ca25", "AQAAAAEAACcQAAAAEDPiBKirStEWk21XXrYeGfBOOdxe3nxhadio5h8xtvSEjEd8DWaGY1J5Z9AYKGR/Mw==", "c0c3a40b-2b71-4d21-bfb5-8777687c9dcf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5473deb0-63d6-42e1-9860-ab6a6023d5dc", "AQAAAAEAACcQAAAAEGM5O1LtSROJ1pe4Ta83aYa0ajBz0IWTwFNbPJ5dEU5KuSuOa5Rg9g91Pym3EwxMFA==", "5abf6193-62ba-4d74-8e71-a18391bad5ac" });
        }
    }
}
