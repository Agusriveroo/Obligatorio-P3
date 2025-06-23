using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUObtenerEnviosPorComentario:ICUObtenerEnviosPorComentario
    {
        private IRepositorioEnvio _repoEnvio;


        public CUObtenerEnviosPorComentario(IRepositorioEnvio repositorioEnvio)
        {
            _repoEnvio = repositorioEnvio;

        }

        public List<DTOListaEnvioSimple> Ejecutar(string palabra, int clienteId)
        {
            var envios = _repoEnvio.BuscarPorComentario(palabra, clienteId);
            return MapperEnvio.FromListaEnvio(envios);

        }
    }
}
