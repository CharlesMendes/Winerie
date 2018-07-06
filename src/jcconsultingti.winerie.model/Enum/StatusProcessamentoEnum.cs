using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.model.Enum
{
    public enum StatusProcessamentoEnum
    {
        [EnumMember]
        [Description("Solicitação não processada")]
        SolicitacaoNaoProcessada = 1,

        [EnumMember]
        [Description("Solicitação processada, mas possui erros de validação")]
        SolicitacaoProcessadaComErros = 2,

        [EnumMember]
        [Description("Solicitação processada corretamente")]
        SolicitacaoProcessadaComSucesso = 3
    }
}
