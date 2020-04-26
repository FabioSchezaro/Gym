using Gym.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gym.Api.Controllers
{
    [Route("People")]
    public class PeopleController : BaseController
    {
        private readonly IPeopleService _peopleService;
        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetById(Guid id)
        {
            var user = await _peopleService.GetById(id);

            if (user != null)
                return Ok(user);

            return BadRequest(new { message = "Não há pessoas para mostrar." });
        }
    }
}