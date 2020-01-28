using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;

namespace WebApplication2.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);
            configuration.Formatters.Add(new ProductCsvFormatter());

            var resolver = new DefaultInlineConstraintResolver();
            resolver.ConstraintMap.Add("nonzero", typeof(NonZeroConstraint));

            configuration.MapHttpAttributeRoutes(resolver);

        }
    }
}