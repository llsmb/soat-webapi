using System.Collections.Generic;

namespace WebApplication2
{
    public interface IProductService
    {
        void Add(ProductRequest pr);
        Product Get(int id);
        IEnumerable<Product> GetAll();
        void Update(int id, Product p);
    }
}