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

        // GET api/products/5
        [Route("{id}:int"), HttpGet]
        public IHttpActionResult Get(int id)
        {
            Product produit = service.GetAll().First(p => p.Id == id);
            return produit == null ? (IHttpActionResult)NotFound() : Ok(produit);
        }

        // POST api/products
        [Route]
        public IHttpActionResult Post(ProductRequest product)
        {
            if (ModelState.IsValid)
            {
                service.Add(product);
                return Ok(service.GetAll());
            }
            else return BadRequest(ModelState);
        }

        // PUT api/<controller>/5
        //[Route("{id}")]
        //public void Put(int id, ProductRequest p)
        //{
        //    service.Update(id, new Product { Libelle = p.Libelle, Prix = p.Prix, DateModification = DateTime.Now });
        //    //Optimiser le renvoi
        //}

        //// DELETE api/<controller>/5
        //[Route("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}