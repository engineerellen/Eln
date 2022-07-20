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
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository<Usuario> _objRepository;
        private IConfiguration _config;
        private IService<Usuario> _objService;

        public UsuarioController(IRepository<Usuario> oRepository, IConfiguration oConfig, IService<Usuario> objService)
        {
            _objRepository = oRepository;
            _config = oConfig;
            _objService = objService;
        }

        [HttpGet("GetUsuarios")]
        public IEnumerable<Usuario> GetUsuarios()
        {
            var lista = _objRepository.GetAll();

            return lista;
        }


        [HttpGet("ConsultaSaldo")]
        public int ConsultaSaldo(int idUsuario)
        {
            var usuario = _objRepository.GetById(idUsuario);

            return usuario.pontos;
        }


        [HttpGet("{email}")]
        public ActionResult<Usuario> GetByEmail(string email)
        {
            List<Usuario> list = _objRepository.GetAll().ToList();

            var entity = list.Where(u => u.Email == email).FirstOrDefault();

            if (entity == null)
            {
                return NotFound(new { message = $"Usuario de email={email} não encontrado" });
            }
            return entity;
        }


        [HttpPost("Logar")]
        [System.Web.Http.AllowAnonymous]
        public IActionResult Logar([FromBody] Usuario entity)
        {
            var list = _objRepository.GetAll();

            var usr = list.Where(u => u.Email == entity.Email && u.PWD == entity.PWD).FirstOrDefault();
            if (usr == null)
            {
                return NotFound("Usuário ou senha inválido.");
            }
            else
            {
                try
                {
                    var tokenString = _objService.GerarTokenJWT(usr.Email, _config["Jwt:Issuer"], _config["Jwt:Key"], _config["Jwt:Audience"]);
                    return Ok(new { token = tokenString });
                }
                catch
                {
                    return BadRequest();
                }
            }

        }


        [HttpPost("Save")]
        public IActionResult Save([FromBody] Usuario entity)
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

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Usuario entity)
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


        [HttpPut("ResgateSaldo")]
        public IActionResult ResgateSaldo([FromBody] Usuario entity, int valorTotalPontosResgatados)
        {
            if (entity == null)
                return NotFound();

            try
            {
                int saldo = ConsultaSaldo(entity.Id);

                if (saldo > 0 && saldo > valorTotalPontosResgatados )
                {
                    entity.pontos = saldo - valorTotalPontosResgatados;
                    _objRepository.Update(entity);

                    return Ok();
                }
                else
                {
                    return BadRequest("Saldo insuficiente para resgate!");
                }

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