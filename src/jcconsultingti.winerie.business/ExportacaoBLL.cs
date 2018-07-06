using System;
using System.Collections.Generic;
using System.Linq;
using jcconsultingti.winerie.model;
using jcconsultingti.winerie.model.NaturalChoice;
using jcconsultingti.winerie.data;
using System.Configuration;
using jcconsultingti.winerie.model.tiny;
using RestSharp;
using Newtonsoft.Json;
using System.IO;
using jcconsultingti.utils;
using jcconsultingti.winerie.model.Enum;
using OfficeOpenXml;

namespace jcconsultingti.winerie.business
{
    public class ExportacaoBLL : ICrud<Exportacao>, IExportacao<Exportacao>
    {
        private ExportacaoDAL _dal;

        //relacionamentos
        private TipoArquivoBLL _bllTipoArquivo;
        private UsuarioBLL _bllUsuario;
        private StatusBLL _bllStatus;
        private PedidosBLL _bllPedidos;
        private NotaFiscalBLL _bllNotaFiscal;
        private CepBLL _bllCep;

        public ExportacaoBLL()
        {
            _dal = new ExportacaoDAL();
            _bllTipoArquivo = new TipoArquivoBLL();
            _bllUsuario = new UsuarioBLL();
            _bllStatus = new StatusBLL();
            _bllPedidos = new PedidosBLL();
            _bllNotaFiscal = new NotaFiscalBLL();
            _bllCep = new CepBLL();
        }

        public void Excluir(int id)
        {
            _dal.Excluir(id);
        }

