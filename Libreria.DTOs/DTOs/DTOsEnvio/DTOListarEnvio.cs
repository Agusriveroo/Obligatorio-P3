using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.DTOs.DTOsEnvio
{
    public class DTOListarEnvio
    {
        public int IdEnvio { get; set; }
        public string NumeroTracking { get; set; }  
        public string EmailCliente { get; set; }
        public double PesoPaquete { get; set; }
        public string Estado { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public List<DTODetallesParaEnvios>? Detalles { get; set; }


        public int? LogueadoId { get; set; }
    }
}
