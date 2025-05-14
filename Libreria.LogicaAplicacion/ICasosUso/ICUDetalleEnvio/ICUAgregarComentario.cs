using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.ICasosUso.ICUDetalleEnvio
{
    public interface ICUAgregarComentario
    {

        void AgregarComentario(int envioId, int? empleadoId, string comentario);
    }
}
