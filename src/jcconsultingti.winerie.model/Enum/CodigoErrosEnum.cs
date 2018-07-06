using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.model.Enum
{
    public enum CodigoErrosEnum
    {
        [EnumMember]
        [Description("Token não informado")]
        TokenNaoInformado = 1,

        [EnumMember]
        [Description("Token inválido ou não encontrado")]
        TokenInvalidoOuNaoEncontrado = 2,

        [EnumMember]
        [Description("XML mal formado ou com erros")]
        XmlMalFormadoOuComErros = 3,

        [EnumMember]
        [Description("Erro de procesamento de XML")]
        ErroDeProcesamentoDeXML = 4,

        [EnumMember]
        [Description("API bloqueada ou sem acesso")]
        ApiBloqueadaOuSemAcesso = 5,

        [EnumMember]
        [Description("API bloqueada momentaneamente - muitos acessos no último minuto")]
        ApiBloqueadaMomentaneamente = 6,

        [EnumMember]
        [Description("Espaço da empresa Esgotado")]
        EspacoDaEmpresaEsgotado = 7,

        [EnumMember]
        [Description("Empresa Bloqueada")]
        EmpresaBloqueada = 8,

        [EnumMember]
        [Description("Números de sequencia em duplicidade")]
        NumerosDeSequenciaEmDuplicidade = 9,

        [EnumMember]
        [Description("Parametro não informado")]
        ParametroNaoInformado = 10,

        [EnumMember]
        [Description("A Consulta não retornou registros")]
        ConsultaNaoRetornouRegistros = 20,

        [EnumMember]
        [Description("A Consulta retornou muitos registros")]
        ConsultaRetornouMuitosRegistros = 21,

        [EnumMember]
        [Description("O xml tem mais registros que o permitido por lote de envio")]
        XmlTemMaisRegistrosQueOPermitidoPorLote = 22,

        [EnumMember]
        [Description("A página que você está tentanto obter não existe")]
        PaginaTentandoObterNaoExiste = 23,

        [EnumMember]
        [Description("Erro de Duplicidade de Registro")]
        ErroDeDuplicidadeDeRegistro = 30,

        [EnumMember]
        [Description("Erros de Validação")]
        ErrosDeValidacao = 31,

        [EnumMember]
        [Description("Registro não localizado")]
        RegistroNaoLocalizado = 32,

        [EnumMember]
        [Description("Registro localizado em duplicidade")]
        RegistroLocalizadoemDuplicidade = 33,

        [EnumMember]
        [Description("Sistema em manutenção")]
        SistemaEmManutencao = 99
    }
}
