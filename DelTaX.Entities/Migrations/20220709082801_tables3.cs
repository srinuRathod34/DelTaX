using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DelTaX.Entities.Migrations
{
    public partial class tables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "ActorDetails");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "ActorDetails");

            migrationBuilder.DropColumn(
                name: "KeyRole",
                table: "ActorDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ActorName",
                table: "ActorDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ActorName",
                table: "ActorDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "ActorDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "Gender",
                table: "ActorDetails",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "KeyRole",
                table: "ActorDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
