using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaryadApp.Migrations
{
    /// <inheritdoc />
    public partial class addusernametoreview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Review");
        }
    }
}
