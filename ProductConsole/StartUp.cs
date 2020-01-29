

using Owin;
using ProductSoat.App_Start;
using System.Web.Http;

namespace ProductConsole
{
    public class StartUp
    {
        public void Configure(IAppBuilder app) {
            var config = new HttpConfiguration();            
            WebApiConfig.Register(config);

            app.UseWelcomePage();

          //  app.UseWebApi(config);


        }
    }
}
