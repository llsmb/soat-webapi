using System.Collections.Generic;

namespace ProductSoat
{
    public interface IProductService
    {
        bool Add(ProductRequest pr);
        Product Get(int id);
        IEnumerable<Product> GetAll();
        void Update(int id, Product p);
    }
}