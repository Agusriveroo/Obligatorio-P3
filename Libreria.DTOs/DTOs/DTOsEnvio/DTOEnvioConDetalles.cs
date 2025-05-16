using Libreria.DTOs.DTOs.DTOsDetalleEnvio;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.DTOs.DTOsEnvio
{
    public class DTOEnvioConDetalles
    {
        public string NumeroTracking { get; set; }

        public string EmailCliente { get; set; }

        public double PesoPaquete { get; set; }

        public string Estado { get; set; }

        public List<DTODetallesParaEnvios> Detalles { get; set; }

    }

}
