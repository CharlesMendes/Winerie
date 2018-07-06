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
    /// Classe Pedido
    /// </summary>
    public class PedidoLayout
    {
        /// <summary>
        /// Amarração do layout pelo codigo da Tiny
        /// </summary>
        public int idTiny { get; set; }

        #region Layout

        /// <summary>
        /// Identificação do Registro
        /// Conteúdo: Fixo "1"
        /// </summary>
        public string IdRegistro
        {
            get
            {
                return "1";
            }            
        }

        /// <summary>
        /// Número do Pedido
        /// </summary>
        public string Numero
        {
            get
            {
                if (_Numero == null)
                    _Numero = string.Empty;

                return _Numero.PadRight(10);
            }

            set
            {
                _Numero = value.ToTruncate(10);
            }
        }

        private string _Numero;

        /// <summary>
        /// Número da Empresa
        /// </summary>
        public string NumeroEmpresa
        {
            get
            {
                return "013848";
            }            
        }

        /// <summary>
        /// Razao Social
        /// </summary>
        public string RazaoSocial
        {
            get
            {
                if (_RazaoSocial == null)
                    _RazaoSocial = string.Empty;

                return _RazaoSocial.PadRight(50);
            }

            set
            {
                _RazaoSocial = value.ToTruncate(50);
            }
        }

        private string _RazaoSocial;

        /// <summary>
        /// Razao Social
        /// </summary>
        public string NomeFantasia
        {
            get
            {
                if (_NomeFantasia == null)
                    _NomeFantasia = string.Empty;

                return _NomeFantasia.PadRight(20);
            }

            set
            {
                _NomeFantasia = value.ToTruncate(20);
            }
        }

        private string _NomeFantasia;

        /// <summary>
        /// Razao Social
        /// </summary>
        public string Pessoa
        {
            get
            {
                if (_Pessoa == null)
                    _Pessoa = string.Empty;

                return _Pessoa.PadRight(1);
            }

            set
            {
                _Pessoa = value.ToTruncate(1);
            }
        }

        private string _Pessoa;

        /// <summary>
        /// Razao Social
        /// </summary>
        public string CNPJ
        {
            get
            {
                if (_CNPJ == null)
                    _CNPJ = string.Empty;

                return _CNPJ.PadLeft(14,'0'); 
            }
            set
            {
                _CNPJ = value.ToTruncate(14, true);
            }
        }

        private string _CNPJ;

        /// <summary>
        /// Razao Social
        /// </summary>
        public string CPF
        {
            get
            {
                if (_CPF == null)
                    _CPF = string.Empty;

                return _CPF.PadLeft(11, '0');
            }
            set
            {
                _CPF = value.ToTruncate(11, true);
            }
        }

        private string _CPF;

        /// <summary>
        /// Inscrição Estadual
        /// </summary>
        public string IE
        {
            get
            {
                if (_IE == null)
                    _IE = string.Empty;

                return _IE.PadRight(17, ' ');
            }
            set
            {
                _IE = value.ToTruncate(17, true);
            }
        }

        private string _IE;

        /// <summary>
        /// Numero do Pedido do Cliente
        /// </summary>
        public string NumeroPedidoCliente
        {
            get
            {
                if (_NumeroPedidoCliente == null)
                    _NumeroPedidoCliente = string.Empty;

                return _NumeroPedidoCliente.PadRight(20, ' ');
            }
            set
            {
                _NumeroPedidoCliente = value.ToTruncate(20);
            }
        }

        private string _NumeroPedidoCliente;

        /// <summary>
        /// Numero da Nota
        /// </summary>
        public string NumeroNota
        {
            get
            {
                if (_NumeroNota == null)
                    _NumeroNota = string.Empty;

                return _NumeroNota.PadLeft(10, '0');
            }
            set
            {
                _NumeroNota = value.ToTruncate(10);
            }
        }

        private string _NumeroNota;

        /// <summary>
        /// Numero do Pedido do Cliente
        /// </summary>
        public DateTime DataPedido
        {
            get
            {
                return _DataPedido;
            }
            set
            {
                _DataPedido = value;
            }
        }

        public DateTime _DataPedido;

        /// <summary>
        /// Retorna a data do pedido no formato YYYYMMDD
        /// </summary>
        /// <returns></returns>
        public string GetDataPedido()
        {
            return DataPedido.ToString("yyyyMMdd");
        }

        /// <summary>
        /// Branco
        /// </summary>
        public string BrancoBCO
        {
            get
            {
                _BrancoBCO = string.Empty;
                return _BrancoBCO.PadLeft(2, ' ');
            }
            set
            {
                _BrancoBCO = value.ToTruncate(2);
            }
        }

        private string _BrancoBCO;

        /// <summary>
        /// Branco
        /// </summary>
        public string BrancoPrazo
        {
            get
            {
                _BrancoPrazo = string.Empty;
                return _BrancoPrazo.PadLeft(30, ' ');
            }
            set
            {
                _BrancoPrazo = value.ToTruncate(30);
            }
        }

        private string _BrancoPrazo;

        /// <summary>
        /// Observacao faturamento
        /// </summary>
        public string ObsFaturamento
        {
            get
            {
                if (_ObsFaturamento == null)
                    _ObsFaturamento = string.Empty;

                return _ObsFaturamento.PadRight(60, ' ');
            }
            set
            {
                _ObsFaturamento = value.ToTruncate(60);
            }
        }

        private string _ObsFaturamento;

        /// <summary>
        /// Observacao faturamento
        /// </summary>
        public string Branco
        {
            get
            {
                _Branco = string.Empty;
                return _Branco.PadLeft(123, ' ');
            }
            set
            {
                _Branco = value.ToTruncate(123);
            }
        }

        private string _Branco;
        
        #endregion

        public string GerarLinha()
        {
            return IdRegistro + Numero + NumeroEmpresa + RazaoSocial + NomeFantasia +
                   Pessoa + CNPJ + CPF + IE + NumeroPedidoCliente + NumeroNota + GetDataPedido() +
                   BrancoBCO + BrancoPrazo + ObsFaturamento + Branco;
        }
    }

}
