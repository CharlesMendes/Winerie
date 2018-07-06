using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.model.tiny
{
    /// <summary>
    /// PESQUISAR PEDIDOS API 2.0
    /// Serviço destinado a fazer consulta de Pedidos.
    /// </summary>
    public class PesquisarPedidos
    {
        public PesquisarPedidos()
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
        /// Filtros de pesquisa de pedidos
        /// </summary>
        public PesquisarRequest filtros { get; set; }
    }

    public class PedidoRoot
    {
        public PedidoRoot()
        {
            pedido = new Pedido();
            detalhes = new ObterPedido();
        }

        public Pedido pedido { get; set; }

        /// <summary>
        /// Recupera os detalhes do pedido pela OBTER PEDIDO API 2.0
        /// </summary>
        public ObterPedido detalhes { get; set; }
    }

    /// <summary>
    /// Elemento utilizado para representar um pedido.
    /// </summary>
    public class Pedido
    {
        /// <summary>
        /// Número de identificação do pedido no Tiny
        /// </summary>
        [Display(Name = "Nº Tiny")]
        public int id { get; set; }

        /// <summary>
        /// Número do pedido no Tiny
        /// </summary>
        public int numero { get; set; }

        /// <summary>
        /// Número do pedido no ecommerce(ou sistema)
        /// </summary>
        [Display(Name = "Nº Ecommerce")]
        public long? numero_ecommerce { get; set; }

        /// <summary>
        /// Data do pedido
        /// </summary>
        [Display(Name = "Data do Pedido")]
        public string data_pedido { get; set; }

        /// <summary>
        /// Data de previsão do pedido
        /// </summary>
        [Display(Name = "Data Prevista")]
        public string data_prevista { get; set; }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        [Display(Name = "Cliente")]
        public string nome { get; set; }

        /// <summary>
        /// Valor total do pedido
        /// </summary>
        [Display(Name = "Total")]
        public decimal valor { get; set; }
        
        /// <summary>
        /// Número de identificação do Vendedor associado ao pedido.
        /// </summary>
        public int? id_vendedor { get; set; }

        /// <summary>
        /// Nome do Vendedor associado ao pedido.
        /// </summary>
        [Display(Name = "Vendedor")]
        public string nome_vendedor { get; set; }
        /// <summary>
        /// Situação do pedido
        /// </summary>
        [Display(Name = "Situação")]
        public string situacao { get; set; }

        /// <summary>
        /// Observação do pedido
        /// </summary>
        [Display(Name = "Observação")]
        public string obs { get; set; }

        /// <summary>
        /// Código de rastreamento do pedido
        /// </summary>
        public string codigo_rastreamento { get; set; }

        /// <summary>
        /// URL de rastreamento do pedido
        /// </summary>
        public string url_rastreamento { get; set; }

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
        /// Lista de itens do pedido
        /// </summary>
        public List<ItemRoot> itens { get; set; }

        /// <summary>
        /// Lista de parcelas do pedido
        /// </summary>
        public List<ParcelaRoot> parcelas { get; set; }

        /// <summary>
        /// Descrição da condição de pagamento
        /// </summary>
        public string condicao_pagamento { get; set; }

        /// <summary>
        /// Código conforme tabela de Formas de pagamento
        /// </summary>
        [Display(Name = "Forma Pgto.")]
        public string forma_pagamento { get; set; }

        /// <summary>
        /// Descrição do meio de pagamento
        /// </summary>
        public string meio_pagamento { get; set; }

        /// <summary>
        /// Nome do transportador
        /// </summary>
        [Display(Name = "Transportadora")]
        public string nome_transportador { get; set; }

        /// <summary>
        /// "R"-Remetente, "D"-Destinatário
        /// </summary>
        public string frete_por_conta { get; set; }

        /// <summary>
        /// Valor do frete do pedido
        /// </summary>
        [DataType(DataType.Currency)]
        [Display(Name = "Frete")]
        public decimal valor_frete { get; set; }

        /// <summary>
        /// Valor do desconto do pedido
        /// </summary>
        [DataType(DataType.Currency)]
        [Display(Name = "Desconto")]
        public decimal valor_desconto { get; set; }

        /// <summary>
        /// Valor total dos produtos
        /// </summary>
        [DataType(DataType.Currency)]
        [Display(Name = "Total dos Produtos")]
        public decimal total_produtos { get; set; }

        /// <summary>
        /// Valor total do pedido
        /// </summary>
        [DataType(DataType.Currency)]
        [Display(Name = "Total do Pedido")]
        public decimal total_pedido { get; set; }

        /// <summary>
        /// Número de ordem de compra
        /// </summary>
        [Display(Name = "Nº Ecommerce")]
        public string numero_ordem_compra { get; set; }

        /// <summary>
        /// Identificador da nota fiscal referenciada pela venda
        /// </summary>
        public int id_nota_fiscal { get; set; }
    }
}
