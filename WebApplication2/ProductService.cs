using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication2
{
    public class ProductService
    {
        private static List<Product> listeProduits = Enumerable.Range(1, 6).Select(i=> new Product { Id = i, Libelle = $"Produit {i}" }).ToList();

       
        public IEnumerable<Product> GetAll()
        {            
            return listeProduits;
        }

        public Product Get(int id)
        {
            return listeProduits.First(p => p.Id == id);
        }

        public void Add(Product p)
        {
            listeProduits.Add(p);
        }

        public void Update(int id, Product p)
        {
            Product product = Get(id);
            listeProduits.Remove(product);
            listeProduits.Add(p);
        }
    }
}