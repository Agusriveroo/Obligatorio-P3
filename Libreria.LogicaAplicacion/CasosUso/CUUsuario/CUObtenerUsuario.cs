using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUObtenerUsuario : ICUObtenerUsuario
    {
        private IRepositorioUsuario _repoUsuario;

        public CUObtenerUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public DTOUsuario ObtenerUsuario(int id)
        {
            Usuario u = _repoUsuario.GetById(id);

            return MapperUsuario.FromUsuarioToDto(u);
        }
    }
}
