using Libreria.DTOs.DTOs.DTOsDetalleEnvio;
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
    public class RepositorioDetalleEnvio : IRepositorioDetalleEnvio
    {
        private ApplicationDbContext _context;

        public RepositorioDetalleEnvio(ApplicationDbContext context)
        {
            _context = context;
        }


        public int Add(DetalleEnvio nuevo)
        {
            _context.DetallesEnvios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<DetalleEnvio> GetAll()
        {
           return _context.DetallesEnvios.ToList();
        }

        public DetalleEnvio GetById(int id)
        {
            return _context.DetallesEnvios.Find(id);
        }

        public int Update(DetalleEnvio u)
        {
            _context.DetallesEnvios.Update(u);
            _context.SaveChanges();
            return u.Id;
        }

      

        public List<DetalleEnvio> ObtenerPorEnvio(int idEnvio)
        {
            return _context.DetallesEnvios
                .Where(x => x.EnvioId == idEnvio)
                .ToList();

        }
    }
}
