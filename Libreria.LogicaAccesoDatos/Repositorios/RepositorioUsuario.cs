using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private ApplicationDbContext _context;

        public RepositorioUsuario(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Usuario nuevo)
        {
            _context.Usuarios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public void Delete(int id)
        {
            var item = _context.Usuarios.FirstOrDefault(x => x.Id == id);
          
                _context.Usuarios.Remove(item);
                _context.SaveChanges();
          
         
        }

        public Usuario FindByEmail(string email)
        {
            return _context.Usuarios.Where(x => x.Email == email).SingleOrDefault();
        }

        public List<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetById(int id)
        {   
            return _context.Usuarios.Find(id);
        }

        public List<Usuario> ObtenerClientes()
        {
            return _context.Usuarios
            .Where(u => u.Rol == RolUsuario.Cliente)
            .OrderBy(u => u.NombreCompleto.Apellido)
            .ThenBy(u => u.NombreCompleto.Nombre)
            .ToList();
        }

        public int Update(Usuario u)
        {
            _context.Usuarios.Update(u);
            _context.SaveChanges();
            return u.Id;
        }

        public void UpdatePassword(int id, string newPassword)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuario != null)
            {
                usuario.Password = newPassword;
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }
        }
    }
}
