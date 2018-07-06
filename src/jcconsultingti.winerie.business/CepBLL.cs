using RestSharp;
using System;
using jcconsultingti.utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using jcconsultingti.winerie.model.viacep;

namespace jcconsultingti.winerie.business
{
    public class CepBLL
    {
        public CepBLL()
        {

        }

        private IRestResponse GET_ApiViaCep(string cep)
        {
            cep = cep.ToTruncate(8, true);
            string baseUrl = string.Format("https://viacep.com.br/ws/{0}/json/", cep);
            var client = new RestClient(baseUrl);

            var request = new RestRequest(Method.GET);
            return client.Execute(request);
        }

        public Endereco ObterEnderecoCompleto(string cep)
        {
            try
            {
                IRestResponse response = this.GET_ApiViaCep(cep);
                return JsonConvert.DeserializeObject<Endereco>(response.Content);
            }
            catch (Exception ex)
            {
                return new Endereco() { ibge = string.Empty };
            }
        }
    }
}
