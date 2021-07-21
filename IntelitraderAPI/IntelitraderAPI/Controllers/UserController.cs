using IntelitraderAPI.Domains;
using IntelitraderAPI.Interfaces;
using IntelitraderAPI.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace IntelitraderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            _userRepository = new UserRepository();
        }
        public string Message { get; set; }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation($"Pesquisa de usuários realizada! {DateTime.UtcNow.ToLongTimeString()}");
            try
            {
                var users = _userRepository.Listar();

                if (users.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = users.Count,
                    data = users
                });
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Houve um erro: {ex.Message}. {DateTime.UtcNow.ToLongTimeString()}");
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/users!"
                });
            }
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            try
            {
                _userRepository.Adicionar(user);

                //  implementar generic result
                //  return Ok('Usuário registrado com sucesso!', user);

                _logger.LogInformation($"Novo Usuário criado! {DateTime.UtcNow.ToLongTimeString()}");
                return Ok(user);
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation($"Houve um erro: {ex.Message}. {DateTime.UtcNow.ToLongTimeString()}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, User user)
        {
            try
            {
                _userRepository.Editar(id, user);

                _logger.LogInformation($"O cadastro do usuário {id} foi alterado! {DateTime.UtcNow.ToLongTimeString()}");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Houve um erro: {ex.Message}. {DateTime.UtcNow.ToLongTimeString()}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _userRepository.Remover(id);

                _logger.LogInformation($"O usuário {id} foi removido do sistema! {DateTime.UtcNow.ToLongTimeString()}");
                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Houve um erro: {ex.Message}. {DateTime.UtcNow.ToLongTimeString()}");
                return BadRequest(ex.Message);
            }
        }

    }
}
