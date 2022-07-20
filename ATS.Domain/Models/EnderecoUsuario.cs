using System;
using System.ComponentModel.DataAnnotations;


namespace ATS.Domain.Models
{
    public class EnderecoUsuario : BaseEntity
    {

        [Required(ErrorMessage = "ID do Usuario � obrigat�rio!")]
        public int idUsuario { get;  set; }

        [Required(ErrorMessage = "Endere�o do Usuario � obrigat�rio!")]
        [MaxLength(200)]
        public string Logradouro{ get;  set; }

        [Required(ErrorMessage = "N�mero do Endereco � obrigat�rio!")]
        [MaxLength(10)]
        public string Numero { get; set; }

        [MaxLength(50)]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Bairro � obrigat�rio!")]
        [MaxLength(100)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo Cidade � obrigat�rio!")]
        [MaxLength(100)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo Estado � obrigat�rio!")]
        [MaxLength(50)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O CEP � obrigat�rio!")]
        [MaxLength(10)]
        public string CEP { get; set; }







    }
}