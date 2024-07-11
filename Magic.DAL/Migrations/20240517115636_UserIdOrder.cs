using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magic.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserIdOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_users_UserId",
                table: "order");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "order",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_order_UserId",
                table: "order",
                newName: "IX_order_user_id");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "order",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_order_users_user_id",
                table: "order",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_users_user_id",
                table: "order");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "order",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_order_user_id",
                table: "order",
                newName: "IX_order_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "order",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_order_users_UserId",
                table: "order",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
