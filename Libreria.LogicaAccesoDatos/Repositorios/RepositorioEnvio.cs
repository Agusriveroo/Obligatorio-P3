using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
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

        public List<Envio> GetByEmail(string email)
        {
            List<Envio> envios = _context.Envios
                .Include(e => e.Cliente)
                .Include(e => e.Empleado)
                .Include(e => e.Detalles)
                .Where(e => e.Cliente.Email == email)
                .ToList();

            return envios;
        }


        public List<Envio> GetAll()
        {
            return _context.Envios
                .Include(e => e.Cliente)
                .Include(e => e.Detalles)
                .ToList();
        }


        public Envio GetById(int id)
        {
            return _context.Envios
                .Include(e => e.Cliente)
                .Include(e => e.Detalles)
                .FirstOrDefault(e => e.Id == id);

        }

        public Envio GetByTracking(string tracking)
        {
            return _context.Envios.Include(e => e.Detalles).FirstOrDefault(e => e.NumeroTracking == tracking);
        }

        public int Update(Envio e)
        {
            _context.Envios.Update(e);
            _context.SaveChanges();
            return e.Id;
        }
    }
}
