using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Domain.Enum
{
    public enum StatusPedido
    {
        Novo = 1
    ,   AguardandoResgate = 2
    ,   AguardandoEnvio = 3
    ,   EmRota =4
    ,   Entregue = 5
    }
}
