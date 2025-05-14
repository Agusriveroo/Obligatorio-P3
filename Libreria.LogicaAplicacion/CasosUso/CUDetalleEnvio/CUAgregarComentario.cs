using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUDetalleEnvio;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUDetalleEnvio
{
    public class CUAgregarComentario : ICUAgregarComentario
    {

        private readonly IRepositorioDetalleEnvio _repoDetalle;
        private readonly IRepositorioEnvio _repoEnvio;
        private readonly IRepositorioUsuario _repoUsuario;

        public CUAgregarComentario(IRepositorioDetalleEnvio repoDetalle, IRepositorioEnvio repoEnvio, IRepositorioUsuario repoUsuario)
        {
            _repoDetalle = repoDetalle;
            _repoEnvio = repoEnvio;
            _repoUsuario = repoUsuario;
        }

        public void AgregarComentario(int envioId, int? empleadoId, string comentario)
        {
            var envio = _repoEnvio.GetById(envioId);
            

            if (envio == null)
                throw new Exception("Envío o Empleado no encontrado");

            if (envio.Estado != EstadoEnvio.EN_PROCESO)
                throw new Exception("No se puede comentar un envío finalizado");

            var detalle = new DetalleEnvio
            {
                Comentario = comentario,
                Fecha = DateTime.Now,
                EnvioId = envioId,
                EmpleadoId = empleadoId
            };

            if (empleadoId.HasValue)
            {
                var empleado = _repoUsuario.GetById(empleadoId.Value);
                if (empleado != null)
                    detalle.EmpleadoId = empleado.Id;
            }


            _repoDetalle.Add(detalle);

        }
    }
   
}
