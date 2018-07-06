using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using jcconsultingti.utils;

namespace jcconsultingti.winerie.model.NaturalChoice
{
    public class ProdutoLayout
    {
        /// <summary>
        /// Amarração do layout pelo codigo da Tiny
        /// </summary>
        public int idTiny { get; set; }

        #region Layout

        /// <summary>
        /// Identificação do Registro
        /// Conteúdo: Fixo "3"
        /// </summary>
        public string IdRegistro
        {
            get
            {
                return "3";
            }
        }

        private string _NumeroPedido;

        /// <summary>
        /// Número do pedido
        /// </summary>
        public string NumeroPedido
        {
            get
            {
                if (_NumeroPedido == null)
                    _NumeroPedido = string.Empty;

                return _NumeroPedido.PadRight(10, ' ');
            }

            set
            {
                _NumeroPedido = value.ToTruncate(10);
            }
        }

        private string _Item;

        /// <summary>
        /// Item do pedido
        /// </summary>
        public string Item
        {
            get
            {
                if (_Item == null)
                    _Item = string.Empty;

                return _Item.PadLeft(3, '0');
            }

            set
            {
                _Item = value.ToTruncate(3);
            }
        }

        /// <summary>
        /// Especie Venda
        /// Conteúdo: Fixo "SL9"
        /// </summary>
        public string EspecieVenda
        {
            get
            {
                return "SL9";
            }
        }

        private string _EAN;

        /// <summary>
        /// EAN
        /// </summary>
        public string EAN
        {
            get
            {
                if (_EAN == null)
                    _EAN = string.Empty;

                return _EAN.PadRight(13, ' ');
            }

            set
            {
                _EAN = value.ToTruncate(13);
            }
        }

        private string _CodigoProduto;

        /// <summary>
        /// Codigo do Produto
        /// </summary>
        public string CodigoProduto
        {
            get
            {
                if (_CodigoProduto == null)
                    _CodigoProduto = string.Empty;

                return _CodigoProduto.PadRight(15, ' ');
            }

            set
            {
                _CodigoProduto = value.ToTruncate(15, false, false);
            }
        }

        private string _NCM;

        /// <summary>
        /// NCM
        /// </summary>
        public string NCM
        {
            get
            {
                if (_NCM == null)
                    _NCM = string.Empty;

                return _NCM.PadRight(12, ' ');
            }

            set
            {
                _NCM = value.ToTruncate(12, true);
            }
        }

        //private string _DescricaoGrupo;

        ///// <summary>
        ///// Descrição Grupo
        ///// </summary>
        //public string DescricaoGrupo
        //{
        //    get
        //    {
        //        if (_DescricaoGrupo == null)
        //            _DescricaoGrupo = string.Empty;

        //        return _DescricaoGrupo.PadRight(30, ' ');
        //    }

        //    set
        //    {
        //        _DescricaoGrupo = value.ToTruncate(30);
        //    }
        //}

        private string _DescricaoProduto;

        /// <summary>
        /// Descrição Produto/Grupo
        /// </summary>
        public string DescricaoProduto
        {
            get
            {
                if (_DescricaoProduto == null)
                    _DescricaoProduto = string.Empty;

                return _DescricaoProduto.PadRight(64, ' ');
            }

            set
            {
                _DescricaoProduto = value.ToTruncate(64);
            }
        }

        private string _Quantidade;

        /// <summary>
        /// Quantidade
        /// </summary>
        public string Quantidade
        {
            get
            {
                if (_Quantidade == null)
                    _Quantidade = string.Empty;

                try
                {
                    return ((int)Convert.ToDouble(_Quantidade)).ToString().PadLeft(8, '0');
                }
                catch
                {
                    return _Quantidade.ToString().PadLeft(8, '0');
                }                       
            }

            set
            {
                _Quantidade = ((int)Convert.ToDouble(value)).ToString().ToTruncate(8);
            }
        }

        private string _Unidade;

        /// <summary>
        /// Unidade
        /// </summary>
        public string Unidade
        {
            get
            {
                if (_Unidade == null)
                    _Unidade = string.Empty;

                return _Unidade.PadRight(2, ' ');
            }

            set
            {
                _Unidade = value.ToTruncate(2);

                if (string.IsNullOrEmpty(_Unidade)) //valor default UN
                    _Unidade = "UN";
            }
        }

        private decimal _ValorUnitarioVenda;

        /// <summary>
        /// Valor Unitario Venda
        /// </summary>
        public decimal ValorUnitarioVenda
        {
            set
            {
                _ValorUnitarioVenda = Convert.ToDecimal(value) * 100;
            }
        }

        /// <summary>
        /// Valor Unitario Venda formatado
        /// </summary>
        public string ValorUnitarioVendaFormatado
        {
            get
            {
                return ((int)_ValorUnitarioVenda).ToString().PadLeft(13, '0');
            }
        }

        private decimal _ValorUnitarioRetorno;

        /// <summary>
        /// Unidade
        /// </summary>
        public decimal ValorUnitarioRetorno
        {
            set
            {
                _ValorUnitarioRetorno = Convert.ToDecimal(value) * 100;
            }
        }

        /// <summary>
        /// Valor unitario retorno formatado
        /// </summary>
        public string ValorUnitarioRetornoFormatado
        {
            get
            {
                return ((int)_ValorUnitarioRetorno).ToString().PadLeft(13, '0');
            }
        }

        private string _BrancoChave;

        /// <summary>
        /// Branco-chave
        /// </summary>
        public string BrancoChave
        {
            get
            {
                if (_BrancoChave == null)
                    _BrancoChave = string.Empty;

                return _BrancoChave.PadRight(47, ' ');
            }

            set
            {
                _BrancoChave = value.ToTruncate(47);
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
                if (_Branco == null)
                    _Branco = string.Empty;

                return _Branco.PadRight(179, ' ');
            }

            set
            {
                _Branco = value.ToTruncate(179);
            }
        }

        #endregion Layout

        public string GerarLinha()
        {
            return IdRegistro + NumeroPedido + Item + EspecieVenda + EAN + CodigoProduto + NCM + 
                   DescricaoProduto + Quantidade + Unidade + ValorUnitarioVendaFormatado + ValorUnitarioRetornoFormatado +
                   BrancoChave + Branco;
        }
    }
}
