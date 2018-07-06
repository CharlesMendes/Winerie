using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.model.Enum
{
    [DefaultValue(Desenvolvimento)]
    public enum ConectorDataBaseEnum
    {
        [EnumMember]
        [Description("winerieDB_DES")]
        Desenvolvimento = 0,

        [EnumMember]
        [Description("winerieDB_HOM")]
        Homologacao = 1,

        [EnumMember]
        [Description("winerieDB_PRD")]
        Producao = 2
    }
}
