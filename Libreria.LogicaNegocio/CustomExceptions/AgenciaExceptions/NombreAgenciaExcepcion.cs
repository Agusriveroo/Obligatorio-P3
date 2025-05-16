using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.AgenciaExceptions
{
    public class NombreAgenciaExcepcion:Exception
    {
        public NombreAgenciaExcepcion() : base("El nombre de la agencia no puede estar vacio")
        {

        }

        public NombreAgenciaExcepcion(string? message) : base(message)
        {
        }
    }
}
