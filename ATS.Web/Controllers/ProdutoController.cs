using System.Collections.Generic;
using System.Linq;
using ATS.Domain.Interfaces;
using ATS.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace ATS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IRepository<Produto> _objRepository;


        public ProdutoController(IRepository<Produto> oRepository)
        {
            _objRepository = oRepository;

        }

        [HttpGet("GetProdutos")]
        public IEnumerable<Produto> GetProdutos()
        {
            try
            {
                var lista = _objRepository.GetAll();

                return lista;
            }
            catch (Exception ex)
            {

                return null;
            }

        }



        [HttpPost("Save")]
        public IActionResult Save([FromBody] Produto entity)
        {
            throw new NotImplementedException();

        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Produto entity)
        {
            throw new NotImplementedException();


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();

        }
    }
}