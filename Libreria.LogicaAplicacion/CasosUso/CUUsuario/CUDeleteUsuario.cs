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
    public class CUDeleteUsuario:ICUDeleteUsuario
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;

        public CUDeleteUsuario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }

        public void Delete(int id)
        {
            try
            {

                Usuario u = _repoUsuario.GetById(id);
                if (u == null) throw new Exception("Usuario no encontrado");

                _repoUsuario.Delete(id);

                RegistroAuditoria aud = new RegistroAuditoria(u.Id, AccionesAuditoria.ELIMINAR, "Usuario", u.Id.ToString(), "Eliminación correcta");
                _repoAuditoria.Auditar(aud);
            }
            catch (Exception e)
            {
                RegistroAuditoria aud = new RegistroAuditoria(id, AccionesAuditoria.ELIMINAR, "Usuario", null, "ERROR");
                _repoAuditoria.Auditar(aud);
                throw;
            }
        }

    }
}
