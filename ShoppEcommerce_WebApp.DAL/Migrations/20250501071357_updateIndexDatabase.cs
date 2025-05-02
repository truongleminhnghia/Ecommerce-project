using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppEcommerce_WebApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateIndexDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_role_role_name",
                table: "role",
                column: "role_name");

            migrationBuilder.CreateIndex(
                name: "IX_account_account_status",
                table: "account",
                column: "account_status");

            migrationBuilder.CreateIndex(
                name: "IX_account_email",
                table: "account",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_role_role_name",
                table: "role");

            migrationBuilder.DropIndex(
                name: "IX_account_account_status",
                table: "account");

            migrationBuilder.DropIndex(
                name: "IX_account_email",
                table: "account");
        }
    }
}
