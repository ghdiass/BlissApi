using Bliss.Api.Shared;
using Bliss.Business.Interfaces.Notification;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Bliss.Api.Controllers.Shared
{
    public class ApiController : Controller
    {
        private readonly INotifier _notifier;

        public ApiController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected IActionResult ResponseOk(object data) =>
             new CustomResult(HttpStatusCode.OK, data);
       
        protected IActionResult ResponseCreated(object data)
        {
            if (_notifier.HasNotification())
            {
                var errors = new List<string>();

                errors.AddRange(_notifier.Get().Select(n => n.Message));
                
                return new CustomResult(HttpStatusCode.BadRequest, new
                {
                    success = false,
                    errors = errors
                });
            }

            return new CustomResult(HttpStatusCode.Created, data);
        }
    }
}