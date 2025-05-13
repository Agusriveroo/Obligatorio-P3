using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class EdadMinimaException:Exception
    {
        public EdadMinimaException() : base("La edad minima es 18 años")
        {
        }
        public EdadMinimaException(string? message) : base(message)
        {
        }
    }
}
