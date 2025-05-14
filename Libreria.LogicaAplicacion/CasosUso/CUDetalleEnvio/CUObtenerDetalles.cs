using Libreria.DTOs.DTOs.DTOsDetalleEnvio;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUDetalleEnvio;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUDetalleEnvio
{
    public class CUObtenerDetalles : ICUObtenerDetalles
    {
        private IRepositorioDetalleEnvio _repoDetalle;

        public CUObtenerDetalles(IRepositorioDetalleEnvio repoDetalle)
        {
            _repoDetalle = repoDetalle;
        }

        public List<DTODetalle> ObtenerDetalles(int envioId)
        {
            var detalles = _repoDetalle.ObtenerPorEnvio(envioId);
            return MapperDetalleEnvio.FromDetallesToDto(detalles);
        }
    }
}
