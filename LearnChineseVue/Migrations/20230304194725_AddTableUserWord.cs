using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnChineseVue.Migrations
{
    /// <inheritdoc />
    public partial class AddTableUserWord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "ChineseWords",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "OrderNumChineseWordsByUser",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChineseWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderNumChineseWordsByUser");

            migrationBuilder.AlterColumn<string>(
                name: "User",
                table: "ChineseWords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
