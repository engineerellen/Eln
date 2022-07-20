using System;
using System.ComponentModel.DataAnnotations;


namespace ATS.Domain.Models
{
    public class EnderecoUsuario : BaseEntity
    {

        [Required(ErrorMessage = "ID do Usuario é obrigatório!")]
        public int idUsuario { get;  set; }

        [Required(ErrorMessage = "Endereço do Usuario é obrigatório!")]
        [MaxLength(200)]
        public string Logradouro{ get;  set; }

        [Required(ErrorMessage = "Número do Endereco é obrigatório!")]
        [MaxLength(10)]
        public string Numero { get; set; }

        [MaxLength(50)]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório!")]
        [MaxLength(100)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo Cidade é obrigatório!")]
        [MaxLength(100)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo Estado é obrigatório!")]
        [MaxLength(50)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório!")]
        [MaxLength(10)]
        public string CEP { get; set; }







    }
}