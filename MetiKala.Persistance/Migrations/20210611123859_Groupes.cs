using Microsoft.EntityFrameworkCore.Migrations;

namespace MetiKala.Persistance.Migrations
{
    public partial class Groupes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsGroupes",
                columns: table => new
                {
                    GroupeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupeTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsGroupes", x => x.GroupeID);
                    table.ForeignKey(
                        name: "FK_ProductsGroupes_ProductsGroupes_ParentID",
                        column: x => x.ParentID,
                        principalTable: "ProductsGroupes",
                        principalColumn: "GroupeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsGroupes_ParentID",
                table: "ProductsGroupes",
                column: "ParentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsGroupes");
        }
    }
}
