using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gym.Api.Controllers
{
    [Route("user")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IPeopleService _peopleService;
        public UserController(IUserService userService, IPeopleService peopleService)
        {
            _userService = userService;
            _peopleService = peopleService;
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var users = await _userService.GetAll();

            if (users != null)
                return Ok(users);

            return BadRequest(new { message = "Não há usuários para mostrar" });
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetBtId(Guid id)
        {
            var user = await _userService.GetById(id);

            if (user != null)
                return Ok(user);

            return BadRequest(new { message = "Usuário não encontrado, verifique os dados de sua busca." });
        }
        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(UserEntity entity)
        {
            var user = await _userService.Authenticate(entity);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = Token.Service.TokenService.GenerateToken(user);
            user.Password = "";
            var people = await _peopleService.GetById(user.IdPeople);

            return Ok(new { user, Token = token, People = people });
        }
    }
}