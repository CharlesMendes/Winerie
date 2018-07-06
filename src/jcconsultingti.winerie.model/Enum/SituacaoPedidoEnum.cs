using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.model.Enum
{
    public enum SituacaoPedidoEnum
    {
        [EnumMember]
        Aberto,

        [EnumMember]
        Cancelado,

        [EnumMember]
        Atendido,

        [EnumMember]
        Aprovado
    }
}
