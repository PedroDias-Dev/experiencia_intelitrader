using IntelitraderAPI.Domains;
using IntelitraderAPI.Interfaces;
using IntelitraderAPI.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace IntelitraderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            try
            {
                _userRepository.Adicionar(user);

                //  implementar generic result
                //  return Ok('Usuário registrado com sucesso!', user);

                return Ok(user);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
