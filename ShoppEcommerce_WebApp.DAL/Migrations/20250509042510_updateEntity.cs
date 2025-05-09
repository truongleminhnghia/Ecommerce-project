using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppEcommerce_WebApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_customer_customer_id",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_employee_address_home_address_id",
                table: "employee");

            migrationBuilder.AlterColumn<Guid>(
                name: "home_address_id",
                table: "employee",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "customer_id",
                table: "address",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_address_customer_customer_id",
                table: "address",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_address_home_address_id",
                table: "employee",
                column: "home_address_id",
                principalTable: "address",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_customer_customer_id",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_employee_address_home_address_id",
                table: "employee");

            migrationBuilder.AlterColumn<Guid>(
                name: "home_address_id",
                table: "employee",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "customer_id",
                table: "address",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_address_customer_customer_id",
                table: "address",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employee_address_home_address_id",
                table: "employee",
                column: "home_address_id",
                principalTable: "address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
