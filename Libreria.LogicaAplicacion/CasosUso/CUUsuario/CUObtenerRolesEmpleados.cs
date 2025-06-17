using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUObtenerRolesEmpleados : ICUObtenerRolesEmpleados
    {
        public List<DTORol> Obtener()
        {
            return new List<DTORol>
            {
                new DTORol { Id = (int)RolUsuario.Administrador, Nombre = "Administrador" },
                new DTORol { Id = (int)RolUsuario.Funcionario, Nombre = "Funcionario" },
                //NOTE: EN CASO DE DAR DE ALTA CLIENTE AGREGAR ESTA LINEA
                new DTORol { Id = (int)RolUsuario.Cliente, Nombre = "Cliente" },
            };
        }
    }
}