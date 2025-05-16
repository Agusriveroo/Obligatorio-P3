using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.ValueObjects
{
    public record VOUbicacionAgencia
    {
        public double Latitud { get;init; }

        public double Longitud { get; init; }


        public VOUbicacionAgencia(double latitud, double longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
        }

        public override string ToString()
        {
            return $"Latitud: {Latitud}, Longitud: {Longitud}";
        }
    }
}
