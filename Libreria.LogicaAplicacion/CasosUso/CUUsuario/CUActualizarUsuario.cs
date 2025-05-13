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
    public class CUActualizarUsuario : ICUActualizarUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;

        public CUActualizarUsuario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }
        public void ActualizarUsuario(DTOUsuario dto)
        {

            try
            {
                Usuario u = MapperUsuario.FromDtoUsuarioToUsuario(dto);
                u.Validar();
                int r = _repoUsuario.Update(u);

                RegistroAuditoria aud = new RegistroAuditoria(dto.LogueadoId,AccionesAuditoria.ACTUALIZAR,"Usuario",r.ToString(),"Actualizacion correcta");
                _repoAuditoria.Auditar(aud);
            }
            catch (EdadMinimaException e)
            {
                RegistroAuditoria aud = new RegistroAuditoria(dto.LogueadoId, AccionesAuditoria.ACTUALIZAR, "Usuario", null, "ERROR:" + e.Message);
                _repoAuditoria.Auditar(aud);
                throw;
            }
            catch (NombreUsuarioException e)
            {
                RegistroAuditoria aud = new RegistroAuditoria(dto.LogueadoId, AccionesAuditoria.ACTUALIZAR, "Usuario", null, "ERROR:" + e.Message);
                _repoAuditoria.Auditar(aud);
                throw;
            }
            catch (Exception e)
            {
                RegistroAuditoria aud = new RegistroAuditoria(dto.LogueadoId, AccionesAuditoria.ACTUALIZAR, "Usuario", null, "ERROR:" + e.Message);
                _repoAuditoria.Auditar(aud);
                throw;
                
            }



        }
    }
}
