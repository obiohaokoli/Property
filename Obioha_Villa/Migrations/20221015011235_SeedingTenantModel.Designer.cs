﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Obioha_VillaAPI.Data;

#nullable disable

namespace Obioha_VillaAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221015011235_SeedingTenantModel")]
    partial class SeedingTenantModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Obioha_VillaAPI.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Built_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Current_Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("No_Of_Bedrooms")
                        .HasColumnType("int");

                    b.Property<int>("No_Of_Toilets")
                        .HasColumnType("int");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<string>("Property_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Purchase_Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Purchased_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Purpose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sitting_Rooms_No")
                        .HasColumnType("int");

                    b.Property<int>("Square_Feet")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Houses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Built_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1949),
                            Created_Date = new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(8975),
                            Current_Cost = 190000m,
                            ImageUrl = "Manchester.jpg",
                            Name = "Manchester_One",
                            No_Of_Bedrooms = 3,
                            No_Of_Toilets = 2,
                            Occupancy = 4,
                            Property_Type = "End Terraced House",
                            Purchase_Cost = 125000m,
                            Purchased_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1994),
                            Purpose = "Buy to Let",
                            Sitting_Rooms_No = 2,
                            Square_Feet = 75,
                            Updated_Date = new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9007)
                        },
                        new
                        {
                            Id = 2,
                            Built_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1969),
                            Created_Date = new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9011),
                            Current_Cost = 132000m,
                            ImageUrl = "Derby.jpg",
                            Name = "Derby_One",
                            No_Of_Bedrooms = 2,
                            No_Of_Toilets = 1,
                            Occupancy = 1,
                            Property_Type = "End Terraced House",
                            Purchase_Cost = 121500m,
                            Purchased_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1982),
                            Purpose = "Buy to Let",
                            Sitting_Rooms_No = 2,
                            Square_Feet = 75,
                            Updated_Date = new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9012)
                        });
                });

            modelBuilder.Entity("Obioha_VillaAPI.Models.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Deposite_Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imageurl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marriage_Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Middle_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Move_in_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("No_Of_kids")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tenancy_End_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tenancy_Period")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tenancy_Start_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Tenants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9085),
                            Deposite_Amount = 1200m,
                            First_Name = "Micheal",
                            Imageurl = "",
                            Last_Name = "kpeke",
                            Marriage_Status = "Married",
                            Middle_Name = "okigwe",
                            Move_in_date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2013),
                            Nationality = "Nigeria",
                            No_Of_kids = 2,
                            Tenancy_End_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014),
                            Tenancy_Period = "one year",
                            Tenancy_Start_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2013),
                            UpdatedDate = new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9088)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9090),
                            Deposite_Amount = 1200m,
                            First_Name = "Peter",
                            Imageurl = "",
                            Last_Name = "Obi",
                            Marriage_Status = "Married",
                            Middle_Name = "Awka",
                            Move_in_date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2013),
                            Nationality = "Nigeria",
                            No_Of_kids = 2,
                            Tenancy_End_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2014),
                            Tenancy_Period = "one year",
                            Tenancy_Start_Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2013),
                            UpdatedDate = new DateTime(2022, 10, 15, 2, 12, 35, 761, DateTimeKind.Local).AddTicks(9093)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}