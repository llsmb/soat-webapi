using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication2
{
    public class ProductService
    {
        private static List<Product> listeProduits = Enumerable.Range(1, 3).Select(i=> new Product { Id = i, Libelle = $"Produit {i}", DateCreation = DateTime.Now }).ToList();

       
        public IEnumerable<Product> GetAll()
        {            
            return listeProduits;
        }

        public Product Get(int id)
        {
            return listeProduits.First(p => p.Id == id);
        }

        public void Add(ProductRequest pr)
        {
            int idMax = listeProduits.Max(p => p.Id);

            listeProduits.Add(new Product {
                Id = idMax + 1,
                Libelle = pr.Libelle,
                Prix = pr.Prix,
                DateCreation = DateTime.Now
            });
        }

        public void Update(int id, Product p)
        {
            Product product = Get(id);
            listeProduits.Remove(product);
            listeProduits.Add(p);
        }
    }
}