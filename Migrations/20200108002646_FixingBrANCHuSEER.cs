using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Migrations
{
    public partial class FixingBrANCHuSEER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Branches_CurrentBranch",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CurrentBranch",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CurrentBranch",
                table: "AspNetUsers",
                newName: "UserBranchId");

            migrationBuilder.AddColumn<int>(
                name: "UserBranchNameBranchId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserBranchNameBranchId",
                table: "AspNetUsers",
                column: "UserBranchNameBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Branches_UserBranchNameBranchId",
                table: "AspNetUsers",
                column: "UserBranchNameBranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Branches_UserBranchNameBranchId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserBranchNameBranchId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserBranchNameBranchId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserBranchId",
                table: "AspNetUsers",
                newName: "CurrentBranch");

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
    }
}
