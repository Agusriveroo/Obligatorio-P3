using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUObtenerEnviosFechas : ICUObtenerEnviosFechas
    {
        private IRepositorioEnvio _repoEnvio;


        public CUObtenerEnviosFechas(IRepositorioEnvio repositorioEnvio)
        {
            _repoEnvio = repositorioEnvio;

        }

        public List<DTOListaEnvioSimple> Ejecutar(DateTime fechaInicio, DateTime fechaFin, EstadoEnvio? estado, int clienteId)
        {
            List<Envio> envios = _repoEnvio.GetByIdFechas(clienteId, fechaInicio, fechaFin, estado);
            List<DTOListaEnvioSimple> ret = MapperEnvio.FromListaEnvio(envios);
            return ret;
        }
    }
}
