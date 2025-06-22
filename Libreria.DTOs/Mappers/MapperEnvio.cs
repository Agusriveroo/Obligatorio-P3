using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.Mappers
{
    public class MapperEnvio
    {

        public static Envio FromDtoAltaEnvioToEnvio(DTOAltaEnvio dto, Usuario c, Usuario? u, Agencia? agenciaRetiro)
        {
            Envio eC;

            if (dto.TipoEnvio.Equals("comun"))
            {
                eC = new Comun(agenciaRetiro, null, c, dto.PesoPaquete, EstadoEnvio.EN_PROCESO);
            }
            else
            {
                eC = new Urgente(dto.DireccionPostal, null, u,c, dto.PesoPaquete, EstadoEnvio.EN_PROCESO);
            }

            return eC;
        }




        public static List<DTOListarEnvio> FromListEnvioToListDto(List<Envio> envios) { 
        
            List<DTOListarEnvio> ret = new List<DTOListarEnvio>();

            foreach (Envio e in envios) { 
            
                DTOListarEnvio dto = new DTOListarEnvio();
                dto.IdEnvio = e.Id;
                dto.EmailCliente = e.Cliente.Email;
                dto.PesoPaquete = e.PesoPaquete;
                dto.Estado = e.Estado.ToString();
                dto.FechaFinalizacion = (DateTime)e.Fecha;

                ret.Add(dto);

            }
            return ret;
        }

        public static Envio FromDtoEnvioToEnvio(DTOListarEnvio dto) {

            if (dto.IdEnvio == 0)
                throw new ArgumentException("IdEnvio no puede ser 0");

            Envio e = new Envio();
            e.Id = dto.IdEnvio;
            e.EmpleadoId = dto.LogueadoId;
            e.ClienteId = dto.ClienteId;
            e.PesoPaquete = dto.PesoPaquete;
            if (dto.MarcarFinalizado)
                e.Estado = EstadoEnvio.FINALIZADO;
            else
                e.Estado = EstadoEnvio.EN_PROCESO;
            e.Fecha = dto.FechaFinalizacion;
            return e;
        }

        public static DTOListarEnvio FromEnvioToDto(Envio e)
        {
            DTOListarEnvio dto = new DTOListarEnvio();
            dto.IdEnvio = e.Id;
            dto.NumeroTracking = e.NumeroTracking;
            dto.EmailCliente = e.Cliente.Email;
            dto.PesoPaquete = e.PesoPaquete;
            dto.Estado = e.Estado.ToString();
            dto.FechaFinalizacion = DateTime.Now;
            dto.Detalles = e.Detalles?.Select(d => new DTODetallesParaEnvios
            {
                Comentario = d.Comentario,
                Fecha = d.Fecha
            }).ToList() ?? new List<DTODetallesParaEnvios>();
            return dto;
        }

        public static DTOEnvioConDetalles FromEnvioToDtoConDetalles(Envio e) {

            return new DTOEnvioConDetalles
            {

                NumeroTracking = e.NumeroTracking,
                EmailCliente = e.Cliente.Email,
                PesoPaquete = e.PesoPaquete,
                Estado = e.Estado.ToString(),
                Detalles = e.Detalles.Select(d => new DTODetallesParaEnvios
                {
                    Comentario = d.Comentario,
                    Fecha = d.Fecha
                }).ToList()

            };
        
        }


        public static List<DTOListaEnvioSimple> FromListaEnvio(List<Envio> envios) 
        {
            List<DTOListaEnvioSimple> ret = new List<DTOListaEnvioSimple>();

            return envios.Select(e => new DTOListaEnvioSimple
            {
                NumeroTracking = e.NumeroTracking,
                PesoPaquete = e.PesoPaquete,
                Estado = e.Estado.ToString(),
                FechaCreacion = e.Fecha,
            }).ToList();

        }




    }
}
