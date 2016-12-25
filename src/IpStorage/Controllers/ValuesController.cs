using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Features;

namespace IpStorage.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            var isLocal = remoteIpAddress.ToString() == "::1";
            var path = Request.Path.ToString();
            var userAgent = Request.HttpContext.GetHeaderValueAs<string>("User-Agent");
            var browserName = Utils.GetBrowserName(userAgent);

           // IHttpConnectionFeature webConnection = HttpContext.Features.Get<IHttpConnectionFeature>();

            return isLocal ? "127.0.0.1" : remoteIpAddress.ToString();
        }
    }
}
