using System;
using System.ComponentModel.DataAnnotations;
using ATS.Domain.Validator;

namespace ATS.Domain.Models
{
    public class Usuario : BaseEntity
    {


        [Required(ErrorMessage = "Email do Usuario � obrigat�rio!")]
        [MaxLength(100)]
        [EmailValidator(ErrorMessage = "Email inv�lido!")]
        public string Email { get;  set; }

        [Required(ErrorMessage = "A senha � obrigat�ria!")]
        [MinLength(8,ErrorMessage ="A senha deve ter pelo menos 8 caracteres")]
        [MaxLength(20)]
        public string PWD { get; set; }


        [Required(ErrorMessage = "Nome do Usuario � obrigat�rio!")]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A data de nascimento � obrigat�ria!")]
        [MaxLength(10)]
        [DataValidator(ErrorMessage ="Data inv�lida!")]
        public string DtNascimento { get; set; }

        public int pontos { get; set; }

    }
}