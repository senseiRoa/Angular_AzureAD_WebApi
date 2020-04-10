using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorTutelas.webApi.DBContext.Enums
{
    public enum EstadoExpedienteParametroEnum
    {
        SinAsignar = 1,
        Asignado,
        Resuelto,
        Cerrado,
        Devuelto
    }
}
