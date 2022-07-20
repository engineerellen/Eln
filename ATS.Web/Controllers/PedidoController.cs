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
    public class PedidoController : ControllerBase
    {
        private readonly IRepository<Pedido> _objRepository;

        public PedidoController(IRepository<Pedido> oRepository)
        {
            _objRepository = oRepository;
        }

        [HttpGet("Extrato")]
        public IEnumerable<Pedido> Extrato([FromBody] int idUsuario)
        {
            var lista = _objRepository.GetAll().Where(p=> p.idUsuario == idUsuario && p.intStatus == 5);

            return lista;
        }


        [HttpPost("CriarResgate")]
        public IActionResult CriarResgate([FromBody] Pedido entity)
        {
            if (entity == null)
                return NotFound();
            try
            {
                entity.intStatus = 1;
                _objRepository.Save(entity);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Pedido entity)
        {
            if (entity == null)
                return NotFound();


            try
            {
                _objRepository.Update(entity);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return NotFound();

            try
            {
                _objRepository.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
    }
}