using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUEnvio;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enum;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUEditarEnvio : ICUEditarEnvio
    {
        private IRepositorioEnvio _repoEnvio;
        private IRepositorioAuditoria _repositorioAuditoria;

        public CUEditarEnvio(IRepositorioEnvio repositorioEnvio, IRepositorioAuditoria repositorioAuditoria)
        {
            _repoEnvio = repositorioEnvio;
            _repositorioAuditoria = repositorioAuditoria;
        }


        public void EditarEnvio(DTOListarEnvio dto)
        {
            try
            {
                
                Envio e = MapperEnvio.FromDtoEnvioToEnvio(dto);
                if (string.IsNullOrWhiteSpace(e.Cliente.Email))
                    throw new EmailClienteException();

                e.Estado = Enum.Parse<EstadoEnvio>(dto.Estado);
                int r = _repoEnvio.Update(e);

                

                RegistroAuditoria aud = new RegistroAuditoria(dto.LogueadoId, AccionesAuditoria.ACTUALIZAR, "Envio", r.ToString(), dto.Estado.ToString());
                _repositorioAuditoria.Auditar(aud);
            }
            catch (Exception e)
            {
                RegistroAuditoria aud = new RegistroAuditoria(dto.LogueadoId, AccionesAuditoria.ACTUALIZAR, "Envio", null, "ERROR:" + e.Message);
                _repositorioAuditoria.Auditar(aud);
                throw;

            }
        }

    }
}
