using Gym.Domain.Entities;
using Gym.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gym.Api.Controllers
{
    [Route("DueDay")]
    public class DueDayController : BaseController
    {
        private readonly IDueDayService _dueDayService;
        public DueDayController(IDueDayService dueDayService)
        {
            _dueDayService = dueDayService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Insert(DueDayEntity dueDay)
        {
            var insert = await _dueDayService.Insert(dueDay);

            if (insert)
                return Ok(new { message = "Data de vencimento salva com sucesso." });

            return BadRequest(new { message = "Erro ao salvar a data de vencimento." });
        }

        [HttpPut]
        public async Task<ActionResult<dynamic>> Update(DueDayEntity dueDay)
        {
            var update = await _dueDayService.Update(dueDay);

            if (update)
                return Ok(new { message = "Data de vencimento atualizada com sucesso." });

            return BadRequest(new { message = "Erro ao atualizar a data de vencimento." });
        }

        [HttpDelete]
        public async Task<ActionResult<dynamic>> Delete(DueDayEntity dueDay)
        {
            var delete = await _dueDayService.Delete(dueDay);

            if (delete)
                return Ok(new { message = "Data de vencimento deletada com sucesso." });

            return BadRequest(new { message = "Erro ao deletar o data de vencimento." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(Guid id)
        {
            var dueDay = await _dueDayService.GetById(id);

            if (dueDay != null)
                return Ok(dueDay);

            return BadRequest(new { message = "Telefone não encontrado." });
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var dueDays = await _dueDayService.GetAll();

            if (dueDays != null)
                return Ok(dueDays);

            return BadRequest(new { message = "Nenhuma data de vencimento encontrada." });
        }
    }
}