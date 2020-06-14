using Gym.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gym.Api.Controllers
{
    [Route("Role")]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            var roles = await _roleService.GetAll();

            if (roles != null)
                return Ok(roles);

            return BadRequest(new { message = "Nenhum telefone encontrado." });
        }
    }
}