using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using jcconsultingti.utils;
using static jcconsultingti.utils.Extensions;

namespace jcconsultingti.winerie.model.NaturalChoice
{
    /// <summary>
    /// Classe Nota Fiscal
    /// </summary>
    public class NotaFiscalLayout
    {
        /// <summary>
        /// Amarração do layout pelo codigo da Tiny
        /// </summary>
        //[EpplusIgnore]
        //public int idTiny { get; set; }

        #region Layout

        public string nr_pedido { get; set; }
        public string nr_cnpj_remetente { get; set; }
        public string nr_cnpj_destinatario { get; set; }
        public string nr_ie { get; set; }
        public string nm_razao_social { get; set; }
        public string ds_endereco { get; set; }
        public string nr_numero { get; set; }
        public string ds_complemento { get; set; }
        public string ds_bairro { get; set; }
        public string ds_cidade { get; set; }
        public string ds_uf { get; set; }
        public string ds_cep { get; set; }
        public string codigo_IBGE { get; set; }
        public string nr_telefone { get; set; }
        public string nr_chave_acesso { get; set; }
        public string vl_declarado_nf { get; set; }
        public string nr_qtde_teorico { get; set; }
        public string nr_peso_teorico { get; set; }
        public string dt_inicio { get; set; }
        public string dt_previsao { get; set; }
        public string nm_solicitante { get; set; }
        public string Nr_Nota { get; set; }

        #endregion
    }
}
