using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.EnvioExceptions
{
    public class PesoException: Exception
    {
        public PesoException() : base("El peso no puede estar vacio")
        {

        }

        public PesoException(string? message) : base(message)
        {
        }
    }
}
