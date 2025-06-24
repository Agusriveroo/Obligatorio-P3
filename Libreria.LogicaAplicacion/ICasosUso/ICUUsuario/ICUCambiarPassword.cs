using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUUsuario
{
    public interface ICUCambiarPassword
    {
        void Ejecutar(int idUsuario, string cActual, string cNueva);
    }
}
