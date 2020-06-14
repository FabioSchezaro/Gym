using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IServices;
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
        public async Task<ActionResult<dynamic>> Insert(FullDataPeopleEntity fullDataPeopleEntity)
        {
            var insert = await _fullDataPeopleService.InsertAsync(fullDataPeopleEntity);

            if (insert)
                return Ok(new { message = "Salvo com sucesso." });

            return BadRequest(new { message = "Erro ao salvar." });
        }

        [HttpPut]
        public async Task<ActionResult<dynamic>> Update(FullDataPeopleEntity fullDataPeopleEntity)
        {
            var update = await _fullDataPeopleService.UpdateAsync(fullDataPeopleEntity);

            if (update)
                return Ok(new { message = "Dados atualizados com sucesso" });

            return BadRequest(new { message = "Erro ao atualizar dados." });
        }

        [HttpDelete]
        public async Task<ActionResult<dynamic>> Delete([FromHeader] PeopleEntity people)
        {
            var delete = await _fullDataPeopleService.DeleteAsync(people);

            if (delete)
                return Ok(new { message = "Dados apagados com sucesso" });

            return BadRequest(new { message = "Erro ao apagar dados." });
        }
    }
}