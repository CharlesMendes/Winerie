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
    public class PedidosBLL : ICrud<PesquisarPedidos>
    {
        public long Salvar(PesquisarPedidos obj)
        {
            throw new NotImplementedException();
        }

        public PesquisarPedidos Detalhe(long id)
        {
            PesquisarPedidos objRetorno = new PesquisarPedidos();
            var detalhes = this.ObterPedidoApi(id.ToString());

            objRetorno.retorno.pedidos.Add(new PedidoRoot()
            { detalhes = detalhes }
            );

            return objRetorno;
        }

        public List<PesquisarPedidos> ListarTodos(PesquisarRequest filtros)
        {
            var lista = new List<PesquisarPedidos>();
            var pesquisaPedido = this.PesquisaPedidosApi(filtros);

            //Se ocorreu sucesso na consulta a API, inclui o retorno da API na lista
            if (pesquisaPedido.retorno.status_processamento.Equals((int)StatusProcessamentoEnum.SolicitacaoProcessadaComSucesso))
            {
                //Recupera os detalhes do pedido
                for (int i = 0; i < pesquisaPedido.retorno.pedidos.Count; i++)
                {
                    pesquisaPedido.retorno.pedidos[i].detalhes = this.ObterPedidoApi(pesquisaPedido.retorno.pedidos[i].pedido.id.ToString());
                }
            }

            lista.Add(pesquisaPedido);

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

        #region "API Pedido"

        private ObterPedido ObterPedidoApi(string id)
        {
            var parametros = new Dictionary<string, object>
            {
                {"id", id}
            };

            IRestResponse response = GET_ApiTiny(MetodoApiEnum.ObterPedido, parametros);
            return JsonConvert.DeserializeObject<ObterPedido>(response.Content);
        }

        private PesquisarPedidos PesquisaPedidosApi(PesquisarRequest filtros)
        {
            var parametros = new Dictionary<string, object>();

            if (filtros != null)
            {
                parametros = new Dictionary<string, object>
                {
                    { "cliente", filtros.cliente },
                    { "cpf_cnpj", filtros.cpf_cnpj },
                    { "dataInicial", filtros.dataInicial },
                    { "dataFinal", filtros.dataFinal },
                    { "numeroEcommerce", filtros.numeroEcommerce },
                    { "numero", filtros.numero},
                    { "idVendedor", filtros.idVendedor },
                    { "nomeVendedor", filtros.nomeVendedor }
                };
            }
            else
                parametros = null;

            IRestResponse response = GET_ApiTiny(MetodoApiEnum.PesquisaPedidos, parametros);
            return JsonConvert.DeserializeObject<PesquisarPedidos>(response.Content);
        }

        public List<PesquisarPedidos> ListarTodos()
        {
            return this.ListarTodos(null);
        }

        #endregion

        #endregion
    }
}
