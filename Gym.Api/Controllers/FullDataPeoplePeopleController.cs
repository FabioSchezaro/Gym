using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gym.Api.Controllers
{
    [Route("FullDataPeople")]
    [ApiController]
    public class FullDataPeoplePeopleController : BaseController
    {
        private readonly IFullDataPeopleService _fullDataPeopleService;
        public FullDataPeoplePeopleController(IFullDataPeopleService fullDataPeopleService)
        {
            _fullDataPeopleService = fullDataPeopleService;
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var users = await _fullDataPeopleService.GetAll();

            if (users != null)
                return Ok(users);

            return BadRequest(new { message = "Não há pessoas para mostrar." });
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(Guid id)
        {
            var user = await _fullDataPeopleService.GetById(id);

            if (user != null)
                return Ok(user);

            return BadRequest(new { message = "Não há pessoas para mostrar." });
        }
        [HttpPost]
        public async Task<ActionResult<dynamic>> Insert(FullDataPeopleEntity entity)
        {
            var people = await _fullDataPeopleService.Insert(entity);

            if (people != null)
                return Ok(people);

            return BadRequest(new { message = "Erro ao salvar." });
        }
    }
}