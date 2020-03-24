using Microsoft.EntityFrameworkCore.Migrations;

namespace WeldingV2._0.Migrations
{
    public partial class UpdateRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Machines_MachineDatas_MachineDataId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Machines_MachineId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_MachineId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Machines_MachineDataId",
                table: "Machines");

            migrationBuilder.AlterColumn<int>(
                name: "MachineDataId",
                table: "Machines",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Machines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "MachineDatas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MachineDataId",
                table: "Machines",
                column: "MachineDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Machines_TaskId",
                table: "Machines",
                column: "TaskId",
                unique: true,
                filter: "[TaskId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_MachineDatas_MachineDataId",
                table: "Machines",
                column: "MachineDataId",
                principalTable: "MachineDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Tasks_TaskId",
                table: "Machines",
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
                name: "FK_Machines_Tasks_TaskId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Machines_MachineDataId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Machines_TaskId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "MachineDatas");

            migrationBuilder.AlterColumn<int>(
                name: "MachineDataId",
                table: "Machines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_MachineId",
                table: "Tasks",
                column: "MachineId",
                unique: true);

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
                name: "FK_Tasks_Machines_MachineId",
                table: "Tasks",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
