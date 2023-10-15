﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SETEC.Data.Entities;

#nullable disable

namespace SETEC.Migrations
{
    [DbContext(typeof(Appdbcontext))]
    [Migration("20230918013354_9time")]
    partial class _9time
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SETEC.Data.Entities.ActualidadCliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Antiguedad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Articulos")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Canal_de_venta")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Contrato")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Descuento")
                        .HasColumnType("double precision");

                    b.Property<int>("Dias_de_atraso")
                        .HasColumnType("integer");

                    b.Property<string>("Gestor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Identidad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Monto_mensual_Factura")
                        .HasColumnType("double precision");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero_telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Pago_con_descuento")
                        .HasColumnType("double precision");

                    b.Property<double>("Saldo_en_Mora")
                        .HasColumnType("double precision");

                    b.Property<double>("Saldo_total_credito")
                        .HasColumnType("double precision");

                    b.Property<string>("Tipo_de_cartera")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Vencimiento_factura")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("ActualidadClientes");
                });

            modelBuilder.Entity("SETEC.Data.Entities.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SETEC.Data.Entities.HistoricoClientesContrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo_Gestion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Contrato")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Desc_gestion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha_Promesa")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Fechagestion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Identidad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Monto_promesa")
                        .HasColumnType("double precision");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("HistoricoClientes");
                });
#pragma warning restore 612, 618
        }
    }
}
