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
   
        public string EmailCliente { get; set; }

        public double PesoPaquete { get; set; }

        public EstadoEnvio Estado { get; set; }

        public DateTime FechaFinalizacion { get; set; } = DateTime.Now;


        public int? LogueadoId { get; set; }
    }
}