        public Exportacao Detalhe(long id)
        {
            var retorno = _dal.ListarPorId(id);

            //relacionamentos
            retorno.TipoArquivo = _bllTipoArquivo.Detalhe(retorno.idTipoArquivo);
            retorno.status = _bllStatus.Detalhe(retorno.idStatus);
            retorno.usuarioExportacao = _bllUsuario.Detalhe(retorno.idUsuarioExportacao);

            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TipoArquivo"></param>
        /// <returns></returns>
        public List<Exportacao> ListarTodos(int? TipoArquivo)
        {
            var lista = new List<Exportacao>();

            //relacionamentos
            foreach (var item in _dal.ListarTodos(TipoArquivo))
            {
                item.TipoArquivo = _bllTipoArquivo.Detalhe(item.idTipoArquivo);
                item.status = _bllStatus.Detalhe(item.idStatus);
                item.usuarioExportacao = _bllUsuario.Detalhe(item.idUsuarioExportacao);

                if (item.dataFimProcessamento.Equals(DateTime.MinValue))
                    item.dataFimProcessamento = null;

                lista.Add(item);
            }

            return lista;
        }

        public long Salvar(Exportacao obj)
        {
            return _dal.Salvar(obj);
        }

        public List<Exportacao> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public List<Exportacao> ListarTodosPorStatus(int? TipoArquivo, long idStatus)
        {
            var listaExportacoes = ListarTodos(TipoArquivo).Where(p => p.idStatus == idStatus).ToList();

            return listaExportacoes;
        }

        /// <summary>
        /// Exportar Pedido em .txt
        /// </summary>
        /// <param name="layoutArquivoPedidos"></param>
        /// <returns></returns>
        private string ExportarPedido(LayoutArquivoPedidos layoutArquivoPedidos)
        {
            TraillerLayout trailler = new TraillerLayout();

            //Gera nome do arquivo a ser exportado
            string arquivoExportacao = "Pedido.txt";
            arquivoExportacao = arquivoExportacao.GerarNomeUnico(true);

            var appSettings = ConfigurationManager.AppSettings;
            string _diretorioExportacao = string.Format("{0}", appSettings["_diretorioExportacao"]);

            string _diretorioPendente = string.Format("{0}{1}", _diretorioExportacao, appSettings["_diretorioPendente"]);
            string _diretorioProcessado = string.Format("{0}{1}", _diretorioExportacao, appSettings["_diretorioProcessado"]);

            string pathArquivoPendente = string.Format("{0}{1}", _diretorioPendente, arquivoExportacao);
            string pathArquivoProcessado = string.Format("{0}{1}", _diretorioProcessado, arquivoExportacao);

            using (FileStream aFile = new FileStream(pathArquivoPendente, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(aFile))
                {
                    foreach (PedidoLayout pedido in layoutArquivoPedidos.listaPedidos)
                    {
                        //Gera a linha do pedido 
                        writer.WriteLine(pedido.GerarLinha());

                        //Lista todos os endereços do pedido
                        List<EnderecoLayout> enderecosPedido = layoutArquivoPedidos.listaEnderecos.Where(p => p.idTiny == pedido.idTiny).ToList();

                        foreach (EnderecoLayout endereco in enderecosPedido)
                        {
                            writer.WriteLine(endereco.GerarLinha());
                        }

                        //Lista todos os produtos do pedido
                        List<ProdutoLayout> produtosPedido = layoutArquivoPedidos.listaProdutos.Where(p => p.idTiny == pedido.idTiny).ToList();

                        foreach (ProdutoLayout produto in produtosPedido)
                        {
                            writer.WriteLine(produto.GerarLinha());
                        }
                    }

                    //Gera arquivo trailler
                    trailler.QuantidadePedidos = layoutArquivoPedidos.listaPedidos.Count.ToString();
                    trailler.QuantidadeProdutos = layoutArquivoPedidos.listaProdutos.Count.ToString();

                    writer.WriteLine(trailler.GerarLinha());
                }
            }

            //remover os arquivos temporarios ao término da geração do arquivo
            if ((File.Exists(pathArquivoPendente)))
            {
                File.Move(pathArquivoPendente, pathArquivoProcessado);
            }

            return arquivoExportacao;
        }

        /// <summary>
        /// Exportar NotaFiscal em excel
        /// </summary>
        /// <param name="notaFiscalLayout"></param>
        /// <returns></returns>
        private string ExportarNotaFiscal(List<NotaFiscalLayout> listaNotaFiscalLayout)
        {
            //Gera nome do arquivo a ser exportado
            string arquivoExportacao = "movimento.xlsx";
            arquivoExportacao = arquivoExportacao.GerarNomeUnico(true);

            var appSettings = ConfigurationManager.AppSettings;
            string _diretorioExportacao = string.Format("{0}", appSettings["_diretorioExportacao"]);

            string _diretorioPendente = string.Format("{0}{1}", _diretorioExportacao, appSettings["_diretorioPendente"]);
            string _diretorioProcessado = string.Format("{0}{1}", _diretorioExportacao, appSettings["_diretorioProcessado"]);

            string pathArquivoPendente = string.Format("{0}{1}", _diretorioPendente, arquivoExportacao);
            string pathArquivoProcessado = string.Format("{0}{1}", _diretorioProcessado, arquivoExportacao);

            using (ExcelPackage package = new ExcelPackage(new FileInfo(pathArquivoPendente)))
            {
                //Cria a pasta de trabalho 'movimentos'
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("movimentos");

                worksheet.Cells["A1"].Value = "nr_pedido";
                worksheet.Cells["B1"].Value = "nr_cnpj_remetente";
                worksheet.Cells["C1"].Value = "nr_cnpj_destinatario";
                worksheet.Cells["D1"].Value = "nr_ie";
                worksheet.Cells["E1"].Value = "nm_razao_social";
                worksheet.Cells["F1"].Value = "ds_endereco";
                worksheet.Cells["G1"].Value = "nr_numero";
                worksheet.Cells["H1"].Value = "ds_complemento";
                worksheet.Cells["I1"].Value = "ds_bairro";
                worksheet.Cells["J1"].Value = "ds_cidade";
                worksheet.Cells["K1"].Value = "ds_uf";
                worksheet.Cells["L1"].Value = "ds_cep";
                worksheet.Cells["M1"].Value = "codigo_IBGE";
                worksheet.Cells["N1"].Value = "nr_telefone";
                worksheet.Cells["O1"].Value = "nr_chave_acesso";
                worksheet.Cells["P1"].Value = "vl_declarado_nf";
                worksheet.Cells["Q1"].Value = "nr_qtde_teorico";
                worksheet.Cells["R1"].Value = "nr_peso_teorico";
                worksheet.Cells["S1"].Value = "dt_inicio";
                worksheet.Cells["T1"].Value = "dt_previsao";
                worksheet.Cells["U1"].Value = "nm_solicitante";
                worksheet.Cells["V1"].Value = "Nr_Nota";

                //Cria a planilha com base em um objeto List
                worksheet.Cells["A2"].LoadFromCollection(listaNotaFiscalLayout, false);

                //Salva a planilha
                package.Save();
            }

            //remover os arquivos temporarios ao término da geração do arquivo
            if ((File.Exists(pathArquivoPendente)))
            {
                File.Move(pathArquivoPendente, pathArquivoProcessado);
            }

            return arquivoExportacao;
        }

        public bool AtualizarStatusExportacao(long idStatusAtual, long idStatusNovo)
        {
            return _dal.AtualizarStatusExportacao(idStatusAtual, idStatusNovo);
        }

        public bool AtualizarStatusExportacao(long idExportacao, long idStatusAtual, long idStatusNovo)
        {
            return _dal.AtualizarStatusExportacao(idExportacao, idStatusAtual, idStatusNovo);
        }

        public string ExportarPedido(long id, string dataInicial, string dataFinal)
        {
            string idParametro = null;
            if (id > 0)
                idParametro = id.ToString();

            PesquisarRequest filtros = new PesquisarRequest()
            {
                numero = idParametro,
                dataInicial = dataInicial,
                dataFinal = dataFinal
            };

            PesquisarPedidos pedidoPesquisaApi = null;

            if (id.Equals(0) && dataInicial == null)
                pedidoPesquisaApi = _bllPedidos.ListarTodos(null).FirstOrDefault();
            else
                pedidoPesquisaApi = _bllPedidos.ListarTodos(filtros).FirstOrDefault();

            #region " - Pedidos - "

            LayoutArquivoPedidos layoutArquivoPedidos = new LayoutArquivoPedidos();
            List<PedidoLayout> listaPedidos = new List<PedidoLayout>();
            List<ProdutoLayout> listaProdutos = new List<ProdutoLayout>();
            List<EnderecoLayout> listaEnderecos = new List<EnderecoLayout>();

            if (pedidoPesquisaApi != null)
                foreach (var pedido in pedidoPesquisaApi.retorno.pedidos)
                {
                    try
                    {
                        //Se for igual a 0, ira retornar todos os pedidos ou entao retorna apenas o pedido selecionado
                        if (id.Equals(0) || pedido.pedido.numero.Equals((int)id))
                        {
                            ObterNotaFiscal notaFiscalDetalhe = _bllNotaFiscal.ObterNotaFiscalApi(pedido.pedido.id_nota_fiscal.ToString());

                            PedidoLayout pedidoLayout = new PedidoLayout();
                            pedidoLayout.idTiny = pedido.pedido.id;

                            pedidoLayout.Numero = pedido.pedido.numero.ToString();
                            pedidoLayout.RazaoSocial = pedido.detalhes.retorno.pedido.cliente.nome;
                            pedidoLayout.NomeFantasia = pedido.detalhes.retorno.pedido.cliente.nome_fantasia;
                            pedidoLayout.Pessoa = pedido.detalhes.retorno.pedido.cliente.tipo_pessoa;

                            if (pedido.detalhes.retorno.pedido.cliente.tipo_pessoa.Trim().ToUpper().Equals("J"))
                                pedidoLayout.CNPJ = pedido.detalhes.retorno.pedido.cliente.cpf_cnpj;

                            if (pedido.detalhes.retorno.pedido.cliente.tipo_pessoa.Trim().ToUpper().Equals("F"))
                                pedidoLayout.CPF = pedido.detalhes.retorno.pedido.cliente.cpf_cnpj;

                            pedidoLayout.IE = pedido.detalhes.retorno.pedido.cliente.ie;
                            pedidoLayout.NumeroPedidoCliente = pedido.detalhes.retorno.pedido.numero_ordem_compra;
                            pedidoLayout.NumeroNota = notaFiscalDetalhe.retorno.nota_fiscal.numero.ToString();
                            pedidoLayout.DataPedido = Convert.ToDateTime(pedido.pedido.data_pedido);
                            pedidoLayout.ObsFaturamento = pedido.detalhes.retorno.pedido.obs;

                            listaPedidos.Add(pedidoLayout);

                            #region " - Produtos - "

                            int contadorProduto = 0;
                            foreach (var produto in pedido.detalhes.retorno.pedido.itens)
                            {
                                contadorProduto++; //incrementa um produto

                                ProdutoLayout produtoLayout = new ProdutoLayout();
                                produtoLayout.idTiny = pedidoLayout.idTiny;
                                produtoLayout.Item = contadorProduto.ToString();

                                produtoLayout.NumeroPedido = pedidoLayout.Numero;

                                //produtoLayout.EAN = ; //<ToDo> Não localizamos o EAN
                                var itemNota = notaFiscalDetalhe.retorno.nota_fiscal.itens.Find(p => p.item.descricao.Trim() == produto.item.descricao.Trim() && p.item.codigo.Trim() == produto.item.codigo.Trim());

                                if (itemNota != null)
                                    produtoLayout.NCM = itemNota.item.ncm;

                                produtoLayout.CodigoProduto = produto.item.codigo;
                                produtoLayout.DescricaoProduto = produto.item.descricao;
                               
                                produtoLayout.Quantidade = produto.item.quantidade.ToString();
                                produtoLayout.Unidade = produto.item.unidade;
                                produtoLayout.ValorUnitarioVenda = produto.item.valor_unitario;
                                produtoLayout.ValorUnitarioRetorno = produto.item.valor_unitario;

                                listaProdutos.Add(produtoLayout);
                            }

                            #endregion

                            #region " - Endereços - "

                            EnderecoLayout enderecoLayout = new EnderecoLayout();
                            enderecoLayout.idTiny = pedidoLayout.idTiny;

                            enderecoLayout.NumeroPedido = pedidoLayout.Numero;
                            var cliente = pedido.detalhes.retorno.pedido.cliente;

                            enderecoLayout.Telefone = cliente.fone;
                            enderecoLayout.Email = cliente.email;

                            //Endereço Principal
                            enderecoLayout.Endereco = cliente.endereco;
                            enderecoLayout.Numero = cliente.numero;
                            enderecoLayout.Complemento = cliente.complemento;
                            enderecoLayout.CEP = cliente.cep;
                            enderecoLayout.Bairro = cliente.bairro;
                            enderecoLayout.CodIBGE = _bllCep.ObterEnderecoCompleto(enderecoLayout.CEP).ibge;

                            //Endereço Cobrança - repetir o endereço principal
                            enderecoLayout.EnderecoCobranca = enderecoLayout.Endereco;
                            enderecoLayout.NumeroCobranca = enderecoLayout.Numero;
                            enderecoLayout.ComplementoCobranca = enderecoLayout.Complemento;
                            enderecoLayout.CEPCobranca = enderecoLayout.CEP;
                            enderecoLayout.BairroCobranca = enderecoLayout.Bairro;
                            enderecoLayout.CodIBGECobranca = enderecoLayout.CodIBGE;

                            listaEnderecos.Add(enderecoLayout);

                            #endregion
                        }
                    }
                    catch (Exception ex) //Try catch para capturar quando a API estoura as chamadas dela, e da um erro.
                    {

                    }
                }

            #endregion

            layoutArquivoPedidos.listaPedidos = listaPedidos;
            layoutArquivoPedidos.listaProdutos = listaProdutos;
            layoutArquivoPedidos.listaEnderecos = listaEnderecos;

            return this.ExportarPedido(layoutArquivoPedidos);
        }

        public string ExportarNotaFiscal(long id, string dataInicial, string dataFinal)
        {
            string idParametro = null;
            if (id > 0)
                idParametro = id.ToString();

            PesquisarRequest filtros = new PesquisarRequest()
            {
                numero = idParametro,
                dataInicial = dataInicial,
                dataFinal = dataFinal
            };

            PesquisarNotaFiscal pesquisarNotaFiscalAPI = null;

            if (id.Equals(0) && dataInicial == null)
                pesquisarNotaFiscalAPI = _bllNotaFiscal.ListarTodos(null).FirstOrDefault();
            else
                pesquisarNotaFiscalAPI = _bllNotaFiscal.ListarTodos(filtros).FirstOrDefault();

            #region " - Notas Fiscais - "

            List<NotaFiscalLayout> listaNotaFiscal = new List<NotaFiscalLayout>();

            if (pesquisarNotaFiscalAPI != null)
            {
                foreach (var notaFiscal in pesquisarNotaFiscalAPI.retorno.notas_fiscais)
                {
                    try
                    {
                        NotaFiscalLayout notaFiscalLayout = new NotaFiscalLayout();
                        //notaFiscalLayout.idTiny = notaFiscal.detalhes.retorno.nota_fiscal.id;

                        if (notaFiscal.detalhes.retorno.status_processamento.Equals((int)StatusProcessamentoEnum.SolicitacaoProcessadaComSucesso))
                        {
                            notaFiscalLayout.nr_pedido = notaFiscal.detalhes.retorno.nota_fiscal.numero_ecommerce.ToString();
                            notaFiscalLayout.nr_cnpj_remetente = notaFiscal.detalhes.retorno.nota_fiscal.cliente.cpf_cnpj;
                            notaFiscalLayout.nr_cnpj_destinatario = notaFiscal.detalhes.retorno.nota_fiscal.cliente.cpf_cnpj;
                            notaFiscalLayout.nr_ie = notaFiscal.detalhes.retorno.nota_fiscal.cliente.ie;
                            notaFiscalLayout.nm_razao_social = notaFiscal.detalhes.retorno.nota_fiscal.cliente.nome;
                            notaFiscalLayout.ds_endereco = notaFiscal.detalhes.retorno.nota_fiscal.cliente.endereco;
                            notaFiscalLayout.nr_numero = notaFiscal.detalhes.retorno.nota_fiscal.cliente.numero;
                            notaFiscalLayout.ds_complemento = notaFiscal.detalhes.retorno.nota_fiscal.cliente.complemento;
                            notaFiscalLayout.ds_bairro = notaFiscal.detalhes.retorno.nota_fiscal.cliente.bairro;
                            notaFiscalLayout.ds_cidade = notaFiscal.detalhes.retorno.nota_fiscal.cliente.cidade;
                            notaFiscalLayout.ds_uf = notaFiscal.detalhes.retorno.nota_fiscal.cliente.uf;
                            notaFiscalLayout.ds_cep = notaFiscal.detalhes.retorno.nota_fiscal.cliente.cep;
                            notaFiscalLayout.codigo_IBGE = _bllCep.ObterEnderecoCompleto(notaFiscalLayout.ds_cep).ibge;
                            notaFiscalLayout.nr_telefone = notaFiscal.detalhes.retorno.nota_fiscal.cliente.fone;
                            notaFiscalLayout.nr_chave_acesso = notaFiscal.detalhes.retorno.nota_fiscal.chave_acesso;
                            notaFiscalLayout.vl_declarado_nf = notaFiscal.detalhes.retorno.nota_fiscal.valor_produtos.ToString();
                            notaFiscalLayout.nr_qtde_teorico = notaFiscal.detalhes.retorno.nota_fiscal.quantidade_volumes.ToString();
                            notaFiscalLayout.nr_peso_teorico = notaFiscal.detalhes.retorno.nota_fiscal.peso_bruto.ToString();
                            notaFiscalLayout.dt_inicio = notaFiscal.detalhes.retorno.nota_fiscal.data_emissao;
                            notaFiscalLayout.dt_previsao = string.Format("{0} {1}", notaFiscal.detalhes.retorno.nota_fiscal.data_saida, notaFiscal.detalhes.retorno.nota_fiscal.hora_saida);
                            notaFiscalLayout.nm_solicitante = notaFiscal.detalhes.retorno.nota_fiscal.nome_vendedor;
                            notaFiscalLayout.Nr_Nota = string.Format("{0}/{1}", notaFiscal.detalhes.retorno.nota_fiscal.numero.ToString(), notaFiscal.detalhes.retorno.nota_fiscal.serie.ToString());
                        }
                        else
                        {
                            notaFiscalLayout.nr_pedido = notaFiscal.detalhes.retorno.erros.FirstOrDefault().erro;
                        }

                        listaNotaFiscal.Add(notaFiscalLayout);
                    }
                    catch (Exception ex) //Try catch para capturar quando a API estoura as chamadas dela, e da um erro.
                    {

                    }
                }
            }
            else
            {
                NotaFiscalLayout notaFiscalLayout = new NotaFiscalLayout();
                notaFiscalLayout.nr_pedido = pesquisarNotaFiscalAPI.retorno.erros.FirstOrDefault().erro;
                listaNotaFiscal.Add(notaFiscalLayout);
            }

            #endregion

            return this.ExportarNotaFiscal(listaNotaFiscal);
        }

        public string Exportar(long id)
        {
            throw new NotImplementedException();
        }
    }
}
