using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Infrastructure.Migrations
{
    public partial class BookATable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "BookATables");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "032a2173-0783-4ba1-ae19-38eb972fb2c5", "AQAAAAEAACcQAAAAEB6DD02jYcxKuf5sBnPu+U3hMAuGOm8lxGdvvquOFIJL/zw8K9o9gLNN9OK4/LRAew==", "0c211f89-073c-47e4-960b-ecf414be157f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "BookATables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5268c017-a051-45a2-b329-32fb7eeae7d5", "AQAAAAEAACcQAAAAELD8Vw6n/TPTZHG4RZXNUMyz/249MDC2aWfGoA6X97vF4BtY1SkUhYlB5C72lcvC8A==", "c34739b9-d2aa-45de-982f-318cc8127ac7" });
        }
    }
}
