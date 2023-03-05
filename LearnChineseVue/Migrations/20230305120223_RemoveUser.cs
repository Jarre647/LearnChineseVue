using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnChineseVue.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "ChineseWords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "ChineseWords",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
