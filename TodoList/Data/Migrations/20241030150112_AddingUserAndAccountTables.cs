using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TodoList.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserAndAccountTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToDoUserId",
                table: "ToDo",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ToDo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => new { x.UserId, x.Email });
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    AccountUserId = table.Column<int>(type: "integer", nullable: false),
                    AccountEmail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Account_AccountUserId_AccountEmail",
                        columns: x => new { x.AccountUserId, x.AccountEmail },
                        principalTable: "Account",
                        principalColumns: new[] { "UserId", "Email" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_ToDoUserId",
                table: "ToDo",
                column: "ToDoUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_Email",
                table: "Account",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_AccountUserId_AccountEmail",
                table: "User",
                columns: new[] { "AccountUserId", "AccountEmail" });

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_User_ToDoUserId",
                table: "ToDo",
                column: "ToDoUserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_User_ToDoUserId",
                table: "ToDo");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropIndex(
                name: "IX_ToDo_ToDoUserId",
                table: "ToDo");

            migrationBuilder.DropColumn(
                name: "ToDoUserId",
                table: "ToDo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ToDo");
        }
    }
}
