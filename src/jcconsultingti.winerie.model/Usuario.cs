using System;
using System.ComponentModel.DataAnnotations;

namespace jcconsultingti.winerie.model
{
    public class Usuario
    {
        [Display(Name = "Cód.")]
        public long id { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Nome do usuário é obrigatório")]
        public string nome { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login do usuário é obrigatório")]
        public string login { get; set; }

        [Display(Name = "Senha")]
        //[Required(ErrorMessage = "Senha do usuário é obrigatório")]
        public string senha { get; set; }

        [Display(Name = "Último login")]
        public DateTime? dataUltimoLogin { get; set; }

        [Display(Name = "Perfil")]
        [Required(ErrorMessage = "Perfil do usuário é obrigatório")]
        public long idPerfilUsuario { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status do usuário é obrigatório")]
        public bool isAtivo { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Favor, informar um email válido")]
        public string email { get; set; }

        #region relacionamentos

        public PerfilUsuario perfilUsuario { get; set; }

        #endregion

        #region Auxiliares

        public DateTime? dataUltimoLoginFeito { get; set; }

        #endregion
    }
}
