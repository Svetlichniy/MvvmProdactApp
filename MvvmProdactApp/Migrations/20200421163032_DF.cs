using Microsoft.EntityFrameworkCore.Migrations;

namespace MvvmProdactApp.Migrations
{
    public partial class DF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjProperties__AbstractPropertyObjs_ECNsectionId",
                table: "ObjProperties");

            migrationBuilder.DropIndex(
                name: "IX_ObjProperties_ECNsectionId",
                table: "ObjProperties");

            migrationBuilder.DropColumn(
                name: "ECNsectionId",
                table: "ObjProperties");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "ObjProperties",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ObjProperties_SectionId",
                table: "ObjProperties",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjProperties__AbstractPropertyObjs_SectionId",
                table: "ObjProperties",
                column: "SectionId",
                principalTable: "_AbstractPropertyObjs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjProperties__AbstractPropertyObjs_SectionId",
                table: "ObjProperties");

            migrationBuilder.DropIndex(
                name: "IX_ObjProperties_SectionId",
                table: "ObjProperties");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "ObjProperties");

            migrationBuilder.AddColumn<int>(
                name: "ECNsectionId",
                table: "ObjProperties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ObjProperties_ECNsectionId",
                table: "ObjProperties",
                column: "ECNsectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjProperties__AbstractPropertyObjs_ECNsectionId",
                table: "ObjProperties",
                column: "ECNsectionId",
                principalTable: "_AbstractPropertyObjs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
