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
    public class EnderecoUsuarioController : ControllerBase
    {
        private readonly IRepository<EnderecoUsuario> _objRepository;

        public EnderecoUsuarioController(IRepository<EnderecoUsuario> oRepository)
        {
            _objRepository = oRepository;
        }

        [HttpGet]
        public IEnumerable<EnderecoUsuario> GetEnderecos()
        {
            var lista = _objRepository.GetAll();

            return lista;
        }


        [HttpGet("{id}")]
        public ActionResult<EnderecoUsuario> GetByID(int id)
        {
            var entity = _objRepository.GetById(id);

            if (entity == null)
            {
                return NotFound(new { message = $"Endereco de id={id} não encontrado" });
            }
            return entity;
        }



        [HttpPost]
        public IActionResult Save([FromBody] EnderecoUsuario entity)
        {
            if (entity == null)
                return NotFound();
            try
            {
                _objRepository.Save(entity);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

        [HttpPut]
        public IActionResult Update([FromBody] EnderecoUsuario entity)
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