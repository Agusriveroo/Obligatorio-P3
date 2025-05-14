using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.DTOs.DTOsDetalleEnvio
{
    public class DTODetalle
    {
        public int Id { get; set; }
        public string? Comentario { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;


        public int EnvioId { get; set; }

        public int? LogueadoId { get; set; }

        
    }
}
