using System;
using System.ComponentModel.DataAnnotations;
using ATS.Domain.Validator;
using ATS.Domain.Enum;

namespace ATS.Domain.Models
{
    public class Pedido : BaseEntity
    {
        [Required(ErrorMessage = "ID do Produto é obrigatório!")]
        public int idProduto { get;  set; }

        [Required(ErrorMessage = "ID do Produto é obrigatórià!")]
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "A data do pedido é obrigatória!")]
        [MaxLength(10)]
        [DataValidator(ErrorMessage ="Data inválida!")]
        public string DtPedido { get; set; }

        [Required(ErrorMessage = "O valor total do pedido obrigatório!")]
        public int valorTotalPedido { get; set; }

        [Required(ErrorMessage = "O status do pedido obrigatório!")]
        public int intStatus { get; set; }

        public StatusPedido Status { get; }

    }
}