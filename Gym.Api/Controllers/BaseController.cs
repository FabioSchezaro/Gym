using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
    }
}