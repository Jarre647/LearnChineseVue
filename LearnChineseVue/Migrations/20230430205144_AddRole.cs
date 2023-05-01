using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnChineseVue.Migrations
{
    /// <inheritdoc />
    public partial class AddRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES ('{Guid.NewGuid()}', 'admin', 'ADMIN', 'ZALUPA')");
            migrationBuilder.Sql($"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES ('{Guid.NewGuid()}', 'user', 'USER', 'ZALUPA')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetRoles] WHERE Name = 'admin' or Name = 'user'");
        }
    }
}
