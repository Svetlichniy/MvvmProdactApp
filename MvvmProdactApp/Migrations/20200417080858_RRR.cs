using Microsoft.EntityFrameworkCore.Migrations;

namespace MvvmProdactApp.Migrations
{
    public partial class RRR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "dbImage",
                table: "_AbstractPropertyObjs",
                nullable: true
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
