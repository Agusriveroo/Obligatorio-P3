using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using Libreria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Libreria.DTOs.Mappers
{
    public class MapperUsuario
    {
        public static Usuario FromDtoAltaUsuario(DTOAltaUsuario dto)
        {
            string passHashed = Utilidades.Cripto.HashPasswordConBcrypt(dto.Password, 12);
            var nombreCompleto = new VONombreCompleto(dto.Nombre, dto.Apellido);
            Usuario usuario = new Usuario(
                nombreCompleto,
                dto.Edad,
                dto.Email,
                passHashed,
                Enum.Parse<RolUsuario>(dto.Rol)
            );


            return usuario;
        }


        public static DTOUsuario FromUsuarioToDto(Usuario usuario)
        {
            DTOUsuario dto = new DTOUsuario();
            dto.Id = usuario.Id;
            dto.Nombre = usuario.NombreCompleto.Nombre;
            dto.Apellido = usuario.NombreCompleto.Apellido;
            dto.Rol = usuario.Rol.ToString();
            dto.Email = usuario.Email;
            dto.Edad = usuario.Edad;
            dto.Password = usuario.Password;
            return dto;
        }

        public static Usuario FromDtoUsuarioToUsuario(DTOUsuario dto) { 
        
            Usuario u = new Usuario();
            u.Id = dto.Id;
            u.NombreCompleto = new VONombreCompleto(dto.Nombre, dto.Apellido);
            u.Edad = dto.Edad;
            u.Email = dto.Email;
            u.Rol = Enum.Parse<RolUsuario>(dto.Rol);
            u.Password = dto.Password;
            return u;



        }



        public static List<DTOListarEmpleado> FromListEmpleadoToListEmpleado(List<Usuario> usuarios) 
        {
            return usuarios.Select(u => new DTOListarEmpleado
            {
                Id = u.Id,
                Nombre = u.NombreCompleto.Nombre,
                Apellido = u.NombreCompleto.Apellido,
                Edad = u.Edad,
                Email = u.Email,
                Rol = u.Rol.ToString()
            }).ToList();

        }
    }
}

