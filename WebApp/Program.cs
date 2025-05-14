using Libreria.LogicaAccesoDatos;
using Libreria.LogicaAccesoDatos.Repositorios;
using Libreria.LogicaAplicacion.CasosUso.CUAgencia;
using Libreria.LogicaAplicacion.CasosUso.CUDetalleEnvio;
using Libreria.LogicaAplicacion.CasosUso.CUEnvio;
using Libreria.LogicaAplicacion.CasosUso.CUUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICUAgencia;
using Libreria.LogicaAplicacion.ICasosUso.ICUDetalleEnvio;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));



            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession();

            //ID - REPOS
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
            builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();  
            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
            builder.Services.AddScoped<IRepositorioDetalleEnvio, RepositorioDetalleEnvio>();


            //ID - CASOS DE USO

            //USUARIO
            builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ICUListarEmpleados, CUListarEmpleados>();
            builder.Services.AddScoped<ICUObtenerRolesEmpleados, CUObtenerRolesEmpleados>();
            builder.Services.AddScoped<ICULogin, CULogin>();
            builder.Services.AddScoped<ICUObtenerUsuario, CUObtenerUsuario>();
            builder.Services.AddScoped<ICUActualizarUsuario, CUActualizarUsuario>();
            builder.Services.AddScoped<ICUDeleteUsuario,CUDeleteUsuario>();
            builder.Services.AddScoped<ICUDetalleUsuario, CUDetalleUsuario>();

            //AGENCIA   
            builder.Services.AddScoped<ICUObtenerAgencias, CUObtenerAgencias>();

            //ENVIO
            builder.Services.AddScoped<ICUAltaEnvio, CUAltaEnvio>();
            builder.Services.AddScoped<ICUListarEnvios, CUListarEnvios>();
            builder.Services.AddScoped<ICUEditarEnvio, CUEditarEnvio>();
            builder.Services.AddScoped<ICUObtenerEnvio, CUObtenerEnvio>();

            //DETALLE ENVIO
            builder.Services.AddScoped<ICUAgregarComentario, CUAgregarComentario>();
            builder.Services.AddScoped<ICUObtenerDetalles, CUObtenerDetalles>();





            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
