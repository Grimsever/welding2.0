using Microsoft.EntityFrameworkCore.Migrations;

namespace WeldingV2._0.Migrations
{
    public partial class AddNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Workers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TechMaps",
                columns: table => new
                {
                    TechMapId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinValueAmp = table.Column<double>(nullable: false),
                    MaxValueAmp = table.Column<double>(nullable: false),
                    MinValueVolt = table.Column<double>(nullable: false),
                    MaxValueVolt = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechMaps", x => x.TechMapId);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechMapId = table.Column<int>(nullable: false),
                    MachineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TechMaps_TechMapId",
                        column: x => x.TechMapId,
                        principalTable: "TechMaps",
                        principalColumn: "TechMapId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_TaskId",
                table: "Workers",
                column: "TaskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_MachineId",
                table: "Tasks",
                column: "MachineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TechMapId",
                table: "Tasks",
                column: "TechMapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Tasks_TaskId",
                table: "Workers",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Tasks_TaskId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TechMaps");

            migrationBuilder.DropIndex(
                name: "IX_Workers_TaskId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Workers");
        }
    }
}
