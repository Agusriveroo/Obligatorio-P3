using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CULogin : ICULogin
    {
        private IRepositorioUsuario _repoUsuario;

        public CULogin(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public DTOUsuario VerificarDatos(DTOUsuario dto)
        {
            Usuario u =  _repoUsuario.FindByEmail(dto.Email);

            bool passOk = Utilidades.Cripto.VerifyPassword(dto.Password, u.Password);

            if (u != null && passOk)
            {
                    
                return MapperUsuario.FromUsuarioToDto(u);

            }
            else
            {
                throw new Exception("Usuario o contraseña incorrectos");
                //TODO Agregar excepcion propia
            }
        }
    }
}
