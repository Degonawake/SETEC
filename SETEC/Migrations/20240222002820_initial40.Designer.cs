﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SETEC.Data.Entities;

#nullable disable

namespace SETEC.Migrations
{
    [DbContext(typeof(Appdbcontext))]
    [Migration("20240222002820_initial40")]
    partial class initial40
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SETEC.Data.Entities.ActualidadCliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Antiguedad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Articulos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Canal_de_venta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Descuento")
                        .HasColumnType("float");

                    b.Property<int>("Dias_de_atraso")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Agenda")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gestor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Monto_mensual_Factura")
                        .HasColumnType("float");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero_telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Pago_con_descuento")
                        .HasColumnType("float");

                    b.Property<double>("Saldo_en_Mora")
                        .HasColumnType("float");

                    b.Property<double>("Saldo_total_credito")
                        .HasColumnType("float");

                    b.Property<string>("Tipo_de_cartera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Vencimiento_factura")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("ActualidadClientes");
                });

            modelBuilder.Entity("SETEC.Data.Entities.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SETEC.Data.Entities.Codgestion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("DescGestion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("idgestion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Mastergestion");
                });

            modelBuilder.Entity("SETEC.Data.Entities.HistoricoClientesContrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo_Gestion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desc_gestion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Agenda")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_NuevaVisita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Promesa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fechagestion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Latitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Monto_promesa")
                        .HasColumnType("float");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HistoricoClientes");
                });

            modelBuilder.Entity("SETEC.Data.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("empresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
