using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAccesoDatos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Comun> Comunes { get; set; }
        public DbSet<DetalleEnvio> DetallesEnvios { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Urgente> Urgentes { get; set; }
        public DbSet<RegistroAuditoria> RegistrosAuditoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<Envio>()
                .HasOne(e => e.Empleado)
                .WithMany()
                .HasForeignKey(e => e.EmpleadoId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Envio>()
                .Property(e => e.EmailCliente)
                .IsRequired()  
                .HasMaxLength(256);

            modelBuilder.Entity<Envio>()
                .Property(e => e.Estado)
                .HasConversion<string>();
        }

    }
}
