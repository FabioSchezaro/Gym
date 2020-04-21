using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gym.Api.Controllers
{
    [Route("Metrics")]
    public class MetricsController : BaseController
    {
        private readonly IMetricsService _metricsService;
        public MetricsController(IMetricsService metricsService)
        {
            _metricsService = metricsService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Insert(MetricsEntity metrics)
        {
            var insert = await _metricsService.Insert(metrics);

            if (insert)
                return Ok(new { message = "Medidas salvas com sucesso." });

            return BadRequest(new { message = "Erro ao salvar medidas." });
        }

        [HttpPut]
        public async Task<ActionResult<dynamic>> Update(MetricsEntity metrics)
        {
            var update = await _metricsService.Update(metrics);

            if (update)
                return Ok(new { message = "Medidas atualizadas com sucesso." });

            return BadRequest(new { message = "Erro ao atualizar medidas." });
        }

        [HttpDelete]
        public async Task<ActionResult<dynamic>> Delete(MetricsEntity metrics)
        {
            var delete = await _metricsService.Delete(metrics);

            if (delete)
                return Ok(new { message = "Medidas deletadas com sucesso." });

            return BadRequest(new { message = "Erro ao deletar medidas." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(Guid id)
        {
            var metrics = await _metricsService.GetById(id);

            if (metrics != null)
                return Ok(metrics);

            return BadRequest(new { message = "Medidas não encontradas." });
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var metrics = await _metricsService.GetAll();

            if (metrics != null)
                return Ok(metrics);

            return BadRequest(new { message = "Nenhuma medida cadastrada." });
        }
    }
}