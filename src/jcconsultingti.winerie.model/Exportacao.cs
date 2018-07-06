using System;
using System.ComponentModel.DataAnnotations;

namespace jcconsultingti.winerie.model
{
    public class Exportacao
    {
        [Display(Name = "Cód.")]
        public long id { get; set; }

        [Required(ErrorMessage = "Tipo do arquivo exportação é obrigatório")]
        public long idTipoArquivo { get; set; }

        [Required(ErrorMessage = "Usuário da exportação é obrigatório")]
        public long idUsuarioExportacao { get; set; }

        [Display(Name = "Início")]
        [Required(ErrorMessage = "Data/hora início do processamento da exportação é obrigatório")]
        public DateTime dataInicioProcessamento { get; set; }

        [Display(Name = "Fim")]
        public DateTime? dataFimProcessamento { get; set; }

        [Required(ErrorMessage = "Status da importação é obrigatório")]
        public long idStatus { get; set; }

        [Display(Name = "Sucesso")]
        public int qtdSucesso { get; set; }

        [Display(Name = "Erros")]
        public int qtdIgnorada { get; set; }

        public string nomeArquivoGerado { get; set; }

        public string nomeArquivoErro { get; set; }

        #region relacionamentos

        public TipoArquivo TipoArquivo { get; set; }

        public Usuario usuarioExportacao { get; set; }

        public Status status { get; set; }

        #endregion

        #region Campos Auxiliares

        public string _diretorioPendente { get; set; }

        public string _diretorioProcessado { get; set; }

        public string _diretorioLog { get; set; }

        #endregion
    }
}
