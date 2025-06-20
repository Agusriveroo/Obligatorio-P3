using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Comun : Envio
    {
        public Agencia AgenciaRetiro { get; set; }


        public Comun(Agencia agenciaRetiro, Usuario? empleado, Usuario cliente, double pesoPaquete, EstadoEnvio estado)
            : base(empleado, cliente, pesoPaquete, estado) 
        {
            AgenciaRetiro = agenciaRetiro;
        }

   
        public Comun() : base() { }
    }

}
