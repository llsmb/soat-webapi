using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplication2
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        private ProductService service = new ProductService();

        // GET api/products
        [Route]
        public IHttpActionResult Get()
        {
            return Ok(service.GetAll());
        }

        // GET api/products/get/5
        [Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            Product produit = service.GetAll().First(p => p.Id == id);
            return produit == null ? (IHttpActionResult)NotFound() : Ok(produit);
        }

        // POST api/products
        [Route]
        public IHttpActionResult Post(Product product)
        {
            service.Add(product);
            return Ok(service.GetAll());
        }

        // PUT api/<controller>/5
        [Route("{id}")]
        public void Put(int id, Product p)
        {
            service.Update(id, p);
            //Optimiser le renvoi
        }

        // DELETE api/<controller>/5
        [Route("{id}")]
        public void Delete(int id)
        {
        }
    }
}