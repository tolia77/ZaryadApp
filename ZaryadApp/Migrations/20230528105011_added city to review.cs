using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaryadApp.Migrations
{
    /// <inheritdoc />
    public partial class addedcitytoreview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Review");
        }
    }
}
