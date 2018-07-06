using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.model.tiny
{
    /// <summary>
    /// PESQUISAR NOTAS FISCAIS API 2.0
    /// </summary>
    public class PesquisarNotaFiscal
    {
        public PesquisarNotaFiscal()
        {
            retorno = new Retorno();
            request = new ParametroServico();
            filtros = new PesquisarRequest();
        }

        /// <summary>
        /// Elemento raiz do retorno/response
        /// </summary>
        public Retorno retorno { get; set; }

        /// <summary>
        /// Parametros de request para chamar o serviço
        /// </summary>
        public ParametroServico request { get; set; }

        /// <summary>
        /// Filtros de pesquisa de notas fiscais
        /// </summary>
        public PesquisarRequest filtros { get; set; }
    }

    public class NotaFiscalRoot
    {
        public NotaFiscalRoot()
        {
            nota_fiscal = new NotaFiscal();
            detalhes = new ObterNotaFiscal();
        }

        public NotaFiscal nota_fiscal { get; set; }

        /// <summary>
        /// Recupera os detalhes da nota fiscal pela OBTER NOTA FISCAL API 2.0
        /// </summary>
        public ObterNotaFiscal detalhes { get; set; }
    }

    /// <summary>
    /// Elemento utilizado para representar uma nota fiscal.
    /// </summary>
    public class NotaFiscal
    {
        public NotaFiscal()
        {
            cliente = new Cliente();
            itens = new List<ItemRoot>();
            transportador = new Transportador();
            parcelas = new List<ParcelaRoot>();
        }

        /// <summary>
        /// Número de identificação da nota fiscal no Tiny
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Tipo da nota fiscal (E/S) - Código conforme Tabela de tipos da nota fiscal
        /// </summary>
        public string tipo_nota { get; set; }

        /// <summary>
        /// Natureza de operação da nota fiscal
        /// </summary>
        public string natureza_operacao { get; set; }

        /// <summary>
        /// Código conforme Tabela de regime tributário da nota fiscal
        /// </summary>
        public int regime_tributario { get; set; }

        /// <summary>
        /// Código conforme Tabela de finalidade da nota fiscal
        /// </summary>
        public int finalidade { get; set; }

        /// <summary>
        /// Número de série da nota fiscal
        /// </summary>
        public int serie { get; set; }

        /// <summary>
        /// Número da nota fiscal
        /// </summary>
        [Display(Name = "Nº Nota")]
        public int numero { get; set; }

        /// <summary>
        /// Número do pedido no ecommerce(ou sistema)
        /// </summary>
        [Display(Name = "Nº Ecommerce")]
        public long? numero_ecommerce { get; set; }

        /// <summary>
        /// Data de emissão da nota fiscal
        /// </summary>
        [Display(Name = "Emissão NF")]
        public string data_emissao { get; set; }

        /// <summary>
        /// Data de saída da nota fiscal
        /// </summary>
        public string data_saida { get; set; }

        /// <summary>
        /// Hora de saída da nota fiscal
        /// </summary>
        public string hora_saida { get; set; }

        /// <summary>
        /// Elemento utilizado para representar o cliente
        /// </summary>
        public Cliente cliente { get; set; }

        /// <summary>
        /// Elemento utilizado para representar o endereço de entrega, 
        /// caso seja diferente do endereço do cliente
        /// </summary>
        public EnderecoEntrega endereco_entrega { get; set; }

        /// <summary>
        /// Lista de itens da Nota Fiscal
        /// </summary>
        public List<ItemRoot> itens { get; set; }

        /// <summary>
        /// Valor da base do ICMS da nota fiscal
        /// </summary>
        public decimal base_icms { get; set; }

        /// <summary>
        /// Valor do ICMS da nota fiscal
        /// </summary>
        public decimal valor_icms { get; set; }

        /// <summary>
        /// Valor da base do ICMS ST da nota fiscal
        /// </summary>
        public decimal base_icms_st { get; set; }

        /// <summary>
        /// Valor do ICMS ST da nota fiscal
        /// </summary>
        public decimal valor_icms_st { get; set; }

        /// <summary>
        /// Valor dos serviços da nota fiscal
        /// </summary>
        public decimal valor_servicos { get; set; }

        /// <summary>
        /// Valor dos podutos da nota fiscal
        /// </summary>
        public decimal valor_produtos { get; set; }

        /// <summary>
        /// Valor do frete da nota fiscal
        /// </summary>
        public decimal valor_frete { get; set; }

        /// <summary>
        /// Valor do seguro da nota fiscal
        /// </summary>
        public decimal valor_seguro { get; set; }

        /// <summary>
        /// Valor das outras despesas da nota fiscal
        /// </summary>
        public decimal valor_outras { get; set; }

        /// <summary>
        /// Valor do IPI da nota fiscal
        /// </summary>
        public decimal valor_ipi { get; set; }

        /// <summary>
        /// Valor do ISSQN da nota fiscal
        /// </summary>
        public decimal valor_issqn { get; set; }

        /// <summary>
        /// Valor da Nota Fiscal
        /// </summary>
        public decimal valor_nota { get; set; }

        /// <summary>
        /// Valor do desconto da Nota Fiscal
        /// </summary>
        public decimal valor_desconto { get; set; }

        /// <summary>
        /// Valor total faturado da Nota Fiscal
        /// </summary>
        [DataType(DataType.Currency)]
        [Display(Name = "Valor Faturado")]
        public decimal valor_faturado { get; set; }

        /// <summary>
        /// "R"-Remetente, "D"-Destinatário
        /// </summary>
        public string frete_por_conta { get; set; }

        /// <summary>
        /// Elemento utilizado para representar o transportador
        /// </summary>
        public Transportador transportador { get; set; }

        /// <summary>
        /// Placa do veículo transportador
        /// </summary>
        public string placa { get; set; }

        /// <summary>
        /// UF da placa do veículo transportador
        /// </summary>
        public string uf_placa { get; set; }

        /// <summary>
        /// Quantidade de volumes da Nota Fiscal
        /// </summary>
        public int quantidade_volumes { get; set; }

        /// <summary>
        /// Espécie dos volumes da Nota Fiscal
        /// </summary>
        public string especie_volumes { get; set; }

        /// <summary>
        /// Marca dos volumes da Nota Fiscal
        /// </summary>
        public string marca_volumes { get; set; }

        /// <summary>
        /// Número dos volumes da Nota Fiscal
        /// </summary>
        public string numero_volumes { get; set; }

        /// <summary>
        /// Peso Bruto da Nota Fiscal
        /// </summary>
        public decimal peso_bruto { get; set; }

        /// <summary>
        /// Peso Líquido da Nota Fiscal
        /// </summary>
        public decimal peso_liquido { get; set; }

        /// <summary>
        /// Código de rastreamento da Nota Fiscal
        /// </summary>
        public string codigo_rastreamento { get; set; }

        /// <summary>
        /// URL de rastreamento da Nota Fiscal
        /// </summary>
        public string url_rastreamento { get; set; }

        /// <summary>
        /// Descrição da condição de pagamento
        /// </summary>
        public string condicao_pagamento { get; set; }

        /// <summary>
        /// Código conforme tabela de Formas de pagamento
        /// </summary>
        public string forma_pagamento { get; set; }

        /// <summary>
        /// Descrição do meio de pagamento
        /// </summary>
        public object meio_pagamento { get; set; }

        /// <summary>
        /// Lista de parcelas da Nota Fiscal
        /// </summary>
        public List<ParcelaRoot> parcelas { get; set; }

        /// <summary>
        /// Número de identificação do vendedor associado a nota fiscal
        /// </summary>
        public string id_vendedor { get; set; }

        /// <summary>
        /// Nome do vendedor associado a nota fiscal
        /// </summary>
        public string nome_vendedor { get; set; }

        /// <summary>
        /// Código conforme tabela de "Situações das Notas Fiscais"
        /// </summary>
        public string situacao { get; set; }

        /// <summary>
        /// condicional	Descrição conforme tabela de "Situações das Notas Fiscais"
        /// </summary>
        [Display(Name = "Situação")]
        public string descricao_situacao { get; set; }

        /// <summary>
        /// Observação da Nota Fiscal
        /// </summary>
        public string obs { get; set; }

        /// <summary>
        /// Chave de acesso da Nota Fiscal
        /// </summary>
        public string chave_acesso { get; set; }
    }
}
