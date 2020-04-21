using Microsoft.EntityFrameworkCore.Migrations;

namespace MvvmProdactApp.Migrations
{
    public partial class BB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_ObjProperties__AbstractPropertyObjs_ECNsectionId",
                table: "ObjProperties",
                column: "ECNsectionId",
                principalTable: "_AbstractPropertyObjs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_ObjProperties__AbstractPropertyObjs_ECNSectionId",
                table: "ObjProperties",
                column: "ECNSectionId",
                principalTable: "_AbstractPropertyObjs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
