using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gym.Api.Controllers
{
    [Route("Telephone")]
    public class TelephoneController : BaseController
    {
        private readonly ITelephoneService _telephoneService;

        public TelephoneController(ITelephoneService telephoneService)
        {
            _telephoneService = telephoneService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Insert(TelephoneEntity telephone)
        {
            var insert = await _telephoneService.Insert(telephone);

            if (insert)
                return Ok(new { message = "Telefone salvo com sucesso." });

            return BadRequest(new { message = "Erro ao salvar o telefone." });
        }

        [HttpPut]
        public async Task<ActionResult<dynamic>> Update(TelephoneEntity telephone)
        {
            var update = await _telephoneService.Update(telephone);

            if (update)
                return Ok(new { message = "Telefone atualizado com sucesso." });

            return BadRequest(new { message = "Erro ao atualizar o telefone." });
        }

        [HttpDelete]
        public async Task<ActionResult<dynamic>> Delete(TelephoneEntity telephone)
        {
            var delete = await _telephoneService.Delete(telephone);

            if (delete)
                return Ok(new { message = "Telefone deletado com sucesso." });

            return BadRequest(new { message = "Erro ao deletar o telefone." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(Guid id)
        {
            var telephone = await _telephoneService.GetById(id);

            if (telephone != null)
                return Ok(telephone);

            return BadRequest(new { message = "Telefone não encontrado." });
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var telephones = await _telephoneService.GetAll();

            if (telephones != null)
                return Ok(telephones);

            return BadRequest(new { message = "Nenhum telefone encontrado." });
        }
    }
}