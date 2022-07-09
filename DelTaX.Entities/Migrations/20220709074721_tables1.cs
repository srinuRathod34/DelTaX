using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DelTaX.Entities.Migrations
{
    public partial class tables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProducerName",
                table: "Producer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProducerName",
                table: "Producer");
        }
    }
}
