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
    [RoutePrefix("")]
    public class DefaultController : ApiController
    {
        [Route("")]
        public IEnumerable<Products> Get()
        {
            return UnityOfWork.Context.Products;
        }

        // GET: api/Values/5
        public IEnumerable<Products> Get(string id)
        {
            return UnityOfWork.Context.Products.Where(p => p.Product_Name.Contains(id));
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
