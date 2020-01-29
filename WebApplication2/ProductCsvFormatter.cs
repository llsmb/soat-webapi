using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Net.Http.Headers;
using System.IO;
using System.Net.Http;

namespace ProductSoat
{
    public class ProductCsvFormatter : BufferedMediaTypeFormatter
    {
        public ProductCsvFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
        }

        public override bool CanReadType(Type type)
        {
            return type.IsAssignableFrom(typeof(IEnumerable<Product>));
        }

        public override bool CanWriteType(Type type)
        {
            return type.IsAssignableFrom(typeof(IEnumerable<Product>));
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                var products = value as IEnumerable<Product>;

                foreach (var p in products)
                {
                    writer.WriteLine($"{p.Id},{p.Libelle}");
                }
            }
        }
    }
}