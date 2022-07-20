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

namespace ATS.Domain.Test.Produto
{
    public class TesteProduto
    {
        private readonly IRepository<ATS.Domain.Models.Produto> _objRepository;

     

       [Fact]
        public void InstanciaProduto_Esperado_Sucesso()
        {
            var entidadeEsperada = new
            {
               Descricao="Celular Samsung"
               ,Detalhe = "Celular de ultima geração galaxy S22 com x polegadas"
               ,DtInclusao = "03/03/2021"
               ,valorPonto=30000
               ,intStatus = 1
            };
 
            var Usuario = new ATS.Domain.Models.Produto() { Descricao = entidadeEsperada.Descricao, Detalhes = entidadeEsperada.Descricao, DtInclusao = entidadeEsperada.DtInclusao, valorPonto = entidadeEsperada.valorPonto, intStatus = entidadeEsperada.intStatus };

            entidadeEsperada.ToExpectedObject().ShouldMatch(entidadeEsperada);
        }
        [Fact]
        public void InstanciaProduto_Esperado_Erro()
        {
            string mensagemError = "Parametros inválidos!";

            var entidadeEsperada = new
            {
                Descricao = "Celular Samsung"
               , Detalhe = "Celular de ultima geração galaxy S22 com x polegadas"
               , DtInclusao = "03/"
               ,valorPonto = 30000
               ,intStatus = 1
            };

            var Usuario = new ATS.Domain.Models.Produto() { Descricao = entidadeEsperada.Descricao, Detalhes = entidadeEsperada.Descricao, DtInclusao = entidadeEsperada.DtInclusao, valorPonto = entidadeEsperada.valorPonto, intStatus = entidadeEsperada.intStatus };

            Assert.Throws<ArgumentException>(() => new ATS.Domain.Models.Produto() { Descricao = entidadeEsperada.Descricao, Detalhes = entidadeEsperada.Descricao, DtInclusao = entidadeEsperada.DtInclusao, valorPonto = entidadeEsperada.valorPonto, intStatus = entidadeEsperada.intStatus }).ValidarMensagem(mensagemError);

        }

     

       

        [Fact]
        public void TesteListagem()
        {
            var dados = _objRepository.GetAll().Where(p=> p.intStatus == 1);
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
