using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Infrastructure.Migrations
{
    public partial class SeedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5473deb0-63d6-42e1-9860-ab6a6023d5dc", "AQAAAAEAACcQAAAAEGM5O1LtSROJ1pe4Ta83aYa0ajBz0IWTwFNbPJ5dEU5KuSuOa5Rg9g91Pym3EwxMFA==", "5abf6193-62ba-4d74-8e71-a18391bad5ac" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Starters" },
                    { 2, "Breakfast" },
                    { 3, "Lunch" },
                    { 4, "Dinner" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12d5948d-2d12-4776-83f9-4a839104349f", "AQAAAAEAACcQAAAAEMlv2nHU0JZdoeXzlBSPyOC0SKpsKNDfARL7endvegicFTg2JClxrMwnGb0/J997Uw==", "1f59c159-8f5e-4798-9ddf-112705db49d8" });
        }
    }
}
