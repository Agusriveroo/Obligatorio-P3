using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvio: IRepositorioEnvio
    {
        private ApplicationDbContext _context;
        public RepositorioEnvio(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Envio nuevo)
        {
            _context.Envios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Envio> GetAll()
        {
            return _context.Envios.ToList();
        }

        public Envio GetById(int id)
        {
            return _context.Envios.Find(id);
        }

        public int Update(Envio e)
        {
            _context.Envios.Update(e);
            _context.SaveChanges();
            return e.Id;
        }
    }
}
