using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Urgente: Envio
    {
        public string DireccionPostal { get; set; }

        public int? ValorEficiencia { get; set; }

        public Urgente(string direccionPostal, int? valorEficiencia, Usuario? empleado, Usuario cliente, double pesoPaquete, EstadoEnvio estado) :base(empleado, cliente, pesoPaquete, estado)
        {
            DireccionPostal = direccionPostal;
            ValorEficiencia = valorEficiencia;
        }

        public Urgente():base()
        {
            
        }

    }
}
