
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Libreria.WebApi
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

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //ID - REPOS
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
            builder.Services.AddScoped<IRepositorioAgencia, RepositorioAgencia>();
            builder.Services.AddScoped<IRepositorioEnvio, RepositorioEnvio>();
            builder.Services.AddScoped<IRepositorioDetalleEnvio, RepositorioDetalleEnvio>();


            //ID - CASOS DE USO
            builder.Services.AddScoped<ICULogin, CULogin>();

            //USUARIO
            builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ICUListarEmpleados, CUListarEmpleados>();
            builder.Services.AddScoped<ICUObtenerRolesEmpleados, CUObtenerRolesEmpleados>();
            builder.Services.AddScoped<ICULogin, CULogin>();
            builder.Services.AddScoped<ICUObtenerUsuario, CUObtenerUsuario>();
            builder.Services.AddScoped<ICUActualizarUsuario, CUActualizarUsuario>();
            builder.Services.AddScoped<ICUDeleteUsuario, CUDeleteUsuario>();
            builder.Services.AddScoped<ICUDetalleUsuario, CUDetalleUsuario>();


            //AGENCIA   
            builder.Services.AddScoped<ICUObtenerAgencias, CUObtenerAgencias>();

            //ENVIO
            builder.Services.AddScoped<ICUAltaEnvio, CUAltaEnvio>();
            builder.Services.AddScoped<ICUListarEnvios, CUListarEnvios>();
            builder.Services.AddScoped<ICUEditarEnvio, CUEditarEnvio>();
            builder.Services.AddScoped<ICUObtenerEnvio, CUObtenerEnvio>();
            builder.Services.AddScoped<ICUObtenerEnvioPorTracking, CUObtenerEnvioPorTracking>();
            builder.Services.AddScoped<ICUObtenerEnviosCliente, CUObtenerEnviosCliente>();
            builder.Services.AddScoped<ICUObtenerEnviosFechas, CUObtenerEnviosFechas>();

            //DETALLE ENVIO
            builder.Services.AddScoped<ICUAgregarComentario, CUAgregarComentario>();
            builder.Services.AddScoped<ICUObtenerDetalles, CUObtenerDetalles>();


            //JWT
            //La clave debe ser almacenada en el json, o en el sistema operativo cuando esté en producción. 
            var clave = "UTzl^7yPl$5xrT6&{7RZCSG&O42MEK89$CW1XXRrN(> XqIp{W4s2S5$> KT$6CG!2M]'ZlrqH-t%eI4.X9W~u#qO+oX£+[?7QDAa"; 
            var claveCodificada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clave));
                builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        //Definir las verificaciones a realizar 
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = claveCodificada
                    };
                });


                var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
