using Microsoft.EntityFrameworkCore.Migrations;

namespace MvvmProdactApp.Migrations
{
    public partial class Link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "LinkToObjId",
                table: "ObjStructures",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LinkToObject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdactObjId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkToObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkToObject_HierarchicalObjects_ProdactObjId",
                        column: x => x.ProdactObjId,
                        principalTable: "HierarchicalObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjStructures_LinkToObjId",
                table: "ObjStructures",
                column: "LinkToObjId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkToObject_ProdactObjId",
                table: "LinkToObject",
                column: "ProdactObjId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjStructures_LinkToObject_LinkToObjId",
                table: "ObjStructures",
                column: "LinkToObjId",
                principalTable: "LinkToObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjStructures_LinkToObject_LinkToObjId",
                table: "ObjStructures");

            migrationBuilder.DropTable(
                name: "LinkToObject");

            migrationBuilder.DropIndex(
                name: "IX_ObjStructures_LinkToObjId",
                table: "ObjStructures");

            migrationBuilder.DropColumn(
                name: "LinkToObjId",
                table: "ObjStructures");

            migrationBuilder.AddColumn<int>(
                name: "ProdactObjectId",
                table: "ObjStructures",
                type: "int",
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
    }
}
