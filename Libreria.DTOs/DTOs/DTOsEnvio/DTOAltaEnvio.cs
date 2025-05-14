using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.DTOs.DTOsEnvio
{
    public class DTOAltaEnvio
    {
        public int Id { get; set; }
        public int? EmpleadoId { get; set; } // quien está logueado y genera el envío


        public string EmailCliente { get; set; }

        public double PesoPaquete { get; set; }

        public string? TipoEnvio { get; set; } // "Comun" o "Urgente"

        // Para Comun
        public int AgenciaRetiroId { get; set; }

        // Para Urgente
        public string? DireccionPostal { get; set; }


        public int? LogueadoId { get; set; }


    }
}
