﻿// <auto-generated />
using System;
using CryptoAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CryptoAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221202200208_CreateInitial")]
    partial class CreateInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CryptoAPI.Crypto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("balance")
                        .HasColumnType("float");

                    b.Property<string>("client")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("cryptoAmount")
                        .HasColumnType("float");

                    b.Property<string>("currencyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("transferDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("transferType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("cryptos");
                });
#pragma warning restore 612, 618
        }
    }
}
