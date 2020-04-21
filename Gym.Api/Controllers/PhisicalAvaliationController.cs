using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gym.Api.Controllers
{
    [Route("PhisicalAvaliation")]
    public class PhisicalAvaliationController : BaseController
    {
        private readonly IPhisicalAvaliationService _phisicalAvaliationService;
        public PhisicalAvaliationController(IPhisicalAvaliationService phisicalAvaliationService)
        {
            _phisicalAvaliationService = phisicalAvaliationService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Insert(PhisicalAvaliationEntity phisicalAvaliation)
        {
            var insert = await _phisicalAvaliationService.Insert(phisicalAvaliation);

            if (insert)
                return Ok(new { message = "Avaliação física salva com sucesso." });

            return BadRequest(new { message = "Erro ao salvar avaliação física." });
        }

        [HttpPut]
        public async Task<ActionResult<dynamic>> Update(PhisicalAvaliationEntity phisicalAvaliation)
        {
            var update = await _phisicalAvaliationService.Update(phisicalAvaliation);

            if (update)
                return Ok(new { message = "Avaliação física atualizada com sucesso." });

            return BadRequest(new { message = "Erro ao atualizar avaliação física." });
        }

        [HttpDelete]
        public async Task<ActionResult<dynamic>> Delete(PhisicalAvaliationEntity phisicalAvaliation)
        {
            var delete = await _phisicalAvaliationService.Delete(phisicalAvaliation);

            if (delete)
                return Ok(new { message = "Avaliação física deletada com sucesso." });

            return BadRequest(new { message = "Erro ao deletar avaliação física." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(Guid id)
        {
            var phisicalAvaliation = await _phisicalAvaliationService.GetById(id);

            if (phisicalAvaliation != null)
                return Ok(phisicalAvaliation);

            return BadRequest(new { message = "Avaliação física não encontrada." });
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var phisicalAvaliations = await _phisicalAvaliationService.GetAll();

            if (phisicalAvaliations != null)
                return Ok(phisicalAvaliations);

            return BadRequest(new { message = "Nenhum avaliação física encontrada." });
        }
    }
}