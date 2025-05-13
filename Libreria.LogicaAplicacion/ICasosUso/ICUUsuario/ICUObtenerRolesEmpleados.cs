using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUUsuario
{
    public interface ICUObtenerRolesEmpleados
    {
        List<DTORol> Obtener();
    }
}
