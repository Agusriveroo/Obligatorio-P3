using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class DetalleEnvio
    {

        public int Id { get; set; }
        public string? Comentario { get; set; }

        public DateTime Fecha { get; set; }
        public int? EmpleadoId { get; set; }  
        public Usuario? Empleado { get; set; }
        public int EnvioId { get; set; }
        public Envio? Envio { get; set; }

        public DetalleEnvio()
        {
            
        }

        public DetalleEnvio(string? comentario, DateTime fecha, Usuario empleado, Envio envio)
        {
            Comentario = comentario;
            Fecha = fecha;
            Empleado = empleado;
            Envio = envio;
        }
    }
}
