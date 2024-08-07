﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SETEC.Data.Entities;

#nullable disable

namespace SETEC.Migrations
{
    [DbContext(typeof(Appdbcontext))]
    partial class AppdbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Agencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Agente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Antiguedad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Articulos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Canal_de_venta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cartera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Consolidado_BD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Descuento")
                        .HasColumnType("float");

                    b.Property<int>("Dias_de_atraso")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion_Empresa_Labor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Empresa_Labor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado_Gest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Agenda")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gen1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gen2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gen3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gestionado")
                        .HasColumnType("bit");

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

                    b.Property<string>("Tel_Empresa_Labor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoGestion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo_de_cartera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Vencimiento_factura")
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

                    b.Property<string>("Agencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Agente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cartera")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<double>("Descuento")
                        .HasColumnType("float");

                    b.Property<DateTime>("Fecha_Agenda")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_NuevaVisita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Promesa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fechagestion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gestor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Latitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Monto_promesa")
                        .HasColumnType("float");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Saldo_Total")
                        .HasColumnType("float");

                    b.Property<double>("Saldo_mora")
                        .HasColumnType("float");

                    b.Property<string>("Tipo_Ingreso")
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

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("SETEC.Data.Entities.Verificacion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Archivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ave_Empresa_Labor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bloque_Empresa_Labor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Calle_Empresa_Labor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Casa_Empresa_Labor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClienteEmpresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColoniaLocalAnterior")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Colonia_Empresa_Labor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color_Empresa_Labor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("CotizaIHSS")
                        .HasColumnType("bit");

                    b.Property<bool?>("CotizaINJUPEMP")
                        .HasColumnType("bit");

                    b.Property<bool?>("CotizaRap")
                        .HasColumnType("bit");

                    b.Property<string>("Depto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dictamen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionSucursal_Empresa_Labor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Edificio_Empresa_Labor")
                        .HasColumnType("bit");

                    b.Property<string>("Empresa_Labor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Empresa_Verificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Estacionamiento")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Creacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Verificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormadePago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoEstacionamiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotografiaPermisoOperacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gestor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HorarioTrabajo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("HorasExtras")
                        .HasColumnType("bit");

                    b.Property<string>("Identidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("IngresoMensual")
                        .HasColumnType("float");

                    b.Property<string>("JefeInmediato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Local")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobiliario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoviemientoClientes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_Cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Peatonal_Empresa_Labor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PermisoOperacion")
                        .HasColumnType("bit");

                    b.Property<string>("PersonaConfirma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Planta1_Empresa_Labor")
                        .HasColumnType("bit");

                    b.Property<bool?>("Planta2_Empresa_Labor")
                        .HasColumnType("bit");

                    b.Property<double?>("Promedio")
                        .HasColumnType("float");

                    b.Property<string>("Puesto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PuestoPersonaConfirma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonNoConfirmacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonNoRealizacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonNuevaVisita")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RubroEmpresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SePudoRealizar")
                        .HasColumnType("bit");

                    b.Property<bool?>("SeSugiereNuevaVisita")
                        .HasColumnType("bit");

                    b.Property<string>("Sector_Empresa_Labor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusConformacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Sucursal_Empresa_Labor")
                        .HasColumnType("bit");

                    b.Property<string>("TamEmpresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel_Empresa_Labor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoRRHH")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TiempoLocal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TiempoLocalActual")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TiempoLocalAnterior")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tienda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UbicacionGPS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZonaEtapa_Empresa_Labor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Verificacion");
                });
#pragma warning restore 612, 618
        }
    }
}
