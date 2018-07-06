using System;
using System.ComponentModel.DataAnnotations;

namespace jcconsultingti.winerie.model
{
    public class TipoArquivo
    {
        [Display(Name = "Cód.")]
        public long id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome do tipo de arquivo é obrigatório")]
        public string nomeTipoArquivo { get; set; }

        [Display(Name = "Modelo Nome Arquivo")]
        public string padraoFormatoNomeArquivo { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    }
}
