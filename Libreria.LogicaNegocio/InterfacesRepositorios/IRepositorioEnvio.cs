using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEnvio: IRepositorio<Envio>
    {
        Envio GetByTracking(string tracking);

        List<Envio> GetByEmail(string email);

        List<Envio> GetByIdFechas(int clienteId, DateTime f1, DateTime f2, EstadoEnvio? estado);
    }
}
