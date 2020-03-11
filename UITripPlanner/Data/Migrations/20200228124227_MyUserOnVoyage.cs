using Microsoft.EntityFrameworkCore.Migrations;

namespace UITripPlanner.Data.Migrations
{
    public partial class MyUserOnVoyage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voyage_AspNetUsers_ApplicationUserId",
                table: "Voyage");

            migrationBuilder.DropIndex(
                name: "IX_Voyage_ApplicationUserId",
                table: "Voyage");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Voyage");

            migrationBuilder.AddColumn<string>(
                name: "MyUserId",
                table: "Voyage",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voyage_MyUserId",
                table: "Voyage",
                column: "MyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voyage_AspNetUsers_MyUserId",
                table: "Voyage",
                column: "MyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voyage_AspNetUsers_MyUserId",
                table: "Voyage");

            migrationBuilder.DropIndex(
                name: "IX_Voyage_MyUserId",
                table: "Voyage");

            migrationBuilder.DropColumn(
                name: "MyUserId",
                table: "Voyage");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Voyage",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voyage_ApplicationUserId",
                table: "Voyage",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voyage_AspNetUsers_ApplicationUserId",
                table: "Voyage",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
