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
    public class EnderecoLayout
    {
        /// <summary>
        /// Amarração do layout pelo codigo da Tiny
        /// </summary>
        public int idTiny { get; set; }

        #region Layout

        /// <summary>
        /// Identificação do Registro
        /// Conteúdo: Fixo "2"
        /// </summary>
        public string IdRegistro
        {
            get
            {
                return "2";
            }
        }

        private string _NumeroPedido;

        /// <summary>
        /// Número do Pedido
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

        private string _Endereco;

        /// <summary>
        /// Logradouro
        /// </summary>
        public string Endereco
        {
            get
            {
                if (_Endereco == null)
                    _Endereco = string.Empty;

                return _Endereco.PadRight(40, ' ');
            }

            set
            {
                _Endereco = value.ToTruncate(40);
            }
        }

        private string _Numero;

        /// <summary>
        /// Número
        /// </summary>  
        public string Numero
        {
            get
            {
                if (_Numero == null)
                    _Numero = string.Empty;

                return _Numero.PadRight(10, ' ');
            }

            set
            {
                _Numero = value.ToTruncate(10);
            }
        }

        private string _Complemento;

        /// <summary>
        /// Complemento
        /// </summary>
        public string Complemento
        {
            get
            {
                if (_Complemento == null)
                    _Complemento = string.Empty;

                return _Complemento.PadRight(20, ' ');
            }

            set
            {
                _Complemento = value.ToTruncate(20);
            }
        }

        private string _CEP;

        /// <summary>
        /// CEP
        /// </summary>
        public string CEP
        {
            get
            {
                if (_CEP == null)
                    _CEP = string.Empty;

                return _CEP.PadLeft(8, '0');
            }

            set
            {
                _CEP = value.ToTruncate(8, true);
            }
        }

        private string _Bairro;

        /// <summary>
        /// Bairro
        /// </summary>
        public string Bairro
        {
            get
            {
                if (_Bairro == null)
                    _Bairro = string.Empty;

                return _Bairro.PadRight(20, ' ');
            }

            set
            {
                _Bairro = value.ToTruncate(20);
            }
        }

        private string _CodIBGE;

        /// <summary>
        /// Código da Cidade
        /// </summary>
        public string CodIBGE
        {
            get
            {
                if (_CodIBGE == null)
                    _CodIBGE = string.Empty;

                return _CodIBGE.PadLeft(7, '0');
            }

            set
            {
                _CodIBGE = value.ToTruncate(7);
            }
        }

        private string _Telefone;

        /// <summary>
        /// Telefone
        /// </summary>
        public string Telefone
        {
            get
            {
                if (_Telefone == null)
                    _Telefone = string.Empty;

                return _Telefone.PadRight(12, ' ');
            }

            set
            {
                _Telefone = value.ToTruncate(12, true);
            }
        }

        private string _ReferenciaEndereco;

        /// <summary>
        /// Referencia Endereço
        /// </summary>
        public string ReferenciaEndereco
        {
            get
            {
                if (_ReferenciaEndereco == null)
                    _ReferenciaEndereco = string.Empty;

                return _ReferenciaEndereco.PadRight(40, ' ');
            }

            set
            {
                _ReferenciaEndereco = value.ToTruncate(40);
            }
        }

        private string _Email;

        /// <summary>
        /// EMail
        /// </summary>
        public string Email
        {
            get
            {
                if (_Email == null)
                    _Email = string.Empty;

                return _Email.PadRight(50, ' ');
            }

            set
            {
                _Email = value.ToTruncate(50, false, false);
            }
        }

        private string _ObservacaoClienteExpedicao;

        /// <summary>
        /// Observacao Cliente Expedicao
        /// </summary>
        public string ObservacaoClienteExpedicao
        {
            get
            {
                if (_ObservacaoClienteExpedicao == null)
                    _ObservacaoClienteExpedicao = string.Empty;

                return _ObservacaoClienteExpedicao.PadRight(60, ' ');
            }

            set
            {
                _ObservacaoClienteExpedicao = value.ToTruncate(60);
            }
        }

        private string _EnderecoCobranca;

        /// <summary>
        /// Logradouro Cobranca
        /// </summary>
        public string EnderecoCobranca
        {
            get
            {
                if (_EnderecoCobranca == null)
                    _EnderecoCobranca = string.Empty;

                return _EnderecoCobranca.PadRight(40, ' ');
            }

            set
            {
                _EnderecoCobranca = value.ToTruncate(40);
            }
        }

        private string _NumeroCobranca;

        /// <summary>
        /// Número Cobranca
        /// </summary>  
        public string NumeroCobranca
        {
            get
            {
                if (_NumeroCobranca == null)
                    _NumeroCobranca = string.Empty;

                return _NumeroCobranca.PadRight(10, ' ');
            }

            set
            {
                _NumeroCobranca = value.ToTruncate(10);
            }
        }

        private string _ComplementoCobranca;

        /// <summary>
        /// Complemento Cobranca
        /// </summary>
        public string ComplementoCobranca
        {
            get
            {
                if (_ComplementoCobranca == null)
                    _ComplementoCobranca = string.Empty;

                return _ComplementoCobranca.PadRight(20, ' ');
            }

            set
            {
                _ComplementoCobranca = value.ToTruncate(20);
            }
        }

        private string _CEPCobranca;

        /// <summary>
        /// CEP Cobranca
        /// </summary>
        public string CEPCobranca
        {
            get
            {
                if (_CEPCobranca == null)
                    _CEPCobranca = string.Empty;

                return _CEPCobranca.PadLeft(8, '0');
            }
            set
            {
                _CEPCobranca = value.ToTruncate(8, true);
            }
        }

        private string _BairroCobranca;

        /// <summary>
        /// Bairro Cobranca
        /// </summary>
        public string BairroCobranca
        {
            get
            {
                if (_BairroCobranca == null)
                    _BairroCobranca = string.Empty;

                return _BairroCobranca.PadRight(20, ' ');
            }

            set
            {
                _BairroCobranca = value.ToTruncate(20);
            }
        }

        private string _CodIBGECobranca;

        /// <summary>
        /// Código da Cidade Cobranca
        /// </summary>
        public string CodIBGECobranca
        {
            get
            {
                if (_CodIBGECobranca == null)
                    _CodIBGECobranca = string.Empty;

                return _CodIBGECobranca.PadLeft(7, '0');
            }

            set
            {
                _CodIBGECobranca = value.ToTruncate(7);
            }
        }

        #endregion

        public string GerarLinha()
        {
            return IdRegistro + NumeroPedido + Endereco + Numero + Complemento + CEP + Bairro + CodIBGE + Telefone +
                   ReferenciaEndereco + Email + ObservacaoClienteExpedicao + EnderecoCobranca + NumeroCobranca +
                   ComplementoCobranca + CEPCobranca + BairroCobranca + CodIBGECobranca;
        }
    }

}

