using Bliss.Business.Dtos;
using Bliss.Business.Interfaces.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bliss.Api.Controllers.Shared
{
    [AllowAnonymous]
    [Route("health")]
    public class HealthController : ApiController
    {
        public HealthController(INotifier notifier) : base(notifier)
        {   }

        [HttpGet]
        public IActionResult Index() => 
            ResponseOk(new HealthDto());
    }
}