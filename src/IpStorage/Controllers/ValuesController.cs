using IpStorage.DAL;
using IpStorage.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IpStorage.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<string> Get()
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            var isLocal = remoteIpAddress.ToString() == "::1";
            var path = Request.Path.ToString();
            var userAgent = Request.HttpContext.GetHeaderValueAs<string>("User-Agent");
            var browserName = Utils.GetBrowserName(userAgent);
            string referer = Request.Headers["Referer"].ToString();

            // IHttpConnectionFeature webConnection = HttpContext.Features.Get<IHttpConnectionFeature>();

            var model = new Visitors { Ip = isLocal ? "127.0.0.1" : remoteIpAddress.ToString(), UserAgent = userAgent, Browser = browserName, ReffererUrl = referer };
            try
            {
                var connection = "data source=184.168.47.19;initial catalog=video_tds;user id=misterbaron;password=letsmakeSome$!;MultipleActiveResultSets=True;App=EntityFramework";
                var visitorsRepository = new VisitorsRepository(new video_tdsContext(connection));

                visitorsRepository.Add(model);
                model.Id = await visitorsRepository.CommitAsync();
            }
            catch (Exception)
            {
            }

            return model.Ip;
        }
    }
}
