using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class RegistroAuditoria
    {
        public int Id { get; set; }
        
        public int? UsuarioId { get; set; }

        public AccionesAuditoria Accion { get; set; } 

        public string? Entidad { get; set; }

        public string? EntidadId { get; set; }

        public DateTime Fecha { get; set; }

        public string? Observaciones { get; set; }


        public RegistroAuditoria()
        {
            Fecha = DateTime.Now;
        }
        public RegistroAuditoria(int? usuarioId, AccionesAuditoria accion, string entidad, string entidadId, string observaciones)
        {
            UsuarioId = usuarioId;
            Accion = accion;
            Entidad = entidad;
            EntidadId = entidadId;
            Fecha = DateTime.Now;
            Observaciones = observaciones;
        }
    }
}
