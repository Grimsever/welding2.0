using Microsoft.EntityFrameworkCore.Migrations;

namespace WeldingV2._0.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foremen",
                columns: table => new
                {
                    ForemenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foremen", x => x.ForemenId);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    WorkerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    ForemenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.WorkerId);
                    table.ForeignKey(
                        name: "FK_Workers_Foremen_ForemenId",
                        column: x => x.ForemenId,
                        principalTable: "Foremen",
                        principalColumn: "ForemenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ForemenId",
                table: "Workers",
                column: "ForemenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Foremen");
        }
    }
}
