using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.model.tiny
{
    /// <summary>
    /// Elemento raiz do retorno/response
    /// </summary>
    public class Retorno
    {
        public Retorno()
        {
            pedido = new Pedido();
            pedidos = new List<PedidoRoot>();
            erros = new List<Erro>();
            notas_fiscais = new List<NotaFiscalRoot>();
            nota_fiscal = new NotaFiscal();
        }

        /// <summary>
        /// Conforme tabela "Status de Processamento"
        /// </summary>
        public int status_processamento { get; set; }

        /// <summary>
        /// Contém o status do retorno “OK” ou “Erro”. 
        /// Para o caso de conter erros estes serão descritos abaixo
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// Número da página que está sendo retornada
        /// </summary>
        public int pagina { get; set; }

        /// <summary>
        /// Número de paginas do retorno
        /// </summary>
        public int numero_paginas { get; set; }

        /// <summary>
        /// Conforme tabela "Códigos de erro"
        /// </summary>
        public int codigo_erro { get; set; }

        /// <summary>
        /// Contém a lista dos erros encontrados.
        /// </summary>
        public List<Erro> erros { get; set; }

        /// <summary>
        /// Lista de resultados da pesquisa
        /// </summary>
        public List<PedidoRoot> pedidos { get; set; }

        /// <summary>
        /// Elemento utilizado para representar um pedido.
        /// </summary>
        public Pedido pedido { get; set; }

        /// <summary>
        /// Lista de resultados da pesquisa
        /// </summary>
        public List<NotaFiscalRoot> notas_fiscais { get; set; }

        /// <summary>
        /// Elemento utilizado para representar uma nota fiscal.
        /// </summary>
        public NotaFiscal nota_fiscal { get; set; }
    }

    /// <summary>
    /// Contém a lista dos erros encontrados.
    /// </summary>
    public class Erro
    {
        /// <summary>
        /// Mensagem contendo a descrição do erro
        /// </summary>
        public string erro { get; set; }
    }

    /// <summary>
    /// Parametros de Request para os serviços
    /// </summary>
    public partial class ParametroServico
    {
        /// <summary>
        /// Chave gerada para identificar sua empresa
        /// </summary>
        public string token { get; set; }

        /// <summary>
        /// Número de identificação do "objeto de negócio" no Tiny
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Formato do retorno (json ou xml)
        /// </summary>
        public string formato { get; set; }
    }

    public class PesquisarRequest
    {
        /// <summary>
        /// Número do pedido/nota (no Tiny)
        /// </summary>
        public string numero { get; set; }
        /// <summary>
        /// Nome ou código (ou parte) do cliente
        /// </summary>
        [Display(Name = "Nome do Cliente")]
        public string cliente { get; set; }

        /// <summary>
        /// CPF ou CNPJ do cliente
        /// </summary>
        [Display(Name = "CPF/CNPJ")]
        public string cpf_cnpj { get; set; }

        /// <summary>
        /// Data de cadastramento inicial dos pedidos/notas que deseja consultar no formato dd/mm/yyyy
        /// </summary>
        [Display(Name = "Data Inicial")]
        public string dataInicial { get; set; }

        /// <summary>
        /// Data de cadastramento final dos pedidos/notas que deseja consultar no formato dd/mm/yyyy
        /// </summary>
        [Display(Name = "Data Final")]
        public string dataFinal { get; set; }

        /// <summary>
        /// Exibir pedidos na situação atual
        /// </summary>
        public string situacao { get; set; }

        /// <summary>
        /// Número do pedido no ecommerce (ou no seu sistema)
        /// </summary>
        [Display(Name = "Nº Ecommerce")]
        public string numeroEcommerce { get; set; }

        /// <summary>
        /// Número de identificação do vendedor no Tiny
        /// </summary>
        [Display(Name = "Cód. Vendedor")]
        public string idVendedor { get; set; }

        /// <summary>
        /// Nome do vendedor no Tiny
        /// </summary>
        [Display(Name = "Nome do Vendedor")]
        public string nomeVendedor { get; set; }

        /// <summary>
        /// Data de ocorrência inicial dos pedidos que deseja consultar no formato dd/mm/yyyy
        /// </summary>
        public string dataInicialOcorrencia { get; set; }

        /// <summary>
        /// Data de ocorrência final dos pedidos que deseja consultar no formato dd/mm/yyyy
        /// </summary>
        public string dataFinalOcorrencia { get; set; }

        /// <summary>
        /// Situação da ocorrência.
        /// </summary>
        public string situacaoOcorrencia { get; set; }

        /// <summary>
        /// Tipo da nota (E/S) E=Entrada, S=Saída
        /// </summary>
        public string tipoNota { get; set; }

        /// <summary>
        /// Número da página
        /// </summary>
        public int pagina { get; set; }

        /// <summary>
        /// Ordenação dos pedidos (ASC ou DESC)
        /// </summary>
        public string sort { get; set; }
    }

    #region "Objetos compartilhados"

    /// <summary>
    /// Elemento utilizado para representar o cliente
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Código do cliente
        /// </summary>
        public string codigo { get; set; }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        [Display(Name = "Cliente")]
        public string nome { get; set; }

        /// <summary>
        /// Nome fantasia do cliente
        /// </summary>
        public string nome_fantasia { get; set; }

        /// <summary>
        /// Inscrição estadual do cliente
        /// </summary>
        public string ie { get; set; }

        /// <summary>
        /// RG do cliente
        /// </summary>
        public string rg { get; set; }

        /// <summary>
        /// Tipo de pessoa (F - Física, J - Jurídica, E - Estrangeiro)
        /// </summary>
        public string tipo_pessoa { get; set; }

        /// <summary>
        /// CPF ou CNPJ do cliente
        /// </summary>
        [Display(Name = "CPF/CNPJ")]
        public string cpf_cnpj { get; set; }

        /// <summary>
        /// Endereço do cliente
        /// </summary>
        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        /// <summary>
        /// Número do endereço do cliente
        /// </summary>
        public string numero { get; set; }

        /// <summary>
        /// Complemento do endereço do cliente
        /// </summary>
        public string complemento { get; set; }

        /// <summary>
        /// Bairro do cliente
        /// </summary>
        public string bairro { get; set; }

        /// <summary>
        /// Cep do cliente
        /// </summary>
        public string cep { get; set; }

        /// <summary>
        /// Nome da cidade do cliente conforme a Tabela de Cidades
        /// </summary>
        public string cidade { get; set; }

        /// <summary>
        /// UF do cliente
        /// </summary>
        public string uf { get; set; }

        /// <summary>
        /// Nome do País do cliente conforme Tabela de Países
        /// </summary>
        public string pais { get; set; }

        /// <summary>
        /// Telefone do cliente
        /// </summary>
        [Display(Name = "Telefone")]
        public string fone { get; set; }

        /// <summary>
        /// Email do cliente
        /// </summary>
        [Display(Name = "E-mail")]
        public string email { get; set; }
    }

    public class ItemRoot
    {
        public Item item { get; set; }
    }

    /// <summary>
    /// Elemento utilizado para representar um item do pedido
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Código do Produto
        /// </summary>
        [Display(Name = "Código")]
        public string codigo { get; set; }

        /// <summary>
        /// Descrição do Produto
        /// </summary>
        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        /// <summary>
        /// Unidade do produto
        /// </summary>
        [Display(Name = "Unidade")]
        public string unidade { get; set; }

        /// <summary>
        /// NCM do produto
        /// </summary>
        public string ncm { get; set; }

        /// <summary>
        /// Quantidade do produto
        /// </summary>
        [Display(Name = "Quantidade")]
        public decimal quantidade { get; set; }

        /// <summary>
        /// Valor unitário do produto
        /// </summary>
        [DataType(DataType.Currency)]
        [Display(Name = "Valor")]
        public decimal valor_unitario { get; set; }

        /// <summary>
        /// Valor total do produto
        /// </summary>
        public string valor_total { get; set; }

        /// <summary>
        /// CFOP do produto
        /// </summary>
        public string cfop { get; set; }

        /// <summary>
        /// Natureza de operação do produto
        /// </summary>
        public string natureza { get; set; }
    }

    /// <summary>
    /// Elemento utilizado para representar o endereço de entrega, 
    /// caso seja diferente do endereço do cliente
    /// </summary>
    public class EnderecoEntrega
    {
        /// <summary>
        /// Tipo de pessoa (F - Física, J - Jurídica, E - Estrangeiro)
        /// </summary>
        public string tipo_pessoa { get; set; }

        /// <summary>
        /// CPF ou CNPJ de entrega
        /// </summary>
        public string cpf_cnpj { get; set; }

        /// <summary>
        /// Endereço de entrega
        /// </summary>
        public string endereco { get; set; }

        /// <summary>
        /// Número do endereço de entrega
        /// </summary>
        public string numero { get; set; }

        /// <summary>
        /// Complemento do endereço de entrega
        /// </summary>
        public string complemento { get; set; }

        /// <summary>
        /// Bairro de entrega
        /// </summary>
        public string bairro { get; set; }

        /// <summary>
        /// Nome da cidade de entrega conforme a Tabela de Cidades
        /// </summary>
        public string cidade { get; set; }

        /// <summary>
        /// UF de entrega
        /// </summary>
        public string uf { get; set; }

        /// <summary>
        /// Telefone de entrega
        /// </summary>
        public string fone { get; set; }

        /// <summary>
        /// Cep de entrega
        /// </summary>
        public string cep { get; set; }
    }

    /// <summary>
    /// Lista de parcelas da Nota Fiscal
    /// </summary>
    public class ParcelaRoot
    {
        /// <summary>
        /// Elemento utilizado para representar uma parcela da Nota Fiscal
        /// </summary>
        public Parcela parcela { get; set; }
    }

    /// <summary>
    /// Elemento utilizado para representar uma parcela do pedido
    /// </summary>
    public class Parcela
    {
        /// <summary>
        /// Dias de Vencimento da Parcela
        /// </summary>
        public int dias { get; set; }

        /// <summary>
        /// Data de Vencimento da Parcela
        /// </summary>
        public string data { get; set; }

        /// <summary>
        /// Valor da parcela
        /// </summary>
        public decimal valor { get; set; }

        /// <summary>
        /// Observação da parcela
        /// </summary>
        public string obs { get; set; }

        /// <summary>
        /// Código conforme tabela de Formas de pagamento
        /// </summary>
        public string forma_pagamento { get; set; }

        /// <summary>
        /// Descrição do meio de pagamento
        /// </summary>
        public string meio_pagamento { get; set; }
    }

    /// <summary>
    /// Elemento utilizado para representar o transportador
    /// </summary>
    public class Transportador
    {
        /// <summary>
        /// Nome do transportador
        /// </summary>
        [Display(Name = "Transportadora")]
        public string nome { get; set; }

        /// <summary>
        /// CPF ou CNPJ do transportador
        /// </summary>
        public string cpf_cnpj { get; set; }

        /// <summary>
        /// Inscrição estadual do transportador
        /// </summary>
        public string ie { get; set; }

        /// <summary>
        /// Endereço do transportador
        /// </summary>
        public string endereco { get; set; }

        /// <summary>
        /// Nome da cidade do transportador conforme a Tabela de Cidades
        /// </summary>
        public string cidade { get; set; }

        /// <summary>
        /// UF do transportador
        /// </summary>
        public string uf { get; set; }
    }

    #endregion
}
