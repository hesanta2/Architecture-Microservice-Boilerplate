using µService.Infrastructure;
using µService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Web.Http;
using System.Web.Http.Description;

namespace µService.WebApi.Infrastructure.Controllers
{
    [RoutePrefix("")]
    public class µServiceController : ApiController
    {
        [Route("")]
        [HttpGet]
        public int HeartBeat()
        {
            return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

    }
}
