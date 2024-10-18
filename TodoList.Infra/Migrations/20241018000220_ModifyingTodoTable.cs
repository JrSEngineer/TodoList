using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ModifyingTodoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InProgress",
                table: "ToDo",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InProgress",
                table: "ToDo");
        }
    }
}
