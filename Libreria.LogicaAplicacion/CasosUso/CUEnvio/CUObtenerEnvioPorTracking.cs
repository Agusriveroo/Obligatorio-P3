using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUObtenerEnvioPorTracking : ICUObtenerEnvioPorTracking
    {
        private IRepositorioEnvio _repoEnvio;
        

        public CUObtenerEnvioPorTracking(IRepositorioEnvio repositorioEnvio)
        {
            _repoEnvio = repositorioEnvio;
           
        }

        public DTOEnvioConDetalles ObtenerPorTracking(string tracking)
        {
            Envio e = _repoEnvio.GetByTracking(tracking);

            if (e == null) throw new Exception($"No se encontró un envío con el número de tracking '{tracking}'.");

            return MapperEnvio.FromEnvioToDtoConDetalles(e);
           
        }
    }
}
