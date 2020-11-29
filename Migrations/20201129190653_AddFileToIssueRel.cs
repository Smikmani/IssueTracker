using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.Migrations
{
    public partial class AddFileToIssueRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Files_IssueId",
                table: "Files",
                column: "IssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Issues_IssueId",
                table: "Files",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Issues_IssueId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_IssueId",
                table: "Files");
        }
    }
}
