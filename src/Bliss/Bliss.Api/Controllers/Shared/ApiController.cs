using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bliss.Api.Controllers.Shared
{
    public class ApiController : Controller
    {
        protected IActionResult ResponseOk(object obj)
        {
            var resultApi = new JsonResult(obj);
            resultApi.StatusCode = (int)HttpStatusCode.OK;

            return resultApi;
        }
    }
}
