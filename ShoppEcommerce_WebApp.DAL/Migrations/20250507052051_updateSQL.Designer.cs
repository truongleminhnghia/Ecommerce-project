﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppEcommerce_WebApp.DAL.Context;

#nullable disable

namespace ShoppEcommerce_WebApp.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250507052051_updateSQL")]
    partial class updateSQL
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("account_id");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("avatar");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("char(36)")
                        .HasColumnName("customer_id");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("email");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("char(36)")
                        .HasColumnName("employee_id");

                    b.Property<string>("EnumAccountStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("account_status");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("first_name");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("gender");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("phone");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)")
                        .HasColumnName("role_id");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("EnumAccountStatus");

                    b.HasIndex("RoleId");

                    b.ToTable("account");
                });

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AddressDetail")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("address_detail");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("country");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)")
                        .HasColumnName("customer_id");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("district");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("street");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ward");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("address");
                });

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("customer_id");

                    b.Property<Guid?>("HomeAddressId")
                        .HasColumnType("char(36)")
                        .HasColumnName("home_address");

                    b.HasKey("Id");

                    b.HasIndex("HomeAddressId");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("employee_id");

                    b.Property<Guid?>("HomeAddressId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasColumnName("home_address_id");

                    b.Property<string>("RefCode")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnName("ref_code");

                    b.Property<Guid?>("StoreId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasColumnName("store_id");

                    b.Property<Guid?>("WorkAddressId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasColumnName("work_address_id");

                    b.HasKey("Id");

                    b.HasIndex("HomeAddressId")
                        .IsUnique();

                    b.HasIndex("StoreId");

                    b.HasIndex("WorkAddressId")
                        .IsUnique();

                    b.ToTable("employee");
                });

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("role_id");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("role_name");

                    b.HasKey("Id");

                    b.HasIndex("RoleName");

                    b.ToTable("role");
                });

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("store_id");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("char(36)")
                        .HasColumnName("address_id");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("char(36)")
                        .HasColumnName("owner_id");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone_number");

                    b.Property<string>("StatusActice")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("is_active");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("store_name");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("StatusActice");

                    b.HasIndex("StoreName");

                    b.ToTable("store");
                });

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Account", b =>
                {
                    b.HasOne("ShoppEcommerce_WebApp.Common.Entities.Customer", "Customer")
                        .WithOne("Account")
                        .HasForeignKey("ShoppEcommerce_WebApp.Common.Entities.Account", "CustomerId");

                    b.HasOne("ShoppEcommerce_WebApp.Common.Entities.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("ShoppEcommerce_WebApp.Common.Entities.Account", "EmployeeId");

                    b.HasOne("ShoppEcommerce_WebApp.Common.Entities.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Address", b =>
                {
                    b.HasOne("ShoppEcommerce_WebApp.Common.Entities.Customer", "Customer")
                        .WithMany("OrderAddresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Customer", b =>
                {
                    b.HasOne("ShoppEcommerce_WebApp.Common.Entities.Address", "HomeAddress")
                        .WithMany()
                        .HasForeignKey("HomeAddressId");

                    b.Navigation("HomeAddress");
                });

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Employee", b =>
                {
                    b.HasOne("ShoppEcommerce_WebApp.Common.Entities.Address", "HomeAddress")
                        .WithOne("EmployeeHome")
                        .HasForeignKey("ShoppEcommerce_WebApp.Common.Entities.Employee", "HomeAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppEcommerce_WebApp.Common.Entities.Store", "Store")
                        .WithMany("Employees")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppEcommerce_WebApp.Common.Entities.Address", "WorkAddress")
                        .WithOne("EmployeeWork")
                        .HasForeignKey("ShoppEcommerce_WebApp.Common.Entities.Employee", "WorkAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HomeAddress");

                    b.Navigation("Store");

                    b.Navigation("WorkAddress");
                });

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Store", b =>
                {
                    b.HasOne("ShoppEcommerce_WebApp.Common.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppEcommerce_WebApp.Common.Entities.Account", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Address", b =>
                {
                    b.Navigation("EmployeeHome");

                    b.Navigation("EmployeeWork");
                });

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Customer", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("OrderAddresses");
                });

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Employee", b =>
                {
                    b.Navigation("Account");
                });

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("ShoppEcommerce_WebApp.Common.Entities.Store", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
