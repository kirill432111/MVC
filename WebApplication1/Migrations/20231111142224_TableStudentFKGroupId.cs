using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class TableStudentFKGroupId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupeId",
                table: "Students",
                column: "GroupeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Groups_GroupeId",
                table: "Students",
                column: "GroupeId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Groups_GroupeId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_GroupeId",
                table: "Students");
        }
    }
}
