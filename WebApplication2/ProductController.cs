using System;
using System.Linq;
using System.Web.Http;

namespace ProductSoat
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route]
        public IHttpActionResult Get()
        {
            return Ok(_productService.GetAll());
        }

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
                return _productService.Add(product) ? (IHttpActionResult) Ok(): BadRequest();
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