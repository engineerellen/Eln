using System;
using System.ComponentModel.DataAnnotations;
using ATS.Domain.Validator;
using ATS.Domain.Enum;

namespace ATS.Domain.Models
{
    public class Produto : BaseEntity
    {

        [MaxLength(200)]
        [Required(ErrorMessage = "Descricao do Produto é obrigatório!")]
        public string Descricao { get;  set; }

       
        [MaxLength(500)]
        public string Detalhes { get; set; }

        [Required(ErrorMessage = "A data de inclusão é obrigatória!")]
        [MaxLength(10)]
        [DataValidator(ErrorMessage ="Data inválida!")]
        public string DtInclusao { get; set; }

        [Required(ErrorMessage = "O valor em pontos do produto obrigatório!")]
        public int valorPonto { get; set; }

        [Required(ErrorMessage = "O status do produto obrigatório!")]
        public int intStatus { get; set; }

        public StatusProduto Status { get; }

    }
}