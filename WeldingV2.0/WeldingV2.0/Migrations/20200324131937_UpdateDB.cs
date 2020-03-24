using Microsoft.EntityFrameworkCore.Migrations;

namespace WeldingV2._0.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MachineDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Amperages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(nullable: false),
                    MachineDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amperages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amperages_MachineDatas_MachineDataId",
                        column: x => x.MachineDataId,
                        principalTable: "MachineDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MachineDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machines_MachineDatas_MachineDataId",
                        column: x => x.MachineDataId,
                        principalTable: "MachineDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voltages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(nullable: false),
                    MachineDataId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voltages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voltages_MachineDatas_MachineDataId",
                        column: x => x.MachineDataId,
                        principalTable: "MachineDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amperages_MachineDataId",
                table: "Amperages",
                column: "MachineDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MachineDataId",
                table: "Machines",
                column: "MachineDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voltages_MachineDataId",
                table: "Voltages",
                column: "MachineDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amperages");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Voltages");

            migrationBuilder.DropTable(
                name: "MachineDatas");
        }
    }
}
