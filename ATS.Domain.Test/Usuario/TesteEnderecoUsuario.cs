using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ExpectedObjects;
using ATS.Domain;
using ATS.Domain.Test.Util;
using ATS.Domain.Interfaces;

namespace ATS.Domain.Test.Usuario
{
    public class TesteEnderecoUsuario
    {
        private readonly IRepository<ATS.Domain.Models.EnderecoUsuario> _objRepository;

        [Fact]
        public void InstanciaEndereco_Esperado_Sucesso()
        {
            var EnderecoEsperado = new
            {
              idUsuario = 1,
              Logradouro = "Rua lalala",
              Numero = "20",
              Complemento = "casa 2",
              Bairro = "Centro",
              Cidade = "Sao Paulo",
              Estado = "SP",
              CEP = "09888-010"

            };
 
            var entity = new ATS.Domain.Models.EnderecoUsuario() { idUsuario = EnderecoEsperado.idUsuario
                                                                  ,Logradouro = EnderecoEsperado.Logradouro
                                                                  ,Numero = EnderecoEsperado.Numero
                                                                  ,Complemento = EnderecoEsperado.Complemento
                                                                  ,Bairro = EnderecoEsperado.Bairro
                                                                  ,Cidade = EnderecoEsperado.Cidade
                                                                  ,Estado = EnderecoEsperado.Estado
                                                                  ,CEP = EnderecoEsperado.CEP
                 
            };

            EnderecoEsperado.ToExpectedObject().ShouldMatch(entity);
        }
        [Fact]
        public void InstanciaEndereco_Esperado_Erro()
        {
            string mensagemError = "Campo obrigatorio!";

            var EnderecoEsperado = new
            {
                idUsuario = 1,
                Complemento = "casa 2",
                Bairro = "Centro",
                Cidade = "Sao Paulo",
                Estado = "SP",
                CEP = "09888-010"

            };

            var Usuario = new ATS.Domain.Models.EnderecoUsuario() {
                                                    idUsuario = EnderecoEsperado.idUsuario,
                                                    Complemento = EnderecoEsperado.Complemento,
                                                    Bairro = EnderecoEsperado.Bairro,
                                                    Cidade = EnderecoEsperado.Cidade,
                                                    Estado = EnderecoEsperado.Estado,
                                                    CEP = EnderecoEsperado.CEP
            };

            Assert.Throws<ArgumentException>(() => new ATS.Domain.Models.EnderecoUsuario() {
                                                                                        idUsuario = EnderecoEsperado.idUsuario,
                                                                                        Complemento = EnderecoEsperado.Complemento,
                                                                                        Bairro = EnderecoEsperado.Bairro,
                                                                                        Cidade = EnderecoEsperado.Cidade,
                                                                                        Estado = EnderecoEsperado.Estado,
                                                                                        CEP = EnderecoEsperado.CEP
            }).ValidarMensagem(mensagemError);

        }

        [Fact]
        public void TesteInclusao( )
        {

            var entityTeste = new Models.EnderecoUsuario
            {
                idUsuario = 1,
                Logradouro = "Rua lalala",
                Numero = "20",
                Complemento = "casa 2",
                Bairro = "Centro",
                Cidade = "Sao Paulo",
                Estado = "SP",
                CEP = "09888-010"
            };

            try
            {
                _objRepository.Save(entityTeste);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }

        }
        [Fact]
        public void TesteListagem()
        {
            var dados = _objRepository.GetAll();
            Assert.True(dados.Count() > 0);
        }

        [Fact]
        public void TesteGetById()
        {
            var dados = _objRepository.GetById(1);
            Assert.True(dados is not null);
        }

    }
}
