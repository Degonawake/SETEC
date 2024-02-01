
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SETEC.Data.Entities;
namespace SETEC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
         
            builder.Services.AddDbContext<Appdbcontext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("conexion")));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);//para especificar que se utilizaran campos de fecha

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseDeveloperExceptionPage();//Se agregó para pode ver el detalle completo de errores
            }

            app.UseHttpsRedirection(); //PAra redigirir a HTTPS Y EVITAR ERROR DE CONEXION NO ES PRIVADA
            app.UseStaticFiles(); //Para poder usar archivos directos de la raiz

            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }



}