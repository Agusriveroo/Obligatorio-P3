using Libreria.DTOs.DTOs.DTOsAgencia;
using Libreria.DTOs.DTOs.DTOsDetalleEnvio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUDetalleEnvio
{
    public interface ICUObtenerDetalles
    {
        List<DTODetalle> ObtenerDetalles(int envioId);
    }
}
