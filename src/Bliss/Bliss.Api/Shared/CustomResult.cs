using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bliss.Api.Shared
{
    public class CustomResult : JsonResult
    {
        public CustomResult(HttpStatusCode statusCode, object data) : base(data) =>
            StatusCode = (int)statusCode;

        public CustomResult(HttpStatusCode statusCode) : base(null) =>
            StatusCode = (int)statusCode;
    }
}
