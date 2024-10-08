using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using SETEC.Data.Entities;
using SETEC;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SETEC.Data.Entities
{
   public class Appdbcontext : DbContext

    {
        public Appdbcontext()
        {
        }

        public Appdbcontext(DbContextOptions<Appdbcontext> options)
            : base(options)
        { 
            
        }
       
       // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

           // optionsBuilder.UseNpgsql("Server = localhost; Port = 5432; Database =setec; Integrated Security = true;User name=diego;password=admin;"); // dentro de los parentesis se dene colocar el option string

               // .EnableSensitiveDataLogging(true); //para utilizar codigo  de c# en lugar de SQL
                //.UseLoggerFactory(new LoggerFactory().add;
           
        //}
        

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ActualidadCliente> ActualidadClientes { get; set; }
        public DbSet<HistoricoClientesContrato> HistoricoClientes { get; set; }
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Codgestion> Mastergestion { get; set; }
        public DbSet<SETEC.Data.Entities.Verificacion>? Verificacion { get; set; }
    }

}
