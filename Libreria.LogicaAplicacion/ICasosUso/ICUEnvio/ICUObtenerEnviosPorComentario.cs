using Libreria.DTOs.DTOs.DTOsEnvio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUObtenerEnviosPorComentario
    {
        List<DTOListaEnvioSimple> Ejecutar(string palabra, int clienteId);
    }
}
