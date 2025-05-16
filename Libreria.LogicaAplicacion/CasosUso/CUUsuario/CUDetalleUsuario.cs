using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUDetalleUsuario : ICUDetalleUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;

        public CUDetalleUsuario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }


        public DTOUsuario ObtenerDetalles(int id, int idUsuarioLogueado)
        {
            try
            {
                Usuario u = _repoUsuario.GetById(id);

                if (u == null)
                {
                    throw new UsuarioNoEncontradoException();
                }

                DTOUsuario dto = MapperUsuario.FromUsuarioToDto(u);

                if (dto == null)
                {
                    throw new Exception("Error al mapear el usuario a DTO");
                }

           
                RegistroAuditoria aud = new RegistroAuditoria(dto.LogueadoId, AccionesAuditoria.CONSULTAR, "Usuario", u.Id.ToString(), "Consulta correcta");
                _repoAuditoria.Auditar(aud);

                return dto;
            }
            catch (Exception e)
            {
        
                RegistroAuditoria aud = new RegistroAuditoria(idUsuarioLogueado, AccionesAuditoria.CONSULTAR, "Usuario", null, "ERROR: " + e.Message);
                _repoAuditoria.Auditar(aud);
                return null;
            }
        }

    }
}
