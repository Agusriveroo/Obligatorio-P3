using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUListarEmpleados : ICUListarEmpleados
    {
        private IRepositorioUsuario _repoUsuario;

        public CUListarEmpleados(IRepositorioUsuario repositorioUsuario)
        {
            _repoUsuario = repositorioUsuario;
        }

        public List<DTOListarEmpleado> ListarEmpleados()
        {
            List<Usuario> usuarios = _repoUsuario.GetAll();

            //NOTE: EN CASO DE LISTAR TODOS LOS USUARIOS, NO SE FILTRA POR ROL
            List<Usuario> empleados = usuarios.Where(u => u.Rol == RolUsuario.Administrador || u.Rol == RolUsuario.Funcionario).ToList();

            if (empleados.Any())
            {
                var dtoEmpleados = MapperUsuario.FromListEmpleadoToListEmpleado(empleados);
                return dtoEmpleados;
            }

            return new List<DTOListarEmpleado>();
        }
    }

}

