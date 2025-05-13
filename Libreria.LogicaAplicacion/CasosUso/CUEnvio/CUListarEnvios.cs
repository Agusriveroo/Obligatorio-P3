using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAccesoDatos.Repositorios;
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
    public class CUListarEnvios : ICUListarEnvios
    {
        private IRepositorioEnvio _repoEnvio;

        public CUListarEnvios(IRepositorioEnvio repositorioEnvio)
        {
            _repoEnvio = repositorioEnvio;
        }
        public List<DTOListarEnvio> ListarEnvios()
        {
            List<Envio> envios = _repoEnvio.GetAll();
            List<Envio> enviosEnProceso = envios.Where(e => e.Estado == EstadoEnvio.EN_PROCESO).ToList();

            if (enviosEnProceso.Any()) { 
                
                var dtoEnvios = MapperEnvio.FromListEnvioToListDto(enviosEnProceso);
                return dtoEnvios;

            }

            return new List<DTOListarEnvio>();
        }
    }
}
