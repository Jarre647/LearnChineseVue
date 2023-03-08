using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnChineseVue.Migrations
{
    /// <inheritdoc />
    public partial class AddKeyOrderNumTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "ChineseWords");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderNumChineseWordsByUser",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderNumChineseWordsByUser",
                table: "OrderNumChineseWordsByUser",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderNumChineseWordsByUser",
                table: "OrderNumChineseWordsByUser");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderNumChineseWordsByUser");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "ChineseWords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
