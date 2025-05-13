using Libreria.DTOs.DTOs.DTOsAgencia;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.Mappers
{
    public class MapperAgencia
    {

        public static List<DTOAgencia> FromAgenciasToDtos(List<Agencia> Agencias)
        {
            List<DTOAgencia> listaDtos = new List<DTOAgencia>();
            foreach (var agencia in Agencias) {

                listaDtos.Add(new DTOAgencia { Id = agencia.Id, Nombre = agencia.Nombre});

            }
            return listaDtos;
        }

    }
}
