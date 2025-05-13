using Libreria.DTOs.DTOs.DTOsAgencia;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUAgencia;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUAgencia
{
    public class CUObtenerAgencias : ICUObtenerAgencias
    {
        private IRepositorioAgencia _repoAgencia;

        public CUObtenerAgencias(IRepositorioAgencia repoAgencia)
        {
            _repoAgencia = repoAgencia;
        }



        public List<DTOAgencia> ObtenerAgencias()
        {
            List<Agencia>listaAgencias = _repoAgencia.GetAll();

            return MapperAgencia.FromAgenciasToDtos(listaAgencias);
        }
    }
}
