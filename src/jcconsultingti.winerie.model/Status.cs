using System;
using System.ComponentModel.DataAnnotations;

namespace jcconsultingti.winerie.model
{
    public class Status
    {
        [Display(Name = "Cód.")]
        public long id { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Nome do status é obrigatório")]
        public string nomeStatus { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    }
}
