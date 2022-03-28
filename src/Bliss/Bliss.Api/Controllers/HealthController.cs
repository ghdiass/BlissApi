using Bliss.Business.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bliss.Api.Controllers.Shared
{
    [AllowAnonymous]
    [Route("health")]
    public class HealthController : ApiController
    {
        [HttpGet]
        public IActionResult Index() => 
            ResponseOk(new HealthDto());
    }
}