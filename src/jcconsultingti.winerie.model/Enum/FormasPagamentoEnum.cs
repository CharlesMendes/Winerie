using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.model.Enum
{
    public enum FormasPagamentoEnum
    {
        [EnumMember]
        [Description("Múltiplas")]
        multiplas,

        [EnumMember]
        [Description("Dinheiro")]
        dinheiro,

        [EnumMember]
        [Description("Crédito")]
        credito,

        [EnumMember]
        [Description("Débito")]
        debito,

        [EnumMember]
        [Description("Boleto")]
        boleto,

        [EnumMember]
        [Description("Depósito")]
        deposito,

        [EnumMember]
        [Description("Cheque")]
        cheque,

        [EnumMember]
        [Description("Crediário")]
        crediario
    }
}
