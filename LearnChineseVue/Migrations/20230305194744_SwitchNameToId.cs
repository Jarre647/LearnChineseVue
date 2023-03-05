using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnChineseVue.Migrations
{
    /// <inheritdoc />
    public partial class SwitchNameToId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChineseWord",
                table: "OrderNumChineseWordsByUser");

            migrationBuilder.RenameColumn(
                name: "OrderNum",
                table: "OrderNumChineseWordsByUser",
                newName: "GroupId");

            migrationBuilder.AddColumn<int>(
                name: "ChineseWordId",
                table: "OrderNumChineseWordsByUser",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChineseWordId",
                table: "OrderNumChineseWordsByUser");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "OrderNumChineseWordsByUser",
                newName: "OrderNum");

            migrationBuilder.AddColumn<string>(
                name: "ChineseWord",
                table: "OrderNumChineseWordsByUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
