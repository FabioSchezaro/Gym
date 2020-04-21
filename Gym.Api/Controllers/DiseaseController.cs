using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gym.Api.Controllers
{
    [Route("Disease")]
    public class DiseaseController : BaseController
    {
        private readonly IDiseaseService _diseaseService;

        public DiseaseController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Insert(DiseaseEntity disease)
        {
            var insert = await _diseaseService.Insert(disease);

            if (insert)
                return Ok(new { message = "Doença salva com sucesso." });

            return BadRequest(new { message = "Erro ao salvar esta doença." });
        }

        [HttpPut]
        public async Task<ActionResult<dynamic>> Update(DiseaseEntity disease)
        {
            var update = await _diseaseService.Update(disease);

            if (update)
                return Ok(new { message = "Doença atualizada com sucesso." });

            return BadRequest(new { message = "Erro ao atualizar esta doença." });
        }

        [HttpDelete]
        public async Task<ActionResult<dynamic>> Delete(DiseaseEntity disease)
        {
            var delete = await _diseaseService.Delete(disease);

            if (delete)
                return Ok(new { message = "Doença deletada com sucesso." });

            return BadRequest(new { message = "Erro ao deletar esta doença." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(Guid id)
        {
            var disease = await _diseaseService.GetById(id);

            if (disease != null)
                return Ok(disease);

            return BadRequest(new { message = "Doença não encontrada." });
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var diseases = await _diseaseService.GetAll();

            if (diseases != null)
                return Ok(diseases);

            return BadRequest(new { message = "Nenhuma doença encontrada." });
        }
    }
}