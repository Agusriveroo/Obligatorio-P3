using Libreria.DTOs.DTOs.DTOsAgencia;
using Libreria.DTOs.DTOs.DTOsEnvio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUAltaEnvio
    {
        void AltaEnvio(DTOAltaEnvio dto);
    }
}
