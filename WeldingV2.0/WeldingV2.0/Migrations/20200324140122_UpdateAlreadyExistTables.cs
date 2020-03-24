using Microsoft.EntityFrameworkCore.Migrations;

namespace WeldingV2._0.Migrations
{
    public partial class UpdateAlreadyExistTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_MachineDatas_MachineDataId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Tasks_TaskId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_TaskId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Machines_MachineDataId",
                table: "Machines");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "Workers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MachineDataId",
                table: "Machines",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_TaskId",
                table: "Workers",
                column: "TaskId",
                unique: true,
                filter: "[TaskId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MachineDataId",
                table: "Machines",
                column: "MachineDataId",
                unique: true,
                filter: "[MachineDataId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_MachineDatas_MachineDataId",
                table: "Machines",
                column: "MachineDataId",
                principalTable: "MachineDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Tasks_TaskId",
                table: "Workers",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_MachineDatas_MachineDataId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Tasks_TaskId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_TaskId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Machines_MachineDataId",
                table: "Machines");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "Workers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MachineDataId",
                table: "Machines",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_TaskId",
                table: "Workers",
                column: "TaskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MachineDataId",
                table: "Machines",
                column: "MachineDataId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_MachineDatas_MachineDataId",
                table: "Machines",
                column: "MachineDataId",
                principalTable: "MachineDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Tasks_TaskId",
                table: "Workers",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
