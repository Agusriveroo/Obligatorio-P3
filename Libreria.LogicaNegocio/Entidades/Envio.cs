using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Envio
    {
        public int Id { get; set; }

        public string? NumeroTracking { get; set; }

        public int EmpleadoId { get; set; }
        public Usuario? Empleado { get; set; }  

        //public int ClienteId { get; set; }
        public string EmailCliente { get; set; } 

        public double PesoPaquete { get; set; }

        public EstadoEnvio Estado { get; set; } = EstadoEnvio.EN_PROCESO;

        public DateTime Fecha{ get; set; } = DateTime.Now;

        public Envio()
        {
            
        }

        public Envio( Usuario? empleado, string emailCliente, double pesoPaquete, EstadoEnvio estado)
        {
          
            Empleado = empleado;
            EmailCliente = emailCliente;
            PesoPaquete = pesoPaquete;
            Estado = estado;
            NumeroTracking = Guid.NewGuid().ToString();
        }
    }





}
