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

        public static Envio FromDtoAltaEnvioToEnvio(DTOAltaEnvio dto, string emailCliente, Usuario? u, Agencia? agenciaRetiro)
        {
            Envio eC;

            if (dto.TipoEnvio.Equals("comun"))
            {
                eC = new Comun(agenciaRetiro, null, emailCliente, dto.PesoPaquete, EstadoEnvio.EN_PROCESO);
            }
            else
            {
                eC = new Urgente(dto.DireccionPostal, null, u, emailCliente, dto.PesoPaquete, EstadoEnvio.EN_PROCESO);
            }

            return eC;
        }




        public static List<DTOListarEnvio> FromListEnvioToListDto(List<Envio> envios) { 
        
            List<DTOListarEnvio> ret = new List<DTOListarEnvio>();

            foreach (Envio e in envios) { 
            
                DTOListarEnvio dto = new DTOListarEnvio();
                dto.IdEnvio = e.Id;
                dto.EmailCliente = e.EmailCliente;
                dto.PesoPaquete = e.PesoPaquete;
                dto.Estado = e.Estado.ToString();

                ret.Add(dto);

            }
            return ret;
        }

        public static Envio FromDtoEnvioToEnvio(DTOListarEnvio dto) { 
        
            Envio e = new Envio();
            e.Id = dto.IdEnvio;
            e.EmpleadoId = (int)dto.LogueadoId;
            e.EmailCliente = dto.EmailCliente;
            e.PesoPaquete = dto.PesoPaquete;
            e.Estado = Enum.Parse<EstadoEnvio>(dto.Estado);
            e.Fecha = dto.FechaFinalizacion;
            return e;


        }

        public static DTOListarEnvio FromEnvioToDto(Envio e)
        {
            DTOListarEnvio dto = new DTOListarEnvio();
            dto.IdEnvio = e.Id;
            dto.EmailCliente = e.EmailCliente;
            dto.PesoPaquete = e.PesoPaquete;
            dto.Estado = e.Estado.ToString();
            dto.FechaFinalizacion = e.Fecha;
            return dto;
        }

        public static DTOEnvioConDetalles FromEnvioToDtoConDetalles(Envio e) {

            return new DTOEnvioConDetalles
            {

                NumeroTracking = e.NumeroTracking,
                EmailCliente = e.EmailCliente,
                PesoPaquete = e.PesoPaquete,
                Estado = e.Estado.ToString(),
                Detalles = e.Detalles.Select(d => new DTODetallesParaEnvios
                {
                    Comentario = d.Comentario,
                    Fecha = d.Fecha
                }).ToList()

            };
        
        }

       



    }
}
