using Microsoft.EntityFrameworkCore.Migrations;

namespace PaginatePOC.Migrations
{
    public partial class Edit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Values",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Values",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
