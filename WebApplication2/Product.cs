using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductSoat
{
    public class Product
    {
        
        public int Id { get; set; }
        public string Libelle { get; set; }
        public int Prix { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        public Product()
        {

        }
    }

    public class ProductRequest
    {
        [Required, MinLength(4)]
        public string Libelle { get; set; }
        public int Prix { get; set; }
    }

    public class ProductResponse
    {
        public string Libelle { get; set; }
        public int Prix { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        public ProductResponse(string libelle, string prix)
        {

        }

    }
}