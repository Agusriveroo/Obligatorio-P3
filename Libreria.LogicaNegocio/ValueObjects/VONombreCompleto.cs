using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.ValueObjects
{
    public record VONombreCompleto
    {
        public string Nombre { get; init; }
        public string Apellido { get; init; }

        public VONombreCompleto(string nombre, string apellido)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                throw new NombreUsuarioException("El nombre y/o el apellido no puede ser vacío.");
            }

            Nombre = nombre;
            Apellido = apellido;
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido}";
        }
    }

}
