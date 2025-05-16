using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class UsuarioNoEncontradoException: Exception
    {
        public UsuarioNoEncontradoException() : base("No se encontró el usuario solicitado.")
        {
        }

        public UsuarioNoEncontradoException(string message) : base(message)
        {
        }
    }
}
