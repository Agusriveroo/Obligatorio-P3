using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUCambiarPassword : ICUCambiarPassword
    {

        private IRepositorioUsuario _repoUsuario;
        public  CUCambiarPassword(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
     
        }
        public void Ejecutar(int idUsuario, string cActual, string cNueva)
        {
            var usuario = _repoUsuario.GetById(idUsuario);

            if (usuario == null)
            {
                throw new UsuarioNoEncontradoException("Usuario no encontrado");
            }

            if (!Cripto.VerifyPassword(cActual,usuario.Password)) 
            { 
                throw new PasswordIncorrectaException("Contraseña actual incorrecta");
            }

            var nuevaPasswordHash = Cripto.HashPasswordConBcrypt(cNueva,12);
            _repoUsuario.UpdatePassword(idUsuario, nuevaPasswordHash);

        }
    }
}
