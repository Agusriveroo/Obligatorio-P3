using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.AgenciaExceptions
{
    public class DireccionExcepcion:Exception
    {
        public DireccionExcepcion() : base("La direccion no puede estar vacio")
        {

        }

        public DireccionExcepcion(string? message) : base(message)
        {
        }
    }
}
