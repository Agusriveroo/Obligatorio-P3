using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUObtenerEnviosFechas
    {
        List<DTOListaEnvioSimple> Ejecutar(DateTime fechaInicio, DateTime fechaFin, EstadoEnvio? estado, int clienteId);
    }
}
