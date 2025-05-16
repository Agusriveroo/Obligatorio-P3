using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.EnvioExceptions
{
    public class EnvioNoEncontradoException:Exception
    {
        public EnvioNoEncontradoException() : base("No se encontró el envio solicitado.")
        {
        }

        public EnvioNoEncontradoException(string message) : base(message)
        {
        }
    }
}
