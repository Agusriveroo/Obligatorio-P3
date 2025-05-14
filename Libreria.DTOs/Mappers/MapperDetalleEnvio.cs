using Libreria.DTOs.DTOs.DTOsDetalleEnvio;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.Mappers
{
    public class MapperDetalleEnvio
    {
        public static DTODetalle FromDetalleToDto(DetalleEnvio detalleEnvio) {

            return new DTODetalle
            {

                Id = detalleEnvio.Id,
                Comentario = detalleEnvio.Comentario,
                Fecha = detalleEnvio.Fecha,
                EnvioId = detalleEnvio.EnvioId,
                LogueadoId = detalleEnvio.Empleado?.Id,
            };
        
        }

        public static List<DTODetalle> FromDetallesToDto(List<DetalleEnvio> dEnvios)
        {
            return dEnvios.Select(detallesE => new DTODetalle
            {
                Id = detallesE.Id,
                Comentario = detallesE.Comentario,
                Fecha = detallesE.Fecha,
                EnvioId = detallesE.EnvioId,
                LogueadoId = detallesE.Empleado?.Id
            }).ToList();
        }




    }
}
