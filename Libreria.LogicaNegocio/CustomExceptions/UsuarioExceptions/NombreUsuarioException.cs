using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class NombreUsuarioException: Exception
    {
        public NombreUsuarioException() : base("El nombre de usuario no puede estar vacio")
        {

        }
        
        public NombreUsuarioException(string? message) : base(message)
        {
        }

    }
}
