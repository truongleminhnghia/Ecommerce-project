using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppEcommerce_WebApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "account",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "customer_id",
                table: "account",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "employee_id",
                table: "account",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    street = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    ward = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    district = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    address_detail = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    customer_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customer_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    home_address = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK_customer_address_home_address",
                        column: x => x.home_address,
                        principalTable: "address",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "store",
                columns: table => new
                {
                    store_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    store_name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    owner_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    address_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    phone_number = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_active = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store", x => x.store_id);
                    table.ForeignKey(
                        name: "FK_store_account_owner_id",
                        column: x => x.owner_id,
                        principalTable: "account",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_store_address_address_id",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    employee_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ref_code = table.Column<string>(type: "VARCHAR(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    home_address_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    work_address_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    store_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_employee_address_home_address_id",
                        column: x => x.home_address_id,
                        principalTable: "address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_address_work_address_id",
                        column: x => x.work_address_id,
                        principalTable: "address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employee_store_store_id",
                        column: x => x.store_id,
                        principalTable: "store",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_account_customer_id",
                table: "account",
                column: "customer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_account_employee_id",
                table: "account",
                column: "employee_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_address_customer_id",
                table: "address",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_home_address",
                table: "customer",
                column: "home_address");

            migrationBuilder.CreateIndex(
                name: "IX_employee_home_address_id",
                table: "employee",
                column: "home_address_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_store_id",
                table: "employee",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_work_address_id",
                table: "employee",
                column: "work_address_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_store_address_id",
                table: "store",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_is_active",
                table: "store",
                column: "is_active");

            migrationBuilder.CreateIndex(
                name: "IX_store_owner_id",
                table: "store",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_store_name",
                table: "store",
                column: "store_name");

            migrationBuilder.AddForeignKey(
                name: "FK_account_customer_customer_id",
                table: "account",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_account_employee_employee_id",
                table: "account",
                column: "employee_id",
                principalTable: "employee",
                principalColumn: "employee_id");

            migrationBuilder.AddForeignKey(
                name: "FK_address_customer_customer_id",
                table: "address",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_customer_customer_id",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "FK_account_employee_employee_id",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "FK_address_customer_customer_id",
                table: "address");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "store");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropIndex(
                name: "IX_account_customer_id",
                table: "account");

            migrationBuilder.DropIndex(
                name: "IX_account_employee_id",
                table: "account");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "account");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "account");

            migrationBuilder.DropColumn(
                name: "customer_id",
                table: "account");

            migrationBuilder.DropColumn(
                name: "employee_id",
                table: "account");
        }
    }
}
