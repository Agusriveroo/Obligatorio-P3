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
    public class CUObtenerEnvio : ICUObtenerEnvio
    {
        private IRepositorioEnvio _repoEnvio;

        public CUObtenerEnvio(IRepositorioEnvio repositorioEnvio)
        {
            _repoEnvio = repositorioEnvio;
        }
        public DTOListarEnvio ObtenerEnvio(int id)
        {
           Envio e = _repoEnvio.GetById(id);

            return MapperEnvio.FromEnvioToDto(e);
        }
    }
}
