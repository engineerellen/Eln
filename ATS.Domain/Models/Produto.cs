using System;
using System.ComponentModel.DataAnnotations;
using ATS.Domain.Validator;
using ATS.Domain.Enum;

namespace ATS.Domain.Models
{
    public class Produto : BaseEntity
    {

        [MaxLength(200)]
        [Required(ErrorMessage = "Descricao do Produto � obrigat�rio!")]
        public string Descricao { get;  set; }

       
        [MaxLength(500)]
        public string Detalhes { get; set; }

        [Required(ErrorMessage = "A data de inclus�o � obrigat�ria!")]
        [MaxLength(10)]
        [DataValidator(ErrorMessage ="Data inv�lida!")]
        public string DtInclusao { get; set; }

        [Required(ErrorMessage = "O valor em pontos do produto obrigat�rio!")]
        public int valorPonto { get; set; }

        [Required(ErrorMessage = "O status do produto obrigat�rio!")]
        public int intStatus { get; set; }

        public StatusProduto Status { get; }

    }
}