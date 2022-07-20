using System;
using System.ComponentModel.DataAnnotations;
using ATS.Domain.Validator;
using ATS.Domain.Enum;

namespace ATS.Domain.Models
{
    public class Pedido : BaseEntity
    {
        [Required(ErrorMessage = "ID do Produto � obrigat�rio!")]
        public int idProduto { get;  set; }

        [Required(ErrorMessage = "ID do Produto � obrigat�ri�!")]
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "A data do pedido � obrigat�ria!")]
        [MaxLength(10)]
        [DataValidator(ErrorMessage ="Data inv�lida!")]
        public string DtPedido { get; set; }

        [Required(ErrorMessage = "O valor total do pedido obrigat�rio!")]
        public int valorTotalPedido { get; set; }

        [Required(ErrorMessage = "O status do pedido obrigat�rio!")]
        public int intStatus { get; set; }

        public StatusPedido Status { get; }

    }
}