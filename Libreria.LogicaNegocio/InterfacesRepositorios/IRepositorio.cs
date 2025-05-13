using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T> where T : class
    {
        int Add(T nuevo);
        List<T> GetAll();
        T GetById(int id);

        void Delete(int id);
        int Update(T u);
    }
    

    
}
