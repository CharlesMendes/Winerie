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

namespace jcconsultingti.winerie.business
{
    public class NotaFiscalBLL : ICrud<PesquisarNotaFiscal>
    {
        public long Salvar(PesquisarNotaFiscal obj)
        {
            throw new NotImplementedException();
        }

        public PesquisarNotaFiscal Detalhe(long id)
        {
            PesquisarNotaFiscal objRetorno = new PesquisarNotaFiscal();
            var detalhes = this.ObterNotaFiscalApi(id.ToString());

            objRetorno.retorno.notas_fiscais.Add(new NotaFiscalRoot()
            { detalhes = detalhes }
            );

            return objRetorno;
        }

        public List<PesquisarNotaFiscal> ListarTodos(PesquisarRequest filtros)
        {
            var lista = new List<PesquisarNotaFiscal>();
            var pesquisaNotaFiscal = this.PesquisaNotaFiscalApi(filtros);

            //Apenas considera as NF que tenham numero de pedido/ecommerce relacionado
            pesquisaNotaFiscal.retorno.notas_fiscais = pesquisaNotaFiscal.retorno.notas_fiscais.FindAll(p => p.nota_fiscal.numero_ecommerce != null).OrderByDescending(p => p.nota_fiscal.numero_ecommerce.Value).ToList();

            //Se ocorreu sucesso na consulta a API, inclui o retorno da API na lista
            if (pesquisaNotaFiscal.retorno.status_processamento.Equals((int)StatusProcessamentoEnum.SolicitacaoProcessadaComSucesso))
            {
                //Recupera os detalhes da Nota Fiscal
                for (int i = 0; i < pesquisaNotaFiscal.retorno.notas_fiscais.Count; i++)
                {
                    pesquisaNotaFiscal.retorno.notas_fiscais[i].detalhes = this.ObterNotaFiscalApi(pesquisaNotaFiscal.retorno.notas_fiscais[i].nota_fiscal.id.ToString());

                    //Se ocorreu algum erro na consulta do detalhe da NF via API, seta o erro para ser exibido em tela
                    if (!pesquisaNotaFiscal.retorno.notas_fiscais[i].detalhes.retorno.status_processamento.Equals((int)StatusProcessamentoEnum.SolicitacaoProcessadaComSucesso))
                    {
                        foreach (var itemErro in pesquisaNotaFiscal.retorno.notas_fiscais[i].detalhes.retorno.erros)
                        {
                            pesquisaNotaFiscal.retorno.erros.Add(itemErro);
                        }
                    }
                }
            }

            lista.Add(pesquisaNotaFiscal);

            return lista;
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        #region "Chamada a API Tiny"

        private IRestResponse GET_ApiTiny(MetodoApiEnum metodo, Dictionary<string, object> parametros)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string _token = string.Format("{0}", appSettings["_token"]);
            string _formato = string.Format("{0}", appSettings["_formato"]);

            var client = new RestClient("https://api.tiny.com.br/");

            var request = new RestRequest(metodo.ToDescriptionString(), Method.GET);
            request.AddParameter("token", _token);
            request.AddParameter("formato", _formato);

            //inclui os parametros genericos
            if (parametros != null)
                foreach (var item in parametros)
                {
                    request.AddParameter(item.Key, item.Value ?? DBNull.Value);
                }

            return client.Execute(request);
        }

        private IRestResponse GET_ApiTiny(MetodoApiEnum metodo)
        {
            return GET_ApiTiny(metodo, null);
        }

        #region "API NotaFiscal"

        public ObterNotaFiscal ObterNotaFiscalApi(string id)
        {
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            IRestResponse response = GET_ApiTiny(MetodoApiEnum.ObterNotaFiscal, parametros);
            return JsonConvert.DeserializeObject<ObterNotaFiscal>(response.Content);
        }

        private PesquisarNotaFiscal PesquisaNotaFiscalApi(PesquisarRequest filtros)
        {
            var parametros = new Dictionary<string, object>();

            if (filtros != null)
            {
                parametros = new Dictionary<string, object>
                {
                    { "numero", filtros.numero },
                    { "tipoNota", "S" }, //Apenas NF de Saída
                    { "dataInicial", filtros.dataInicial },
                    { "dataFinal", filtros.dataFinal },
                    { "numeroEcommerce", filtros.numeroEcommerce }
                };
            }
            else
                parametros = null;

            IRestResponse response = GET_ApiTiny(MetodoApiEnum.PesquisaNotaFiscal, parametros);
            return JsonConvert.DeserializeObject<PesquisarNotaFiscal>(response.Content);
        }

        public List<PesquisarNotaFiscal> ListarTodos()
        {
            return this.ListarTodos(null);
        }

        #endregion

        #endregion
    }
}
