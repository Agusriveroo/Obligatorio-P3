using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.EnvioExceptions
{
    public class PesoNegativoExcepcion:Exception
    {
        public PesoNegativoExcepcion() : base("El peso no puede ser negativo")
        {

        }

        public PesoNegativoExcepcion(string? message) : base(message)
        {
        }
    }
}
