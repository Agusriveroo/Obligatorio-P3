using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Edad { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public RolUsuario Rol { get; set; }


        public Usuario()
        {
            
        }

        public Usuario(string nombre, string apellido, int edad, string email, string password, RolUsuario rol)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Email = email;
            Password = password;
            Rol = rol;
            Validar();
        }

        public void Validar() {

            if (Edad < 18) 
            {
                throw new EdadMinimaException();
            }
            if (String.IsNullOrEmpty(Nombre)) 
            { 
                throw new NombreUsuarioException("El nombre no cumple");

            }
        
        
        }     

        
    }
}
