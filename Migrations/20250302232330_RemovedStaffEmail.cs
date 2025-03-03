using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCourseWork.Migrations
{
    /// <inheritdoc />
    public partial class RemovedStaffEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Staff");

            migrationBuilder.RenameColumn(
                name: "Quantitiy",
                table: "OrderItems",
                newName: "Quantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderItems",
                newName: "Quantitiy");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Staff",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
