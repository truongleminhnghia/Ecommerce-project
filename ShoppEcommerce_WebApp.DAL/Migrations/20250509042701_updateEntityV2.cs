using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppEcommerce_WebApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateEntityV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_address_work_address_id",
                table: "employee");

            migrationBuilder.AlterColumn<Guid>(
                name: "work_address_id",
                table: "employee",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_address_work_address_id",
                table: "employee",
                column: "work_address_id",
                principalTable: "address",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_address_work_address_id",
                table: "employee");

            migrationBuilder.AlterColumn<Guid>(
                name: "work_address_id",
                table: "employee",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_address_work_address_id",
                table: "employee",
                column: "work_address_id",
                principalTable: "address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
