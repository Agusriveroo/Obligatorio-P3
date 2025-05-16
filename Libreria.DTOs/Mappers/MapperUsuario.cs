using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.Mappers
{
    public class MapperUsuario
    {
        public static Usuario FromDtoAltaUsuario(DTOAltaUsuario dto) 
        { 

            string passHashed = Utilidades.Cripto.HashPasswordConBcrypt(dto.Password,12);

            Usuario usuario = new Usuario(dto.Nombre, dto.Apellido, dto.Edad, dto.Email, passHashed, Enum.Parse<RolUsuario>(dto.Rol));

            return usuario;
        }

        public static DTOUsuario FromUsuarioToDto(Usuario usuario)
        {
            DTOUsuario dto = new DTOUsuario();
            dto.Id = usuario.Id;
            dto.Nombre = usuario.Nombre;
            dto.Apellido = usuario.Apellido;
            dto.Rol = usuario.Rol.ToString();
            dto.Email = usuario.Email;
            dto.Edad = usuario.Edad;
            dto.Password = usuario.Password;
            return dto;
        }

        public static Usuario FromDtoUsuarioToUsuario(DTOUsuario dto) { 
        
            Usuario u = new Usuario();
            u.Id = dto.Id;
            u.Nombre = dto.Nombre;
            u.Apellido = dto.Apellido;
            u.Edad = dto.Edad;
            u.Email = dto.Email;
            u.Rol = Enum.Parse<RolUsuario>(dto.Rol);
            u.Password = dto.Password;
            return u;



        }



        public static List<DTOListarEmpleado> FromListEmpleadoToListEmpleado(List<Usuario> usuarios) 
        { 
            List<DTOListarEmpleado> ret = new List<DTOListarEmpleado>();

            foreach (Usuario u in usuarios) 
            {
                DTOListarEmpleado dto = new DTOListarEmpleado();
                dto.Id = u.Id;
                dto.Nombre = u.Nombre;
                dto.Apellido = u.Apellido;
                dto.Edad = u.Edad;
                dto.Email = u.Email;
                dto.Rol = u.Rol.ToString();

                ret.Add(dto);


            }
            return ret;

        }
    }
}

