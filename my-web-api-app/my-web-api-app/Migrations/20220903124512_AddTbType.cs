using Microsoft.EntityFrameworkCore.Migrations;

namespace my_web_api_app.Migrations
{
    public partial class AddTbType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeCode",
                table: "Good",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Good_TypeCode",
                table: "Good",
                column: "TypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Good_Type_TypeCode",
                table: "Good",
                column: "TypeCode",
                principalTable: "Type",
                principalColumn: "TypeCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Good_Type_TypeCode",
                table: "Good");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Good_TypeCode",
                table: "Good");

            migrationBuilder.DropColumn(
                name: "TypeCode",
                table: "Good");
        }
    }
}
