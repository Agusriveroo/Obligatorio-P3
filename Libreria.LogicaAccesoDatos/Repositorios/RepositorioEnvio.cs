using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
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
            return _context.Envios
                                .Include(e => e.Cliente)   
                                .Include(e => e.Detalles)
                                .FirstOrDefault(e => e.NumeroTracking == tracking);
        }

        public int Update(Envio e)
        {
            var envioExistente = _context.Envios.Find(e.Id);

            envioExistente.Estado = e.Estado;
          
            _context.SaveChanges();

            return envioExistente.Id;
        }

        public List<Envio> GetByIdFechas(int clienteId, DateTime f1, DateTime f2, EstadoEnvio? estado)
        {
            var ret = _context.Envios
                .Include(e => e.Cliente)
                .Where(e => e.ClienteId == clienteId && e.Fecha.Date >= f1.Date && e.Fecha.Date <= f2.Date.AddDays(1));

            if (estado.HasValue) 
            { 
                ret = ret.Where(e => e.Estado == estado.Value);
            }

            return ret.OrderBy(e => e.NumeroTracking).ToList();
        }

        public List<Envio> BuscarPorComentario(string palabra, int clienteId)
        {

            if (string.IsNullOrWhiteSpace(palabra))
                return new List<Envio>();

            return _context.Envios
                .Include(e => e.Cliente)
                .Include(e => e.Detalles)
                .Where(e => e.ClienteId == clienteId && e.Detalles.Any(d => d.Comentario.ToLower().Contains(palabra)))
                .OrderBy(e => e.Fecha)
                .ToList();
        }
    }
}
