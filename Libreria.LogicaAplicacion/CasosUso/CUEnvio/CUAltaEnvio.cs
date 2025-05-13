using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
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
                Usuario empleado = _repoUsuario.GetById((int)dto.LogueadoId);
                string emailCliente = dto.EmailCliente;

                if (dto.LogueadoId == null)
                    throw new Exception("No se encontró el empleado con ese ID.");
                Envio e = MapperEnvio.FromDtoAltaEnvioToEnvio(dto, emailCliente, empleado, agenciaRetiro);

                int idEntidad = _repositorioEnvio.Add(e);

                RegistroAuditoria a = new RegistroAuditoria(dto.LogueadoId, AccionesAuditoria.ALTA, "Envio " + e.GetType().Name, idEntidad.ToString(),JsonSerializer.Serialize(e));
                _repoAuditoria.Auditar(a);

            }
            catch (Exception e)
            {
                RegistroAuditoria a = new RegistroAuditoria(dto.LogueadoId, AccionesAuditoria.ALTA, "Envio " + e.GetType().Name, null, "ERROR" + e.Message);
                _repoAuditoria.Auditar(a);

                throw e;
            }
            

        }
    }
}
