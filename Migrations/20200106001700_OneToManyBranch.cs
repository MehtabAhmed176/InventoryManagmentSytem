using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class OneToManyBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentBranch",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CurrentBranch",
                table: "AspNetUsers",
                column: "CurrentBranch");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Branches_CurrentBranch",
                table: "AspNetUsers",
                column: "CurrentBranch",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Branches_CurrentBranch",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CurrentBranch",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CurrentBranch",
                table: "AspNetUsers");
        }
    }
}
