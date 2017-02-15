using µService.Infrastructure;
using µService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace µService.WebApi.Controllers
{
    [RoutePrefix("Default")]
    public class DefaultController : ApiController
    {
        [Route("")]
        public IEnumerable<Products> Get()
        {
            return UnityOfWork.Context.Products;
        }

        [Route("id")]
        public IEnumerable<Products> Get(int id)
        {
            return UnityOfWork.Context.Products.Where(p => p.Product_ID == id);
        }

        // POST: api/Values
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Values/5
        public void Delete(int id)
        {
        }
    }
}
