using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.DTOs.DTOsEnvio
{
    public class DTOListaEnvioSimple
    {
        public string NumeroTracking { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public double PesoPaquete { get; set; }
    }
}
