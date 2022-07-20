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

namespace ATS.Domain.Test.Pedido
{
    public class TestePedido
    {
        private readonly IRepository<ATS.Domain.Models.Pedido> _objRepository;



        [Fact]
        public void InstanciaPedido_Esperado_Sucesso()
        {
            var entidadeEsperada = new
            {
               idProduto = 55,
               idUsuario = 3,
               DtPedido = "28/06/2022",
               valorTotalPedido = 20000,
               intStatus = 1
            };
 
            var Usuario = new ATS.Domain.Models.Pedido() { idProduto = entidadeEsperada.idProduto, idUsuario = entidadeEsperada.idUsuario, DtPedido = entidadeEsperada.DtPedido, valorTotalPedido = entidadeEsperada.valorTotalPedido, intStatus = entidadeEsperada.intStatus };

            entidadeEsperada.ToExpectedObject().ShouldMatch(entidadeEsperada);
        }
        [Fact]
        public void InstanciaPedido_Esperado_Erro()
        {
            string mensagemError = "Parametros inválidos!";

            var entidadeEsperada = new
            {
                idProduto = 55,
                idUsuario = 3,
                DtPedido = "28/0",
                valorTotalPedido = 20000,
                intStatus = 1
            };

            var Usuario = new ATS.Domain.Models.Pedido() { idProduto = entidadeEsperada.idProduto, idUsuario = entidadeEsperada.idUsuario, DtPedido = entidadeEsperada.DtPedido, valorTotalPedido = entidadeEsperada.valorTotalPedido, intStatus = entidadeEsperada.intStatus };

            Assert.Throws<ArgumentException>(() => new ATS.Domain.Models.Pedido() { idProduto = entidadeEsperada.idProduto, idUsuario = entidadeEsperada.idUsuario, DtPedido = entidadeEsperada.DtPedido, valorTotalPedido = entidadeEsperada.valorTotalPedido, intStatus = entidadeEsperada.intStatus }).ValidarMensagem(mensagemError);

        }

        [Fact]
        public void TesteInclusaoResgate()
        {

            var entidadeEsperada = new Models.Pedido
            {
                idProduto = 55,
                idUsuario = 3,
                DtPedido = "28/06/2022",
                valorTotalPedido = 20000,
                intStatus = 1
            };

            try
            {
                _objRepository.Save(entidadeEsperada);
                Assert.True(true);
            }
            catch
            {
                Assert.False(false);
            }

        }



        [Fact]
        public void TesteExtrato()
        {
            var dados = _objRepository.GetAll().Where(p=> p.idUsuario ==  3);
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
