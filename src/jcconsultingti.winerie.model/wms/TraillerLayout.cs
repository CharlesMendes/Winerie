using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using jcconsultingti.utils;

namespace jcconsultingti.winerie.model.NaturalChoice
{
    /// <summary>
    /// Classe Endereco
    /// </summary>
    public class TraillerLayout
    {
        #region Layout

        /// <summary>
        /// Identificação do Registro
        /// Conteúdo: Fixo "9"
        /// </summary>
        public string IdRegistro
        {
            get
            {
                return "9";
            }
        }

        private string _QuantidadePedidos;

        /// <summary>
        /// Quantidade de Pedidos
        /// </summary>
        public string QuantidadePedidos
        {
            get
            {
                return _QuantidadePedidos.PadLeft(8, '0');
            }

            set
            {
                _QuantidadePedidos = value.ToTruncate(8);
            }
        }

        private string _QuantidadeProdutos;

        /// <summary>
        /// Quantidade de Produtos
        /// </summary>
        public string QuantidadeProdutos
        {
            get
            {
                return _QuantidadeProdutos.PadLeft(8, '0');
            }

            set
            {
                _QuantidadeProdutos = value.ToTruncate(8);
            }
        }

        private string _Branco;

        /// <summary>
        /// Branco
        /// </summary>
        public string Branco
        {
            get
            {
                _Branco = string.Empty;
                return _Branco.PadRight(366, ' ');
            }

            set
            {
                _Branco = value.ToTruncate(366);
            }
        }

        #endregion

        public string GerarLinha()
        {
            return IdRegistro + QuantidadePedidos + QuantidadeProdutos + Branco;
        }
    }
}