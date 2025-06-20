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
    public class CUObtenerEnviosCliente : ICUObtenerEnviosCliente
    {
        private IRepositorioEnvio _repoEnvio;


        public CUObtenerEnviosCliente(IRepositorioEnvio repositorioEnvio)
        {
            _repoEnvio = repositorioEnvio;
        }




        public List<DTOListarEnvio> Ejecutar(string email)
        {
            var envios = _repoEnvio.GetByEmail(email)
                           .OrderByDescending(e => e.Fecha)
                           .ToList();

            return MapperEnvio.FromListEnvioToListDto(envios);

           
        }
    }
}
