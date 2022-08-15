using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertyManagementRepository.Migrations
{
    public partial class addKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestID",
                table: "MaintenanceRequests",
                newName: "RequestId");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "MaintenanceRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaintenanceRequests",
                table: "MaintenanceRequests",
                column: "RequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MaintenanceRequests",
                table: "MaintenanceRequests");

            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "MaintenanceRequests",
                newName: "RequestID");

            migrationBuilder.AlterColumn<int>(
                name: "RequestID",
                table: "MaintenanceRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
