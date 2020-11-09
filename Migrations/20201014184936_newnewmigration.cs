using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.Migrations
{
    public partial class newnewmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Types",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Status",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_StatusId",
                table: "Issues",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_TypeId",
                table: "Issues",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Status_StatusId",
                table: "Issues",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Types_TypeId",
                table: "Issues",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Status_StatusId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Types_TypeId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_StatusId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_TypeId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Types",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
