using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcconsultingti.winerie.model.tiny
{
    /// <summary>
    /// OBTER PEDIDO API 2.0
    /// Serviço destinado a obter os dados de um Pedido.
    /// </summary>
    public class ObterPedido
    {
        /// <summary>
        /// Elemento raiz do retorno/response
        /// </summary>
        public Retorno retorno { get; set; }

        /// <summary>
        /// Parametros de request para chamar o serviço
        /// </summary>
        public ParametroServico request { get; set; }
    }
}
