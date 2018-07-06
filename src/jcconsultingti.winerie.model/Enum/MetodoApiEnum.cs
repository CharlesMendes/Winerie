using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.model.Enum
{
    public enum MetodoApiEnum
    {
        [EnumMember]
        [Description("api2/pedidos.pesquisa.php")]
        PesquisaPedidos,

        [EnumMember]
        [Description("api2/pedido.obter.php")]
        ObterPedido,

        [EnumMember]
        [Description("api2/notas.fiscais.pesquisa.php")]
        PesquisaNotaFiscal,

        [EnumMember]
        [Description("api2/nota.fiscal.obter.php")]
        ObterNotaFiscal
    }
}
