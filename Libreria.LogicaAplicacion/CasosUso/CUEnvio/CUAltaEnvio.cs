using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaNegocio.CustomExceptions.EnvioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUAltaEnvio : ICUAltaEnvio
    {
        private IRepositorioEnvio _repositorioEnvio;
        private IRepositorioAgencia _repoAgencia;
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;

        public CUAltaEnvio(IRepositorioEnvio repositorioEnvio, IRepositorioAgencia repoAgencia, IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repositorioEnvio = repositorioEnvio;
            _repoAgencia = repoAgencia;
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }
        public void AltaEnvio(DTOAltaEnvio dto)
        {
            try
            {
                Agencia agenciaRetiro = _repoAgencia.GetById(dto.AgenciaRetiroId);

                Usuario? empleado = null;
                if (dto.LogueadoId.HasValue)
                {
                    empleado = _repoUsuario.GetById(dto.LogueadoId.Value);
                }



                string emailCliente = dto.EmailCliente;

                Envio e = MapperEnvio.FromDtoAltaEnvioToEnvio(dto, emailCliente, empleado, agenciaRetiro);

                int idEntidad = _repositorioEnvio.Add(e);

                RegistroAuditoria a = new RegistroAuditoria(dto.LogueadoId, AccionesAuditoria.ALTA, "Envio " + e.GetType().Name, idEntidad.ToString(), JsonSerializer.Serialize(e));
                _repoAuditoria.Auditar(a);
            }
            catch (PesoNegativoExcepcion) 
            {
                throw;
            }
            catch (Exception ex)
            {
                string mensaje = ex.InnerException?.Message ?? ex.Message;
                RegistroAuditoria a = new RegistroAuditoria(dto.LogueadoId, AccionesAuditoria.ALTA, "Envio " + ex.GetType().Name, null, "ERROR" + mensaje);
                _repoAuditoria.Auditar(a);

                throw new Exception("No se pudo registrar el envío: " + mensaje);
            }
        }

    }
}
