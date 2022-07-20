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
    public class TesteUsuario
    {
        private readonly IRepository<ATS.Domain.Models.Usuario> _objRepository;

        private readonly IService<ATS.Domain.Models.Usuario> _objService;

        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;

       [Fact]
        public void InstanciaUsuario_Esperado_Sucesso()
        {
            var UsuarioEsperado = new
            {
                Email = "joao@joao.com",
                PWD = "12345678",
                Nome = "João da Silva",
                DtNascimento = "10/08/1998",
                pontos = 1000
            };
 
            var Usuario = new ATS.Domain.Models.Usuario() { Email = UsuarioEsperado.Email, PWD = UsuarioEsperado.PWD, Nome = UsuarioEsperado.Nome, DtNascimento = UsuarioEsperado.DtNascimento, pontos = UsuarioEsperado.pontos };

            UsuarioEsperado.ToExpectedObject().ShouldMatch(Usuario);
        }
        [Fact]
        public void InstanciaUsuario_Esperado_Erro()
        {
            string mensagemError = "Parametros inválidos!";

            var UsuarioEsperado = new
            {
                Email = "joao",
                PWD = "12345678",
                Nome = "João da Silva",
                DtNascimento = "10/",
                pontos = 1000
            };

            var Usuario = new ATS.Domain.Models.Usuario() { Email = UsuarioEsperado.Email, PWD = UsuarioEsperado.PWD, Nome = UsuarioEsperado.Nome, DtNascimento = UsuarioEsperado.DtNascimento , pontos = UsuarioEsperado.pontos };

            Assert.Throws<ArgumentException>(() => new ATS.Domain.Models.Usuario() { Email = UsuarioEsperado.Email, PWD = UsuarioEsperado.PWD, Nome = UsuarioEsperado.Nome, DtNascimento = UsuarioEsperado.DtNascimento, pontos = UsuarioEsperado.pontos }).ValidarMensagem(mensagemError);

        }

        [Fact]
        public void TesteInclusao( )
        {

            var usuarioTeste = new Models.Usuario
            {
                Email = "joao@joao.com",
                PWD = "12345678",
                Nome = "João da Silva",
                DtNascimento = "10/08/1998",
                pontos = 1000
            };

            try
            {
                _objRepository.Save(usuarioTeste);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }

        }

        [Fact]
        public void TesteToken()
        {

            var usuarioTeste = new Models.Usuario
          {
              Email= "ellenengineer@gmail.com",
              PWD= "12345678",
              Nome= "Ellen",
              DtNascimento= "28/01/1986",
              pontos = 1000
            };

            try
            {
                _objService.GerarTokenJWT(usuarioTeste.Email, _config["Jwt:Issuer"], _config["Jwt:Key"], _config["Jwt:Audience"]);
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
