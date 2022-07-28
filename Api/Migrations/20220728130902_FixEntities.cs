using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class FixEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreExtracts_Users_UserId",
                table: "ScoreExtracts");

            migrationBuilder.DropIndex(
                name: "IX_ScoreExtracts_UserId",
                table: "ScoreExtracts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ScoreExtracts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "ScoreExtracts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ScoreExtracts_UserId",
                table: "ScoreExtracts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreExtracts_Users_UserId",
                table: "ScoreExtracts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
