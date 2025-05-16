using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
     public class EmailClienteException:Exception
     {
        public EmailClienteException() : base("El email del cliente no puede ser vacio")
        {
        }
        public EmailClienteException(string? message) : base(message)
        {
        }
     }
}
