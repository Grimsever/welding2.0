using Microsoft.EntityFrameworkCore.Migrations;

namespace WeldingV2._0.Migrations
{
    public partial class UpdateWorkerAndTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Tasks_TaskId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_TaskId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Workers");

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_WorkerId",
                table: "Tasks",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Workers_WorkerId",
                table: "Tasks",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Workers_WorkerId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_WorkerId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Workers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_TaskId",
                table: "Workers",
                column: "TaskId",
                unique: true,
                filter: "[TaskId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Tasks_TaskId",
                table: "Workers",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
