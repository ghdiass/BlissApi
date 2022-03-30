using Bliss.Business.Dtos;
using Bliss.Business.Interfaces.Notification;
using Bliss.Business.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bliss.Api.Controllers.Shared
{
    [AllowAnonymous]
    [Route("share")]
    public class ShareController : ApiController
    {
        private readonly IShareScreenService _shareScreenService;

        public ShareController(IShareScreenService shareScreenService,
                                   INotifier notifier) : base(notifier)
        {
            _shareScreenService = shareScreenService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string destination_email, string content_url)
        {
            try
            {
                await _shareScreenService.Share(new ShareScreenDto(destination_email, content_url));
                return ResponseOk(new HealthDto());
            }
            catch (Exception e)
            {
                return ResponseInternalServerError(e);
            }
        }
    }
}