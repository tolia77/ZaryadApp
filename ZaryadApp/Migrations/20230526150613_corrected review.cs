using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaryadApp.Migrations
{
    /// <inheritdoc />
    public partial class correctedreview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_ReviewId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Review",
                newName: "ApplicationUserId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ApplicationUserId",
                table: "Review",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_ApplicationUserId",
                table: "Review",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_ApplicationUserId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ApplicationUserId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Review",
                newName: "ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_ReviewId",
                table: "Review",
                column: "ReviewId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
