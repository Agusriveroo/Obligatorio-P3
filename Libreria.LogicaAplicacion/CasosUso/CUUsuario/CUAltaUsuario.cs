using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAccesoDatos.Repositorios;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUAltaUsuario : ICUAltaUsuario
    {
        
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;

        public CUAltaUsuario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }

        //TODO : Validar que el login sea de un Administrador 
        public void AltaEmpleado(DTOAltaUsuario nuevo) {


            try
            {
                Usuario u = MapperUsuario.FromDtoAltaUsuario(nuevo);

                if (string.IsNullOrEmpty(u.NombreCompleto.Nombre) || string.IsNullOrEmpty(u.NombreCompleto.Apellido)) throw new NombreUsuarioException();
        
                if (u.Edad < 18) throw new EdadMinimaException();

                Console.WriteLine("{u.NombreCompleto}'");
                int idEntidad = _repoUsuario.Add(u);

                RegistroAuditoria a = new RegistroAuditoria(nuevo.LogueadoId, AccionesAuditoria.ALTA, u.GetType().Name, idEntidad.ToString(), "Alta correcta");
                _repoAuditoria.Auditar(a);


            }
            catch(Exception e)
            {
                RegistroAuditoria a = new RegistroAuditoria(nuevo.LogueadoId, AccionesAuditoria.ALTA, "Usuario", null, "ERROR" + e.Message);
                _repoAuditoria.Auditar(a);
                throw;
            }



    
               
        }

    }
}
