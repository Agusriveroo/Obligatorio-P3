using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class PasswordIncorrectaException:Exception
    {
        public PasswordIncorrectaException() : base("Contraseña incorrecta.")
        {
        }

        public PasswordIncorrectaException(string message) : base(message)
        {
        }

    }
}
