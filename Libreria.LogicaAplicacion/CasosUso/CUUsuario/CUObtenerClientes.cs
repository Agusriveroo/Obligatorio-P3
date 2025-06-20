using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUObtenerClientes : ICUObtenerClientes
    {
        private IRepositorioUsuario _repoUsuario;

        public CUObtenerClientes(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public List<DTOListarEmpleado> Ejecutar()
        {
            var clientes = _repoUsuario.ObtenerClientes();

           
            return MapperUsuario.FromListEmpleadoToListEmpleado(clientes);

        }
    }
}
