﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace store_backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231217131656_initmigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CategoryDTO", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<bool>("active")
                        .HasColumnType("boolean");

                    b.Property<string>("createdby")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("createddate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("modifiedby")
                        .HasColumnType("text");

                    b.Property<DateTime?>("modifieddate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("ProductDTO", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<bool>("active")
                        .HasColumnType("boolean");

                    b.Property<int>("category_id")
                        .HasColumnType("integer");

                    b.Property<string>("createdby")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("createddate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("modifiedby")
                        .HasColumnType("text");

                    b.Property<DateTime?>("modifieddate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("plu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("ProductVariantDTO", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<bool>("active")
                        .HasColumnType("boolean");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("createdby")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("createddate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("image_location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("modifiedby")
                        .HasColumnType("text");

                    b.Property<DateTime?>("modifieddate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("price")
                        .HasColumnType("integer");

                    b.Property<int>("product_id")
                        .HasColumnType("integer");

                    b.Property<int>("qty")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("productvariants");
                });
#pragma warning restore 612, 618
        }
    }
}
