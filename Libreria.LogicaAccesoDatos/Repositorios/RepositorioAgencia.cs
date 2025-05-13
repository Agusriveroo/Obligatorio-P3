using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAccesoDatos.Repositorios
{
    public class RepositorioAgencia:IRepositorioAgencia
    {
        private ApplicationDbContext _context;

        public RepositorioAgencia(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Agencia nuevo)
        {
            _context.Agencias.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Agencia> GetAll()
        {
            return _context.Agencias.ToList();
        }

        public Agencia GetById(int id)
        {
            return _context.Agencias.Find(id);
        }

        public int Update(Agencia u)
        {
            throw new NotImplementedException();
        }
    }
}
