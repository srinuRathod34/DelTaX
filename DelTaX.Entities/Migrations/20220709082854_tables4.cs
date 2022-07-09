using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DelTaX.Entities.Migrations
{
    public partial class tables4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Producer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                table: "Producer",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
