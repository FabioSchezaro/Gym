using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Api.Controllers
{
    [Route("Plan")]
    public class PlanController : BaseController
    {
        private readonly IPlanService _planService;
        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Insert(PlanEntity plan)
        {
            var insert = await _planService.Insert(plan);

            if (insert)
                return Ok(new { message = "Plano salvo com sucesso." });

            return BadRequest(new { message = "Erro ao salvar plano." });
        }

        [HttpPut]
        public async Task<ActionResult<dynamic>> Update(PlanEntity plan)
        {
            var update = await _planService.Update(plan);

            if (update)
                return Ok(new { message = "Plano atualizado com sucesso." });

            return BadRequest(new { message = "Erro ao atualizar plano." });
        }

        [HttpDelete]
        public async Task<ActionResult<dynamic>> Delete([FromHeader] PlanEntity plan)
        {
            var delete = await _planService.Delete(plan);

            if (delete)
                return Ok(new { message = "Plano deletado com sucesso." });

            return BadRequest(new { message = "Erro ao deletar plano." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(Guid id)
        {
            var plan = await _planService.GetById(id);

            if (plan != null)
                return Ok(plan);

            return BadRequest(new { message = "Plano não encontrado." });
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var plans = await _planService.GetAll();

            if (plans != null)
                return Ok(plans.OrderBy(d => d.Description));

            return BadRequest(new { message = "Nenhum plano encontrado." });
        }
    }
}