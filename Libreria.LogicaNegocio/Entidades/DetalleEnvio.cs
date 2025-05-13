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
        public required Usuario Empleado { get; set; }

        public required Envio Envio { get; set; }


    }
}
