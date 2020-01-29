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
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/products
        [Route]
        public IHttpActionResult Get()
        {
            return Ok(_productService.GetAll());
        }

        // GET api/products/5
        [Route("{id:nonzero}"), HttpGet]
        public IHttpActionResult Get(int id)
        {
            Product produit = _productService.GetAll().First(p => p.Id == id);
            return produit == null ? (IHttpActionResult)NotFound() : Ok(produit);
        }
                
        [Route]
        public IHttpActionResult Post(ProductRequest product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                return Ok(_productService.GetAll());
            }
            else return BadRequest(ModelState);
        }
                
        [Route("{id}")]
        public void Put(int id, ProductRequest p)
        {
            _productService.Update(id, new Product { Libelle = p.Libelle, Prix = p.Prix, DateModification = DateTime.Now });
            //Optimiser le renvoi
        }
                
        [Route("{id}")]
        public void Delete(int id)
        {
        }
    }
}