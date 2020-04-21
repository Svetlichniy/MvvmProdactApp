using Microsoft.EntityFrameworkCore.Migrations;

namespace MvvmProdactApp.Migrations
{
    public partial class Link2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjStructures_HierarchicalObjects_ParentId",
                table: "ObjStructures");

            migrationBuilder.DropIndex(
                name: "IX_ObjStructures_ParentId",
                table: "ObjStructures");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ObjStructures");

            migrationBuilder.AddColumn<int>(
                name: "ProdactObjectId",
                table: "ObjStructures",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ObjStructures_ProdactObjectId",
                table: "ObjStructures",
                column: "ProdactObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjStructures_HierarchicalObjects_ProdactObjectId",
                table: "ObjStructures",
                column: "ProdactObjectId",
                principalTable: "HierarchicalObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjStructures_HierarchicalObjects_ProdactObjectId",
                table: "ObjStructures");

            migrationBuilder.DropIndex(
                name: "IX_ObjStructures_ProdactObjectId",
                table: "ObjStructures");

            migrationBuilder.DropColumn(
                name: "ProdactObjectId",
                table: "ObjStructures");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "ObjStructures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ObjStructures_ParentId",
                table: "ObjStructures",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjStructures_HierarchicalObjects_ParentId",
                table: "ObjStructures",
                column: "ParentId",
                principalTable: "HierarchicalObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
