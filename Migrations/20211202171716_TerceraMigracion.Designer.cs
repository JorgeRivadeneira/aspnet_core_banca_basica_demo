﻿// <auto-generated />
using System;
using BancaBasica.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BancaBasica.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211202171716_TerceraMigracion")]
    partial class TerceraMigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BancaBasica.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("BancaBasica.Models.Cuenta", b =>
                {
                    b.Property<int>("Id_Cuenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.Property<int?>("clienteId")
                        .HasColumnType("int");

                    b.HasKey("Id_Cuenta");

                    b.HasIndex("clienteId");

                    b.ToTable("cuenta");
                });

            modelBuilder.Entity("BancaBasica.Models.Cuenta", b =>
                {
                    b.HasOne("BancaBasica.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteId");

                    b.Navigation("cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
