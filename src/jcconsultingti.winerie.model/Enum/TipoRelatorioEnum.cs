using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.model.Enum
{
    public enum TipoRelatorioEnum
    {
        [EnumMember]
        [Description("Relatório 1: Exibir Terminais Achados")]
        ExibirTerminaisAchados = 0,

        [EnumMember]
        [Description("Relatório 2: Exibir Terminais Pagos Sem Venda")]
        ExibirTerminaisPagosSemVenda = 1
    }
}
